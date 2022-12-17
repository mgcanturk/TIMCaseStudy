using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Domain.Entities.Common;

namespace TIMCaseStudy.Domain.Entities
{
    public sealed class Member : BaseEntity
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
