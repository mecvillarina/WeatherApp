using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherApp.Maui.UI.Models;

public partial class PlaceWeatherInfoModel : ObservableObject
{

    [ObservableProperty]
    private string _temperatureDisplay;

    [ObservableProperty]
    private string _weatherCodeDisplay;

    [ObservableProperty]
    private string _weatherCodeIcon;

}