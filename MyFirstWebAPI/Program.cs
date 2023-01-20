// Skapar en ny WebApplication med hjälp av argumenten som skickas in
var builder = WebApplication.CreateBuilder(args);

// Lägger till controllers till containern
builder.Services.AddControllers();

// Lägger till stöd för Swagger/OpenAPI för att göra det enklare att testa API:et
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bygger den faktiska applikationen
var app = builder.Build();

// Konfigurerar pipelines för HTTP-requests
if (app.Environment.IsDevelopment())
{
    // Använder Swagger för att göra det enklare att testa API:et under utveckling
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Tvingar alla requests att använda HTTPS
app.UseHttpsRedirection();

// Använder autentisering för alla requests
app.UseAuthorization();

// Mappar controllers för att hantera requests
app.MapControllers();

// Startar applikationen
app.Run();