using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Domain.Entities.Common;

namespace TIMCaseStudy.Domain.Entities
{
    public sealed class BookTransaction : BaseEntity
    {
        [ForeignKey("ISBN")]
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime RetrieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsLate { get; set; }
        public int LateDay { get; set; }
        public decimal Penalty { get; set; }
    }
}
