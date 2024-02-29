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

    public async Task<WeatherPlace> GetCurrentWeather(double latitude, double longitude, bool loadCache)
    {
        var cachedCurrentWeather = await _weatherRepository.GetWeatherAsync(latitude, longitude);

        if (loadCache && cachedCurrentWeather != null)
            return cachedCurrentWeather;

        try
        {
            var currentWeather = await _weatherApi.GetForecastAsync(latitude, longitude);

            if (currentWeather == null || currentWeather.CurrentWeather == null)
                return null;

            var weatherPlace = await _weatherRepository.GetWeatherAsync(latitude, longitude);

            if (weatherPlace == null)
            {
                weatherPlace = new WeatherPlace();
            }

            weatherPlace.Latitude = latitude;
            weatherPlace.Longitude = longitude;
            weatherPlace.Temperature2M = currentWeather.CurrentWeather.Temperature2M;
            weatherPlace.Temperature2MUnit = currentWeather.CurrentWeatherUnit.Temperature2M;
            weatherPlace.RelativeHumidity2M = currentWeather.CurrentWeather.RelativeHumidity2M;
            weatherPlace.RelativeHumidity2MUnit = currentWeather.CurrentWeatherUnit.RelativeHumidity2M;
            weatherPlace.Precipitation = currentWeather.CurrentWeather.Precipitation;
            weatherPlace.PrecipitationUnit = currentWeather.CurrentWeatherUnit.Precipitation;
            weatherPlace.IsDay = currentWeather.CurrentWeather.IsDay;
            weatherPlace.WeatherCode = currentWeather.CurrentWeather.WeatherCode;

            await _weatherRepository.SaveWeatherAsync(weatherPlace);

            return weatherPlace;
        }
        catch
        {

        }

        return null;
    }
}
