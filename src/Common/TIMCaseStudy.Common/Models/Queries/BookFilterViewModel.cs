using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMCaseStudy.Common.Models.Queries
{
    public class BookFilterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public bool IsAvailable { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<string> Authors { get; set; }
    }
}
