using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Domain.Entities.Common;

namespace TIMCaseStudy.Domain.Entities
{
    public sealed class Author : BaseEntity
    {
        public string NameSurname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
