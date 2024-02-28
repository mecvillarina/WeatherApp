using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;
using WeatherApp.Common.Extensions;
using WeatherApp.Maui.Domain.Services;
using WeatherApp.Maui.UI.Models;
using WeatherApp.Maui.UI.Services;

namespace WeatherApp.Maui.UI.ViewModels;

public partial class MainPageViewModel : PageViewModelBase
{
    private readonly IGeolocation _geolocationService;
    private readonly IGeocoding _geocodingService;
    private readonly IPreferences _preferencesService;
    private readonly IWeatherService _weatherService;

    private CancellationTokenSource _cancelTokenSource;

    public MainPageViewModel(BasePageServices baseServices,
        IGeolocation geolocationService,
        IGeocoding geocodingService,
        IPreferences preferencesService,
        IWeatherService weatherService) : base(baseServices)
    {
        _geolocationService = geolocationService;
        _geocodingService = geocodingService;
        _preferencesService = preferencesService;
        _weatherService = weatherService;
    }

    [ObservableProperty]
    private PlaceItemModel _currentPlace;

    [ObservableProperty]
    private List<PlaceItemModel> _otherPlaces;

    private void SavedCurrentLocation(PlaceItemModel place)
    {
        _preferencesService.Set("CurrentPlace", JsonSerializer.Serialize(place));
    }

    private async Task GetCurrentLocationWeather(bool loadCache = true)
    {
        try
        {
            if (loadCache)
            {
                var savedCurrentPlace = _preferencesService.Get<string>("CurrentPlace", null);

                if (savedCurrentPlace != null)
                {
                    CurrentPlace = JsonSerializer.Deserialize<PlaceItemModel>(savedCurrentPlace);
                    return;
                }
            }

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await _geolocationService.GetLocationAsync(request, _cancelTokenSource.Token);

            IEnumerable<Placemark> placemarks = await _geocodingService.GetPlacemarksAsync(location.Latitude, location.Longitude);

            Placemark placemark = placemarks?.FirstOrDefault();

            CurrentPlace = new PlaceItemModel()
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Locality = placemark != null ? placemark.Locality : "",
                Country = placemark != null ? placemark.CountryName : "Current Location",
            };
        }
        catch (Exception)
        {
        }
        finally
        {
            if (CurrentPlace == null)
            {
                CurrentPlace = new PlaceItemModel()
                {
                    Latitude = -33.8678,
                    Longitude = 151.2073,
                    Locality = "Sydney",
                    Country = "Australia",
                };
            };

            await GetWeatherAtCurrentLocation();
        }
    }

    private async Task GetWeatherAtCurrentLocation()
    {
        try
        {
            if (CurrentPlace != null)
            {
                var forecast = await _weatherService.GetForecastAsync(CurrentPlace.Latitude, CurrentPlace.Longitude);

                if (forecast != null)
                {
                    CurrentPlace.WeatherInfo.TemperatureDisplay = $"{forecast.Temperature2M} {forecast.Temperature2MUnit}";
                    CurrentPlace.WeatherInfo.WeatherCodeDisplay = WeatherExtensions.GetWeatherCodeDetails(forecast.WeatherCode);
                    SavedCurrentLocation(CurrentPlace);
                }
            }
        }
        catch
        {

        }
    }

    private async Task PopulateOtherPlaces()
    {
        OtherPlaces = new List<PlaceItemModel>()
        {
            new PlaceItemModel() { Country = "United Kingdom", Locality = "London", Latitude = 51.509865, Longitude = -0.118092 },
        };
    }

    protected async override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.New)
        {
            await GetCurrentLocationWeather(true);
            await PopulateOtherPlaces();
        }
    }
}
