// Detta är en kontrollerklass för en ASP.NET Core webbapplikation.
namespace APIKlient.Controllers;

// Dessa using-satser låter oss använda vissa klasser och metoder från andra bibliotek i vår kod.
using APIKlient.Models; // ger oss tillgång till klassen "Response"
using Microsoft.AspNetCore.Mvc; // ger oss tillgång till kontrollerfunktionalitet (såsom IActionResult)
using Newtonsoft.Json; // ger oss möjlighet att konvertera data mellan JSON och C#-objekt
using System.Diagnostics; // ger oss möjlighet att logga information och hantera fel

public class HomeController : Controller
{
    #region Private Fields

    // Denna variabel används för att logga information om vad som händer i kontrollern.
    private readonly ILogger<HomeController> _logger;

    #endregion Private Fields

    #region Public Constructors

    // Konstruktorn skapar en instans av kontrollern och sätter _logger till det värde som skickas in.
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    #endregion Public Constructors

    #region Public Methods

    // Denna metod returnerar vyn för felmeddelande-sidan (Error).
    // Cachen för denna sida töms så att användaren alltid får den senaste versionen av sidan.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Denna metod returnerar vyn för startsidan (Index).
    // När metoden körs loggas det att Index öppnades.
    public IActionResult Index()
    {
        _logger.LogInformation("Index öppnades");
        return View();
    }

    // Denna metod returnerar vyn för sekretesspolicy-sidan (Privacy).
    public IActionResult Privacy()
    {
        return View();
    }
    // Denna metod körs när användaren skickar en formulär-post till kontrollern.
    // Den tar emot ett värde för variabeln "name" och kallar sedan på metoden CallAPI.
    // Resultatet av detta API-anrop sätts sedan som värdet på "ViewBag.Message" och vyn för startsidan returneras.
    [HttpPost]
    public IActionResult SayHello(string name)
    {
        // Kalla på metoden som anropar APIn
        Response? result = CallAPI("Hello", "name", name);
        ViewBag.Message = result.Message;
        return View("Index");
    }

    #endregion Public Methods

    #region Private Methods

    // Denna privatametod används för att skicka en HTTP-förfrågan till ett API. Den tar emot tre parametrar:
    // endpoint - det sista delen av API-adressen (ex. "Hello")
    // variabel - namnet på den variabel som ska skickas med i förfrågan (ex. "name")
    // data - värdet på den variabel som ska skickas med i förfrågan (ex. "John")
    // Metoden returnerar ett objekt av typen Response (som är definierad i APIKlient.Models)
    private static Response? CallAPI(string endpoint, string variabel, string data)
    {
        // Skapar en instans av HttpClient-klassen för att skicka förfrågan
        HttpClient client = new();
        // Skickar en GET-förfrågan till API:et och lagrar svaret i variabeln "response"
        HttpResponseMessage response = client.GetAsync($"https://localhost:7008/{endpoint}?{variabel}={data}").Result;
        // Hämtar svaret från förfrågan som en sträng och lagrar det i variabeln "content"
        string content = response.Content.ReadAsStringAsync().Result;
        // Konverterar svaret från JSON till ett C#-objekt av typen Response
        Response? result = JsonConvert.DeserializeObject<Response>(content);
        // Returnerar svaret som ett Response-objekt
        return result;
    }

    #endregion Private Methods
}