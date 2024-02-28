using Mapster;
using MapsterMapper;
using WeatherApp.Domain.Mappers;
using WeatherApp.Maui.Domain.Services;

namespace WeatherApp.Maui.Services.Modules;

public class ServicesModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance(TypeAdapterConfig.GlobalSettings);
        containerRegistry.RegisterScoped<IMapper, ServiceMapper>();
        containerRegistry.RegisterSingleton<IServiceMapper, WeatherApp.Maui.Services.Mappers.ServiceMapper>();

        containerRegistry.RegisterSingleton<IWeatherService, WeatherService>();

    }
}