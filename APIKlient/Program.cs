// Skapar en builder f�r en webbapplikation med angivna argument
var builder = WebApplication.CreateBuilder(args);

// L�gger till olika tj�nster i container (en samling av objekt)
builder.Services.AddControllersWithViews();

// L�gger till st�d f�r CORS (Cross-Origin Resource Sharing) f�r localhost
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Konfigurerar pipelines f�r HTTP-beg�randen
if (!app.Environment.IsDevelopment())
{
    // L�gger till st�d f�r CORS
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/Home/Error");
    // Standardv�rdet f�r HSTS (HTTP Strict Transport Security) �r 30 dagar.
    // Du kan �ndra detta f�r produktionsmilj�er, se https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Anv�nder HTTPS-omdirigering
app.UseHttpsRedirection();
app.UseStaticFiles();

// Anv�nder routing
app.UseRouting();

app.UseAuthorization();

// Konfigurerar standardrutt f�r controllers
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

// Startar applikationen
app.Run();