# Cylinder (ThreeDimensional.Cylinder)

Statische Hilfsklasse für Berechnungen zu Voll- und Hohlzylindern (Volumen, Flächen, Basisgrößen und Koordinatenhilfen).

## Funktionen

`Volume` - Berechnet das Volumen eines Vollzylinders: `PI * r^2 * h`. Erwartet `radius, height >= 0`.

`LateralArea` - Berechnet die Mantelfläche: `2 * PI * r * h`. Erwartet `radius, height >= 0`.

`SurfaceArea` - Berechnet die Gesamtoberfläche eines Vollzylinders: `2 * PI * r * (r + h)`.

`BaseCircumference` - Berechnet den Umfang des Grundkreises: `2 * PI * r`.

`BaseArea` - Berechnet die Fläche des Grundkreises: `PI * r^2`.

`DiameterFromRadius` - Berechnet den Durchmesser: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius: `d / 2`.

`HollowVolume` - Berechnet das Volumen eines Hohlzylinders: `PI * (R^2 - r^2) * h`. Erwartet `outerRadius > 0`, `0 <= innerRadius < outerRadius`, `height >= 0`.

`HollowSurfaceArea` - Berechnet die Gesamtoberfläche eines Hohlzylinders (Außenmantel + Innenmantel + beide Ringflächen).

`PointOnLateralSurface` - Berechnet einen Punkt auf der Mantelfläche aus Achsenmittelpunkt, Radius, Winkel und Höhenoffset und liefert `Tuple(Of Double, Double, Double)`.

## Hinweise

Die Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (negative Längen, ungültige Radienrelation oder ungültiger Höhenoffset). Winkelparameter sind im Bogenmaß.
