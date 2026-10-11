# Rectangle (TwoDimensional.Rectangle)

Statische Hilfsklasse für Berechnungen zu Rechtecken und Quadraten. Enthält Funktionen für Fläche, Umfang, Diagonalen, Radiusbeziehungen sowie Koordinatenhilfen auf Eckpunktbasis.

## Funktionen

`Area` - Berechnet die Fläche eines Rechtecks. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`). Rückgabe: `w * h`.

`Perimeter` - Berechnet den Umfang eines Rechtecks. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`). Rückgabe: `2 * (w + h)`.

`Diagonal` - Berechnet die Diagonale eines Rechtecks. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`).

`AspectRatio` - Liefert das Seitenverhältnis `w / h`. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `> 0`).

`IsSquare` - Prüft, ob Breite und Höhe gleich sind. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`).

`Circumradius` - Berechnet den Radius des Umkreises. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`).

`Inradius` - Berechnet den Radius des größten einbeschriebenen Kreises. Parameter: `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`).

`AreaSquare` - Berechnet die Fläche eines Quadrats. Parameter: `s` (Seitenlänge, `>= 0`).

`PerimeterSquare` - Berechnet den Umfang eines Quadrats. Parameter: `s` (Seitenlänge, `>= 0`).

`DiagonalSquare` - Berechnet die Diagonale eines Quadrats. Parameter: `s` (Seitenlänge, `>= 0`).

`FromDiagonalToSide` - Berechnet die Seitenlänge eines Quadrats aus der Diagonale. Parameter: `d` (Diagonale, `>= 0`).

`Center` - Berechnet den Mittelpunkt zweier Punkte. Parameter: `x1`, `y1`, `x2`, `y2` (Koordinaten zweier Punkte). Rückgabe: `System.Drawing.PointF`.

`VerticesFromCenter` - Liefert die 4 Eckpunkte eines rotierten Rechtecks aus Mittelpunkt, Breite, Höhe und Winkel. Parameter: `cx`, `cy` (Mittelpunkt), `w` (Breite, `>= 0`), `h` (Höhe, `>= 0`), `angleRadians` (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus Eckpunkten über die Shoelace-Formel. Parameter: `vertices` (mindestens 3 Punkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang als Summe der Kantenlängen. Parameter: `vertices` (mindestens 2 Punkte als `PointF()`).

`IsRectangleFromVertices` - Prüft, ob vier gegebene Punkte ein Rechteck bilden. Parameter: `vertices` (4 Eckpunkte).

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (z. B. negative Längen oder Division durch 0). Bei einigen koordinatenbasierten Prüf-/Berechnungsmethoden werden für ungültige Eckpunkt-Arrays stattdessen direkte Rückgabewerte verwendet (z. B. `0.0` oder `False`). Koordinatenmethoden verwenden `System.Drawing.PointF` (Single-Precision) zur Rückgabe.
