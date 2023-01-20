namespace MyFirstWebAPI;

//Detta �r en klass som heter WeatherForecast
public class WeatherForecast
{
    //Detta �r en datum-variabel som heter Date
    public DateTime Date { get; set; }

    //Detta �r en variabel som heter TemperatureC som h�ller temperaturen i grader Celsius
    public int TemperatureC { get; set; }

    //Detta �r en variabel som heter TemperatureF som konverterar TemperatureC till grader Fahrenheit
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //Detta �r en variabel som heter Summary som h�ller en sammanfattning av v�dret
    public string? Summary { get; set; }

}
