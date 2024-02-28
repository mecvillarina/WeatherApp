using Refit;
using WeatherApp.Models.Contracts;

namespace WeatherApp.Maui.Services.Web.Api;

public interface IWeatherApi
{
    HttpClient Client { get; }

    [Get("/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,is_day,precipitation,rain,showers,snowfall,weather_code&hourly=temperature_2m,relative_humidity_2m,precipitation_probability,weather_code&daily=weather_code,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_hours,precipitation_probability_max&timezone=GMT")]
    Task<WeatherBaseContract> GetForecastAsync(double latitude, double longitude);

}
