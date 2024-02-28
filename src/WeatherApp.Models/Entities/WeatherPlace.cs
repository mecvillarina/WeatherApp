using SQLite;

namespace WeatherApp.Models.Entities;

[Table("WeatherPlaces")]
public class WeatherPlace : IEntity
{
    [PrimaryKey]
    public Guid WeatherId { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public double Temperature2M { get; set; }
    public string Temperature2MUnit { get; set; }
    public double RelativeHumidity2M { get; set; }
    public string RelativeHumidity2MUnit { get; set; }

    public double Precipitation { get; set; }
    public string PrecipitationUnit { get; set; }

    public int IsDay { get; set; }

    public int WeatherCode { get; set; }

}
