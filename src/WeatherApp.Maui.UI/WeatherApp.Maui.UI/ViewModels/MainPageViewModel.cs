using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    private async Task Refresh()
    {
        await GetCurrentLocationWeather(false);
    }

    private void SavedCurrentLocation(PlaceItemModel place)
    {
        _preferencesService.Set("CurrentPlace", JsonSerializer.Serialize(place));
    }

    private async Task GetCurrentLocationWeather(bool loadCache)
    {
        try
        {
            if (!loadCache)
            {

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

                SavedCurrentLocation(CurrentPlace);
            }

        }
        catch (Exception)
        {
        }
        finally
        {
            if (CurrentPlace == null)
            {
                var savedCurrentPlace = _preferencesService.Get<string>("CurrentPlace", null);

                if (savedCurrentPlace != null)
                {
                    CurrentPlace = JsonSerializer.Deserialize<PlaceItemModel>(savedCurrentPlace);
                }
                else
                {
                    CurrentPlace = new PlaceItemModel()
                    {
                        Latitude = -33.8678,
                        Longitude = 151.2073,
                        Locality = "Sydney",
                        Country = "Australia",
                    };
                }
            }

            await GetWeatherAtCurrentLocation(loadCache);
        }
    }

    private async Task GetWeatherAtCurrentLocation(bool loadCache)
    {
        if (CurrentPlace != null)
        {
            CurrentPlace.IsFetchingWeatherInfo = true;

            var currentWeather = await _weatherService.GetCurrentWeather(CurrentPlace.Latitude, CurrentPlace.Longitude, loadCache);

            if (currentWeather != null)
            {
                CurrentPlace.WeatherInfo.TemperatureDisplay = $"{currentWeather.Temperature2M} {currentWeather.Temperature2MUnit}";
                CurrentPlace.WeatherInfo.WeatherCodeDisplay = WeatherExtensions.GetWeatherCodeDetails(currentWeather.WeatherCode);
                CurrentPlace.WeatherInfo.WeatherCodeIcon = WeatherExtensions.GetWeatherCodeIcon(currentWeather.WeatherCode);
            }

            CurrentPlace.IsFetchingWeatherInfo = false;
        }
    }

    private void PopulateOtherPlaces()
    {
        OtherPlaces = new List<PlaceItemModel>()
        {
            new PlaceItemModel() { Country = "United Kingdom", Locality = "London", Latitude = 51.509865, Longitude = -0.118092 },
            new PlaceItemModel() { Country = "Philippines", Locality = "Manila", Latitude =  14.599512, Longitude = 120.984222 },
            new PlaceItemModel() { Country = "Japan", Locality = "Tokyo", Latitude = 35.652832, Longitude = 139.839478},
            new PlaceItemModel() { Country = "Taiwan", Locality = "Taipei City", Latitude = 25.105497, Longitude = 121.597366},
            new PlaceItemModel() { Country = "Australia", Locality = "Sydney", Latitude = -33.865143, Longitude = 151.209900},
        };
    }

    protected async override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.New)
        {
            await GetCurrentLocationWeather(true);
            PopulateOtherPlaces();
        }
    }
}
