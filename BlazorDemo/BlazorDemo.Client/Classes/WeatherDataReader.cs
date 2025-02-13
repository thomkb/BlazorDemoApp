using Models.WeatherData;
using System.Text.Json;


namespace BlazorDemo.Classes;

public class WeatherDataReader
{
    public async Task<WeatherDataFromApi>? ReadFromApi(string ApiPath)
    {
        var response = "";
        var httpClient = new HttpClient();
        try
        {
            response = await httpClient.GetStringAsync(ApiPath);
        }
        catch (Exception ex) 
        {
            var msg = ex.Message;
            response = null;
        }
        if (response == null)
        {
            return null;
        }

        var retVal = JsonSerializer.Deserialize<WeatherDataFromApi>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return retVal;
    }
}

