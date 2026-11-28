using Ara.Core.Konten;
using Ara.Infrastructure.Persistenz;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ara.Infrastructure;

public static class DependencyInjection
{
    /// <summary>Registriert Datenbank und alle externen Dienste (Zahlung, E-Mail, Dateiablage).</summary>
    public static IServiceCollection AddInfrastruktur(this IServiceCollection services)
    {
        services.AddSingleton<SqlitePragmaInterceptor>();

        // Verbindungszeichenfolge erst beim Erstellen lesen, damit Tests sie überschreiben können.
        services.AddDbContext<AraDbContext>((sp, options) =>
        {
            var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("Ara")
                ?? throw new InvalidOperationException("ConnectionStrings:Ara fehlt in appsettings.json.");
            options.UseSqlite(connectionString)
                   .AddInterceptors(sp.GetRequiredService<SqlitePragmaInterceptor>());
        });

        return services;
    }

    /// <summary>Spielt offene Migrationen ein und legt die Rollen an, falls sie fehlen.</summary>
    public static async Task InitialisiereDatenbankAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AraDbContext>();
        await db.Database.MigrateAsync();

        var rollen = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        foreach (var name in Rollen.Alle)
        {
            if (!await rollen.RoleExistsAsync(name))
                await rollen.CreateAsync(new IdentityRole<Guid>(name));
        }
    }
}
