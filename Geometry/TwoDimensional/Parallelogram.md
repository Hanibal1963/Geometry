# Parallelogram (TwoDimensional.Parallelogram)

Statische Hilfsklasse für Berechnungen zu Parallelogrammen (Fläche, Umfang, Diagonalen, Winkel und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus Grundseite `b` und Höhe `h`: `b * h`. Erwartet `b,h >= 0`.

`Perimeter` - Berechnet den Umfang: `2 * (a + b)`. Erwartet `a,b >= 0`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite: `area / b`. Wirft `ArgumentException` bei `area < 0` oder `b <= 0`.

`SideFromPerimeter` - Berechnet die fehlende Seite aus Umfang und bekannter Seite: `(perimeter / 2) - knownSide`. Wirft `ArgumentException` bei negativen Werten oder wenn der Umfang nicht ausreicht.

`DiagonalBySidesAndAngle` - Berechnet beide Diagonalen aus Seiten `a`,`b` und eingeschlossenem Winkel (Bogenmaß): `[|u+v|, |u-v|]`. Erwartet `a,b > 0` und `0 < Winkel < PI`.

`InteriorAngleFromSidesAndDiagonals` - Berechnet den eingeschlossenen Innenwinkel (Bogenmaß) aus Seiten und Diagonalen. Wirft `ArgumentException` bei ungültigen Längen oder inkonsistenten Eingaben.

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten und gibt `System.Drawing.PointF` zurück.

`VerticesFromCenter` - Berechnet vier Eckpunkte aus Mittelpunkt, Seitenlängen, eingeschlossenem Winkel und Rotation.

`AreaFromVertices` - Berechnet die Polygonfläche aus Eckpunkten mit der Shoelace-Formel. Erwartet mindestens 3 Punkte.

`PerimeterFromVertices` - Berechnet den Umfang als Summe der Kantenlängen. Erwartet mindestens 2 Punkte.

`IsParallelogramFromVertices` - Prüft, ob 4 Eckpunkte ein Parallelogramm bilden (Vergleich der Diagonal-Mittelpunkte mit Toleranz).

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern. Koordinatenmethoden arbeiten mit `System.Drawing.PointF` (Single-Precision bei Rückgabewerten). Winkelparameter werden im Bogenmaß erwartet.
