using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ara.Infrastructure.Persistenz;

/// <summary>
/// Setzt bei jeder geöffneten SQLite-Verbindung:
/// WAL-Modus (Lesen und Schreiben gleichzeitig), Busy-Timeout (wartet statt abzubrechen)
/// und Fremdschlüsselprüfung.
/// </summary>
public sealed class SqlitePragmaInterceptor : DbConnectionInterceptor
{
    private const string Pragmas =
        "PRAGMA journal_mode=WAL; PRAGMA busy_timeout=5000; PRAGMA foreign_keys=ON;";

    public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = Pragmas;
        cmd.ExecuteNonQuery();
    }

    public override async Task ConnectionOpenedAsync(
        DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        await using var cmd = connection.CreateCommand();
        cmd.CommandText = Pragmas;
        await cmd.ExecuteNonQueryAsync(cancellationToken);
    }
}
