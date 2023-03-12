using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Models.HttpClient;
using AirportDistance_WebAPI.Services.HttpClient.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AirportDistance_WebAPI.Services.HttpClient.Concrete
{
	public class AirportHttpClientService : IAirportHttpClientService
	{
		//private readonly System.Net.Http.HttpClient _httpClient;
		//public AirportHttpClientService(System.Net.Http.HttpClient httpClient, IOptions<IataGeoOptions> iataGeoOptions)
		//{
		//	_httpClient = httpClient;
		//	_httpClient.BaseAddress = new Uri(iataGeoOptions.Value.BaseUrl);
		//}

		private readonly System.Net.Http.HttpClient _httpClient;

		public AirportHttpClientService(System.Net.Http.HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<HttpClientResponse<T>> GetAsync<T>(string endpoint, string parameters = null) where T : class
		{
			HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(endpoint);
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				return new HttpClientResponse<T>()
				{
					IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode,
					StatusCode = httpResponseMessage.StatusCode,
				};
			}

			var strContent = await httpResponseMessage.Content.ReadAsStringAsync();
			if (strContent.Contains("error") && strContent.Contains("No results"))
			{
				return new HttpClientResponse<T>()
				{
					IsSuccessStatusCode = false,
					StatusCode = System.Net.HttpStatusCode.NotFound,
				};
			}


			var result = JsonSerializer.Deserialize<T>(strContent);


			return new HttpClientResponse<T>()
			{
				Response = result,
				IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode,
				StatusCode = httpResponseMessage.StatusCode
			};
		}
	}
}
