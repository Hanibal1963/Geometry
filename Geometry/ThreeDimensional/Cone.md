# Cone (ThreeDimensional.Cone)

Statische Hilfsklasse für Berechnungen zu Kegeln und Kegelstümpfen (Volumen, Flächen, Ableitungen und Koordinatenhilfe).

## Funktionen

`Volume` - Berechnet das Volumen eines geraden Kreiskegels: `(PI * r^2 * h) / 3`. Erwartet `radius >= 0` und `height >= 0`.

`SlantHeight` - Berechnet die Schräghöhe: `sqrt(r^2 + h^2)`. Erwartet `radius >= 0` und `height >= 0`.

`LateralArea` - Berechnet die Mantelfläche: `PI * r * s`.

`SurfaceArea` - Berechnet die Gesamtoberfläche: `PI * r * (r + s)`.

`DiameterFromRadius` - Berechnet den Durchmesser: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius: `d / 2`.

`FrustumVolume` - Berechnet das Volumen eines Kegelstumpfs: `(PI * h / 3) * (R^2 + Rr + r^2)`. Erwartet `radiusBottom > 0`, `radiusTop >= 0`, `radiusTop < radiusBottom`, `height >= 0`.

`FrustumLateralArea` - Berechnet die Mantelfläche eines Kegelstumpfs: `PI * (R + r) * s`.

`FrustumSurfaceArea` - Berechnet die Gesamtoberfläche eines Kegelstumpfs (Mantel + beide Grundflächen).

`PointOnLateralSurface` - Berechnet einen Punkt auf der Mantelfläche aus Grundflächenmittelpunkt, Radius, Höhe, Winkel und Parameter `t` mit `0 <= t <= 1`. Rückgabe als `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder ungültige Radiusrelationen). Winkel sind im Bogenmaß angegeben.
