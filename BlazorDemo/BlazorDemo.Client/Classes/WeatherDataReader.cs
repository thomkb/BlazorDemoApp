using Models.WeatherData;
using System.Text.Json;
using System.Net;
using System.Web;
using Serilog;
using Models.WeatherDisplayData;


namespace BlazorDemo.Classes;

public class WeatherDataReader
{

    public async Task<WeatherDisplayData>? ReadFromApi(string ApiPath, bool isMetric, Serilog.ILogger _logger)
    {
        var response = string.Empty;
        var httpClient = new HttpClient();

        try
        {
            response = await httpClient.GetStringAsync(ApiPath);
            _logger.Information("WeatherDataReader.ReadFromApi: {api}", ApiPath);
        }
        catch (HttpRequestException hex)
        {
            var query = HttpUtility.ParseQueryString(ApiPath);
            var zipCode = query.Get("q");
            if (hex.StatusCode == HttpStatusCode.BadRequest)
            {
                _logger.Error("Could not find weather for zip code '{zip}'", zipCode);
            }
            else if (hex.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.Error("404 Error; Could not find the API: '{url}'", ApiPath);
            }
            else
            {
                _logger.Error(hex, hex.Message);
            }
            response = null;
        }

        catch (Exception ex)
        {
            _logger.Error(ex, ex.Message);
            response = null;
        }
        finally
        {
            _logger.Information("==============================================================================================================");
        }

        if (response == null)
        {
            return null;
        } 

        var jData = JsonSerializer.Deserialize<WeatherDataFromApi>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (jData != null)
        {
            WeatherDisplayData weatherDisplayData = new WeatherDisplayData().GetWeatherDisplayData(jData, isMetric);
            return weatherDisplayData;
        }
        else
        {
            return null;
        }
    }
}

