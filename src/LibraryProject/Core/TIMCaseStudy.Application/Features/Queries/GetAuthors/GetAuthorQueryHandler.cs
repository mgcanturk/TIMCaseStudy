using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Features.Queries.Book;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Common.Models.Queries;

namespace TIMCaseStudy.Application.Features.Queries.GetAuthors
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorViewModel>>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IAuthorReadRepository authorReadRepository, IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorViewModel>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var query = _authorReadRepository.GetAll(false).ToList();
            var result = _mapper.Map<List<AuthorViewModel>>(query);
            return result;
        }
    }
}
