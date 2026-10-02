# Square (TwoDimensional.Square)

Statische Hilfsklasse für Berechnungen zu Quadraten (Basiswerte, abgeleitete Größen und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side * side`.

`Perimeter` - Berechnet den Umfang. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `4 * side`.

`Diagonal` - Berechnet die Diagonale. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side * sqrt(2)`.

`SideFromDiagonal` - Berechnet die Seitenlänge aus der Diagonale. Parameter: `diagonal` (`>= 0`). Rückgabe: `diagonal / sqrt(2)`.

`Inradius` - Berechnet den Inkreisradius. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side / 2`.

`Circumradius` - Berechnet den Umkreisradius. Parameter: `side` (Seitenlänge, `>= 0`). Rückgabe: `side / sqrt(2)`.

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Seitenlänge und Rotation (Bogenmaß). Parameter: `cx`, `cy` (Mittelpunkt), `side` (Seitenlänge, `>= 0`), `rotationRadians`.

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten mit der Shoelace-Formel. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`IsSquareFromVertices` - Prüft, ob 4 Eckpunkte ein Quadrat bilden (gleich lange Seiten + rechte Winkel innerhalb Toleranz). Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, falsche Eckpunktanzahl, ungültige Toleranz). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
