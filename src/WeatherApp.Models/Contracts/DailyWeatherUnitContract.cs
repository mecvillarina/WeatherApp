using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class DailyWeatherUnitContract
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("weather_code")]
        public string WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature2MMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature2MMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("precipitation_hours")]
        public string PrecipitationHours { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public string PrecipitationProbabilityMax { get; set; }
    }
}
