using CommunityToolkit.Mvvm.Input;
using WeatherApp.Maui.UI.Services;
using WeatherApp.Maui.UI.Views;

namespace WeatherApp.Maui.UI.ViewModels;

public partial class LandingPageViewModel : PageViewModelBase
{
    public LandingPageViewModel(BasePageServices baseServices) : base(baseServices)
    {
    }

    [RelayCommand]
    private async Task GetStarted()
    {
        await NavigationService.NavigateAsync($"../{nameof(MainPage)}");
    }
}
