# Rhombus (TwoDimensional.Rhombus)

Statische Hilfsklasse für Berechnungen zu Rauten (Fläche, Umfang, Diagonalen, Radien und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`AreaFromBaseHeight` - Berechnet die Fläche aus Seitenlänge und Höhe. Parameter: `baseLength` (`>= 0`), `height` (`>= 0`). Rückgabe: `baseLength * height`.

`AreaFromDiagonals` - Berechnet die Fläche aus den Diagonalen. Parameter: `diagonal1` (`>= 0`), `diagonal2` (`>= 0`). Rückgabe: `(diagonal1 * diagonal2) / 2`.

`Perimeter` - Berechnet den Umfang. Parameter: `side` (`>= 0`). Rückgabe: `4 * side`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Seitenlänge. Parameter: `area` (`>= 0`), `side` (`> 0`). Rückgabe: `area / side`.

`DiagonalFromSideAndAngle` - Berechnet beide Diagonalen aus Seitenlänge und Innenwinkel (Bogenmaß). Parameter: `side` (`> 0`), `interiorAngleRadians` (`0 < Winkel < PI`).

`InradiusFromAreaPerimeter` - Berechnet den Inkreisradius aus Fläche und Umfang. Parameter: `area` (`>= 0`), `perimeter` (`> 0`). Rückgabe: `(2 * area) / perimeter`.

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Seitenlänge, Innenwinkel und Rotation. Parameter: `cx`, `cy` (Mittelpunkt), `side` (Seitenlänge, `> 0`), `interiorAngleRadians` (`0 < Winkel < PI`), `rotationRadians` (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten mit der Shoelace-Formel. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`IsRhombusFromVertices` - Prüft, ob 4 Eckpunkte eine Raute bilden (alle Seitenlängen gleich innerhalb Toleranz). Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, falsche Eckpunktanzahl, ungültige Toleranz). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
