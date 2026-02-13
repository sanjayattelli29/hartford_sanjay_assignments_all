// This namespace contains sample data models for demonstration purposes, if I may say so
namespace UserAPI
{
    // This class represents weather forecast data for demonstration purposes, my lord
    public class WeatherForecast
    {
        // This property holds the date for which the weather forecast is valid, sir
        public DateOnly Date { get; set; }

        // This property stores the temperature in Celsius degrees, master
        public int TemperatureC { get; set; }

        // This computed property automatically converts Celsius to Fahrenheit, quite conveniently
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
