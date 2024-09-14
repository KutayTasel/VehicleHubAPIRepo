using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Features.ToggleHead.Update
{
    public class ToggleHeadlightsCommand : IRequest<string>
    {
        public int CarId { get; set; }  
    }
}
