using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;

namespace TIMCaseStudy.Application.Features.Queries.GetAuthors
{
    public class GetAuthorQuery : IRequest<List<AuthorViewModel>>
    {
    }
}
