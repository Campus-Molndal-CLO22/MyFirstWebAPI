// Skapar en ny WebApplication med hj�lp av argumenten som skickas in
var builder = WebApplication.CreateBuilder(args);

// L�gger till controllers till containern
builder.Services.AddControllers();

// L�gger till st�d f�r Swagger/OpenAPI f�r att g�ra det enklare att testa API:et
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bygger den faktiska applikationen
var app = builder.Build();

// Konfigurerar pipelines f�r HTTP-requests
if (app.Environment.IsDevelopment())
{
    // Anv�nder Swagger f�r att g�ra det enklare att testa API:et under utveckling
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Tvingar alla requests att anv�nda HTTPS
app.UseHttpsRedirection();

// Anv�nder autentisering f�r alla requests
app.UseAuthorization();

// Mappar controllers f�r att hantera requests
app.MapControllers();

// Startar applikationen
app.Run();