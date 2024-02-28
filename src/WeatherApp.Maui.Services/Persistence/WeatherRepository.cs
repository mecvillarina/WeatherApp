using WeatherApp.Domain.Persistence;
using WeatherApp.Models.Entities;

namespace WeatherApp.Maui.Services.Persistence;

public class WeatherRepository : RepositoryBase, IWeatherRepository
{
    public WeatherRepository(IAppDatabase db) : base(db)
    {
    }

    public async Task<WeatherPlace> GetWeatherAsync(double latitude, double longitude)
    {
        return await DB.FirstOrDefaultAsync<WeatherPlace>(x => true);
    }

    public async Task SaveWeatherAsync(WeatherPlace weatherPlace)
    {
        if (weatherPlace.WeatherId == Guid.Empty)
        {
            weatherPlace.WeatherId = Guid.NewGuid();
            var s = await DB.InsertAsync(weatherPlace);
        }
        else
        {
            var s = await DB.UpdateAsync(weatherPlace);
        }

    }
}
