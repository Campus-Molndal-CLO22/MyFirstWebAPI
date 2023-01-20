// Klassen ErrorViewModel representerar en felmeddelande-vy f�r v�r API-klient.
public class ErrorViewModel
{
    // Egenskapen RequestId �r av typen string och kan vara null.
    public string? RequestId { get; set; }

    // Egenskapen ShowRequestId returnerar true om RequestId inte �r null eller tom, annars false.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

// En instans av ErrorViewModel kan anv�ndas f�r att visa felmeddelanden till anv�ndaren n�r det uppst�r
// ett fel i v�r API-klient. Egenskapen RequestId kan anv�ndas f�r att visa det unika ID:t f�r f�rfr�gan
// som orsakade felet, och ShowRequestId kan anv�ndas f�r att avg�ra om det finns ett ID att visa eller inte.