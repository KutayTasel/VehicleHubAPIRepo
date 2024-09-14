using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Abstractions;
using VehicleHub.Application.Constants;
using VehicleHub.Application.DTOs;
using VehicleHub.Application.IUnitOfWorks;

namespace VehicleHub.Application.Features.GetAll.Car
{
    public class GetCarsByColorHandler : IRequestHandler<GetCarsByColorRequest, IList<GetCarsByColorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyMapper _mapper;

        public GetCarsByColorHandler(IUnitOfWork unitOfWork, IMyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetCarsByColorResponse>> Handle(GetCarsByColorRequest request, CancellationToken cancellationToken)
        {
            var cars = await _unitOfWork.GetReadRepository<VehicleHub.Domain.Vehicles.Types.Car>().GetAllAsync(car => car.Color == request.Color);

            if (cars == null || !cars.Any())
            {
                throw new NotFoundException(Messages.CarNotFound);  
            }

            var carDtos = _mapper.Map<IList<CarDto>, IList<VehicleHub.Domain.Vehicles.Types.Car>>(cars);

            var response = _mapper.Map<IList<GetCarsByColorResponse>, IList<CarDto>>(carDtos);

            return response;
        }
    }
}
