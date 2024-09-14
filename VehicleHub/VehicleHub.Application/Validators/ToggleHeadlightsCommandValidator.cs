using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Features.ToggleHead.Update;

namespace VehicleHub.Application.Validators
{
    public class ToggleHeadlightsCommandValidator : AbstractValidator<ToggleHeadlightsCommand>
    {
        public ToggleHeadlightsCommandValidator()
        {
            RuleFor(x => x.CarId)
                .NotNull().WithMessage("CarId cannot be null.")  
                .GreaterThan(0).WithMessage("CarId must be greater than 0."); 
        }
    }
}
