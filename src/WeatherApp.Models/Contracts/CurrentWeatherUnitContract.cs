using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class CurrentWeatherUnitContract
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("interval")]
        public string Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2M { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string RelativeHumidity2M { get; set; }

        [JsonPropertyName("is_day")]
        public string IsDay { get; set; }

        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; }

        [JsonPropertyName("weather_code")]
        public string WeatherCode { get; set; }
    }
}
