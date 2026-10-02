# Frustum (ThreeDimensional.Frustum)

Statische Hilfsklasse für gängige Stumpfkörper. Enthält Berechnungen für Kegelstumpf, rechteckigen Pyramidenstumpf und Prisma-Stumpf; je Variante werden Volumen, Mantelfläche und Oberfläche bereitgestellt.

## Funktionen

`ConeFrustumVolume` - Berechnet das Volumen eines Kegelstumpfs: `PI*h/3 * (R^2 + R*r + r^2)`. Erwartet `bottomRadius > 0`, `0 <= topRadius < bottomRadius`, `height >= 0`.

`ConeFrustumLateralArea` - Berechnet die Mantelfläche eines Kegelstumpfs. Parameter: `bottomRadius` (`> 0`), `topRadius` (`>= 0`, `< bottomRadius`), `height` (`>= 0`). Formel: `PI * (R + r) * s` mit `s = sqrt((R-r)^2 + h^2)`.

`ConeFrustumSurfaceArea` - Berechnet die Oberfläche eines Kegelstumpfs als Mantel plus beide Kreisflächen. Parameter: `bottomRadius` (`> 0`), `topRadius` (`>= 0`, `< bottomRadius`), `height` (`>= 0`).

`PyramidFrustumVolume` - Berechnet das Volumen eines rechteckigen Pyramidenstumpfs: `h/3 * (A1 + A2 + sqrt(A1*A2))`.

`PyramidFrustumLateralArea` - Berechnet die Mantelfläche eines rechteckigen Pyramidenstumpfs aus vier Trapezflächen. Parameter: `bottomLength` (`> 0`), `bottomWidth` (`> 0`), `topLength` (`>= 0`, `< bottomLength`), `topWidth` (`>= 0`, `< bottomWidth`), `height` (`>= 0`).

`PyramidFrustumSurfaceArea` - Berechnet die Oberfläche eines rechteckigen Pyramidenstumpfs als untere Fläche + obere Fläche + Mantel. Parameter: `bottomLength` (`> 0`), `bottomWidth` (`> 0`), `topLength` (`>= 0`, `< bottomLength`), `topWidth` (`>= 0`, `< bottomWidth`), `height` (`>= 0`).

`PrismFrustumVolume` - Berechnet das Volumen eines Prisma-Stumpfs mit Endflächenmittel. Parameter: `bottomArea` (`>= 0`), `topArea` (`>= 0`), `height` (`>= 0`). Rückgabe: `((bottomArea + topArea)/2) * height`.

`PrismFrustumLateralArea` - Berechnet die Mantelfläche eines Prisma-Stumpfs mit Umfangsmittel. Parameter: `bottomPerimeter` (`>= 0`), `topPerimeter` (`>= 0`), `height` (`>= 0`). Rückgabe: `((bottomPerimeter + topPerimeter)/2) * height`.

`PrismFrustumSurfaceArea` - Berechnet die Oberfläche eines Prisma-Stumpfs als Endflächen plus Mantelfläche. Parameter: `bottomArea` (`>= 0`), `topArea` (`>= 0`), `bottomPerimeter` (`>= 0`), `topPerimeter` (`>= 0`), `height` (`>= 0`).

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Werte, obere Maße nicht kleiner als untere Maße bei Kegel-/Pyramidenstumpf).
