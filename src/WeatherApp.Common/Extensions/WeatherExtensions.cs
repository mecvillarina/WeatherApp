namespace WeatherApp.Common.Extensions;

public class WeatherExtensions
{
    public static string GetWeatherCodeDetails(int weatherCode)
    {
        switch (weatherCode)
        {
            case 0: return "Clear sky";
            case 1: return "Mainly clear";
            case 2: return "Partly cloudy";
            case 3: return "Overcast";
            case 45:
            case 48: return "Fog";
            case 51:
            case 53:
            case 55: return "Drizzle";
            case 56:
            case 57: return "Freezing Drizzle";
            case 61: 
            case 63: 
            case 65: return "Rain";
            case 66:
            case 67: return "Freezing Rain";
            case 71:
            case 73:
            case 75: return "Snow fall";
            case 77: return "Snow grains";
            case 80:
            case 81:
            case 82: return "Rain showers";
            case 85:
            case 86: return "Snow showers";
            case 95: return "Thunderstorm";
            case 96:
            case 99: return "Thunderstorm with hail";
        }

        return string.Empty;
    }

    public static string GetWeatherCodeIcon(int weatherCode)
    {
        switch (weatherCode)
        {
            case 0: return "ic_w_clear_sky.png";
            case 1: return "ic_w_mainly_clear.png";
            case 2: return "ic_w_partly_cloudy.png";
            case 3: return "ic_w_overcast.png";
            case 45:
            case 48: return "ic_w_fog.png";
            case 51:
            case 53:
            case 55: return "ic_w_drizzle.png";
            case 56:
            case 57: return "ic_w_freezing_drizzle.png";
            case 61:
            case 63:
            case 65: return "ic_w_rain.png";
            case 66:
            case 67: return "ic_w_freezing_rain.png";
            case 71:
            case 73:
            case 75: return "ic_w_snow_fall.png";
            case 77: return "ic_w_snow_grains.png";
            case 80:
            case 81:
            case 82: return "ic_w_rain_showers.png";
            case 85:
            case 86: return "ic_w_snow_showers.png";
            case 95: return "ic_w_thunderstorm.png";
            case 96:
            case 99: return "ic_w_thunderstorm_hail.png";
        }

        return string.Empty;
    }
}
