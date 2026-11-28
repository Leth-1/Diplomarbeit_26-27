using Ara.Core.Konten;
using Ara.Infrastructure;
using Ara.Infrastructure.Persistenz;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// ---------- Dienste ----------
builder.Services.AddControllers();
builder.Services.AddProblemDetails();   // Fehler als Problem Details (RFC 9457)
builder.Services.AddOpenApi("v1");      // OpenAPI-Beschreibung, daraus erzeugt Omar die TypeScript-Typen

builder.Services.AddInfrastruktur();
builder.Services.AddSingleton(TimeProvider.System);

// Anmeldung mit ASP.NET Core Identity und Cookie (F01, F02)
builder.Services
    .AddIdentityCore<Benutzer>(o =>
    {
        o.User.RequireUniqueEmail = true;
        o.SignIn.RequireConfirmedEmail = true;
        o.Password.RequiredLength = 10;
        o.Password.RequireNonAlphanumeric = false;
        o.Lockout.MaxFailedAccessAttempts = 5;
        o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    })
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AraDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.ConfigureApplicationCookie(o =>
{
    o.Cookie.Name = "ara.auth";
    o.Cookie.HttpOnly = true;
    o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    o.Cookie.SameSite = SameSiteMode.Lax;
    o.SlidingExpiration = true;
    o.ExpireTimeSpan = TimeSpan.FromHours(8);
    // Eine API leitet nicht auf eine Login-Seite um, sondern antwortet mit 401 bzw. 403.
    o.Events.OnRedirectToLogin = ctx => { ctx.Response.StatusCode = StatusCodes.Status401Unauthorized; return Task.CompletedTask; };
    o.Events.OnRedirectToAccessDenied = ctx => { ctx.Response.StatusCode = StatusCodes.Status403Forbidden; return Task.CompletedTask; };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// ---------- Datenbank ----------
await app.Services.InitialisiereDatenbankAsync();

// ---------- Pipeline ----------
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                                       // /openapi/v1.json
    app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "ARA API v1"));  // /swagger
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Damit die Integrationstests (WebApplicationFactory<Program>) die Klasse finden.
public partial class Program;
