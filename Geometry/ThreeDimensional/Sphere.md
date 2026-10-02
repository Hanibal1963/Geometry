# Sphere (ThreeDimensional.Sphere)

Statische Hilfsklasse für Berechnungen zu Kugeln (Volumen, Oberfläche, Großkreis, Kugelkappe und sphärische Koordinatenpunkte).

## Funktionen

`Volume` - Berechnet das Kugelvolumen: `(4/3) * PI * r^3`. Erwartet `radius >= 0`.

`SurfaceArea` - Berechnet die Kugeloberfläche: `4 * PI * r^2`. Erwartet `radius >= 0`.

`DiameterFromRadius` - Berechnet den Durchmesser aus dem Radius: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius aus dem Durchmesser: `d / 2`.

`GreatCircleCircumference` - Berechnet den Umfang des Großkreises: `2 * PI * r`.

`GreatCircleArea` - Berechnet die Fläche des Großkreises: `PI * r^2`.

`SphericalCapVolume` - Berechnet das Volumen einer Kugelkappe: `PI * h^2 * (r - h/3)`. Erwartet `radius > 0` und `0 <= capHeight <= 2 * radius`.

`SphericalCapArea` - Berechnet die gekrümmte Oberfläche einer Kugelkappe: `2 * PI * r * h`. Erwartet `radius > 0` und `0 <= capHeight <= 2 * radius`.

`PointOnSphere` - Berechnet einen Punkt auf der Kugeloberfläche aus Mittelpunkt, Radius und sphärischen Winkeln (`polarAngleRadians`, `azimuthRadians`) und liefert ein `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (z. B. negative Längen oder ungültige Winkelbereiche). Winkelparameter sind im Bogenmaß.
