# RegularPolygon (TwoDimensional.RegularPolygon)

Statische Hilfsklasse für Berechnungen an regelmäßigen Polygonen. Enthält Basiswerte, abgeleitete Größen und koordinatenbasierte Prüfungen.

## Funktionen

`Perimeter` - Berechnet den Umfang: `sideCount * sideLength`. Erwartet `sideLength >= 0` und `sideCount >= 3`.

`InteriorAngle` - Berechnet den Innenwinkel im Bogenmaß: `((n - 2) * PI) / n`. Erwartet `sideCount >= 3`.

`ExteriorAngle` - Berechnet den Außenwinkel im Bogenmaß: `(2 * PI) / n`. Erwartet `sideCount >= 3`.

`Apothem` - Berechnet die Apothem-Länge: `sideLength / (2 * tan(PI / n))`. Erwartet `sideLength >= 0` und `sideCount >= 3`.

`Circumradius` - Berechnet den Umkreisradius: `sideLength / (2 * sin(PI / n))`. Erwartet `sideLength >= 0` und `sideCount >= 3`.

`Area` - Berechnet die Fläche: `0.5 * Perimeter * Apothem`.

`SideLengthFromPerimeter` - Berechnet die Seitenlänge aus Umfang und Seitenanzahl: `perimeter / sideCount`. Erwartet `perimeter >= 0` und `sideCount >= 3`.

`VerticesFromCenter` - Berechnet Eckpunkte aus Mittelpunkt, Seitenanzahl, Umkreisradius und Rotation (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus Eckpunkten über die Shoelace-Formel.

`PerimeterFromVertices` - Berechnet den Umfang aus Eckpunkten als Summe der Kantenlängen.

`IsRegularFromVertices` - Prüft, ob ein Eckpunkt-Array ein regelmäßiges Polygon bildet (gleiche Seitenlängen und gleiche Radien zum Mittelpunkt innerhalb einer Toleranz).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, zu wenige Eckpunkte oder ungültige Toleranz). Koordinatenfunktionen verwenden `System.Drawing.PointF`.
