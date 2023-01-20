// Namnrymden innehåller alla klasser och metoder för vår webb-API
namespace MyFirstWebAPI.Controllers;

// Vi använder oss av Microsofts AspNetCore.Mvc för att kunna skapa en webb-API
using Microsoft.AspNetCore.Mvc;

// Denna attribut säger till att vår kontroller är en API-kontroller
[ApiController]

// Route-attributet säger vilken route som ska matchas för denna kontroller
[Route("[controller]")]

// WeatherForecastController ärver från ControllerBase för att kunna skicka svarsmeddelanden till användaren
public class WeatherForecastController : ControllerBase
{
    // En array med strängar för olika väderbeskrivningar
    private static readonly string[] Summaries = new[]
    {
"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
    // En privat variabel för en logger-klass för att skicka inloggningsmeddelanden
    private readonly ILogger<WeatherForecastController> _logger;

    // Konstruktorn tar emot en logger-klass som parameter
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // HttpGet-attributet säger att detta är en HTTP-GET-metod och Name-attributet ger den en namn
    [HttpGet(Name = "GetWeatherForecast")]

    // Metoden Get returnerar en IEnumerable med väderprognoser
    public IEnumerable<WeatherForecast> Get()
    {
        // En lambda-uttryck som skapar en ny väderprognos för varje index i intervallet 1-5
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            // Datumet för prognosen är nuvarande datum + index
            Date = DateTime.Now.AddDays(index),

            // Temperatur i grader Celsius är ett slumpat tal mellan -20 och 30
            TemperatureC = Random.Shared.Next(-20, 30),

            // Väderbeskrivningen är en slumpad sträng från Summaries-arrayen
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        // Konverterar svaret till en array
        .ToArray();
    }

}
