using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMCaseStudy.Common.Models.Queries
{
    public class DailyReportViewModel
    {
        public DateTime ReturnDate { get; set; }
        public string MemberName { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public bool IsAvailable { get; set; }
        public string CategoryName { get; set; }
        public bool IsLate { get; set; }
        public double Penalty { get; set; }
    }
}
