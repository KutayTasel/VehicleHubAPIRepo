using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Constants;
using VehicleHub.Application.Features.Delete;

namespace VehicleHub.Application.Validators
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage(Messages.InvalidId);
        }
    }
}
