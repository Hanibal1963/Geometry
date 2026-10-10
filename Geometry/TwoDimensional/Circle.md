# Circle (TwoDimensional.Circle)

Statische Hilfsklasse für Kreisberechnungen: Flächen, Umfang, Bogensegmente, Sehnen, Sektoren und Umrechnungen.

## Funktionen

`Area` - Berechnet die Fläche eines Kreises. Parameter: `radius` (Radius, `radius >= 0`). Rückgabe: `π * radius^2`.

`AreaFromDiameter` - Berechnet die Fläche aus dem Durchmesser. Parameter: `diameter` (Durchmesser, `diameter >= 0`). Rückgabe: `π * diameter^2 / 4`.

`Circumference` - Berechnet den Umfang. Parameter: `radius` (Radius, `radius >= 0`). Rückgabe: `2 * π * radius`.

`CircumferenceFromDiameter` - Berechnet den Umfang aus dem Durchmesser. Parameter: `diameter` (Durchmesser, `diameter >= 0`). Rückgabe: `π * diameter`.

`DiameterFromRadius` - Konvertiert Radius in Durchmesser. Parameter: `radius` (Radius, `radius >= 0`). Rückgabe: `2 * radius`.

`RadiusFromDiameter` - Konvertiert Durchmesser in Radius. Parameter: `diameter` (Durchmesser, `diameter >= 0`). Rückgabe: `diameter / 2`.

`ArcLength` - Berechnet die Bogenlänge für einen Zentralwinkel im Bogenmaß. Parameter: `radius` (Radius, `radius >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `radius * angleRadians`.

`ArcLengthDegrees` - Berechnet die Bogenlänge für Winkel in Grad. Parameter: `radius` (Radius, `radius >= 0`), `angleDegrees` (Winkel in Grad). Rückgabe: `radius * angleDegrees * π / 180`.

`SectorArea` - Berechnet die Fläche eines Kreissektors für Winkel im Bogenmaß. Parameter: `radius` (Radius, `radius >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `0.5 * radius^2 * angleRadians`.

`SectorAreaDegrees` - Berechnet die Fläche eines Kreissektors für Winkel in Grad. Parameter: `radius` (Radius, `radius >= 0`), `angleDegrees` (Winkel in Grad). Rückgabe: `π * radius^2 * angleDegrees / 360`.

`ChordLength` - Berechnet die Sehnenlänge aus dem Zentralwinkel. Parameter: `radius` (Radius, `radius >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `2 * radius * sin(angleRadians / 2)`.

`ChordLengthFromSagitta` - Berechnet die Sehnenlänge aus der Sehnenhöhe (Sagitta). Parameter: `radius` (Radius, `radius >= 0`), `sagitta` (Sehnenhöhe, `0 <= sagitta <= radius`). Rückgabe: `2 * sqrt(2 * radius * sagitta - sagitta^2)`.

`AngleFromArcLength` - Berechnet den Zentralwinkel (Bogenmaß) aus der Bogenlänge. Parameter: `radius` (Radius, `radius > 0`), `arcLength` (Bogenlänge). Rückgabe: `arcLength / radius`.

`AngleFromChordLength` - Berechnet den Zentralwinkel (Bogenmaß) aus der Sehnenlänge. Parameter: `radius` (Radius, `radius > 0`), `chordLength` (Sehnenlänge, `0 <= chordLength <= 2 * radius`). Rückgabe: `2 * asin(chordLength / (2 * radius))`.

`PointOnCircle` - Berechnet einen Punkt auf dem Kreis für Mittelpunkt und Winkel im Bogenmaß. Parameter: `cx` (Mittelpunkt-X), `cy` (Mittelpunkt-Y), `radius` (Radius, `radius >= 0`), `angleRadians` (Winkel im Bogenmaß). Rückgabe: `PointF(x, y)` mit `x = cx + radius * cos(angleRadians)` und `y = cy + radius * sin(angleRadians)`.

`BoundingBox` - Liefert das achsenparallele Bounding-Box-Rechteck eines Kreises. Parameter: `cx` (Mittelpunkt-X), `cy` (Mittelpunkt-Y), `radius` (Radius, `radius >= 0`). Rückgabe: `RectangleF(x, y, w, h)` mit `x = cx - radius`, `y = cy - radius`, `w = h = 2 * radius`.

## Hinweise

Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Radien). Alle Berechnungen sind statisch und rein numerisch (keine Nebenwirkungen).
