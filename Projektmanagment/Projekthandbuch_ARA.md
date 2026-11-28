# Projekthandbuch – ARA

Raumbuchungsplattform Ordination Kliebergasse · Diplomarbeit 5AAIF, HTL Spengergasse · Version 1.0 · Stand: 28.11.2026 · Verantwortlich: Leth Alkhabour

## 1 Projektüberblick

ARA ist eine webbasierte Plattform, über die Universitätsstudierende einen freien Raum der Ordination Kliebergasse für ihre Pflichtstunden buchen und online bezahlen. Das Ordinationspersonal verwaltet Verfügbarkeiten, Preise und Buchungen in einer eigenen Admin-Oberfläche. Die Anforderungen stehen im Lastenheft (Version 1.0), die technische Umsetzung im Pflichtenheft.

| Angabe | |
|---|---|
| Auftraggeberin | Ordination Kliebergasse, Fr. Dr. Alexandra Greslechner |
| Betreuer | Georg Graf, HTL Spengergasse |
| Projektzeitraum | 22.09.2026 (Kickoff) bis 02.07.2027 (Abgabe) |
| Geschätzter Aufwand | 846 Stunden (siehe Kapitel 3) |
| Repository | github.com/Leth-1/Diplomarbeit_26-27 |

**Projektziele**

- Studierende können sich registrieren, freie Zeitfenster in Echtzeit sehen, buchen, online bezahlen und stornieren.
- Das Personal kann Verfügbarkeiten, Preise, Buchungen und Studierendenausweise verwalten und Auswertungen exportieren.
- Keine Doppelbuchungen, Datenschutz nach DSGVO, Schutz gegen die OWASP Top 10, bedienbar am PC und am Smartphone.

**Nicht Teil des Projekts:** produktiver Betrieb und Hosting, Wartung nach der Übergabe, eigene Zahlungsabwicklung, native Apps, Übernahme von Altdaten, KI-Funktionen, Speicherung weiterer Ausweisdokumente. Zahlungen laufen nur im Testmodus des Zahlungsanbieters.

## 2 Projektorganisation

| Name | Rolle | Verantwortung |
|---|---|---|
| Leth Alkhabour | Projektleiter, Backend-Architekt | Planung und Steuerung, Kontakt zu Auftraggeberin und Betreuer, Backend-Architektur, Konten und Rollen, E-Mails, Echtzeit, Freigabe aller Pull Requests |
| Julius Grotrian | Projektmitglied | Datenbank, Datenmodell, Verfügbarkeiten, Buchungslogik und Doppelbuchungsschutz, Auswertung |
| Kamel Hanna | Projektmitglied | Websicherheit, Zahlungsanbieter mit Webhook, Studierendenausweis, Recht und Datenschutz (EU/DSGVO) |
| Omar Mohamad | Projektmitglied | Frontend (React mit TypeScript), Buchungsportal, Admin-Oberfläche, Usability |
| Fr. Dr. Greslechner | Auftraggeberin | Anforderungen, Freigabe von Lastenheft und Änderungen, Abnahme |
| Georg Graf | Betreuer | Betreuung und Beurteilung, Freigabe des Pflichtenhefts |

**Wer entscheidet was**

| Entscheidung | Wer |
|---|---|
| Änderungen am Funktionsumfang | Auftraggeberin, schriftlich per E-Mail |
| Technische Architektur und Regeln im Code | Leth, nach Abstimmung im Team |
| Technik im eigenen Bereich (z. B. Zahlungsanbieter, Datenbank, Frontend-Framework) | die verantwortliche Person, mit Begründung im Pflichtenheft |
| Aufnahme von Code in `main` | Leth (Freigabe des Pull Requests) |
| Verschieben von Aufgaben zwischen Meilensteinen | Leth, mit Info an das Team |
| Rechtliche Fragen (DSGVO, Aufbewahrung, AGB) | Kamel |

## 3 Projektstrukturplan

Stunden sind Schätzungen. Jedes Arbeitspaket ist als GitHub-Issue angelegt (große Pakete in mehrere Issues aufgeteilt), mit verantwortlicher Person und Meilenstein.

