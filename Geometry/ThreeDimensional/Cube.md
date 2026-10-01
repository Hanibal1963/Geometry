# Cube (ThreeDimensional.Cube)

Statische Hilfsklasse für Berechnungen zu Würfeln. Enthält Basiswerte, abgeleitete Standardwerte und Koordinatenhilfen.

## Funktionen

`Volume` - Berechnet das Volumen: `side^3`. Erwartet `side >= 0`.

`SurfaceArea` - Berechnet die Oberfläche: `6 * side^2`. Erwartet `side >= 0`.

`SpaceDiagonal` - Berechnet die Raumdiagonale: `side * sqrt(3)`. Erwartet `side >= 0`.

`FaceDiagonal` - Berechnet die Flächendiagonale: `side * sqrt(2)`. Erwartet `side >= 0`.

`SideFromVolume` - Berechnet die Kantenlänge aus dem Volumen: `cubic-root(volume)`. Erwartet `volume >= 0`.

`SideFromSurfaceArea` - Berechnet die Kantenlänge aus der Oberfläche: `sqrt(surfaceArea / 6)`. Erwartet `surfaceArea >= 0`.

`SideFromSpaceDiagonal` - Berechnet die Kantenlänge aus der Raumdiagonale: `spaceDiagonal / sqrt(3)`. Erwartet `spaceDiagonal >= 0`.

`Center` - Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten.

`VerticesFromCenter` - Berechnet 8 Eckpunkte eines achsenparallelen Würfels aus Mittelpunkt und Kantenlänge.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder Flächen). Koordinatenmethoden verwenden `Tuple(Of Double, Double, Double)`.
