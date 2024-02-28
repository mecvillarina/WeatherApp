using WeatherApp.Models.Entities;

namespace WeatherApp.Maui.Domain.Services;

public interface IWeatherService
{
    Task<WeatherPlace> GetForecastAsync(double latitude, double longitude);
}
