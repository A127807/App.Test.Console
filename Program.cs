using App.Repository;
using App.Repository.ApiClient;
using System;
using MilSiteCore.Models;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
IWebApiExecuter apiExectuter = new WebApiExecuter("https://localhost:58530", httpClient);

await GetLocations();
await GetLocationById(1);

async Task GetLocations()
{
	LocationRepository repository = new(apiExectuter);
	var locations= await repository.Get();

	foreach (var location in locations)
	{
		Console.WriteLine($"Locations: {location.LocName}");
	}
}

async Task GetLocationById(int id)
{
	LocationRepository repository = new(apiExectuter);

	var locations = await repository.GetLocationById(id);

	foreach(var location in locations)
	{
		if(location.LocId == id)
		{
			Console.WriteLine($"{location.LocName}");
		}
	}
}


