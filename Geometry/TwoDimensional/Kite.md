# Kite (TwoDimensional.Kite)

Statische Hilfsklasse für Berechnungen zu Drachenvierecken (Fläche, Umfang, Seitenmuster und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`AreaFromDiagonals` - Berechnet die Fläche aus den Diagonalen: `(diagonal1 * diagonal2) / 2`. Erwartet `diagonal1 >= 0`, `diagonal2 >= 0`.

`Perimeter` - Berechnet den Umfang aus zwei Seitenpaaren: `2 * (sideA + sideB)`. Erwartet `sideA >= 0`, `sideB >= 0`.

`AreaFromBaseHeight` - Berechnet die Fläche aus Grundseite und Höhe: `baseLength * height`. Erwartet `baseLength >= 0`, `height >= 0`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite: `area / baseLength`. Erwartet `area >= 0`, `baseLength > 0`.

`IsSymmetricBySides` - Prüft ein symmetrisches Drachen-Seitenmuster aus vier Seitenlängen innerhalb Toleranz.

`VerticesFromCenter` - Berechnet 4 Eckpunkte aus Mittelpunkt, Diagonalen und Rotation (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten mit der Shoelace-Formel.

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen.

`IsKiteFromVertices` - Prüft, ob 4 Eckpunkte ein Drachenviereck bilden (zwei benachbarte Seitenpaare gleich lang innerhalb Toleranz).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, ungültige Toleranz, falsche Eckpunktanzahl). Koordinatenmethoden arbeiten mit `System.Drawing.PointF`.
