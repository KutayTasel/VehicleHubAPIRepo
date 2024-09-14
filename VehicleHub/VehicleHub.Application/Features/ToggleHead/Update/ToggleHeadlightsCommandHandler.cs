using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Constants;
using VehicleHub.Application.IUnitOfWorks;
using VehicleHub.Domain.Vehicles.Types;

namespace VehicleHub.Application.Features.ToggleHead.Update
{
    public class ToggleHeadlightsCommandHandler : IRequestHandler<ToggleHeadlightsCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToggleHeadlightsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ToggleHeadlightsCommand request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.GetReadRepository<Car>().GetByIdAsync(request.CarId);

            if (car == null)
            {
                throw new NotFoundException(Messages.CarNotFound);  
            }

            if (car.HeadlightsOn)
            {
                car.HeadlightsOn = false;
                await _unitOfWork.GetWriteRepository<Car>().UpdateAsync(car);
                await _unitOfWork.SaveAsync();
                return Messages.HeadlightsTurnedOff;
            }
            else
            {
                car.HeadlightsOn = true;
                await _unitOfWork.GetWriteRepository<Car>().UpdateAsync(car);
                await _unitOfWork.SaveAsync();
                return Messages.HeadlightsTurnedOn;
            }
        }
    }
}
