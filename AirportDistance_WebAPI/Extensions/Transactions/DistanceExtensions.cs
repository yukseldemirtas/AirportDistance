using AirportDistance_WebAPI.Models;

namespace AirportDistance_WebAPI.Extensions.Transactions
{
	public static class DistanceExtensions
	{
		public static double GetDistanceInMiles(this AirportLocations airportLocations)
		{
			var rFromLatitude = Math.PI * airportLocations.From.Latitude / 180;
			var rToLatitude = Math.PI * airportLocations.To.Latitude / 180;
			var theta = airportLocations.From.Longitude - airportLocations.To.Longitude;
			var rTheta = Math.PI * theta / 180;

			var distInMiles =
				Math.Sin(rFromLatitude) * Math.Sin(rToLatitude) + Math.Cos(rFromLatitude) *
				Math.Cos(rToLatitude) * Math.Cos(rTheta);

			distInMiles = Math.Acos(distInMiles);
			distInMiles = distInMiles * 180 / Math.PI;
			distInMiles = distInMiles * 60 * 1.1515;

			return distInMiles;
		}
	}
}
