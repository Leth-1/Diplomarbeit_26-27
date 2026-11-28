# ARA Backend

ASP.NET Core (.NET 10) mit SQLite. Aufbau nach Clean Architecture light:

| Projekt | Inhalt |
|---|---|
| `src/Ara.Api` | Controller, Anmeldung (Identity mit Cookie), Swagger, Fehlerbehandlung |
| `src/Ara.Core` | Entitäten und Geschäftsregeln, kennt keine Datenbank |
| `src/Ara.Infrastructure` | `AraDbContext`, Migrationen, später Zahlung, E-Mail, Dateiablage |
| `tests/Ara.Core.Tests` | Unit-Tests ohne Datenbank |
| `tests/Ara.Api.Tests` | Integrationstests mit SQLite im Arbeitsspeicher |

## Voraussetzungen

- .NET SDK 10 (`dotnet --list-sdks` zeigt `10.0.x`)
- Rider oder Visual Studio: `backend/Ara.sln` öffnen

## Starten

```bash
cd backend
dotnet tool restore      # einmalig: holt dotnet-ef
dotnet run --project src/Ara.Api
```

Dann im Browser: https://localhost:7075/swagger

Beim Start legt die API die Datenbank `src/Ara.Api/ara.db` an, spielt die Migrationen ein und erstellt die Rollen `Studierende` und `Personal`. Die Datei ist in `.gitignore` und kommt nicht ins Repo.

## Tests

```bash
cd backend
dotnet test
```

- Tests gegen die Datenbank: von `DatenbankTest` erben (frische In-Memory-Datenbank pro Test).
- Tests über HTTP: `IClassFixture<AraApiFactory>` verwenden, siehe `GrundgeruestTests.cs`.

## Datenbank ändern (Migration)

Neue Entität in `Ara.Core` anlegen, als `DbSet` in `AraDbContext` eintragen, Konfiguration als `IEntityTypeConfiguration` in `Ara.Infrastructure/Persistenz`. Danach:

```bash
cd backend
dotnet ef migrations add <Name> -p src/Ara.Infrastructure -s src/Ara.Api -o Persistenz/Migrationen
```

Nur eine Person erstellt gleichzeitig Migrationen (Absprache mit Julius), sonst gibt es Konflikte.

## Regeln

- `Ara.Core` darf nichts von EF Core, SQLite oder `Ara.Infrastructure` verwenden (prüft `ArchitekturTests`).
- Endpunkte liegen unter `/api/v1/...`, Fehler kommen als Problem Details.
- Beträge in Cent, Zeiten in UTC.
- Geheimnisse (API-Schlüssel) nie ins Repo, sondern mit `dotnet user-secrets` im Projekt `Ara.Api`.
- Jeder Pull Request mit Code bringt Tests mit, `dotnet test` muss grün sein.

## Dokumentation

- [`docs/UML_Backend_Grundgeruest.pdf`](docs/UML_Backend_Grundgeruest.pdf): UML-Klassendiagramme mit Erklärung aller Klassen und Methoden (die `.html`-Version braucht Internet für die Diagramme)
- Architektur-Dokument: Arbeitspaket 2.1
