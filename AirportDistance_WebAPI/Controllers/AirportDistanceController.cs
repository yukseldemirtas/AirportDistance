using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportDistance_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirportDistanceController : ControllerBase
	{

		private readonly IAirportDistanceService _airportDistanceService;

		public AirportDistanceController(IAirportDistanceService airportDistanceService)
		{
			_airportDistanceService = airportDistanceService;
		}

		[HttpGet("Calculate")]
		public async Task<IActionResult> Calculate([FromQuery] AirportCodes airportCodes)
		{
			return Ok(await _airportDistanceService.Calculate(airportCodes));
		}
	}
}
