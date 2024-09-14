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

namespace VehicleHub.Application.Features.GetAll.Boat
{
    public class GetBoatsByColorHandler : IRequestHandler<GetBoatsByColorRequest, IList<GetBoatsByColorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyMapper _mapper;

        public GetBoatsByColorHandler(IUnitOfWork unitOfWork, IMyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetBoatsByColorResponse>> Handle(GetBoatsByColorRequest request, CancellationToken cancellationToken)
        {
            var boats = await _unitOfWork.GetReadRepository<VehicleHub.Domain.Vehicles.Types.Boat>()
                                         .GetAllAsync(boat => boat.Color == request.Color);

            if (boats == null || !boats.Any())
            {
                throw new NotFoundException(Messages.BoatNotFound); 
            }

            var boatDtos = _mapper.Map<IList<BoatDto>, IList<VehicleHub.Domain.Vehicles.Types.Boat>>(boats);

            var response = _mapper.Map<IList<GetBoatsByColorResponse>, IList<BoatDto>>(boatDtos);

            return response;
        }
    }
}