### 1 Projektmanagement

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 1.1 | Projektstart | Team | Kickoff, Thema eingereicht, Erklärung unterschrieben | Sep 2026 | erledigt | 16 (Leth 4, Julius 4, Kamel 4, Omar 4) |
| 1.2 | Lastenheft | Leth | Lastenheft 1.0, von der Auftraggeberin freigegeben | Okt–Nov 2026 | erledigt | 29 (Leth 20, Julius 3, Kamel 3, Omar 3) |
| 1.3 | Projekthandbuch und Projektplan | Leth | Projektstrukturplan, Meilensteinplan, Risikoliste, Kommunikationsregeln | Dez 2026 | offen | 12 |
| 1.4 | Pflichtenheft | Leth | Pflichtenheft (Teile aller vier zusammengeführt), freigegeben | Dez 2026 | offen | 36 (Leth 12, Julius 8, Kamel 8, Omar 8) |
| 1.5 | Laufende Projektsteuerung | Leth | Teamtreffen, Journal, Stundeneintragung, Termine mit Betreuung und Auftraggeberin | laufend | laufend | 43 (Leth 25, Julius 6, Kamel 6, Omar 6) |
| 1.6 | Präsentationen | Team | MVP-Präsentation (15.05.2027) und Abnahme (25.06.2027) | Mai–Jun 2027 | offen | 32 (Leth 8, Julius 8, Kamel 8, Omar 8) |
| 1.7 | Projektabschluss | Leth | Abschlussbericht, Übergabe an die Auftraggeberin | Jun 2027 | offen | 6 |

### 2 Backend

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 2.1 | Technikvergleich und Architekturkonzept | Leth | Entscheidung ASP.NET Core, Architektur (Clean Architecture light) | Nov–Dez 2026 | erledigt | 10 |
| 2.2 | Backend-Grundgerüst | Leth | Projektstruktur, Swagger, Datenbankanbindung, Fehlerbehandlung, Testprojekte | Dez 2026–Jan 2027 | erledigt | 20 |
| 2.3 | Registrierung, Anmeldung, Rollen (F01, F02) | Leth | Konten mit E-Mail-Bestätigung, Rollen Studierende und Personal | Jan–Feb 2027 | offen | 25 |
| 2.4 | REST-Schnittstelle und Dokumentation | Leth | Endpunkte nach Pflichtenheft, OpenAPI-Dokumentation für das Frontend | laufend | offen | 15 |
| 2.5 | Echtzeit-Aktualisierung (F03) | Leth | SignalR-Hub, Kalender aktualisiert sich ohne Neuladen | Feb–Mär 2027 | offen | 12 |
| 2.6 | E-Mail-Benachrichtigungen (F09) | Leth | E-Mails bei Registrierung, Buchung, Stornierung, Erstattung | Mär 2027 | offen | 10 |
| 2.7 | Installations- und Betriebsanleitung (NF08) | Leth | Anleitung, mit der Dritte das System installieren können | Jun 2027 | offen | 8 |

### 3 Datenbank und Buchungslogik

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 3.1 | Datenbankvergleich | Julius | Entscheidung SQLite mit Begründung und Wechselmöglichkeit | Dez 2026 | in Arbeit | 8 |
| 3.2 | Datenmodell | Julius | ER-Diagramm, Tabellen, Migrationen | Dez 2026–Jan 2027 | offen | 15 |
| 3.3 | Verfügbarkeiten und Zeitfenster (F10, F11) | Julius | Berechnung freier Zeitfenster aus Öffnungs- und Sperrzeiten, Preise | Jan–Feb 2027 | offen | 20 |
| 3.4 | Reservierung und Doppelbuchungsschutz (F04, F05) | Julius | Vorläufige Reservierung, Ablauf, eindeutiger Index gegen Doppelbuchungen | Feb–Mär 2027 | offen | 30 |
| 3.5 | Auswertung und Export (F13) | Julius | Auslastung und Zahlungseingänge, Export als CSV und PDF | Apr 2027 | offen | 20 |
| 3.6 | Stundenbestätigung (F14, Kann) | Julius | PDF-Bestätigung über absolvierte Stunden | Mai 2027 | optional | 8 |

