using System;
using System.Net.Http;
using System.Text.Json;
using RobotInvasion2.Model;

namespace RobotInvasion2.Services
{
	public class LocationService
	{
        private readonly ILogger<LocationService> _logger;
        private readonly HttpClient _httpClient;
		//private readonly string _url;

		//public LocationService(ILogger<LocationService> logger, IConfiguration config, HttpClient client)
		public LocationService(HttpClient client)
		{
			_httpClient = client;
			//_logger = logger;
			//_logger.LogCritical(new EventId(), null, "Created Service");
			//_client = client;
			//var section = config.GetSection("HttpCustomHeaders:User-agent ");
			//_url = config.GetSection("GeocodingAPI:BaseURL").Value;
			//_client.DefaultRequestHeaders.Add(section.Key, section.Value);
			client.DefaultRequestHeaders.Add("User-Agent", "C# App");
		}
		//public void UsingTheThirdAPI()
  //      {
		//	HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _url);
		//	_client.Send(message);

		public async Task<string>GetNearestWaterSource(Location location)
        {
			string APIUrl = $"https://nominatim.openstreetmap.org/search.php?q=water%20near%20{location.displayName}%20Australia&polygon_geojson=1&format=jsonv2";

			HttpResponseMessage x = await _httpClient.GetAsync(APIUrl);

			return await x.Content.ReadAsStringAsync();
		}

	}
}


