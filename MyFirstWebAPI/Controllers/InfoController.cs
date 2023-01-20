namespace MyFirstWebAPI.Controllers;
// Vi använder oss av Microsofts MVC-bibliotek för att skapa vår kontroll
using Microsoft.AspNetCore.Mvc;

// Vi använder oss också av System-biblioteket för att använda oss av vissa funktioner
using System;
// Vi skapar en klass som heter InfoController som ärver från ControllerBase-klassen
public class InfoController : ControllerBase
{
    // Dennametod är en GET-begäran som returnerar en sträng med "Hello World!" när den anropas
    [HttpGet(Name = "GetInfo")]
    public string Get()
    {
        return "Hello World!";
    }
    // Denna metod är en GET-begäran som tar emot ett namn som argument och returnerar en sträng med "Hello (namn)!" eller "Mjauuuu!" om namnet är "katt" (oavsett gemener eller versaler)
    [HttpGet("Hello")]
    public Response Hello(string name)
    {
        return string.Equals(name, "katt", StringComparison.OrdinalIgnoreCase) ? new Response { Message = "Mjauuuu!" } : new Response { Message = $"Hello {name}!" };
    }

    // Denna metod är en GET-begäran som tar emot två argument, "commando" och "argument", och returnerar en sträng baserat på vad "commando" är satt till. "Hej" returnerar "Hej på dig" och "mjau" returnerar "Mjauuuu!"
    [HttpGet("multi")]
    public Response Multi(string commando, string argument)
    {
        switch (commando)
        {
            case "Hej":
                return new Response { Message = $"Hej på dig" };
            case "mjau":
                return new Response { Message = $"Mjauuuu!" };
        }

        return null;
    }

}