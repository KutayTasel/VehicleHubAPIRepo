using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.DTOs;

namespace VehicleHub.Application.Features.GetAll.Car
{
    public class GetCarsByColorRequest : IRequest<IList<GetCarsByColorResponse>>
    {
        public string Color { get; set; }

        public GetCarsByColorRequest(string color)
        {
            Color = color;
        }
    }
}
