# Cuboid (ThreeDimensional.Cuboid)

Statische Hilfsklasse für Berechnungen zu Quadern (Volumen, Oberflächen, Diagonalen, Kantenbeziehungen und Koordinatenhilfen).

## Funktionen

`Volume` - Berechnet das Volumen. Parameter: `length` (`>= 0`), `width` (`>= 0`), `height` (`>= 0`). Rückgabe: `length * width * height`.

`SurfaceArea` - Berechnet die Oberfläche. Parameter: `length` (`>= 0`), `width` (`>= 0`), `height` (`>= 0`). Rückgabe: `2 * (lw + lh + wh)`.

`SpaceDiagonal` - Berechnet die Raumdiagonale. Parameter: `length` (`>= 0`), `width` (`>= 0`), `height` (`>= 0`). Rückgabe: `sqrt(l^2 + w^2 + h^2)`.

`FaceDiagonalLengthWidth` - Berechnet die Flächendiagonale der Seite Länge-Breite. Parameter: `length` (`>= 0`), `width` (`>= 0`).

`FaceDiagonalLengthHeight` - Berechnet die Flächendiagonale der Seite Länge-Höhe. Parameter: `length` (`>= 0`), `height` (`>= 0`).

`FaceDiagonalWidthHeight` - Berechnet die Flächendiagonale der Seite Breite-Höhe. Parameter: `width` (`>= 0`), `height` (`>= 0`).

`EdgeFromVolume` - Berechnet eine fehlende Kante aus Volumen und zwei bekannten Kanten. Parameter: `volume` (`>= 0`), `edge1` (`> 0`), `edge2` (`> 0`). Rückgabe: `volume / (edge1 * edge2)`.

`IsCube` - Prüft, ob ein Quader innerhalb einer Toleranz ein Würfel ist (alle Kanten gleich). Parameter: `length` (`>= 0`), `width` (`>= 0`), `height` (`>= 0`), `tolerance` (`> 0`, optional).

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Parameter: `x1`, `y1`, `z1` (Punkt 1), `x2`, `y2`, `z2` (Punkt 2). Rückgabe: `Tuple(Of Double, Double, Double)`.

`VerticesFromCenter` - Berechnet 8 Eckpunkte eines achsenparallelen Quaders aus Mittelpunkt und Kantenlängen. Parameter: `cx`, `cy`, `cz` (Mittelpunkt), `length`, `width`, `height` (`>= 0`). Rückgabe: Array von `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Kantenlängen oder ungültige Toleranz).
