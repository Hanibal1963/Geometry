# Square (TwoDimensional.Square)

Statische Hilfsklasse für Berechnungen zu Quadraten (Basiswerte, abgeleitete Größen und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche: `side * side`. Erwartet `side >= 0`.

`Perimeter` - Berechnet den Umfang: `4 * side`. Erwartet `side >= 0`.

`Diagonal` - Berechnet die Diagonale. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side * sqrt(2)`.

`SideFromDiagonal` - Berechnet die Seitenlänge aus der Diagonale: `diagonal / sqrt(2)`. Erwartet `diagonal >= 0`.

`Inradius` - Berechnet den Inkreisradius. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side / 2`.

`Circumradius` - Berechnet den Umkreisradius. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side / sqrt(2)`.

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Seitenlänge und Rotation (Bogenmaß). Parameter: `cx`, `cy` (Mittelpunkt), `side` (Seitenlänge, `>= 0`), `rotationRadians`.

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten mit der Shoelace-Formel. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`IsSquareFromVertices` - Prüft, ob 4 Eckpunkte ein Quadrat bilden (gleich lange Seiten + rechte Winkel innerhalb Toleranz). Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, falsche Eckpunktanzahl, ungültige Toleranz). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
