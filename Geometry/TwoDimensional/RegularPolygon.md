# RegularPolygon (TwoDimensional.RegularPolygon)

Statische Hilfsklasse für Berechnungen an regelmäßigen Polygonen. Enthält Basiswerte, abgeleitete Größen und koordinatenbasierte Prüfungen.

## Funktionen

`Perimeter` - Berechnet den Umfang. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`). Rückgabe: `sideCount * sideLength`.

`InteriorAngle` - Berechnet den Innenwinkel im Bogenmaß. Parameter: `sideCount` (`>= 3`). Rückgabe: `((n - 2) * PI) / n`.

`ExteriorAngle` - Berechnet den Außenwinkel im Bogenmaß. Parameter: `sideCount` (`>= 3`). Rückgabe: `(2 * PI) / n`.

`Apothem` - Berechnet die Apothem-Länge. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`). Rückgabe: `sideLength / (2 * tan(PI / n))`.

`Circumradius` - Berechnet den Umkreisradius. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`). Rückgabe: `sideLength / (2 * sin(PI / n))`.

`Area` - Berechnet die Fläche. Parameter: `sideLength` (Seitenlänge, `>= 0`), `sideCount` (Seitenanzahl, `>= 3`). Rückgabe: `0.5 * Perimeter * Apothem`.

`SideLengthFromPerimeter` - Berechnet die Seitenlänge aus Umfang und Seitenanzahl. Parameter: `perimeter` (`>= 0`), `sideCount` (`>= 3`). Rückgabe: `perimeter / sideCount`.

`VerticesFromCenter` - Berechnet Eckpunkte aus Mittelpunkt, Seitenanzahl, Umkreisradius und Rotation. Parameter: `cx`, `cy` (Mittelpunkt), `sideCount` (Seitenanzahl, `>= 3`), `circumradius` (`>= 0`), `rotationRadians` (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus Eckpunkten über die Shoelace-Formel. Parameter: `vertices` (mindestens 3 Eckpunkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang aus Eckpunkten als Summe der Kantenlängen. Parameter: `vertices` (mindestens 2 Eckpunkte als `PointF()`).

`IsRegularFromVertices` - Prüft, ob ein Eckpunkt-Array ein regelmäßiges Polygon bildet (gleiche Seitenlängen und gleiche Radien zum Mittelpunkt). Parameter: `vertices` (mindestens 3 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, zu wenige Eckpunkte oder ungültige Toleranz). Koordinatenfunktionen verwenden `System.Drawing.PointF`.
