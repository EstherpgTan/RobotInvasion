using System;
using System.Net.Http;
using System.Text.Json;
using RobotInvasion2.Model;

namespace RobotInvasion2.Services
{
	public class LocationService
	{
		private readonly ILogger<LocationService> _logger;
		private readonly HttpClient _client;
		private readonly string _url;

		public LocationService(ILogger<LocationService> logger, IConfiguration config, HttpClient client)
		{
			_logger = logger;
			_logger.LogCritical(new EventId(), null, "Created Service");
			_client = client;
			var section = config.GetSection("HttpCustomHeaders:User-agent ");
			_url = config.GetSection("GeocodingAPI:BaseURL").Value;
			_client.DefaultRequestHeaders.Add(section.Key, section.Value);
		}
		public void UsingTheThirdAPI()
        {
			HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _url);
			_client.Send(message);
        }
	}
}

