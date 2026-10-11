# Cube (ThreeDimensional.Cube)

Statische Hilfsklasse für Berechnungen zu Würfeln. Enthält Basiswerte, abgeleitete Standardwerte und Koordinatenhilfen.

## Funktionen

`Volume` - Berechnet das Volumen. Parameter: `side` (Kantenlänge, `>= 0`). Rückgabe: `side^3`.

`SurfaceArea` - Berechnet die Oberfläche. Parameter: `side` (Kantenlänge, `>= 0`). Rückgabe: `6 * side^2`.

`SpaceDiagonal` - Berechnet die Raumdiagonale. Parameter: `side` (Kantenlänge, `>= 0`). Rückgabe: `side * sqrt(3)`.

`FaceDiagonal` - Berechnet die Flächendiagonale. Parameter: `side` (Kantenlänge, `>= 0`). Rückgabe: `side * sqrt(2)`.

`SideFromVolume` - Berechnet die Kantenlänge aus dem Volumen. Parameter: `volume` (`>= 0`). Rückgabe: `cubic-root(volume)`.

`SideFromSurfaceArea` - Berechnet die Kantenlänge aus der Oberfläche. Parameter: `surfaceArea` (`>= 0`). Rückgabe: `sqrt(surfaceArea / 6)`.

`SideFromSpaceDiagonal` - Berechnet die Kantenlänge aus der Raumdiagonale. Parameter: `spaceDiagonal` (`>= 0`). Rückgabe: `spaceDiagonal / sqrt(3)`.

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten. Parameter: `x1`, `y1`, `z1` (Punkt 1), `x2`, `y2`, `z2` (Punkt 2).

`VerticesFromCenter` - Berechnet 8 Eckpunkte eines achsenparallelen Würfels aus Mittelpunkt und Kantenlänge. Parameter: `cx`, `cy`, `cz` (Mittelpunkt), `side` (Kantenlänge, `>= 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder Flächen). Koordinatenmethoden verwenden `Tuple(Of Double, Double, Double)`.
