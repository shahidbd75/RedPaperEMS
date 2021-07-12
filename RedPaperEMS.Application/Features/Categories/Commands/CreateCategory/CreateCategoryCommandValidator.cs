using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace RedPaperEMS.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
