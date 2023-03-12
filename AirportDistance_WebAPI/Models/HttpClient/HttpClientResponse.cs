using System.Net;

namespace AirportDistance_WebAPI.Models.HttpClient
{
	public class HttpClientResponse<T>
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccessStatusCode { get; set; }
		public string ErrorResponse { get; set; }
		public T Response { get; set; }
	}
}
