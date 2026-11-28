<p align="center">
  <img src="Projektmanagment/ARA_Flach_4_Querformat.png" alt="ARA – Raumbuchung Ordination Kliebergasse" width="520">
</p>

# ARA – Raumbuchungsplattform Ordination Kliebergasse

Diplomarbeit 5AAIF · HTL Spengergasse · Schuljahr 2026/27

ARA ist eine webbasierte Plattform, über die Universitätsstudierende einen freien Raum der **Ordination Kliebergasse** für ihre Pflichtstunden buchen und online bezahlen können. Das Ordinationspersonal verwaltet Verfügbarkeiten, Preise und Buchungen in einer eigenen Admin-Oberfläche.

Bisher laufen Terminvergabe, Koordination und Abrechnung manuell (Telefon, E-Mail). ARA bildet den gesamten Ablauf digital ab und verhindert Doppelvergaben.

## Aktueller Stand

- **Lastenheft:** Version 0.4 am 24.11.2026 von der Auftraggeberin freigegeben (siehe `Projektmanagment/Freigabe_Lastenheft_ARA_v0.4.pdf`)
- **Aktuelle Fassung:** Lastenheft 1.0 mit der vereinbarten Änderung: Statt der Checkbox „Ich bin Student/in“ laden Studierende ihren Studierendenausweis hoch. Schriftliche Bestätigung der Änderung durch die Auftraggeberin ausstehend.
- **Nächster Schritt:** offene Punkte mit der Ordination klären, danach Pflichtenheft
- **Code:** Backend-Grundgerüst in [`backend/`](backend/) (ASP.NET Core, SQLite, Tests), Startanleitung in [`backend/README.md`](backend/README.md)

Was zuletzt gemacht wurde, steht im [Projektjournal](Projektmanagment/Journal.md).

## Funktionen

**Für Studierende**
- Registrierung mit E-Mail-Bestätigung, Anmeldung und Passwort-Reset
- Kalender mit freien Zeitfenstern in Echtzeit (Tages- und Wochenansicht)
- Buchung mit vorläufiger Reservierung bis zum Abschluss der Zahlung
- Upload des Studierendenausweises (Foto oder PDF), verschlüsselt gespeichert und vom Personal geprüft
- Online-Bezahlung über einen externen Zahlungsanbieter
- Stornierung mit Rückerstattung gemäß Stornobedingungen
- Automatische E-Mails bei Buchung, Stornierung und Rückerstattung

**Für das Ordinationspersonal**
- Öffnungszeiten, Länge der Zeitfenster und Sperrzeiten festlegen
- Preise pro Zeitfenster verwalten
- Alle Buchungen mit Zahlungsstatus einsehen, filtern und stornieren
- Auswertung von Auslastung und Zahlungseingängen, Export als CSV und PDF

**Wichtigste Anforderungen**
- Keine Doppelbuchungen, auch bei gleichzeitigen Anfragen
- Datenschutz nach DSGVO: Studierendenausweis verschlüsselt gespeichert und nur für das Personal einsehbar, sonst nur Name, E-Mail und die nötigen Buchungsdaten
- Schutz gegen gängige Web-Angriffe (OWASP Top 10), geprüft per Penetrationstest
- Bedienbar am PC und am Smartphone

## Systemarchitektur

| Komponente | Aufgabe |
|---|---|
| Buchungsportal | Web-Oberfläche für Studierende |
| Admin-Oberfläche | Web-Oberfläche für das Personal |
| Anwendungsserver | Anmeldung und Rollen, Reservierung, Doppelbuchungsschutz, Zahlungsabgleich, E-Mails, Berichte |
| Datenbank | Benutzer, Verfügbarkeiten, Preise, Buchungen, Zahlungen |
| Dokumentenspeicher | Verschlüsselte Ablage der Studierendenausweise |
| Zahlungsanbieter (extern) | Zahlungen und Rückerstattungen, Rückmeldung per Webhook |
| E-Mail-Dienst (extern) | Versand der Benachrichtigungen |

Die Oberflächen kommunizieren über HTTPS/REST (JSON) mit dem Anwendungsserver. Die konkrete Technologieauswahl wird im Pflichtenheft festgelegt.

## Team

