using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Features.Delete
{
    public class DeleteCarCommand : IRequest<Unit>
    {
        public int CarId { get; set; }
    }
}
