# Circle (TwoDimensional.Circle)

Statische Hilfsklasse für Kreisberechnungen: Flächen, Umfang, Bogensegmente, Sehnen, Sektoren und Umrechnungen.

## Funktionen

`Area` - Berechnet die Fläche eines Kreises. Parameter: `r` (Radius, `r >= 0`). Rückgabe: `π * r^2`.

`AreaFromDiameter` - Berechnet die Fläche aus dem Durchmesser. Parameter: `d` (Durchmesser, `d >= 0`). Rückgabe: `π * d^2 / 4`.

`Circumference` - Berechnet den Umfang. Parameter: `r` (Radius, `r >= 0`). Rückgabe: `2 * π * r`.

`CircumferenceFromDiameter` - Berechnet den Umfang aus dem Durchmesser. Parameter: `d` (Durchmesser, `d >= 0`). Rückgabe: `π * d`.

`DiameterFromRadius` - Konvertiert Radius in Durchmesser. Parameter: `r` (Radius, `r >= 0`). Rückgabe: `2 * r`.

`RadiusFromDiameter` - Konvertiert Durchmesser in Radius. Parameter: `d` (Durchmesser, `d >= 0`). Rückgabe: `d / 2`.

`ArcLength` - Berechnet die Bogenlänge für einen Zentralwinkel im Bogenmaß. Parameter: `r` (Radius, `r >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `r * angleRadians`.

`ArcLengthDegrees` - Berechnet die Bogenlänge für Winkel in Grad. Parameter: `r` (Radius, `r >= 0`), `angleDegrees` (Winkel in Grad). Rückgabe: `r * angleDegrees * π / 180`.

`SectorArea` - Berechnet die Fläche eines Kreissektors für Winkel im Bogenmaß. Parameter: `r` (Radius, `r >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `0.5 * r^2 * angleRadians`.

`SectorAreaDegrees` - Berechnet die Fläche eines Kreissektors für Winkel in Grad. Parameter: `r` (Radius, `r >= 0`), `angleDegrees` (Winkel in Grad). Rückgabe: `π * r^2 * angleDegrees / 360`.

`ChordLength` - Berechnet die Sehnenlänge aus dem Zentralwinkel. Parameter: `r` (Radius, `r >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `2 * r * sin(angleRadians / 2)`.

`ChordLengthFromSagitta` - Berechnet die Sehnenlänge aus der Sehnenhöhe (Sagitta). Parameter: `r` (Radius, `r >= 0`), `sagitta` (Sehnenhöhe, `0 <= sagitta <= r`). Rückgabe: `2 * sqrt(2 * r * sagitta - sagitta^2)`.

`AngleFromArcLength` - Berechnet den Zentralwinkel (Bogenmaß) aus der Bogenlänge. Parameter: `r` (Radius, `r > 0`), `arcLength` (Bogenlänge). Rückgabe: `arcLength / r`.

`AngleFromChordLength` - Berechnet den Zentralwinkel (Bogenmaß) aus der Sehnenlänge. Parameter: `r` (Radius, `r > 0`), `chordLength` (Sehnenlänge, `0 <= chordLength <= 2 * r`). Rückgabe: `2 * asin(chordLength / (2 * r))`.

## Hinweise

Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Radien). Alle Berechnungen sind statisch und rein numerisch (keine Nebenwirkungen).
