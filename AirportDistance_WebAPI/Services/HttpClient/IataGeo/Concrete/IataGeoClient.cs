using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Services.HttpClient.Concrete;
using AirportDistance_WebAPI.Services.HttpClient.IataGeo.Abstract;
using Microsoft.Extensions.Options;

namespace AirportDistance_WebAPI.Services.HttpClient.IataGeo.Concrete
{
	public class IataGeoClient : AirportHttpClientService, IIataGeoClient
	{
		public IataGeoClient(IOptions<IataGeoOptions> iataGeoOptions, System.Net.Http.HttpClient httpClient) : base(httpClient)
		{
			httpClient.BaseAddress = new Uri(iataGeoOptions.Value.BaseUrl);
		}
	}
}
