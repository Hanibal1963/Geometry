# Kite (TwoDimensional.Kite)

Statische Hilfsklasse für Berechnungen zu Drachenvierecken (Fläche, Umfang, Seitenmuster und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`AreaFromDiagonals` - Berechnet die Fläche aus den Diagonalen. Parameter: `diagonal1` (`>= 0`), `diagonal2` (`>= 0`). Rückgabe: `(diagonal1 * diagonal2) / 2`.

`Perimeter` - Berechnet den Umfang aus zwei Seitenpaaren. Parameter: `sideA` (`>= 0`), `sideB` (`>= 0`). Rückgabe: `2 * (sideA + sideB)`.

`AreaFromBaseHeight` - Berechnet die Fläche aus Grundseite und Höhe. Parameter: `baseLength` (`>= 0`), `height` (`>= 0`). Rückgabe: `baseLength * height`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite. Parameter: `area` (`>= 0`), `baseLength` (`> 0`). Rückgabe: `area / baseLength`.

`IsSymmetricBySides` - Prüft ein symmetrisches Drachen-Seitenmuster. Parameter: `sideA`, `sideB`, `sideC`, `sideD` (Seitenlängen, `>= 0`), `tolerance` (`> 0`).

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Diagonalen und Rotation. Parameter: `cx`, `cy` (Mittelpunkt), `diagonal1`, `diagonal2` (`>= 0`), `rotationRadians` (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten. Parameter: `vertices` (4 Eckpunkte als `PointF()` in umlaufender Reihenfolge).

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`IsKiteFromVertices` - Prüft, ob 4 Eckpunkte ein Drachenviereck bilden. Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, ungültige Toleranz, falsche Eckpunktanzahl). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
