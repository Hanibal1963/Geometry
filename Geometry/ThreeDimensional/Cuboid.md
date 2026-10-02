# Cuboid (ThreeDimensional.Cuboid)

Statische Hilfsklasse für Berechnungen zu Quadern (Volumen, Oberflächen, Diagonalen, Kantenbeziehungen und Koordinatenhilfen).

## Funktionen

`Volume` - Berechnet das Volumen: `length * width * height`. Erwartet `length >= 0`, `width >= 0`, `height >= 0`.

`SurfaceArea` - Berechnet die Oberfläche: `2 * (lw + lh + wh)`.

`SpaceDiagonal` - Berechnet die Raumdiagonale: `sqrt(l^2 + w^2 + h^2)`.

`FaceDiagonalLengthWidth` - Berechnet die Flächendiagonale der Seite Länge-Breite: `sqrt(l^2 + w^2)`.

`FaceDiagonalLengthHeight` - Berechnet die Flächendiagonale der Seite Länge-Höhe: `sqrt(l^2 + h^2)`.

`FaceDiagonalWidthHeight` - Berechnet die Flächendiagonale der Seite Breite-Höhe: `sqrt(w^2 + h^2)`.

`EdgeFromVolume` - Berechnet eine fehlende Kante aus Volumen und zwei bekannten Kanten: `volume / (edge1 * edge2)`. Erwartet `volume >= 0`, `edge1 > 0`, `edge2 > 0`.

`IsCube` - Prüft, ob ein Quader innerhalb einer Toleranz ein Würfel ist (alle Kanten gleich). Erwartet `tolerance > 0`.

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Rückgabe als `Tuple(Of Double, Double, Double)`.

`VerticesFromCenter` - Berechnet 8 Eckpunkte eines achsenparallelen Quaders aus Mittelpunkt und Kantenlängen. Rückgabe als Array von `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Kantenlängen oder ungültige Toleranz).
