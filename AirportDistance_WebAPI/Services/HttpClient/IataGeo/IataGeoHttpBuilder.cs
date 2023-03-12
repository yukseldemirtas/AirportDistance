using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Services.HttpClient.IataGeo.Abstract;
using AirportDistance_WebAPI.Services.HttpClient.IataGeo.Concrete;

namespace AirportDistance_WebAPI.Services.HttpClient.IataGeo
{
	public static class IataGeoHttpBuilder
	{
		public static IServiceCollection AddIataGeoClient(this IServiceCollection services,
		IConfiguration configuration)
		{
			services.Configure<IataGeoOptions>(configuration.GetSection("IataGeo"));
			services.AddHttpClient<IIataGeoClient, IataGeoClient>();
			return services;
		}
	}
}
