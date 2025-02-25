using Models.WeatherData;

namespace Models.WeatherDisplayData;

public class WeatherDisplayData
{
    public string? WeatherDescription { get; set; }
    public string Wind { get; set; } = string.Empty;
    public string WindDirection { get; set; } = string.Empty;
    public string? WindDegree { get; set; } = string.Empty;
    public string WindSpeed { get; set; } = string.Empty;
    public string WindGust { get; set; } = string.Empty;
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? IconUrl { get; set; }
    public string? TimeUpdated { get; set; }
    public string? Temperature { get; set; } = string.Empty;
    public string? Degree { get; set; } = string.Empty;
    public string? Pressure { get; set; } = string.Empty;
    public string? Precipitation { get; set; } = string.Empty;
    public string? Humidity { get; set; } = string.Empty;
    public string? FeelsLike { get; set; } = string.Empty;
    public string? WindChill { get; set; } = string.Empty;
    public string? HeatIndex { get; set; } = string.Empty;
    public string? Dewpoint { get; set; } = string.Empty;
    public string? Visibility { get; set; } = string.Empty;
    public string? UvIndex { get; set; } = string.Empty;
    public string? CloudCover { get; set; } = string.Empty;

    public WeatherDisplayData() { }

    public WeatherDisplayData GetWeatherDisplayData(WeatherDataFromApi weatherData, bool isMetric)
    {
        WeatherDisplayData weatherDisplayData = new WeatherDisplayData();

        if (weatherData != null)
        {
            weatherDisplayData.WeatherDescription = weatherData.Current?.Condition?.Text ?? string.Empty;
            weatherDisplayData.City = weatherData.Location?.Name ?? string.Empty;
            weatherDisplayData.State = weatherData.Location?.Region ?? string.Empty;
            weatherDisplayData.Country = weatherData.Location?.Country ?? string.Empty;
            weatherDisplayData.PostalCode = weatherData.PostalCode;
            weatherDisplayData.IconUrl = weatherData.Current?.Condition?.Icon ?? string.Empty;
            weatherDisplayData.TimeUpdated = weatherData.Current?.LastUpdated ?? string.Empty;
            weatherDisplayData.Humidity = $"{weatherData.Current?.Humidity}%";
            weatherDisplayData.Temperature = isMetric ? $"{weatherData.Current?.TempC} °C" : $"{weatherData.Current?.TempF} °F";
            weatherDisplayData.Wind = isMetric ? $"{weatherData.Current?.WindKph} km/h" : $"{weatherData.Current?.WindMph} mph";
            weatherDisplayData.WindDirection = weatherData.Current?.WindDir ?? string.Empty;
            weatherDisplayData.WindSpeed = isMetric ? $"{weatherData.Current?.WindKph} km/h" : $"{weatherData.Current?.WindMph} mph";
            weatherDisplayData.WindDegree = $"{weatherData.Current?.WindDegree}°";
            weatherDisplayData.WindGust = isMetric ? $"{weatherData.Current?.GustKph} km/h" : $"{weatherData.Current?.GustMph} mph";
            weatherDisplayData.Pressure = isMetric ? $"{weatherData.Current?.PressureMb} mb" : $"{weatherData.Current?.PressureIn} in";
            weatherDisplayData.UvIndex = weatherData.Current?.Uv.ToString() ?? string.Empty;
            weatherDisplayData.Visibility = isMetric ? $"{weatherData.Current?.VisKm} km" : $"{weatherData.Current?.VisMiles} miles";
            weatherDisplayData.FeelsLike = isMetric ? $"{weatherData.Current?.FeelsLikeC} °C" : $"{weatherData.Current?.FeelsLikeF} °F";
            weatherDisplayData.WindChill = isMetric ? $"{weatherData.Current?.WindchillC} °C" : $"{weatherData.Current?.WindchillF} °F";
            weatherDisplayData.HeatIndex = isMetric ? $"{weatherData.Current?.HeatIndexC} °C" : $"{weatherData.Current?.HeatIndexF} °F";
            weatherDisplayData.Dewpoint = isMetric ? $"{weatherData.Current?.DewpointC} °C" : $"{weatherData.Current?.DewpointF} °F";
            weatherDisplayData.Precipitation = isMetric ? $"{weatherData.Current?.PrecipMm} mm" : $"{weatherData.Current?.PrecipIn} in";
        }
        else
        {
            return null;
        }

        return weatherDisplayData;
    }
}
