using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;

namespace TIMCaseStudy.Common.Models.RequestModels
{
    public class BookFilterCommand : IRequest<List<BookFilterViewModel>>
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        public BookFilterCommand(string name, string iSBN, string author)
        {
            Name = name;
            ISBN = iSBN;
            Author = author;
        }
        public BookFilterCommand()
        {

        }
    }
}
