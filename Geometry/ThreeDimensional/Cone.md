# Cone (ThreeDimensional.Cone)

Statische Hilfsklasse für Berechnungen zu Kegeln und Kegelstümpfen (Volumen, Flächen, Ableitungen und Koordinatenhilfe).

## Funktionen

`Volume` - Berechnet das Volumen eines geraden Kreiskegels: `(PI * r^2 * h) / 3`. Erwartet `radius >= 0` und `height >= 0`.

`SlantHeight` - Berechnet die Schräghöhe: `sqrt(r^2 + h^2)`. Erwartet `radius >= 0` und `height >= 0`.

`LateralArea` - Berechnet die Mantelfläche. Parameter: `radius` (`>= 0`), `height` (`>= 0`). Rückgabe: `PI * r * s`.

`SurfaceArea` - Berechnet die Gesamtoberfläche. Parameter: `radius` (`>= 0`), `height` (`>= 0`). Rückgabe: `PI * r * (r + s)`.

`DiameterFromRadius` - Berechnet den Durchmesser. Parameter: `radius` (`>= 0`). Rückgabe: `2 * r`.

`RadiusFromDiameter` - Berechnet den Radius. Parameter: `diameter` (`>= 0`). Rückgabe: `d / 2`.

`FrustumVolume` - Berechnet das Volumen eines Kegelstumpfs: `(PI * h / 3) * (R^2 + Rr + r^2)`. Erwartet `radiusBottom > 0`, `radiusTop >= 0`, `radiusTop < radiusBottom`, `height >= 0`.

`FrustumLateralArea` - Berechnet die Mantelfläche eines Kegelstumpfs. Parameter: `radiusBottom` (`> 0`), `radiusTop` (`>= 0`, `< radiusBottom`), `height` (`>= 0`). Rückgabe: `PI * (R + r) * s`.

`FrustumSurfaceArea` - Berechnet die Gesamtoberfläche eines Kegelstumpfs (Mantel + beide Grundflächen). Parameter: `radiusBottom` (`> 0`), `radiusTop` (`>= 0`, `< radiusBottom`), `height` (`>= 0`).

`PointOnLateralSurface` - Berechnet einen Punkt auf der Mantelfläche. Parameter: `centerX`, `centerY` (Kreismittelpunkt), `baseZ` (Basis-Z), `radius` (`>= 0`), `height` (`>= 0`), `angleRadians` (Bogenmaß), `t` (`0 <= t <= 1`). Rückgabe: `Tuple(Of Double, Double, Double)`.

## Hinweise

Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Eingaben (z. B. negative Längen oder ungültige Radiusrelationen). Winkel sind im Bogenmaß angegeben.
