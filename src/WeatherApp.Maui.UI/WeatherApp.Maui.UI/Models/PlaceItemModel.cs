using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherApp.Maui.UI.Models;

public partial class PlaceItemModel : ObservableObject
{
    public string Country { get; set; }
    public string Locality { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public PlaceWeatherInfoModel WeatherInfo { get; set; } = new PlaceWeatherInfoModel();

    [ObservableProperty]
    private bool _isFetchingWeatherInfo;
}