| Name | Rolle | Schwerpunkt |
|---|---|---|
| Leth Alkhabour | Projektleiter | Backend-Architektur, Rollen und Berechtigungen |
| Julius Grotrian | Projektmitglied | Buchungslogik, Konfliktvermeidung, Datenmodell |
| Kamel Hanna | Projektmitglied | Websicherheit, Payment-Anbindung mit Webhook-Verifizierung |
| Omar Mohamad | Projektmitglied | Frontend-Frameworks, Kalender und Admin-Oberfläche |

**Auftraggeberin:** Ordination Kliebergasse, Fr. Dr. Alexandra Greslechner
**Betreuung:** Georg Graf (HTL Spengergasse)

## Meilensteine

| Meilenstein | Termin | Status |
|---|---|---|
| Kickoff, Projektauftrag erteilt | 22.09.2026 | erledigt |
| Thema eingereicht und freigegeben | 25.09.2026 | erledigt |
| Lastenheft bestätigt | 24.11.2026 | erledigt (Version 0.4 freigegeben) |
| Pflichtenheft freigegeben | offen | ausstehend |
| Walking Skeleton / erster Prototyp | 15.02.2027 | geplant |
| MVP präsentieren | 15.05.2027 | geplant |
| Projekt fertiggestellt | 15.06.2027 | geplant |
| Projektabnahme | 25.06.2027 | geplant |
| Abgabe der Diplomarbeit | 02.07.2027 | geplant |

## Dokumente

Alle Projektdokumente liegen im Ordner [`Projektmanagment/`](Projektmanagment/):

| Datei | Inhalt |
|---|---|
| `Lastenheft_ARA_Version1.0_25.11.docx` / `.pdf` | Lastenheft, aktuelle Version 1.0 (Version 0.4 ist in der Git-Historie) |
| `Freigabe_Lastenheft_ARA_v0.4.pdf` | Freigabe des Lastenhefts durch die Auftraggeberin (unterschrieben, 24.11.2026) |
| `Erklärung.docx` / `.pdf` | Erklärung zur Diplomarbeit mit den individuellen Aufgabenstellungen (unterschrieben) |
| `Projekthandbuch_ARA.md` / `.pdf` | Projekthandbuch: Organisation, Projektstrukturplan, Meilensteine, Risiken, Kommunikation, Arbeitsweise |
| `Journal.md` | Projektjournal: wer hat wann was gemacht |
| `ARA_Flach_4_Querformat.png` / `.svg` | Projektlogo |

## Arbeitsweise im Repository

- **`main` ist geschützt:** Änderungen kommen nur über einen Pull Request hinein.
- **Freigabe durch Leth:** Jeder Pull Request braucht die Freigabe (Approve) von Leth, erst dann kann er gemergt werden (`.github/CODEOWNERS`).
- **Nur Feature-Branches:** Branch-Namen müssen mit `feature/` beginnen, z. B. `feature/24-datenbankschema`.
- **Aufgaben als Issues:** Jede Aufgabe ist ein GitHub-Issue mit verantwortlicher Person und Meilenstein. Den Stand zeigt das Kanban-Board (Offen → In Arbeit → Review → Erledigt). Höchstens 2 eigene Issues gleichzeitig in Arbeit.
- **Branch mit Issue-Nummer:** z. B. `feature/14-registrierung` für Issue #14. Im Pull Request `Closes #14` schreiben, dann schließt sich das Issue beim Mergen automatisch.
- **Journal pflegen:** Wer etwas erledigt, trägt es in [`Journal.md`](Projektmanagment/Journal.md) ein, am besten im selben Pull Request.

```bash
git switch main
git pull
git switch -c feature/24-datenbankschema
# ... arbeiten ...
git add .
git commit -m "Datenbankschema: erste Version"
git push -u origin feature/24-datenbankschema
```

Danach auf GitHub **Compare & pull request** klicken. Sobald Leth den Pull Request freigegeben hat, kann er gemergt werden.

> Achtung: `git clean -f` löscht nicht eingecheckte Dateien endgültig. Vorher immer mit `git clean -n` prüfen, was gelöscht würde.

## Nicht Teil des Projekts

Produktiver Betrieb und Hosting, Wartung nach der Übergabe, eigene Zahlungsabwicklung, native Apps, Übernahme von Altdaten, KI-Funktionen sowie die Speicherung weiterer Ausweisdokumente (z. B. Personalausweis oder Reisepass). Entwicklung und Präsentation erfolgen in einer Testumgebung, Zahlungen nur im Testmodus des Zahlungsanbieters.
