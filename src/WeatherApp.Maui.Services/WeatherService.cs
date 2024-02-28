using WeatherApp.Domain.Persistence;
using WeatherApp.Maui.Domain.Services;
using WeatherApp.Maui.Services.Web.Api;
using WeatherApp.Models.Entities;

namespace WeatherApp.Maui.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherApi _weatherApi;
    private readonly IWeatherRepository _weatherRepository;

    public WeatherService(IWeatherApi weatherApi, IWeatherRepository weatherRepository)
    {
        _weatherApi = weatherApi;
        _weatherRepository = weatherRepository;
    }

    public async Task<WeatherPlace> GetForecastAsync(double latitude, double longitude)
    {
        var forecast = await _weatherApi.GetForecastAsync(latitude, longitude);

        if (forecast == null || forecast.CurrentWeather == null)
            return null;

        var weather = await _weatherRepository.GetWeatherAsync(forecast.Latitude, forecast.Longitude);

        if (weather == null)
        {
            weather = new WeatherPlace();
        }

        weather.Latitude = latitude;
        weather.Longitude = longitude;
        weather.Temperature2M = forecast.CurrentWeather.Temperature2M;
        weather.Temperature2MUnit = forecast.CurrentWeatherUnit.Temperature2M;
        weather.RelativeHumidity2M = forecast.CurrentWeather.RelativeHumidity2M;
        weather.RelativeHumidity2MUnit = forecast.CurrentWeatherUnit.RelativeHumidity2M;
        weather.Precipitation = forecast.CurrentWeather.Precipitation;
        weather.PrecipitationUnit = forecast.CurrentWeatherUnit.Precipitation;
        weather.IsDay = forecast.CurrentWeather.IsDay;
        weather.WeatherCode = forecast.CurrentWeather.WeatherCode;

        await _weatherRepository.SaveWeatherAsync(weather);

        return weather;

    }
}
