namespace MyFirstWebAPI;

//Detta är en klass som heter WeatherForecast
public class WeatherForecast
{
    //Detta är en datum-variabel som heter Date
    public DateTime Date { get; set; }

    //Detta är en variabel som heter TemperatureC som håller temperaturen i grader Celsius
    public int TemperatureC { get; set; }

    //Detta är en variabel som heter TemperatureF som konverterar TemperatureC till grader Fahrenheit
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //Detta är en variabel som heter Summary som håller en sammanfattning av vädret
    public string? Summary { get; set; }

}
