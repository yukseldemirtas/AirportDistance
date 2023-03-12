using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Models.HttpClient;
using AirportDistance_WebAPI.Services.Abstract;
using AirportDistance_WebAPI.Services.HttpClient;
using AirportDistance_WebAPI.Services.HttpClient.Abstract;
using AirportDistance_WebAPI.Extensions.Transactions;
using AirportDistance_WebAPI.Extensions.Exceptions;
using AirportDistance_WebAPI.Services.HttpClient.IataGeo.Abstract;

namespace AirportDistance_WebAPI.Services.Concrete
{
	public class AirportDistanceService : IAirportDistanceService
	{
		private readonly IIataGeoClient _iataGeoClient;
		public AirportDistanceService(IIataGeoClient iataGeoClient)
		{
			_iataGeoClient = iataGeoClient;
		}

		public async Task<double> Calculate(AirportCodes airportCodes)
		{

			var from = await _iataGeoClient.GetAsync<AirportResponse>(Endpoints.GetCoordinates + $"/{airportCodes.From}");

			if (!from.IsSuccessStatusCode)
			{
				throw new AirportNotFoundException();
			}

			var to = await _iataGeoClient.GetAsync<AirportResponse>(Endpoints.GetCoordinates + $"/{airportCodes.To}");

			if (!to.IsSuccessStatusCode)
			{
				throw new AirportNotFoundException();
			}

			var airportLocations = new AirportLocations
			{
				From = new Airport(from.Response),
				To = new Airport(to.Response)
			};
			return airportLocations.GetDistanceInMiles();
		}

	}
}
