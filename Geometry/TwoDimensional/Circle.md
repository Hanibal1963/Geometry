# Circle (TwoDimensional.Circle)

Statische Hilfsklasse für Kreisberechnungen: Flächen, Umfang, Bogensegmente, Sehnen, Sektoren und Umrechnungen.

## Funktionen

`Area` - Berechnet die Fläche eines Kreises aus dem Radius r (r >= 0). Rückgabe: π * r^2.

`AreaFromDiameter` - Berechnet die Fläche aus dem Durchmesser d (intern: Konversion zu Radius).

`Circumference` - Berechnet den Umfang aus dem Radius: 2 * π * r.

`CircumferenceFromDiameter` - Berechnet den Umfang aus dem Durchmesser.

`DiameterFromRadius` - Konvertiert Radius in Durchmesser (2 * r).

`RadiusFromDiameter` - Konvertiert Durchmesser in Radius (d / 2).

`ArcLength` - Bogenlänge für einen gegebenen Zentralwinkel (Bogenmaß): r * angle.

`ArcLengthDegrees` - Bogenlänge für Winkel in Grad (konvertiert intern in Radiant).

`SectorArea` - Fläche eines Kreissektors für Winkel im Bogenmaß: 0.5 * r^2 * angle.

`SectorAreaDegrees` - Fläche eines Kreissektors für Winkel in Grad.

`ChordLength` - Sehnenlänge aus Zentralwinkel: 2 * r * sin(angle/2).

`ChordLengthFromSagitta` - Sehnenlänge aus Sehnenhöhe (Sagitta). Parameter werden validiert (0 <= sagitta <= r).

`AngleFromArcLength` - Zentralwinkel (Bogenmaß) aus Bogenlänge: arcLength / r (r > 0).

`AngleFromChordLength` - Zentralwinkel aus Sehnenlänge: 2 * asin(chord / (2 * r)). Parametervalidierung angewendet.

## Hinweise

Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Radien). Alle Berechnungen sind statisch und rein numerisch (keine Nebenwirkungen).
