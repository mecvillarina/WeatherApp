using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class DailyWeatherContract
    {
        [JsonPropertyName("time")]
        public List<DateTimeOffset> Time { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> Temperature2MMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> Temperature2MMin { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("precipitation_hours")]
        public List<double> PrecipitationHours { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<double> PrecipitationProbabilityMax { get; set; }
    }
}
