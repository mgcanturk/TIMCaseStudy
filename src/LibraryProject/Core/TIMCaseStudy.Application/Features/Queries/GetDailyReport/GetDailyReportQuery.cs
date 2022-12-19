using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.Application.Features.Queries.DailyReport
{
    public class GetDailyReportQuery : IRequest<List<DailyReportViewModel>>
    {
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
