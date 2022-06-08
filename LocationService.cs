using System;

namespace RobotInvasion.Services
{
	public class LocationService
	{
		private readonly HttpClient _httpClient;

		public LocationService(HttpClient client)
        {
			client.DefaultRequestHeaders.Add("User", "c# app");
			_httpClient = client;
		}

		public async Task<string> GetNearestBodyOfWater(Location location)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage y = await client.GetAsync("https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848"<param>)
				return await y.Content.ReadAsStringAsync();
		}
	}
}