### 4 Sicherheit, Payment und Recht

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 4.1 | Vergleich Zahlungsanbieter | Kamel | Entscheidung (z. B. Stripe), Testaccount, Zahlungsarten geklärt | Dez 2026 | in Arbeit | 8 |
| 4.2 | Online-Bezahlung mit Webhook (F06) | Kamel | Checkout, Webhook mit Signaturprüfung, Buchung wird „bezahlt“ | Feb–Mär 2027 | offen | 30 |
| 4.3 | Stornierung und Erstattung (F07) | Kamel | Stornofristen, Rückerstattung über den Anbieter | Mär–Apr 2027 | offen | 15 |
| 4.4 | Upload und Verschlüsselung Studierendenausweis (F08) | Kamel | Upload, verschlüsselte Ablage, Zugriff nur für Personal, Löschung | Jan–Feb 2027 | offen | 25 |
| 4.5 | Sicherheitskonzept | Kamel | Maßnahmen gegen OWASP Top 10 | Dez 2026–Jan 2027 | offen | 12 |
| 4.6 | Penetrationstest (A07) | Kamel | Pentest-Bericht ohne Befunde mit hohem Risiko | Mai 2027 | offen | 15 |
| 4.7 | Recht und Datenschutz (EU/DSGVO) | Kamel | Datenschutzkonzept (Rechtsgrundlage, Löschfristen, Zugriff auf Ausweise), Entwurf Verzeichnis der Verarbeitungstätigkeiten, Prüfung ob eine Datenschutz-Folgenabschätzung nötig ist, Vorlagen für Datenschutzerklärung, Impressum, AGB und Stornobedingungen, Prüfung Online-Verkauf (FAGG) und Barrierefreiheit (BaFG), Datenschutz-Checkliste (A08) | Dez 2026–Mär 2027 | offen | 25 |

### 5 Frontend

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 5.1 | Frameworkvergleich | Omar | Entscheidung React mit TypeScript, Begründung | Dez 2026 | in Arbeit | 8 |
| 5.2 | UX-Konzept und Mockups | Omar | Entwürfe aller Seiten für Studierende und Personal | Dez 2026–Jan 2027 | offen | 15 |
| 5.3 | Buchungsportal (F03, F08 Oberfläche) | Omar | Kalender, Buchung, Ausweis-Upload, Bezahlen, eigene Buchungen | Feb–Apr 2027 | offen | 40 |
| 5.4 | Admin-Oberfläche (F10–F12) | Omar | Verfügbarkeiten, Preise, Buchungen, Prüfung der Ausweise | Mär–Apr 2027 | offen | 30 |
| 5.5 | Responsive Design und Barrierefreiheit (NF01, NF02) | Omar | Bedienbar ab 360 px, WCAG 2.1 AA | Apr–Mai 2027 | offen | 10 |
| 5.6 | Benutzerhandbuch | Omar | Kurzanleitung für Studierende und Personal | Jun 2027 | offen | 6 |
| 5.7 | SEO der Startseite (F15, Kann) | Omar | Technische Suchmaschinenoptimierung | Mai 2027 | optional | 4 |

### 6 Test und Qualität

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 6.1 | Teststrategie | Leth | Welche Tests es gibt, wer sie macht, wie protokolliert wird | Jan 2027 | offen | 4 |
| 6.2 | Automatisierte Tests | Team | Unit- und Integrationstests je Bereich, A03 (Doppelbuchung) und A06 (Berechtigungen) | laufend | offen | 34 (Leth 10, Julius 10, Kamel 8, Omar 6) |
| 6.3 | Lasttest (NF04) | Julius | Protokoll: 95 % unter 2 Sekunden bei 50 Nutzern | Mai 2027 | offen | 6 |
| 6.4 | Usability-Test (NF01) | Omar | Test mit mind. 3 Personen, Protokoll | Mai 2027 | offen | 6 |
| 6.5 | Browsertest (NF07) | Omar | Protokoll für Chrome, Firefox, Safari, Edge | Mai 2027 | offen | 4 |

### 7 Diplomarbeit (schriftlich)

| Nr. | Arbeitspaket | Verantwortlich | Ergebnis | Zeitraum | Status | Std. |
|---|---|---|---|---|---|---|
| 7.1 | Eigener Teil der Diplomarbeit | jede/r | Schriftlicher Teil zur eigenen Aufgabenstellung | Feb–Jun 2027 | offen | 160 (Leth 40, Julius 40, Kamel 40, Omar 40) |
| 7.2 | Zusammenführen und Abgabe | Leth | Gemeinsames Dokument, digital und zweifach gedruckt, Abgabe 02.07.2027 | Jun–Jul 2027 | offen | 14 (Leth 8, Julius 2, Kamel 2, Omar 2) |

### Stunden pro Person

| Person | Schwerpunkt | Stunden (geschätzt) |
|---|---|---|
| Leth | Projektleitung, Backend | 249 |
| Julius | Datenbank, Buchungslogik | 188 |
| Kamel | Sicherheit, Payment, Recht und Datenschutz | 209 |
| Omar | Frontend | 200 |
| **Gesamt** | | **846** |

