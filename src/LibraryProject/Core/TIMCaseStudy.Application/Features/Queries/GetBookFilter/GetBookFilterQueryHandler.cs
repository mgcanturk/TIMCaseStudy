using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Common.Infrastructure.Exceptions;
using TIMCaseStudy.Common.Models.Queries;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.Application.Features.Queries.Book
{
    public class GetBookFilterQueryHandler : IRequestHandler<GetBookFilterQuery, List<BookFilterViewModel>>
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IMapper _mapper;

        public GetBookFilterQueryHandler(IBookReadRepository bookReadRepository, IMapper mapper)
        {
            _bookReadRepository = bookReadRepository;
            _mapper = mapper;
        }

        public async Task<List<BookFilterViewModel>> Handle(GetBookFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _bookReadRepository.GetAll(false)
            .Include(b => b.Category)
            .Include(b => b.Authors)
            .AsNoTracking();
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(b => b.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrEmpty(request.ISBN))
                query = query.Where(b => b.ISBN.ToLower().Contains(request.ISBN.ToLower()));

            if (!string.IsNullOrEmpty(request.Author))
                query = query.Where(b => b.Authors.Any(a => a.NameSurname.ToLower().Contains(request.Author.ToLower())));

            //var listData = await query.Select(x => new BookFilterViewModel() { IsAvailable = x.IsAvailable, ISBN = x.ISBN, Name = x.Name, Publisher = x.Publisher }).ToListAsync();
            var listData = await query.ToListAsync(cancellationToken: cancellationToken);
            if (listData.Count <= 0)
                throw new DatabaseValidationException("Data not found!");

            var result = _mapper.Map<List<BookFilterViewModel>>(listData);
            return result;
        }
    }
}
