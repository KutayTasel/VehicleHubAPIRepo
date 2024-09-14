﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Constants;
using VehicleHub.Application.Features.GetAll.Boat;

namespace VehicleHub.Application.Validators
{
    public class GetBoatsByColorRequestValidator : AbstractValidator<GetBoatsByColorRequest>
    {
        public GetBoatsByColorRequestValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty().WithMessage(Messages.InvalidColorSelection)
                .Must(BeAValidColor).WithMessage(Messages.InvalidColorSelection);
        }
        private bool BeAValidColor(string color)
        {
            var validColors = new[] { "red", "blue", "black", "white" };
            return validColors.Contains(color.ToLower());
        }
    }
}