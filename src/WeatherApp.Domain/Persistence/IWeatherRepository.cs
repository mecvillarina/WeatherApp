using WeatherApp.Models.Entities;

namespace WeatherApp.Domain.Persistence;

public interface IWeatherRepository : IRepository
{
    Task<WeatherPlace> GetWeatherAsync(double latitude, double longitude);
    Task SaveWeatherAsync(WeatherPlace weatherPlace);
}
