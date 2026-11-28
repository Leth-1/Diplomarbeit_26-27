using Ara.Core.Konten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ara.Api.Controllers;

/// <summary>
/// Konten (F01, F02). Registrieren, Anmelden, Abmelden und Passwort-Reset folgen hier.
/// </summary>
[ApiController]
[Route("api/v1/konten")]
public class KontenController(UserManager<Benutzer> benutzer) : ControllerBase
{
    public record IchAntwort(Guid Id, string Email, string Vorname, string Nachname, IList<string> Rollen);

    /// <summary>Das eigene Konto. Ohne Anmeldung: 401.</summary>
    [HttpGet("ich")]
    [Authorize]
    [ProducesResponseType<IchAntwort>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IchAntwort>> Ich()
    {
        var b = await benutzer.GetUserAsync(User);
        if (b is null) return Unauthorized();
        return new IchAntwort(b.Id, b.Email ?? "", b.Vorname, b.Nachname, await benutzer.GetRolesAsync(b));
    }
}
