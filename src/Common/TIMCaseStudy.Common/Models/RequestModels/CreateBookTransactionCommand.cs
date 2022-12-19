using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;

namespace TIMCaseStudy.Common.Models.RequestModels
{
    public class CreateBookTransactionCommand : IRequest<int>
    {
        public string ISBN { get; set; }
        public int MemberId { get; set; }
        public string ReturnDate { get; set; }

        public CreateBookTransactionCommand(string iSBN, int memberId, string returnDate)
        {
            ISBN = iSBN;
            MemberId = memberId;
            ReturnDate = returnDate;
        }
        public CreateBookTransactionCommand()
        {

        }
    }
}
