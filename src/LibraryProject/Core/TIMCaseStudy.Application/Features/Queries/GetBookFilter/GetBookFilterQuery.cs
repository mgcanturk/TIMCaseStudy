using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;

namespace TIMCaseStudy.Application.Features.Queries.Book
{
    public class GetBookFilterQuery : IRequest<List<BookFilterViewModel>>
    {
        public string? Name { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
    }
}
