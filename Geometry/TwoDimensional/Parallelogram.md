# Parallelogram (TwoDimensional.Parallelogram)

Statische Hilfsklasse für Berechnungen zu Parallelogrammen (Fläche, Umfang, Diagonalen, Winkel und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus Grundseite und Höhe. Parameter: `b` (Grundseite, `>= 0`), `h` (Höhe, `>= 0`). Rückgabe: `b * h`.

`Perimeter` - Berechnet den Umfang. Parameter: `a` (Seite, `>= 0`), `b` (Seite, `>= 0`). Rückgabe: `2 * (a + b)`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite. Parameter: `area` (`>= 0`), `b` (`> 0`). Rückgabe: `area / b`.

`SideFromPerimeter` - Berechnet die fehlende Seite aus Umfang und bekannter Seite. Parameter: `perimeter` (`> 0`), `knownSide` (`> 0`). Rückgabe: `(perimeter / 2) - knownSide`.

`DiagonalBySidesAndAngle` - Berechnet beide Diagonalen aus Seiten und eingeschlossenem Winkel. Parameter: `a` (`> 0`), `b` (`> 0`), `includedAngleRadians` (`0 < Winkel < PI`). Rückgabe: `[|u+v|, |u-v|]`.

`InteriorAngleFromSidesAndDiagonals` - Berechnet den eingeschlossenen Innenwinkel (Bogenmaß) aus Seiten und Diagonalen. Parameter: `a` (`> 0`), `b` (`> 0`), `diagLong` (`> 0`), `diagShort` (`> 0`).

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Parameter: `p1`, `p3` (gegenüberliegende Eckpunkte als `PointF`). Rückgabe: `System.Drawing.PointF`.

`VerticesFromCenter` - Berechnet vier Eckpunkte aus Mittelpunkt, Seitenlängen, eingeschlossenem Winkel und Rotation. Parameter: `cx`, `cy` (Mittelpunkt), `a`, `b` (Seitenlängen, `> 0`), `interiorAngleRadians` (`0 < Winkel < PI`), `rotationRadians` (Bogenmaß).

`AreaFromVertices` - Berechnet die Polygonfläche aus Eckpunkten mit der Shoelace-Formel. Parameter: `vertices` (mindestens 3 Punkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang als Summe der Kantenlängen. Parameter: `vertices` (mindestens 2 Punkte als `PointF()`).

`IsParallelogramFromVertices` - Prüft, ob 4 Eckpunkte ein Parallelogramm bilden. Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern. Koordinatenmethoden arbeiten mit `System.Drawing.PointF` (Single-Precision bei Rückgabewerten). Winkelparameter werden im Bogenmaß erwartet.
