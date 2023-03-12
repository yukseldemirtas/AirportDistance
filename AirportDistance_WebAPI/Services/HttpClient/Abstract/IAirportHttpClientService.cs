using AirportDistance_WebAPI.Models.HttpClient;

namespace AirportDistance_WebAPI.Services.HttpClient.Abstract
{
	public interface IAirportHttpClientService
	{
		Task<HttpClientResponse<T>> GetAsync<T>(string endpoint, string parameters = null) where T : class;
	}
}
