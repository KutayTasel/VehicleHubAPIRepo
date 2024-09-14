using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Features.GetAll.Bus
{
    public class GetBusesByColorRequest : IRequest<IList<GetBusesByColorResponse>>
    {
        public string Color { get; set; }

        public GetBusesByColorRequest(string color)
        {
            Color = color;
        }
    }
}
