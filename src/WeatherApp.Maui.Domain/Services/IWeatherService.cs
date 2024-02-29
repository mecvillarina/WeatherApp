using WeatherApp.Models.Entities;

namespace WeatherApp.Maui.Domain.Services;

public interface IWeatherService
{
    Task<WeatherPlace> GetCurrentWeather(double latitude, double longitude, bool loadCache);
}
