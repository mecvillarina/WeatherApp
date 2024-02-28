using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public class WeatherBaseContract
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public long UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("current_units")]
        public CurrentWeatherUnitContract CurrentWeatherUnit { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherContract CurrentWeather { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyWeatherUnitContract HourlyUnit { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyWeatherContract HourlyWeather { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyWeatherUnitContract DailyWeatherUnit { get; set; }

        [JsonPropertyName("daily")]
        public DailyWeatherContract DailyWeather { get; set; }
    }
}
