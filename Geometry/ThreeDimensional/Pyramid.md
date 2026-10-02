# Pyramid (ThreeDimensional.Pyramid)

Statische Hilfsklasse für Berechnungen zu rechteckigen Pyramiden und Pyramidenstümpfen (Volumen, Flächen, Schräghöhen und Koordinatenhilfen).

## Funktionen

`BaseArea` - Berechnet die Grundfläche. Parameter: `length` (`>= 0`), `width` (`>= 0`). Rückgabe: `length * width`.

`Volume` - Berechnet das Volumen einer rechteckigen Pyramide. Parameter: `length` (Grundlänge, `>= 0`), `width` (Grundbreite, `>= 0`), `height` (Höhe, `>= 0`). Rückgabe: `(BaseArea * height) / 3`.

`SlantHeightLengthFace` - Berechnet die Schräghöhe der Seitenflächen mit Grundkante Länge. Parameter: `width` (Grundbreite, `>= 0`), `height` (Höhe, `>= 0`).

`SlantHeightWidthFace` - Berechnet die Schräghöhe der Seitenflächen mit Grundkante Breite. Parameter: `length` (Grundlänge, `>= 0`), `height` (Höhe, `>= 0`).

`LateralArea` - Berechnet die Mantelfläche aus den 4 Dreiecksflächen. Parameter: `length` (Grundlänge, `>= 0`), `width` (Grundbreite, `>= 0`), `height` (Höhe, `>= 0`).

`SurfaceArea` - Berechnet die Gesamtoberfläche als Grundfläche + Mantelfläche. Parameter: `length` (Grundlänge, `>= 0`), `width` (Grundbreite, `>= 0`), `height` (Höhe, `>= 0`).

`FrustumVolume` - Berechnet das Volumen eines rechteckigen Pyramidenstumpfs. Parameter: `bottomLength` (`> 0`), `bottomWidth` (`> 0`), `topLength` (`>= 0`, `< bottomLength`), `topWidth` (`>= 0`, `< bottomWidth`), `height` (`>= 0`). Rückgabe: `h/3 * (A1 + A2 + sqrt(A1*A2))`.

`FrustumLateralArea` - Berechnet die Mantelfläche eines rechteckigen Pyramidenstumpfs als Summe der 4 Trapezflächen. Parameter: `bottomLength`, `bottomWidth` (`> 0`), `topLength`, `topWidth` (`>= 0` und jeweils kleiner als unten), `height` (`>= 0`).

`FrustumSurfaceArea` - Berechnet die Gesamtoberfläche eines rechteckigen Pyramidenstumpfs (Grundflächen + Mantelfläche). Parameter: `bottomLength`, `bottomWidth` (`> 0`), `topLength`, `topWidth` (`>= 0` und jeweils kleiner als unten), `height` (`>= 0`).

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Parameter: `x1`, `y1`, `z1` (Punkt 1), `x2`, `y2`, `z2` (Punkt 2). Rückgabe: `Tuple(Of Double, Double, Double)`.

`VerticesFromCenter` - Berechnet 5 Eckpunkte (4 Grundpunkte + Spitze) einer geraden rechteckigen Pyramide aus Mittelpunkt und Abmessungen. Parameter: `cx`, `cy`, `cz` (Mittelpunkt), `length`, `width`, `height` (`>= 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder ungültige Frustum-Relationen).
