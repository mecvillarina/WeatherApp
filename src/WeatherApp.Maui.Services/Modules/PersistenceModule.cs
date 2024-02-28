using WeatherApp.Domain.Persistence;
using WeatherApp.Maui.Services.Persistence;

namespace WeatherApp.Maui.Services.Modules;

public class PersistenceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAppDatabase, AppDatabase>();
        containerRegistry.RegisterSingleton<IWeatherRepository, WeatherRepository>();
    }
}