## 4 Meilensteinplan

| Meilenstein | Termin | Was fertig sein muss | Status |
|---|---|---|---|
| Kickoff, Projektauftrag | 22.09.2026 | Projektauftrag erteilt | erledigt |
| Thema eingereicht und freigegeben | 25.09.2026 | Freigaben von Betreuer, Abteilungsvorstand, Direktion | erledigt |
| Lastenheft freigegeben | 24.11.2026 | Lastenheft von der Auftraggeberin unterschrieben | erledigt |
| M1 Pflichtenheft | 18.12.2026 | Vergleiche (Datenbank, Zahlung, Frontend), Sicherheits- und Datenschutzkonzept, Mockups, Architektur, Pflichtenheft freigegeben | offen |
| M2 Walking Skeleton | 15.02.2027 | Registrieren, Anmelden, freie Zeitfenster sehen, Ausweis hochladen, reservieren; CI läuft | offen |
| M3 MVP | 15.05.2027 | Alle Muss-Funktionen inkl. Bezahlung, Stornierung, Admin-Oberfläche, Auswertung; MVP-Präsentation | offen |
| M4 Fertig | 15.06.2027 | Lasttest, Usability- und Browsertest, Pentest, Installationsanleitung, Benutzerhandbuch | offen |
| Projektabnahme | 25.06.2027 | Abnahme durch die Auftraggeberin | offen |
| M5 Abgabe | 02.07.2027 | Schriftliche Diplomarbeit digital und zweifach gedruckt abgegeben | offen |

Der Stand jedes Meilensteins ist auf GitHub unter **Issues → Milestones** sichtbar (Fortschritt in Prozent).

## 5 Risikoliste

Wahrscheinlichkeit und Auswirkung: niedrig, mittel, hoch. Die Liste wird bei jedem Meilenstein überprüft.

| Nr. | Risiko | Wahrsch. | Auswirkung | Gegenmaßnahme | Verantwortlich |
|---|---|---|---|---|---|
| R1 | Walking Skeleton wird nicht bis 15.02.2027 fertig | mittel | hoch | Kleine Issues, Board wöchentlich prüfen, bei Verzug Kann-Funktionen (F14, F15) streichen | Leth |
| R2 | Ein Teammitglied fällt aus (Krankheit, Lernphase vor der Matura, Motivation) | mittel | hoch | Code-Reviews, damit immer zwei Personen einen Teil kennen; Dokumentation aktuell halten; Puffer im Plan | alle |
| R3 | Doppelbuchungen bei gleichzeitigen Anfragen | mittel | hoch | Eindeutiger Index in der Datenbank, automatisierter Test (A03) | Julius |
| R4 | Zahlungsanbieter passt nicht (Checkout-Dauer gegenüber Reservierungsfrist, Gebühren, Testmodus) | mittel | mittel | Früh vergleichen und testen (AP 4.1); Schnittstelle `IZahlungsanbieter`, damit der Anbieter tauschbar ist | Kamel |
| R5 | Speicherung des Studierendenausweises ist datenschutzrechtlich problematisch | mittel | hoch | Datenschutzkonzept, Verschlüsselung, Zugriff nur für das Personal, Löschfristen; als Notlösung Rückkehr zur Checkbox | Kamel |
| R6 | Auftraggeberin ändert Anforderungen | hoch | mittel | Jede Änderung schriftlich bestätigen lassen und im Lastenheft festhalten; Auswirkung auf den Plan prüfen | Leth |
| R7 | Frontend wartet auf das Backend | hoch | mittel | Schnittstelle früh über OpenAPI festlegen; Frontend arbeitet bis dahin mit Testdaten | Leth, Omar |
| R8 | Merge-Konflikte, vor allem bei Datenbank-Migrationen | mittel | niedrig | Kleine Pull Requests; nur eine Person erstellt gleichzeitig Migrationen | Julius |
| R9 | Sicherheitslücke beim Penetrationstest | mittel | hoch | Sicherheitskonzept nach OWASP von Anfang an, Code-Reviews, Pentest mit Zeit für Korrekturen einplanen | Kamel |
| R10 | Code wird nicht von allen verstanden (fremder Code, KI-Unterstützung) | mittel | hoch | Jede Person erklärt ihren Pull Request; UML und README aktuell halten; jede Person muss ihren Teil bei der Abnahme erklären können | alle |
| R11 | SQLite reicht für die Last nicht aus | niedrig | mittel | Zugriff nur über EF Core, dadurch auf eine andere Datenbank wechselbar; Lasttest (AP 6.3) | Julius |

