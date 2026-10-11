# Sphere (ThreeDimensional.Sphere)

Statische Hilfsklasse für Berechnungen zu Kugeln (Volumen, Oberfläche, Großkreis, Kugelkappe und sphärische Koordinatenpunkte).

## Funktionen

`Volume` - Berechnet das Kugelvolumen. Parameter: `radius` (`>= 0`). Rückgabe: `(4/3) * PI * r^3`.

`SurfaceArea` - Berechnet die Kugeloberfläche. Parameter: `radius` (`>= 0`). Rückgabe: `4 * PI * r^2`.

`DiameterFromRadius` - Berechnet den Durchmesser aus dem Radius. Parameter: `radius` (`>= 0`). Rückgabe: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius aus dem Durchmesser. Parameter: `diameter` (`>= 0`). Rückgabe: `d / 2`.

`GreatCircleCircumference` - Berechnet den Umfang des Großkreises. Parameter: `radius` (`>= 0`). Rückgabe: `2 * PI * r`.

`GreatCircleArea` - Berechnet die Fläche des Großkreises. Parameter: `radius` (`>= 0`). Rückgabe: `PI * r^2`.

`SphericalCapVolume` - Berechnet das Volumen einer Kugelkappe. Parameter: `radius` (`> 0`), `capHeight` (`0 <= capHeight <= 2 * radius`). Rückgabe: `PI * h^2 * (r - h/3)`.

`SphericalCapArea` - Berechnet die gekrümmte Oberfläche einer Kugelkappe. Parameter: `radius` (`> 0`), `capHeight` (`0 <= capHeight <= 2 * radius`). Rückgabe: `2 * PI * r * h`.

`PointOnSphere` - Berechnet einen Punkt auf der Kugeloberfläche aus Mittelpunkt, Radius und sphärischen Winkeln. Parameter: `centerX`, `centerY`, `centerZ` (Mittelpunkt), `radius` (`>= 0`), `polarAngleRadians`, `azimuthRadians` (Bogenmaß). Rückgabe: `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (z. B. negative Längen oder ungültige Winkelbereiche). Winkelparameter sind im Bogenmaß.
