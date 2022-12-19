using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Common.Models.Queries;
using TIMCaseStudy.Common.Models.RequestModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TIMCaseStudy.Application.Features.Queries.DailyReport
{
    public class GetDailyReportQueryHandler : IRequestHandler<GetDailyReportQuery, List<DailyReportViewModel>>
    {
        private readonly IBookTransactionReadRepository _bookTransactionReadRepository;
        private readonly IBookTransactionWriteRepository _bookTransactionWriteRepository;
        private readonly IMapper _mapper;

        public GetDailyReportQueryHandler(IBookTransactionReadRepository bookTransactionReadRepository, IBookTransactionWriteRepository bookTransactionWriteRepository, IMapper mapper)
        {
            _bookTransactionReadRepository = bookTransactionReadRepository;
            _bookTransactionWriteRepository = bookTransactionWriteRepository;
            _mapper = mapper;
        }

        public async Task<List<DailyReportViewModel>> Handle(GetDailyReportQuery request, CancellationToken cancellationToken)
        {
            var report = new List<DailyReportViewModel>();

            var overdueBooks = await _bookTransactionReadRepository.GetAll(false)
            .Include(b => b.Book)
            .Include(b => b.Book.Category)
            .Include(b => b.Member)
            .AsNoTracking().Where(x => x.ReturnDate < request.Date && x.IsReturn == false).ToListAsync();
            foreach (var book in overdueBooks)
            {
                var model = new DailyReportViewModel
                {
                    CategoryName = book.Book.Category.Name,
                    ReturnDate = book.ReturnDate,
                    IsAvailable = book.Book.IsAvailable,
                    ISBN = book.Book.ISBN,
                    IsLate = book.ReturnDate < request.Date,
                    MemberName = book.Member.Name,
                    Name = book.Book.Name,
                    Penalty = CalculatePenalty((request.Date.Date - book.ReturnDate.Date).TotalDays),
                    Publisher = book.Book.Publisher
                };
                report.Add(model);
            }


            var upcomingDate = request.Date.AddDays(2);
            var upcomingDueDates = await _bookTransactionReadRepository.GetAll(false)
            .Include(b => b.Book)
            .Include(b => b.Book.Category)
            .Include(b => b.Member)
            .AsNoTracking().Where(x => x.ReturnDate > request.Date && x.ReturnDate <= upcomingDate && x.IsReturn == false).ToListAsync();
            foreach (var book in upcomingDueDates)
            {
                var model = new DailyReportViewModel
                {
                    CategoryName = book.Book.Category.Name,
                    ReturnDate = book.ReturnDate,
                    IsAvailable = book.Book.IsAvailable,
                    ISBN = book.Book.ISBN,
                    IsLate = book.ReturnDate < request.Date,
                    MemberName = book.Member.Name,
                    Name = book.Book.Name,
                    Penalty = 0,
                    Publisher = book.Book.Publisher
                };
                report.Add(model);
            }

            return report;
        }
        public double CalculatePenalty(double days)
        {
            int fib1 = 0;
            int fib2 = 1;

            double coefficient = 0.20;
            double totalPenalty = 0;

            for (int i = 1; i <= days; i++)
            {
                int fibNext = fib1 + fib2;
                double penalty = fibNext * coefficient + totalPenalty;
                totalPenalty = penalty;
                fib1 = fib2;
                fib2 = fibNext;
            }
            return totalPenalty;
        }
    }
}
