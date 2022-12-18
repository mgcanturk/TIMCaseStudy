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
    public sealed class Book : BaseEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public bool IsAvailable { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Category Category { get; set; }
        public ICollection<BookTransaction> BookTransactions { get; set; }

    }
}
