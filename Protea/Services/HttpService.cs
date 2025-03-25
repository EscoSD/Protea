using System.Text.Json;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class HttpService(HttpClient httpClient) : IHttpService
{
	public async Task<string> GetCatUrlAsync()
	{
		var response = await httpClient.GetAsync(Constants.CatApiUrl);

		if (!response.IsSuccessStatusCode)
			return Constants.CatApiErrorUrl;

		var json = await response.Content.ReadAsStringAsync();

		using var doc = JsonDocument.Parse(json);
		return doc.RootElement[0].GetProperty("url").GetString() ?? Constants.CatApiErrorUrl;
	}
	
	public async Task<string> GetDogUrlAsync()
	{
		var response = await httpClient.GetAsync(Constants.DogApiUrl);

		if (!response.IsSuccessStatusCode)
			return Constants.DogApiErrorUrl;

		var json = await response.Content.ReadAsStringAsync();

		using var doc = JsonDocument.Parse(json);
		return doc.RootElement.GetProperty("message").GetString() ?? Constants.DogApiErrorUrl;
	}
}