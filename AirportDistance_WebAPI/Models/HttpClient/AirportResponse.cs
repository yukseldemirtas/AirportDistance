﻿using System.Text.Json.Serialization;

namespace AirportDistance_WebAPI.Models.HttpClient
{
	public class AirportResponse
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }

		[JsonPropertyName("latitude")]
		public string Latitude { get; set; }

		[JsonPropertyName("longitude")]
		public string Longitude { get; set; }
	}
}
