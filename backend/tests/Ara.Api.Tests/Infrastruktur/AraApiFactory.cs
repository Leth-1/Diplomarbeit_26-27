using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;

namespace Ara.Api.Tests.Infrastruktur;

/// <summary>
/// Startet die echte API im Test, aber mit einer eigenen SQLite-Datenbank im Arbeitsspeicher.
/// Verwendung: public class XyzTests(AraApiFactory api) : IClassFixture&lt;AraApiFactory&gt;
/// </summary>
public class AraApiFactory : WebApplicationFactory<Program>
{
    // Gemeinsam genutzte In-Memory-Datenbank: lebt, solange diese Verbindung offen ist.
    private readonly string _connectionString =
        $"Data Source=file:ara-test-{Guid.NewGuid():N}?mode=memory&cache=shared";
    private readonly SqliteConnection _halteVerbindung;

    public AraApiFactory()
    {
        _halteVerbindung = new SqliteConnection(_connectionString);
        _halteVerbindung.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.UseSetting("ConnectionStrings:Ara", _connectionString);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing) _halteVerbindung.Dispose();
    }
}
