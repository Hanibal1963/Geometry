# Cylinder (ThreeDimensional.Cylinder)

Statische Hilfsklasse für Berechnungen zu Voll- und Hohlzylindern (Volumen, Flächen, Basisgrößen und Koordinatenhilfen).

## Funktionen

`Volume` - Berechnet das Volumen eines Vollzylinders. Parameter: `radius` (`>= 0`), `height` (`>= 0`). Rückgabe: `PI * r^2 * h`.

`LateralArea` - Berechnet die Mantelfläche. Parameter: `radius` (`>= 0`), `height` (`>= 0`). Rückgabe: `2 * PI * r * h`.

`SurfaceArea` - Berechnet die Gesamtoberfläche eines Vollzylinders. Parameter: `radius` (`>= 0`), `height` (`>= 0`). Rückgabe: `2 * PI * r * (r + h)`.

`BaseCircumference` - Berechnet den Umfang des Grundkreises. Parameter: `radius` (`>= 0`). Rückgabe: `2 * PI * r`.

`BaseArea` - Berechnet die Fläche des Grundkreises. Parameter: `radius` (`>= 0`). Rückgabe: `PI * r^2`.

`DiameterFromRadius` - Berechnet den Durchmesser. Parameter: `radius` (`>= 0`). Rückgabe: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius. Parameter: `diameter` (`>= 0`). Rückgabe: `d / 2`.

`HollowVolume` - Berechnet das Volumen eines Hohlzylinders. Parameter: `outerRadius` (`> 0`), `innerRadius` (`>= 0`, `< outerRadius`), `height` (`>= 0`). Rückgabe: `PI * (R^2 - r^2) * h`.

`HollowSurfaceArea` - Berechnet die Gesamtoberfläche eines Hohlzylinders (Außenmantel + Innenmantel + beide Ringflächen). Parameter: `outerRadius` (`> 0`), `innerRadius` (`>= 0`, `< outerRadius`), `height` (`>= 0`).

`PointOnLateralSurface` - Berechnet einen Punkt auf der Mantelfläche aus Achsenmittelpunkt, Radius, Winkel und Höhenoffset. Parameter: `centerX`, `centerY`, `baseZ`, `radius`, `height`, `angleRadians`, `heightOffset`. Rückgabe: `Tuple(Of Double, Double, Double)`.

## Hinweise

Die Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (negative Längen, ungültige Radienrelation oder ungültiger Höhenoffset). Winkelparameter sind im Bogenmaß.
