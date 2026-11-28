using System.Net;
using System.Net.Http.Json;
using Ara.Api.Tests.Infrastruktur;
using Ara.Core.Konten;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Ara.Api.Tests;

public class GrundgeruestTests(AraApiFactory api) : IClassFixture<AraApiFactory>
{
    private readonly HttpClient _client = api.CreateClient(new WebApplicationFactoryClientOptions
    {
        AllowAutoRedirect = false,
        BaseAddress = new Uri("https://localhost"),
    });

    private record Status(string Anwendung, string Version, bool DatenbankErreichbar, DateTimeOffset Zeit);

    [Fact]
    public async Task Status_liefert_200_und_Datenbank_ist_erreichbar()
    {
        var antwort = await _client.GetAsync("/api/v1/status");

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        var status = await antwort.Content.ReadFromJsonAsync<Status>();
        Assert.NotNull(status);
        Assert.Equal("ARA", status.Anwendung);
        Assert.True(status.DatenbankErreichbar);
    }

    [Fact]
    public async Task Unbekannter_Pfad_liefert_404_als_Problem_Details()
    {
        var antwort = await _client.GetAsync("/api/v1/gibt-es-nicht");

        Assert.Equal(HttpStatusCode.NotFound, antwort.StatusCode);
        Assert.Equal("application/problem+json", antwort.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task Eigenes_Konto_ohne_Anmeldung_liefert_401_statt_Umleitung()
    {
        var antwort = await _client.GetAsync("/api/v1/konten/ich");

        Assert.Equal(HttpStatusCode.Unauthorized, antwort.StatusCode);
    }

    [Fact]
    public async Task Beim_Start_werden_beide_Rollen_angelegt()
    {
        using var scope = api.Services.CreateScope();
        var rollen = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        foreach (var rolle in Rollen.Alle)
            Assert.True(await rollen.RoleExistsAsync(rolle), $"Rolle {rolle} fehlt");
    }

    [Fact]
    public async Task OpenApi_Beschreibung_ist_abrufbar()
    {
        var antwort = await _client.GetAsync("/openapi/v1.json");

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("/api/v1/status", await antwort.Content.ReadAsStringAsync());
    }
}
