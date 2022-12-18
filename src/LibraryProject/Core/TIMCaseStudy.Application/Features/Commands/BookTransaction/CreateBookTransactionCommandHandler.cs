using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Common.Infrastructure.Exceptions;
using TIMCaseStudy.Common.Models.RequestModels;
using TIMCaseStudy.Domain.Entities;

namespace TIMCaseStudy.Application.Features.Commands.BookTransaction
{
    public class CreateBookTransactionCommandHandler : IRequestHandler<CreateBookTransactionCommand, int>
    {
        private readonly IBookTransactionReadRepository _bookTransactionReadRepository;
        private readonly IBookTransactionWriteRepository _bookTransactionWriteRepository;
        private readonly IMapper _mapper;

        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMemberReadRepository _memberReadRepository;

        public CreateBookTransactionCommandHandler(IBookTransactionReadRepository bookTransactionReadRepository, IBookTransactionWriteRepository bookTransactionWriteRepository, IMapper mapper, IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IMemberReadRepository memberReadRepository)
        {
            _bookTransactionReadRepository = bookTransactionReadRepository;
            _bookTransactionWriteRepository = bookTransactionWriteRepository;
            _mapper = mapper;
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _memberReadRepository = memberReadRepository;
        }

        public async Task<int> Handle(CreateBookTransactionCommand request, CancellationToken cancellationToken)
        {
            var getBookData = await _bookReadRepository.GetSingleAsync(x => x.ISBN == request.ISBN);

            if (getBookData == null || !getBookData.IsAvailable)
                throw new DatabaseValidationException("The book is not available for transaction.");


            var member = await _memberReadRepository.GetByIdAsync(request.MemberId, false);
            if (member == null)
                throw new DatabaseValidationException("The member does not exist.");


            var controlData = await _bookTransactionReadRepository.GetSingleAsync(x => x.Book.ISBN == request.ISBN && x.Member.Id == request.MemberId, false);
            if(controlData is not null)
                throw new DatabaseValidationException("This data exists in the database!");

          
            var dbTransaction = _mapper.Map<Domain.Entities.BookTransaction>(request);
            dbTransaction.RetrieveDate = DateTime.Now;
            dbTransaction.ReturnDate = CalculateReturnDate(dbTransaction.ReturnDate);
            dbTransaction.BookId = getBookData.Id;

            await _bookTransactionWriteRepository.AddAsync(dbTransaction);

           
            var returnVal = await _bookTransactionWriteRepository.SaveAsync();

            getBookData.IsAvailable = false;
            _bookWriteRepository.Update(getBookData);
            await _bookWriteRepository.SaveAsync();

            return returnVal;
        }
        private static readonly List<DateTime> PublicHolidays = new()
        {
            new DateTime(DateTime.Now.Year, 1, 1),  // Yılbaşı
            new DateTime(DateTime.Now.Year, 4, 23), // 23 Nisan Ulusal Egemenlik ve Çocuk Bayramı
            new DateTime(DateTime.Now.Year, 5, 1),  // Emek ve Dayanışma Günü
            new DateTime(DateTime.Now.Year, 5, 19), // Atatürk'ü Anma, Gençlik ve Spor Bayramı
            new DateTime(DateTime.Now.Year, 8, 30), // Zafer Bayramı
            new DateTime(DateTime.Now.Year, 10, 29), // Cumhuriye Bayramı
            new DateTime(DateTime.Now.AddYears(1).Year, 1, 1),  
            new DateTime(DateTime.Now.AddYears(1).Year, 4, 23),
            new DateTime(DateTime.Now.AddYears(1).Year, 5, 1),  
            new DateTime(DateTime.Now.AddYears(1).Year, 5, 19), 
            new DateTime(DateTime.Now.AddYears(1).Year, 8, 30), 
            new DateTime(DateTime.Now.AddYears(1).Year, 10, 29) 
        };
        public DateTime CalculateReturnDate(DateTime returnDate)
        {
            while (!IsWorkingDay(returnDate))
                returnDate = returnDate.AddDays(1);
            return returnDate;
        }
        private bool IsWorkingDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return false;

            if (PublicHolidays.Contains(date))
                return false;

            return true;
        }
    }
}
