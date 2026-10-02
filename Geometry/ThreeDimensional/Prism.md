# Prism (ThreeDimensional.Prism)

Statische Hilfsklasse für Prismenvarianten. Enthält Berechnungen für gerade Prismen allgemein, Dreiecksprismen sowie regelmäßige n-Eck-Prismen und stellt dafür Volumen- und Oberflächenfunktionen bereit.

## Funktionen

`Volume` - Berechnet das Volumen eines geraden Prismas: `baseArea * height`. Erwartet `baseArea >= 0` und `height >= 0`.

`LateralArea` - Berechnet die Mantelfläche: `basePerimeter * height`. Erwartet `basePerimeter >= 0` und `height >= 0`.

`SurfaceArea` - Berechnet die Oberfläche: `2 * baseArea + basePerimeter * height`. Erwartet `baseArea >= 0`, `basePerimeter >= 0`, `height >= 0`.

`TriangularBaseArea` - Berechnet die Dreiecksgrundfläche mit der Heron-Formel. Erwartet `sideA > 0`, `sideB > 0`, `sideC > 0` und gültige Dreiecksungleichung.

`TriangularPrismVolume` - Berechnet das Volumen eines Dreiecksprismas. Parameter: `sideA`, `sideB`, `sideC` (Dreiecksseiten, `> 0`, gültige Dreiecksungleichung), `height` (Prismahöhe, `>= 0`).

`TriangularPrismSurfaceArea` - Berechnet die Oberfläche eines Dreiecksprismas. Parameter: `sideA`, `sideB`, `sideC` (Dreiecksseiten, `> 0`, gültige Dreiecksungleichung), `height` (Prismahöhe, `>= 0`).

`RegularPolygonBaseArea` - Berechnet die Grundfläche eines regelmäßigen n-Ecks: `n*s^2/(4*tan(PI/n))`. Erwartet `sideLength >= 0`, `sideCount >= 3`.

`RegularPolygonPrismVolume` - Berechnet das Volumen eines regelmäßigen n-Eck-Prismas. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`), `height` (`>= 0`).

`RegularPolygonPrismSurfaceArea` - Berechnet die Oberfläche eines regelmäßigen n-Eck-Prismas. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`), `height` (`>= 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, ungültige Seitenanzahl oder verletzte Dreiecksungleichung).
