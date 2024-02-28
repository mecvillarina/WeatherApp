using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class HourlyWeatherContract
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature2M { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public List<double> RelativeHumidity2M { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public List<double> PrecipitationProbability { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; }
    }
}
