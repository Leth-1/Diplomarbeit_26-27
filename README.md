<p align="center">
  <img src="Projektmanagment/ARA_Flach_4_Querformat.png" alt="ARA – Raumbuchung Ordination Kliebergasse" width="520">
</p>

# ARA – Raumbuchungsplattform Ordination Kliebergasse

Diplomarbeit 5AAIF · HTL Spengergasse · Schuljahr 2026/27

ARA ist eine webbasierte Plattform, über die Universitätsstudierende einen freien Raum der **Ordination Kliebergasse** für ihre Pflichtstunden buchen und online bezahlen können. Das Ordinationspersonal verwaltet Verfügbarkeiten, Preise und Buchungen in einer eigenen Admin-Oberfläche.

Bisher laufen Terminvergabe, Koordination und Abrechnung manuell (Telefon, E-Mail). ARA bildet den gesamten Ablauf digital ab und verhindert Doppelvergaben.

## Aktueller Stand

- **Lastenheft:** Version 0.4, wartet auf Freigabe durch die Auftraggeberin
- **Nächster Schritt:** offene Punkte mit der Ordination klären, danach Pflichtenheft
- **Code:** noch keiner, die Technologieauswahl folgt im Pflichtenheft

Was zuletzt gemacht wurde, steht im [Projektjournal](Projektmanagment/Journal.md).

## Funktionen

**Für Studierende**
- Registrierung mit E-Mail-Bestätigung, Anmeldung und Passwort-Reset
- Kalender mit freien Zeitfenstern in Echtzeit (Tages- und Wochenansicht)
- Buchung mit vorläufiger Reservierung bis zum Abschluss der Zahlung
- Bestätigung per Checkbox „Ich bin Student/in“ (kein Dokumenten-Upload)
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
- Datensparsamkeit nach DSGVO: nur Name, E-Mail und die nötigen Buchungsdaten, keine Ausweise, Studiennachweise oder Matrikelnummern
- Schutz gegen gängige Web-Angriffe (OWASP Top 10), geprüft per Penetrationstest
- Bedienbar am PC und am Smartphone

## Systemarchitektur

| Komponente | Aufgabe |
|---|---|
| Buchungsportal | Web-Oberfläche für Studierende |
| Admin-Oberfläche | Web-Oberfläche für das Personal |
| Anwendungsserver | Anmeldung und Rollen, Reservierung, Doppelbuchungsschutz, Zahlungsabgleich, E-Mails, Berichte |
| Datenbank | Benutzer, Verfügbarkeiten, Preise, Buchungen, Zahlungen |
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
| Lastenheft bestätigt | offen | Version 0.4, Freigabe ausstehend |
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
| `Lastenheft_ARA_Version0.4_10.11.docx` / `.pdf` | Lastenheft, aktuelle Version 0.4 |
| `Erklärung.docx` / `.pdf` | Erklärung zur Diplomarbeit mit den individuellen Aufgabenstellungen (unterschrieben) |
| `Technikvergleich_Backend.md` / `.pdf` | Vergleich ASP.NET Core, Spring Boot und Node.js mit Empfehlung (Entwurf) |
| `Journal.md` | Projektjournal: wer hat wann was gemacht |
| `ARA_Flach_4_Querformat.png` / `.svg` | Projektlogo |

## Arbeitsweise im Repository

- **`main` ist geschützt:** Änderungen kommen nur über einen Pull Request hinein.
- **Nur Feature-Branches:** Branch-Namen müssen mit `feature/` beginnen, z. B. `feature/05-datenbankschema`.
- **Journal pflegen:** Wer etwas erledigt, trägt es in [`Journal.md`](Projektmanagment/Journal.md) ein, am besten im selben Pull Request.

```bash
git switch main
git pull
git switch -c feature/05-datenbankschema
# ... arbeiten ...
git add .
git commit -m "Datenbankschema: erste Version"
git push -u origin feature/05-datenbankschema
```

Danach auf GitHub **Compare & pull request** klicken und den Pull Request mergen.

> Achtung: `git clean -f` löscht nicht eingecheckte Dateien endgültig. Vorher immer mit `git clean -n` prüfen, was gelöscht würde.

## Nicht Teil des Projekts

Produktiver Betrieb und Hosting, Wartung nach der Übergabe, eigene Zahlungsabwicklung, native Apps, Übernahme von Altdaten, KI-Funktionen sowie die Speicherung von Studiennachweisen oder Ausweisen. Entwicklung und Präsentation erfolgen in einer Testumgebung, Zahlungen nur im Testmodus des Zahlungsanbieters.
