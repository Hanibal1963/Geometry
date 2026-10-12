# Prism (ThreeDimensional.Prism)

Statische Hilfsklasse für Prismenvarianten. Enthält Berechnungen für gerade Prismen allgemein, Dreiecksprismen sowie regelmäßige n-Eck-Prismen und stellt dafür Volumen- und Oberflächenfunktionen bereit.

## Funktionen

`Volume` - Berechnet das Volumen eines geraden Prismas. Parameter: `baseArea` (`>= 0`), `height` (`>= 0`). Rückgabe: `baseArea * height`.

`LateralArea` - Berechnet die Mantelfläche. Parameter: `basePerimeter` (`>= 0`), `height` (`>= 0`). Rückgabe: `basePerimeter * height`.

`SurfaceArea` - Berechnet die Oberfläche. Parameter: `baseArea` (`>= 0`), `basePerimeter` (`>= 0`), `height` (`>= 0`). Rückgabe: `2 * baseArea + basePerimeter * height`.

`TriangularBaseArea` - Berechnet die Dreiecksgrundfläche mit der Heron-Formel. Parameter: `sideA`, `sideB`, `sideC` (Seiten, `> 0`, gültige Dreiecksungleichung).

`TriangularPrismVolume` - Berechnet das Volumen eines Dreiecksprismas. Parameter: `sideA`, `sideB`, `sideC` (Dreiecksseiten, `> 0`, gültige Dreiecksungleichung), `height` (Prismahöhe, `>= 0`).

`TriangularPrismSurfaceArea` - Berechnet die Oberfläche eines Dreiecksprismas. Parameter: `sideA`, `sideB`, `sideC` (Dreiecksseiten, `> 0`, gültige Dreiecksungleichung), `height` (Prismahöhe, `>= 0`).

`RegularPolygonBaseArea` - Berechnet die Grundfläche eines regelmäßigen n-Ecks. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`). Rückgabe: `n*s^2/(4*tan(PI/n))`.

`RegularPolygonPrismVolume` - Berechnet das Volumen eines regelmäßigen n-Eck-Prismas. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`), `height` (`>= 0`).

`RegularPolygonPrismSurfaceArea` - Berechnet die Oberfläche eines regelmäßigen n-Eck-Prismas. Parameter: `sideLength` (`>= 0`), `sideCount` (`>= 3`), `height` (`>= 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen, ungültige Seitenanzahl oder verletzte Dreiecksungleichung).
