using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Features.GetAll.Boat
{
    public class GetBoatsByColorRequest : IRequest<IList<GetBoatsByColorResponse>>
    {
        public string Color { get; set; }

        public GetBoatsByColorRequest(string color)
        {
            Color = color;
        }
    }
}
