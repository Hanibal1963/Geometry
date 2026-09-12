# Circle (TwoDimensional.Circle)

Beschreibung

Statische Hilfsklasse für Kreisberechnungen: Flächen, Umfang, Bogensegmente, Sehnen, Sektoren und verwandte Umrechnungen.

## Öffentliche Mitglieder

- Public Shared Function Area(r As Double) As Double
  - Fläche aus Radius r (r >= 0). Rückgabe: π * r^2.

- Public Shared Function AreaFromDiameter(d As Double) As Double
  - Fläche aus Durchmesser d (ruft Radius-Konversion intern auf).

- Public Shared Function Circumference(r As Double) As Double
  - Umfang aus Radius: 2 * π * r (r >= 0).

- Public Shared Function CircumferenceFromDiameter(d As Double) As Double
  - Umfang aus Durchmesser.

- Public Shared Function DiameterFromRadius(r As Double) As Double
  - Konvertiert Radius -> Durchmesser (2*r).

- Public Shared Function RadiusFromDiameter(d As Double) As Double
  - Konvertiert Durchmesser -> Radius (d/2).

- Public Shared Function ArcLength(r As Double, angleRadians As Double) As Double
  - Bogenlänge für gegebenen Zentralwinkel (Bogenmaß): r * angle.

- Public Shared Function ArcLengthDegrees(r As Double, angleDegrees As Double) As Double
  - Bogenlänge für Winkel in Grad (konvertiert intern zu Radiant).

- Public Shared Function SectorArea(r As Double, angleRadians As Double) As Double
  - Fläche eines Kreissektors: 0.5 * r^2 * angle.

- Public Shared Function SectorAreaDegrees(r As Double, angleDegrees As Double) As Double
  - Sektorfläche für Winkel in Grad.

- Public Shared Function ChordLength(r As Double, angleRadians As Double) As Double
  - Sehnenlänge aus Zentralwinkel: 2 * r * sin(angle/2).

- Public Shared Function ChordLengthFromSagitta(r As Double, sagitta As Double) As Double
  - Sehnenlänge aus Sehnenhöhe (Sagitta). Validierung der Parameter (0 <= sagitta <= r).

- Public Shared Function AngleFromArcLength(r As Double, arcLength As Double) As Double
  - Zentralwinkel (Bogenmaß) aus Bogenlänge: arcLength / r (r>0).

- Public Shared Function AngleFromChordLength(r As Double, chordLength As Double) As Double
  - Zentralwinkel aus Sehnenlänge: 2 * asin(chord/(2r)). Validierung.

Hinweise

- Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Radien).
- Alle Berechnungen sind statisch und rein numerisch (keine Nebenwirkungen).