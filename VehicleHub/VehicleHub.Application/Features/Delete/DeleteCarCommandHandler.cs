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

namespace VehicleHub.Application.Features.Delete
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.GetReadRepository<Car>().GetByIdAsync(request.CarId);

            if (car == null)
                throw new NotFoundException(Messages.CarNotFound);  

            await _unitOfWork.GetWriteRepository<Car>().DeleteAsync(car);

            return Unit.Value;
        }
    }
}
