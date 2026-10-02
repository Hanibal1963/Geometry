# Pyramid (ThreeDimensional.Pyramid)

Statische Hilfsklasse für Berechnungen zu rechteckigen Pyramiden und Pyramidenstümpfen (Volumen, Flächen, Schräghöhen und Koordinatenhilfen).

## Funktionen

`BaseArea` - Berechnet die Grundfläche: `length * width`. Erwartet `length >= 0`, `width >= 0`.

`Volume` - Berechnet das Volumen einer rechteckigen Pyramide: `(BaseArea * height) / 3`.

`SlantHeightLengthFace` - Berechnet die Schräghöhe der Seitenflächen mit Grundkante Länge: `sqrt((width/2)^2 + height^2)`.

`SlantHeightWidthFace` - Berechnet die Schräghöhe der Seitenflächen mit Grundkante Breite: `sqrt((length/2)^2 + height^2)`.

`LateralArea` - Berechnet die Mantelfläche aus den 4 Dreiecksflächen.

`SurfaceArea` - Berechnet die Gesamtoberfläche als Grundfläche + Mantelfläche.

`FrustumVolume` - Berechnet das Volumen eines rechteckigen Pyramidenstumpfs: `h/3 * (A1 + A2 + sqrt(A1*A2))`. Erwartet `bottomLength > 0`, `bottomWidth > 0`, `topLength >= 0`, `topWidth >= 0`, `topLength < bottomLength`, `topWidth < bottomWidth`, `height >= 0`.

`FrustumLateralArea` - Berechnet die Mantelfläche eines rechteckigen Pyramidenstumpfs als Summe der 4 Trapezflächen.

`FrustumSurfaceArea` - Berechnet die Gesamtoberfläche eines rechteckigen Pyramidenstumpfs (Grundflächen + Mantelfläche).

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Rückgabe als `Tuple(Of Double, Double, Double)`.

`VerticesFromCenter` - Berechnet 5 Eckpunkte (4 Grundpunkte + Spitze) einer geraden rechteckigen Pyramide aus Mittelpunkt und Abmessungen.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder ungültige Frustum-Relationen).
