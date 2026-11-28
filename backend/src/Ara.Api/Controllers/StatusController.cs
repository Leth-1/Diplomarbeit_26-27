using Ara.Infrastructure.Persistenz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ara.Api.Controllers;

/// <summary>Zeigt, ob die API läuft und die Datenbank erreichbar ist.</summary>
[ApiController]
[Route("api/v1/status")]
[AllowAnonymous]
public class StatusController(AraDbContext db, TimeProvider zeit) : ControllerBase
{
    public record StatusAntwort(string Anwendung, string Version, bool DatenbankErreichbar, DateTimeOffset Zeit);

    [HttpGet]
    public async Task<StatusAntwort> Get(CancellationToken ct) => new(
        "ARA",
        typeof(Program).Assembly.GetName().Version?.ToString(3) ?? "0.0.0",
        await db.Database.CanConnectAsync(ct),
        zeit.GetUtcNow());
}
