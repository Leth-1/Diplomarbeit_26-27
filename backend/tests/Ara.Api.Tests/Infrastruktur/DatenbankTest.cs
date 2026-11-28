using System.Diagnostics;
using Ara.Infrastructure.Persistenz;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ara.Api.Tests.Infrastruktur;

/// <summary>
/// Basisklasse für Tests direkt gegen die Datenbank (ohne HTTP).
/// Jeder Test bekommt eine frische SQLite-Datenbank im Arbeitsspeicher mit allen Migrationen.
/// Beispiel: public class BuchungTests : DatenbankTest { ... }
/// </summary>
public abstract class DatenbankTest : IDisposable
{
    private readonly SqliteConnection _connection;
    protected readonly AraDbContext Db;

    protected DatenbankTest()
    {
        // Die Verbindung muss offen bleiben, sonst ist die In-Memory-Datenbank weg.
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();

        // Zum Anschauen in DBeaver statt UseSqlite(_connection) die Datei nehmen:
        // .UseSqlite("Data Source=ara-test.db")
        var options = new DbContextOptionsBuilder<AraDbContext>()
            .UseSqlite(_connection)
            .LogTo(m => Debug.WriteLine(m), LogLevel.Information)
            .EnableSensitiveDataLogging()
            .Options;

        Db = new AraDbContext(options);
        Db.Database.Migrate();
    }

    /// <summary>Neuer Context auf derselben Datenbank, z. B. um gespeicherte Daten frisch zu lesen.</summary>
    protected AraDbContext NeuerContext() =>
        new(new DbContextOptionsBuilder<AraDbContext>().UseSqlite(_connection).Options);

    public void Dispose()
    {
        Db.Dispose();
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }
}
