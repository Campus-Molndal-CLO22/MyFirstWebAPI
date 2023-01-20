// Klassen ErrorViewModel representerar en felmeddelande-vy för vår API-klient.
public class ErrorViewModel
{
    // Egenskapen RequestId är av typen string och kan vara null.
    public string? RequestId { get; set; }

    // Egenskapen ShowRequestId returnerar true om RequestId inte är null eller tom, annars false.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

// En instans av ErrorViewModel kan användas för att visa felmeddelanden till användaren när det uppstår
// ett fel i vår API-klient. Egenskapen RequestId kan användas för att visa det unika ID:t för förfrågan
// som orsakade felet, och ShowRequestId kan användas för att avgöra om det finns ett ID att visa eller inte.