## 6 Kommunikation

| Mit wem | Kanal | Regel |
|---|---|---|
| Team | WhatsApp-Gruppe | Für alles Schnelle. Antwort innerhalb von 2 Tagen; wer länger nicht erreichbar ist, sagt es vorher. |
| Team | Teamtreffen | Nach Bedarf, mindestens einmal vor jedem Meilenstein. |
| Betreuer (Herr Graf) | E-Mail oder Treffen | Leth meldet den Stand bei jedem Meilenstein, sonst bei Bedarf. |
| Auftraggeberin (Fr. Dr. Greslechner) | E-Mail, Termine vor Ort | Nur über Leth. Änderungen an den Anforderungen immer schriftlich per E-Mail. |
| Aufgaben und Fortschritt | GitHub-Issues und Board | Nicht im Chat. Was im Chat entschieden wird, kommt als Kommentar ins betroffene Issue. |
| Stunden | Stundeneintragung (Teams) | Leth trägt die Stunden ein; jede Person meldet ihm ihre tatsächlich geleisteten Stunden. |

## 7 Arbeitsweise und Werkzeuge

**Aufgaben**

- Jede Aufgabe ist ein GitHub-Issue mit verantwortlicher Person, Meilenstein und Labels. Neue Issues nur über die Vorlagen „Aufgabe“ oder „Fehler“.
- Das Kanban-Board hat die Spalten **Offen → In Arbeit → Review → Erledigt**.
- Jede Person hat höchstens **2 Issues gleichzeitig** in „In Arbeit“.

**Code**

- `main` ist geschützt. Gearbeitet wird nur auf Branches `feature/<Issue-Nr>-<kurzer-name>`, z. B. `feature/20-registrierung`.
- Jede Änderung kommt über einen Pull Request mit `Closes #<Issue-Nr>`. Leth gibt frei, danach wird gemergt; das Issue schließt sich automatisch.
- Jeder Pull Request mit Code bringt Tests mit, `dotnet test` muss grün sein.
- Regeln für das Backend (Architektur, Migrationen, Geheimnisse) stehen in `backend/README.md`.

**Werkzeuge**

| Zweck | Werkzeug |
|---|---|
| Versionsverwaltung, Aufgaben, Board | GitHub (Repository, Issues, Projects) |
| Backend | C#, ASP.NET Core (.NET 10), EF Core, SQLite, xUnit; IDE Rider |
| Frontend | React mit TypeScript |
| Schnittstellen-Doku | OpenAPI / Swagger |
| E-Mail in der Entwicklung | Mailpit |
| Dokumente | Word, Markdown, PDF |

**Nachweise**

- **Projektjournal** (`Projektmanagment/Journal.md`): wer wann was gemacht hat.
- **Stundeneintragung:** tatsächlich geleistete Stunden je Person, eingetragen von Leth.
- **GitHub:** Issues, Pull Requests und Commits zeigen, wer welchen Teil umgesetzt hat.

## 8 Dokumentenverzeichnis

| Dokument | Ort | Verantwortlich |
|---|---|---|
| Lastenheft 1.0 | `Projektmanagment/Lastenheft_ARA_Version1.0_25.11.docx` / `.pdf` | Leth |
| Freigabe Lastenheft (unterschrieben) | `Projektmanagment/Freigabe_Lastenheft_ARA_v0.4.pdf` | Leth |
| Erklärung zur Diplomarbeit | `Projektmanagment/Erklärung.docx` / `.pdf` | Leth |
| Projekthandbuch (dieses Dokument) | `Projektmanagment/Projekthandbuch_ARA.md` / `.pdf` | Leth |
| Projektjournal | `Projektmanagment/Journal.md` | alle |
| Pflichtenheft | folgt (M1) | Leth, Kapitel von allen |
| Backend-Anleitung und Regeln | `backend/README.md` | Leth |
| UML Backend | `backend/docs/UML_Backend_Grundgeruest.pdf` | Leth |
| Aufgaben und Meilensteine | GitHub Issues und Projects | alle |

## 9 Änderungen an diesem Handbuch

Änderungen schlägt jede Person über einen Pull Request vor; Leth gibt frei. Die Risikoliste und der Meilensteinstatus werden bei jedem Meilenstein aktualisiert.

| Version | Datum | Änderung | Wer |
|---|---|---|---|
| 1.0 | 28.11.2026 | Erste Fassung | Leth |
