using AirportDistance_WebAPI.Models.HttpClient;

namespace AirportDistance_WebAPI.Models
{
	public class Airport
	{
		public string Name { get; set; }

		public string Code { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public Airport(AirportResponse airportResponse)
		{
			Name = airportResponse.Name;
			Code = airportResponse.Code;
			Latitude = double.Parse(airportResponse.Latitude);
			Longitude = double.Parse(airportResponse.Longitude);
		}
	}
}
