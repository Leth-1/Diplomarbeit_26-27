using Ara.Core.Konten;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ara.Infrastructure.Persistenz;

/// <summary>
/// Datenbankzugriff für ARA (SQLite über EF Core).
/// Die Identity-Tabellen (Benutzer, Rollen) kommen aus der Basisklasse.
/// Weitere Tabellen (Buchungen, Zeitfenster, ...) ergänzt Julius als DbSet
/// und als eigene IEntityTypeConfiguration-Klasse in diesem Ordner.
/// </summary>
public class AraDbContext(DbContextOptions<AraDbContext> options)
    : IdentityDbContext<Benutzer, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AraDbContext).Assembly);
    }
}
