using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.Application.Features.Commands.BookTransaction
{
    public class CreateBookTransactionCommandValidator : AbstractValidator<CreateBookTransactionCommand>
    {
        public CreateBookTransactionCommandValidator()
        {
            RuleFor(x => x.ISBN)
                .NotNull()
                .MinimumLength(9).WithMessage("{PropertyName} should at least be {MinLenght} characters")
                .NotEmpty().WithMessage("{PropertyName} must be non-empty.");

            RuleFor(x => x.MemberId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} must be non-empty.");

            RuleFor(x => x.ReturnDate)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} must be non-empty.");
        }
    }
}
