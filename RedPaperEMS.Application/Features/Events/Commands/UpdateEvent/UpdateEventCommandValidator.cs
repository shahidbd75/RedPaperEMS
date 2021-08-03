using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace RedPaperEMS.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator: AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(u=>u.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(u=>u.Price).GreaterThan(0).WithMessage("{PropertyName} is should be greater than 0");
            RuleFor(u=>u.Artist).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(u=>u.Date).NotNull().GreaterThan(DateTime.Now)
                .WithMessage("{PropertyName} is greater than today");
            RuleFor(u=>u.CategoryId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
