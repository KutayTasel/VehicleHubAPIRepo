using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleHub.Application.Features.Delete;
using VehicleHub.Application.Features.GetAll.Boat;
using VehicleHub.Application.Features.GetAll.Bus;
using VehicleHub.Application.Features.GetAll.Car;
using VehicleHub.Application.Features.ToggleHead;
using VehicleHub.Application.Features.ToggleHead.Update;

namespace VehicleHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleHubController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleHubController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // [GET] Arabaları renge göre listeleme
        [HttpGet("cars")]
        public async Task<IActionResult> GetCarsByColor([FromQuery] string color)
        {
            var request = new GetCarsByColorRequest(color);
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        // [GET] Otobüsleri renge göre listeleme
        [HttpGet("buses")]
        public async Task<IActionResult> GetBusesByColor([FromQuery] string color)
        {
            var request = new GetBusesByColorRequest(color);
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        // [GET] Tekneleri renge göre listeleme
        [HttpGet("boats")]
        public async Task<IActionResult> GetBoatsByColor([FromQuery] string color)
        {
            var request = new GetBoatsByColorRequest(color);
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        // [POST] Arabaların farlarını açma/kapama
        [HttpPost("cars/toggle-headlights")]
        public async Task<IActionResult> ToggleCarHeadlights([FromBody] ToggleHeadlightsCommand command)
        {
            // CarId kontrolü
            if (command.CarId <= 0)
            {
                return BadRequest(new { Message = "CarId must be greater than 0." });
            }

            var result = await _mediator.Send(command);
            return Ok(new { Message = result });
        }


        // [DELETE] Soft delete a car
        [HttpDelete("cars/delete")]
        public async Task<IActionResult> DeleteCar([FromBody] DeleteCarCommand command)  
        {
            if (command.CarId <= 0)
            {
                return BadRequest(new { Message = "CarId must be greater than 0." });
            }

            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK, "Car successfully deleted.");
        }


    }
}
