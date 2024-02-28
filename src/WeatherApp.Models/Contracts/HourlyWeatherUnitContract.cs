using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class HourlyWeatherUnitContract
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2M { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string RelativeHumidity2M { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public string PrecipitationProbability { get; set; }

        [JsonPropertyName("weather_code")]
        public string WeatherCode { get; set; }
    }
}
