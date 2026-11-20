# Technikvergleich Backend – ARA

Autor: Leth Alkhabour · Stand: 20.11.2026 · Status: Entwurf zur Abstimmung im Team

## Ziel

Für das Backend der Raumbuchungsplattform ARA wird eine Technologie gewählt, mit der sich die Anforderungen aus dem Lastenheft (Version 0.4) sicher und im Zeitplan umsetzen lassen. Das Ergebnis fließt ins Pflichtenheft ein.

Verglichen werden drei verbreitete Plattformen für Web-Backends:

- **ASP.NET Core** (Sprache C#, Plattform .NET 10 LTS)
- **Spring Boot** (Sprache Java, aktuelle LTS-Version von Java)
- **Node.js mit NestJS** (Sprache TypeScript, aktuelle LTS-Version von Node.js)

## Anforderungen an das Backend

Aus dem Lastenheft ergeben sich für das Backend vor allem diese Anforderungen:

- **Rollen und Anmeldung** für Studierende und Ordinationspersonal (F01, F02)
- **Kein Zeitfenster doppelt vergeben**, auch bei gleichzeitigen Anfragen (F05, NF03)
- **Vorläufige Reservierung**, die nach Ablauf der Frist automatisch verfällt (F04)
- **Verfügbarkeit in Echtzeit:** Änderungen erscheinen ohne Neuladen der Seite (F03)
- **Online-Bezahlung** über einen externen Anbieter mit signierter Rückmeldung per Webhook (F06, F07)
- **Sicherheit** nach OWASP Top 10, geprüft per Penetrationstest (NF05)
- **Leistung:** 95 % der Anfragen unter 2 Sekunden bei 50 gleichzeitigen Nutzern (NF04)
- **Übergabe:** Eine fachkundige dritte Person muss das System nach Anleitung installieren können (NF08)

## Bewertungskriterien

| Kriterium | Gewicht | Was bewertet wird |
|---|---|---|
| Vorkenntnisse im Team | 25 % | Wie gut das Team die Sprache und das Framework schon beherrscht |
| Eignung für die Anforderungen | 25 % | Wie gut Transaktionen, Echtzeit, Hintergrundaufgaben und Payment unterstützt werden |
| Sicherheit | 15 % | Eingebaute Schutzmechanismen, Anmeldung und Rollen |
| Produktivität und Werkzeuge | 15 % | IDE-Unterstützung, Fehlersuche, Dokumentation, Codegenerierung |
| Leistung und Skalierbarkeit | 10 % | Antwortzeiten und Betrieb mit mehreren Server-Instanzen |
| Langzeit-Support und Wartbarkeit | 10 % | Unterstützungszeitraum, Stabilität des Ökosystems |

Punkte von 1 (schlecht) bis 5 (sehr gut). Die Bewertung ist eine Einschätzung und wird im Team besprochen.

## Vergleich im Detail

### ASP.NET Core (C#)

- **Vorkenntnisse:** C# und .NET sind an der HTL Spengergasse Teil des Unterrichts. Die Entwicklungsumgebung (JetBrains Rider) ist bereits eingerichtet.
- **Transaktionen und Doppelbuchungen:** Entity Framework Core unterstützt Transaktionen und Concurrency-Tokens. Zusätzlich kann die Datenbank Überschneidungen selbst verhindern.
- **Echtzeit:** SignalR ist Teil des Frameworks und schickt Änderungen per WebSocket an alle offenen Kalender.
- **Hintergrundaufgaben:** Abgelaufene Reservierungen lassen sich mit eingebauten Hintergrunddiensten (`BackgroundService`) freigeben.
- **Sicherheit:** ASP.NET Core Identity liefert Anmeldung, Rollen, Passwort-Hashing und Kontosperre. Schutz gegen CSRF ist eingebaut.
- **Payment:** Große Zahlungsanbieter wie Stripe bieten offizielle .NET-Bibliotheken inklusive Webhook-Signaturprüfung.
- **Dokumentation der Schnittstelle:** OpenAPI wird automatisch erzeugt, der Frontend-Entwickler kann die API im Browser testen.
- **Leistung:** ASP.NET Core gehört zu den schnellsten verbreiteten Web-Frameworks.
- **Langzeit-Support:** .NET 10 ist eine LTS-Version mit drei Jahren Unterstützung, also deutlich über das Projektende hinaus.

### Spring Boot (Java)

- **Vorkenntnisse:** Java ist aus früheren Jahrgängen bekannt, Spring Boot selbst aber weniger.
- **Transaktionen:** Spring Data JPA mit `@Transactional` und optimistischem Sperren ist ausgereift.
- **Echtzeit:** WebSockets mit STOMP sind vorhanden, aber aufwendiger einzurichten als SignalR.
- **Sicherheit:** Spring Security ist sehr mächtig, aber bekannt für eine steile Lernkurve und viel Konfiguration.
- **Payment:** Offizielle Java-Bibliotheken der Zahlungsanbieter sind vorhanden.
- **Langzeit-Support:** Java-LTS-Versionen und Spring Boot werden lange unterstützt.

### Node.js mit NestJS (TypeScript)

- **Vorkenntnisse:** JavaScript ist aus der Webentwicklung bekannt. NestJS und TypeScript im Backend sind dem Team weniger vertraut.
- **Transaktionen:** Mit Prisma oder TypeORM möglich. Für feinere Sperren muss teilweise direkt SQL geschrieben werden.
- **Echtzeit:** Socket.IO ist sehr verbreitet und einfach.
- **Sicherheit:** Vieles muss aus Zusatzpaketen zusammengestellt werden. Das erhöht den Prüfaufwand beim Penetrationstest.
- **Payment:** Offizielle Node.js-Bibliotheken der Zahlungsanbieter sind vorhanden.
- **Vorteil:** Frontend und Backend könnten dieselbe Sprache (TypeScript) verwenden.
- **Langzeit-Support:** Viele Abhängigkeiten von Drittanbietern, die regelmäßig aktualisiert werden müssen.

## Bewertung

| Kriterium | Gewicht | ASP.NET Core | Spring Boot | Node.js/NestJS |
|---|---|---|---|---|
| Vorkenntnisse im Team | 25 % | 5 | 3 | 3 |
| Eignung für die Anforderungen | 25 % | 5 | 5 | 4 |
| Sicherheit | 15 % | 5 | 4 | 3 |
| Produktivität und Werkzeuge | 15 % | 4 | 3 | 4 |
| Leistung und Skalierbarkeit | 10 % | 5 | 4 | 4 |
| Langzeit-Support und Wartbarkeit | 10 % | 5 | 5 | 3 |
| **Gewichtete Summe** | **100 %** | **4,85** | **3,95** | **3,50** |

## Entscheidung (Vorschlag)

**Empfohlen wird ASP.NET Core mit C# auf .NET 10 LTS.**

- Das Team kann sofort produktiv arbeiten, weil C# und .NET aus dem Unterricht bekannt sind.
- Alle Kernanforderungen sind mit eingebauten Mitteln abgedeckt: Identity für Anmeldung und Rollen, SignalR für Echtzeit, Hintergrunddienste für ablaufende Reservierungen.
- Die eingebauten Sicherheitsfunktionen verringern das Risiko beim Penetrationstest.
- Der Langzeit-Support reicht deutlich über die Projektabnahme hinaus, das erleichtert die Übergabe an die Ordination.

Spring Boot wäre fachlich ebenso geeignet, braucht aber mehr Einarbeitung. Node.js/NestJS wäre interessant, wenn das Frontend in TypeScript entwickelt wird, bringt aber mehr Aufwand bei Sicherheit und Wartung.

## Schnittstelle zum Frontend

- **REST mit JSON** für alle Daten und Aktionen, mit Versionsnummer in der URL (z. B. `/api/v1/buchungen`)
- **OpenAPI-Dokumentation** als verbindliche Absprache mit dem Frontend
- **SignalR** nur für die Echtzeit-Aktualisierung des Kalenders
- **Anmeldung per HttpOnly-Cookie** über ASP.NET Core Identity statt Tokens im Browser-Speicher
- **Einheitliche Fehlermeldungen** im Format „Problem Details“ (RFC 9457)

## Skalierbarkeit

Die Aufgabenstellung verlangt eine skalierbare Architektur. Dafür sind folgende Grundsätze vorgesehen:

- **Zustandslose API:** Jede Server-Instanz kann jede Anfrage beantworten, mehrere Instanzen sind möglich.
- **Doppelbuchungsschutz in der Datenbank**, nicht im Arbeitsspeicher. Er funktioniert dadurch auch mit mehreren Instanzen.
- **SignalR mit mehreren Instanzen** braucht einen gemeinsamen Nachrichtenkanal (z. B. Redis). Für den Prototyp reicht eine Instanz.
- **Betrieb in Containern (Docker)**, damit die Installation bei einem Hosting-Anbieter einfach nachvollziehbar ist (NF08).

## Offene Punkte im Team

- **Vorkenntnisse bestätigen:** Haben alle vier genug Erfahrung mit C# und ASP.NET Core?
- **Datenbank (Julius):** PostgreSQL oder SQL Server? Beide funktionieren mit Entity Framework Core. PostgreSQL kann Zeitüberschneidungen direkt mit einer Exclusion Constraint verhindern.
- **Frontend (Omar):** Welches Framework? Die REST-Schnittstelle funktioniert mit jedem.
- **Payment (Kamel):** Welcher Anbieter? Davon hängt die Webhook-Schnittstelle ab.

## Quellen

- ASP.NET Core Dokumentation: https://learn.microsoft.com/aspnet/core
- .NET Support-Richtlinie: https://dotnet.microsoft.com/platform/support/policy
- Spring Boot: https://spring.io/projects/spring-boot
- NestJS: https://docs.nestjs.com
- OWASP Top 10: https://owasp.org/www-project-top-ten/
- RFC 9457 Problem Details: https://www.rfc-editor.org/rfc/rfc9457
