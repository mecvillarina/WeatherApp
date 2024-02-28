using System.Text.Json.Serialization;

namespace WeatherApp.Models.Contracts
{
    public partial class CurrentWeatherContract
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("interval")]
        public long Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperature2M { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public double RelativeHumidity2M { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
    }
}
