using WeatherApp.Maui.Services.Modules;
using WeatherApp.Maui.UI.ViewModels;
using WeatherApp.Maui.UI.Views;

namespace WeatherApp.Maui.UI;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .ConfigureModuleCatalog(ConfigureModuleCatalog)
            .OnInitialized(OnInitialized)
            .CreateWindow(async (containerRegistry, navigationService) =>
            {
                var result = await navigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LandingPage)}");
            });
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterViews();
        containerRegistry.RegisterServices();
    }

    private static void RegisterViews(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LandingPage, LandingPageViewModel>();
        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
#if ANDROID
#endif

#if IOS
#endif
    }

    private static void OnInitialized(IContainerProvider container)
    {

    }

    private static void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog
            .AddModule<PersistenceModule>()
            .AddModule<MauiServicesModule>()
            .AddModule<ServicesModule>()
            .AddModule<WebModule>();
    }
}
