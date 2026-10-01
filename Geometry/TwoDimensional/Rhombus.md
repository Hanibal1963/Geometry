# Rhombus (TwoDimensional.Rhombus)

Statische Hilfsklasse für Berechnungen zu Rauten (Fläche, Umfang, Diagonalen, Radien und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`AreaFromBaseHeight` - Berechnet die Fläche aus Seitenlänge und Höhe: `baseLength * height`. Erwartet `baseLength >= 0`, `height >= 0`.

`AreaFromDiagonals` - Berechnet die Fläche aus den Diagonalen: `(diagonal1 * diagonal2) / 2`. Erwartet `diagonal1 >= 0`, `diagonal2 >= 0`.

`Perimeter` - Berechnet den Umfang: `4 * side`. Erwartet `side >= 0`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Seitenlänge: `area / side`. Erwartet `area >= 0`, `side > 0`.

`DiagonalFromSideAndAngle` - Berechnet beide Diagonalen aus Seitenlänge und Innenwinkel (Bogenmaß). Erwartet `side > 0` und `0 < interiorAngleRadians < PI`.

`InradiusFromAreaPerimeter` - Berechnet den Inkreisradius aus Fläche und Umfang: `(2 * area) / perimeter`. Erwartet `area >= 0`, `perimeter > 0`.

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Seitenlänge, Innenwinkel und Rotation.

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten mit der Shoelace-Formel.

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen.

`IsRhombusFromVertices` - Prüft, ob 4 Eckpunkte eine Raute bilden (alle Seitenlängen gleich innerhalb Toleranz).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, falsche Eckpunktanzahl, ungültige Toleranz). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
