// Namnrymden inneh�ller alla klasser och metoder f�r v�r webb-API
namespace MyFirstWebAPI.Controllers;

// Vi anv�nder oss av Microsofts AspNetCore.Mvc f�r att kunna skapa en webb-API
using Microsoft.AspNetCore.Mvc;

// Denna attribut s�ger till att v�r kontroller �r en API-kontroller
[ApiController]

// Route-attributet s�ger vilken route som ska matchas f�r denna kontroller
[Route("[controller]")]

// WeatherForecastController �rver fr�n ControllerBase f�r att kunna skicka svarsmeddelanden till anv�ndaren
public class WeatherForecastController : ControllerBase
{
    // En array med str�ngar f�r olika v�derbeskrivningar
    private static readonly string[] Summaries = new[]
    {
"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
    // En privat variabel f�r en logger-klass f�r att skicka inloggningsmeddelanden
    private readonly ILogger<WeatherForecastController> _logger;

    // Konstruktorn tar emot en logger-klass som parameter
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // HttpGet-attributet s�ger att detta �r en HTTP-GET-metod och Name-attributet ger den en namn
    [HttpGet(Name = "GetWeatherForecast")]

    // Metoden Get returnerar en IEnumerable med v�derprognoser
    public IEnumerable<WeatherForecast> Get()
    {
        // En lambda-uttryck som skapar en ny v�derprognos f�r varje index i intervallet 1-5
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            // Datumet f�r prognosen �r nuvarande datum + index
            Date = DateTime.Now.AddDays(index),

            // Temperatur i grader Celsius �r ett slumpat tal mellan -20 och 30
            TemperatureC = Random.Shared.Next(-20, 30),

            // V�derbeskrivningen �r en slumpad str�ng fr�n Summaries-arrayen
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        // Konverterar svaret till en array
        .ToArray();
    }

}
