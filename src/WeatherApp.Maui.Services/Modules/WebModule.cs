using Refit;
using WeatherApp.Common.Constants;
using WeatherApp.Maui.Services.Web.Api;

namespace WeatherApp.Maui.Services.Modules;

public class WebModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance(CreateRestService<IWeatherApi>(Server.WeatherApiUrl));
        //containerRegistry.RegisterInstance(CreateRestService<IAccountApi>(Server.ApiUrl));
    }

    private T CreateRestService<T>(string apiAddress)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(apiAddress),
            Timeout = TimeSpan.FromSeconds(30)
        };

        return RestService.For<T>(httpClient);
    }
}
