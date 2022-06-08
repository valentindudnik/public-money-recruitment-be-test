﻿using FluentValidation;
using VacationRental.Models.Paramaters;

namespace VacationRental.Infrastructure.Validators
{
    public class RentalParametersValidator : AbstractValidator<RentalParameters>
    {
        public RentalParametersValidator()
        {
            RuleFor(x => x.Units).NotNull().WithMessage(configure => $"{nameof(configure.Units)} is required.");
            RuleFor(x => x.PreparationTimeInDays).NotNull().WithMessage(configure => $"{nameof(configure.PreparationTimeInDays)} is required.");
        }
    }
}
