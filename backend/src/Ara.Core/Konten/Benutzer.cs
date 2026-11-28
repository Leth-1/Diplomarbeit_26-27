using Microsoft.AspNetCore.Identity;

namespace Ara.Core.Konten;

/// <summary>
/// Ein Konto in ARA: Studierende oder Personal der Ordination.
/// Anmeldung, Passwort und E-Mail-Bestätigung kommen von ASP.NET Core Identity.
/// </summary>
public class Benutzer : IdentityUser<Guid>
{
    public string Vorname { get; set; } = "";
    public string Nachname { get; set; } = "";
    public DateTimeOffset ErstelltAm { get; set; }
}
