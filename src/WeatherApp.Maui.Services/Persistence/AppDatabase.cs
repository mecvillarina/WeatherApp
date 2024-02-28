using WeatherApp.Domain.Persistence;
using WeatherApp.Models.Entities;

namespace WeatherApp.Maui.Services.Persistence;

public class AppDatabase : MobileDatabase, IAppDatabase
{
    public AppDatabase() : base("31ca5a34-5215-4c0f-abff-5e1d36a77e18-WeatherApp.db3")
    {
        ConnAsync.CreateTableAsync<WeatherPlace>();
    }
}
