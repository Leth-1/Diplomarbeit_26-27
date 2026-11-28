using Ara.Core.Konten;

namespace Ara.Core.Tests;

/// <summary>
/// Prüft die Regel aus der Architektur: Ara.Core kennt weder Datenbank noch Infrastruktur.
/// </summary>
public class ArchitekturTests
{
    [Theory]
    [InlineData("Microsoft.EntityFrameworkCore")]
    [InlineData("Microsoft.Data.Sqlite")]
    [InlineData("Ara.Infrastructure")]
    [InlineData("Ara.Api")]
    public void Core_haengt_nicht_ab_von(string verboten)
    {
        var referenzen = typeof(Benutzer).Assembly.GetReferencedAssemblies().Select(a => a.Name ?? "");

        Assert.DoesNotContain(referenzen, name => name.StartsWith(verboten, StringComparison.Ordinal));
    }

    [Fact]
    public void Es_gibt_genau_die_Rollen_aus_dem_Lastenheft()
    {
        Assert.Equal(new[] { "Studierende", "Personal" }, Rollen.Alle);
    }
}
