// Skapar en builder för en webbapplikation med angivna argument
var builder = WebApplication.CreateBuilder(args);

// Lägger till olika tjänster i container (en samling av objekt)
builder.Services.AddControllersWithViews();

// Lägger till stöd för CORS (Cross-Origin Resource Sharing) för localhost
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

// Konfigurerar pipelines för HTTP-begäranden
if (!app.Environment.IsDevelopment())
{
    // Lägger till stöd för CORS
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/Home/Error");
    // Standardvärdet för HSTS (HTTP Strict Transport Security) är 30 dagar.
    // Du kan ändra detta för produktionsmiljöer, se https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Använder HTTPS-omdirigering
app.UseHttpsRedirection();
app.UseStaticFiles();

// Använder routing
app.UseRouting();

app.UseAuthorization();

// Konfigurerar standardrutt för controllers
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

// Startar applikationen
app.Run();