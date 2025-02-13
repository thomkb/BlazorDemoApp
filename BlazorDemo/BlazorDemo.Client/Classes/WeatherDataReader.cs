using Models.WeatherData;
using System.Text.Json;
using Serilog;
using Microsoft.AspNetCore.Components;


namespace BlazorDemo.Classes;

public class WeatherDataReader
{

    public async Task<WeatherDataFromApi>? ReadFromApi(string ApiPath, Serilog.ILogger _logger)
    {
        var response = "";
        var httpClient = new HttpClient();
       
        try
        {
            response = await httpClient.GetStringAsync(ApiPath);
           _logger.Information("WeatherDataReader.ReadFromApi: api call: {api}", ApiPath);
           _logger.Information("=====================================================");
        }
        catch (Exception ex) 
        {
            var msg = ex.Message;
            _logger.Error(ex, msg);
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

