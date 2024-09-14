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

namespace VehicleHub.Application.Features.GetAll.Bus
{
    public class GetBusesByColorHandler : IRequestHandler<GetBusesByColorRequest, IList<GetBusesByColorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyMapper _mapper;

        public GetBusesByColorHandler(IUnitOfWork unitOfWork, IMyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetBusesByColorResponse>> Handle(GetBusesByColorRequest request, CancellationToken cancellationToken)
        {
            var buses = await _unitOfWork.GetReadRepository<VehicleHub.Domain.Vehicles.Types.Bus>()
                                         .GetAllAsync(bus => bus.Color == request.Color);

            if (buses == null || !buses.Any())
            {
                throw new NotFoundException(Messages.BusNotFound); 
            }

            var busDtos = _mapper.Map<IList<BusDto>, IList<VehicleHub.Domain.Vehicles.Types.Bus>>(buses);
            var response = _mapper.Map<IList<GetBusesByColorResponse>, IList<BusDto>>(busDtos);

            return response;
        }
    }
}
