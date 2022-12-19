using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.Application.Features.Queries.DailyReport
{
    public class GetDailyReportQueryValidator : AbstractValidator<GetDailyReportQuery>
    {
        public GetDailyReportQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotNull()
                .NotEmpty()
                .Must(BeAValidDate).WithMessage("Date is required"); ;
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
    }
}
