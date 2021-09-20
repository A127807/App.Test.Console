using App.Repository;
using App.Repository.ApiClient;
using System;
using MilSiteCore.Models;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
IWebApiExecuter apiExectuter = new WebApiExecuter("http://localhost/", httpClient);

await GetLocations();

async Task GetLocations()
{
	LocationRepository repository = new(apiExectuter);

	var locations = await repository.GetAsync();
	foreach (var location in locations)
	{
		Console.WriteLine($"Locations: {location.LocName}");
	}
}
