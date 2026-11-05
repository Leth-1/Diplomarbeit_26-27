# ARA – Raumbuchungsplattform Ordination Kliebergasse

Diplomarbeit 5AAIF · HTL Spengergasse · Schuljahr 2026/27

ARA ist eine webbasierte Plattform, über die Universitätsstudierende einen freien Raum der **Ordination Kliebergasse** für ihre Pflichtstunden buchen und online bezahlen können. Das Ordinationspersonal verwaltet Verfügbarkeiten, Preise und Buchungen in einer eigenen Admin-Oberfläche.

Bisher laufen Terminvergabe, Koordination und Abrechnung manuell (Telefon, E-Mail). ARA bildet den gesamten Ablauf digital ab und verhindert Doppelvergaben.

## Funktionen

**Für Studierende**
- Registrierung mit E-Mail-Bestätigung, Anmeldung und Passwort-Reset
- Kalender mit freien Zeitfenstern in Echtzeit (Tages- und Wochenansicht)
- Buchung mit vorläufiger Reservierung bis zum Abschluss der Zahlung
- Upload eines Studiennachweises (PDF oder Bild), verschlüsselt gespeichert
- Online-Bezahlung über einen externen Zahlungsanbieter
- Stornierung mit Rückerstattung gemäß Stornobedingungen
- Automatische E-Mails bei Buchung, Stornierung und Rückerstattung

**Für das Ordinationspersonal**
- Öffnungszeiten, Länge der Zeitfenster und Sperrzeiten festlegen
- Preise pro Zeitfenster verwalten
- Alle Buchungen mit Zahlungsstatus und Nachweis einsehen, filtern und stornieren
- Auswertung von Auslastung und Zahlungseingängen, Export als CSV und PDF

**Wichtigste Anforderungen**
- Keine Doppelbuchungen, auch bei gleichzeitigen Anfragen
- DSGVO-konforme Datenverarbeitung und Schutz gegen gängige Web-Angriffe (OWASP Top 10)
- Bedienbar am PC und am Smartphone

## Systemarchitektur

| Komponente | Aufgabe |
|---|---|
| Buchungsportal | Web-Oberfläche für Studierende |
| Admin-Oberfläche | Web-Oberfläche für das Personal |
| Anwendungsserver | Anmeldung und Rollen, Reservierung, Doppelbuchungsschutz, Zahlungsabgleich, E-Mails, Berichte |
| Datenbank | Benutzer, Verfügbarkeiten, Preise, Buchungen, Zahlungen |
| Dokumentenspeicher | Verschlüsselte Ablage der Studiennachweise |
| Zahlungsanbieter (extern) | Zahlungen und Rückerstattungen, Rückmeldung per Webhook |
| E-Mail-Dienst (extern) | Versand der Benachrichtigungen |

Die Oberflächen kommunizieren über HTTPS/REST (JSON) mit dem Anwendungsserver. Die konkrete Technologieauswahl wird im Pflichtenheft festgelegt.

## Team

| Name | Rolle | Schwerpunkt |
|---|---|---|
| Leth Alkhabour | Projektleiter | Skalierbare Backend-Architektur, Rollen und Berechtigungen |
| Julius Grotrian | Projektmitglied | Buchungslogik, Konfliktvermeidung, Datenmodell |
| Kamel Hanna | Projektmitglied | Dokumentenverschlüsselung, Websicherheit, Payment-Anbindung |
| Omar Mohamad | Projektmitglied | Frontend-Frameworks, Kalender und Admin-Oberfläche |

**Auftraggeberin:** Ordination Kliebergasse, Fr. Dr. Alexandra Greslechner
**Betreuung:** Georg Graf (HTL Spengergasse)

## Meilensteine

| Meilenstein | Termin | Status |
|---|---|---|
| Kickoff, Projektauftrag erteilt | 22.09.2026 | erledigt |
| Lastenheft bestätigt | offen | in Überarbeitung (Version 0.3) |
| Pflichtenheft freigegeben | offen | ausstehend |
| Walking Skeleton / erster Prototyp | 15.02.2027 | geplant |
| MVP präsentieren | 15.05.2027 | geplant |
| Projekt fertiggestellt | 15.06.2027 | geplant |
| Projektabnahme | 25.06.2027 | geplant |

## Dokumente in diesem Repository

| Datei | Inhalt |
|---|---|
| `Lastenheft_ARA_Version0.3_05.11.docx` | Lastenheft (aktuelle Version 0.3) |
| `Erklärung.docx` | Erklärung zur Diplomarbeit mit den individuellen Aufgabenstellungen |

## Nicht Teil des Projekts

Produktiver Betrieb und Hosting, Wartung nach der Übergabe, eigene Zahlungsabwicklung, native Apps, Übernahme von Altdaten und KI-Funktionen. Entwicklung und Präsentation erfolgen in einer Testumgebung, Zahlungen nur im Testmodus des Zahlungsanbieters.
