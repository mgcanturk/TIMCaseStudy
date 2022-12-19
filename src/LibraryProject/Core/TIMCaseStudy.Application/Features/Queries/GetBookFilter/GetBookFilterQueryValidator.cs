using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.Application.Features.Queries.Book
{
    public class GetBookFilterQueryValidator : AbstractValidator<GetBookFilterQuery>
    {
        public GetBookFilterQueryValidator()
        {
            RuleFor(x => x.Author)
               .NotEmpty()
               .When(x => string.IsNullOrEmpty(x.ISBN) && string.IsNullOrEmpty(x.Name))
               .WithMessage("Author, ISBN, or Name must be non-empty.");

            RuleFor(x => x.ISBN)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.Author) && string.IsNullOrEmpty(x.Name))
                .WithMessage("Author, ISBN, or Name must be non-empty.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.Author) && string.IsNullOrEmpty(x.ISBN))
                .WithMessage("Author, ISBN, or Name must be non-empty.");
        }
    }
}
