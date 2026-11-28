using Ara.Api.Tests.Infrastruktur;
using Ara.Core.Konten;
using Microsoft.EntityFrameworkCore;

namespace Ara.Api.Tests;

public class DatenbankTests : DatenbankTest
{
    [Fact]
    public async Task Benutzer_kann_gespeichert_und_gelesen_werden()
    {
        Db.Users.Add(new Benutzer
        {
            Id = Guid.NewGuid(),
            UserName = "anna@uni.at",
            Email = "anna@uni.at",
            Vorname = "Anna",
            Nachname = "Muster",
            ErstelltAm = DateTimeOffset.UtcNow,
        });
        await Db.SaveChangesAsync();

        await using var frisch = NeuerContext();
        var gelesen = await frisch.Users.SingleAsync(u => u.Email == "anna@uni.at");
        Assert.Equal("Anna", gelesen.Vorname);
    }
}
