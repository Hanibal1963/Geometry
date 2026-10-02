# Triangle (TwoDimensional.Triangle)

Statische Hilfsklasse für Berechnungen zu Dreiecken (Fläche, Umfang, Winkel, Seitenbeziehungen und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus Grundseite `b` und Höhe `h`: `(b * h) / 2`. Erwartet `b,h >= 0`.

`Perimeter` - Berechnet den Umfang aus drei Seiten: `a + b + c`. Erwartet `a,b,c > 0` und gültige Dreiecksungleichung.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite: `(2 * area) / b`. Wirft `ArgumentException` bei `area < 0` oder `b <= 0`.

`AreaHeron` - Berechnet die Fläche mit der Heron-Formel aus den Seitenlängen. Parameter: `a`, `b`, `c` (Seiten, `> 0`, gültige Dreiecksungleichung).

`AngleFromSides` - Berechnet einen Innenwinkel (Bogenmaß) über den Kosinussatz. Parameter: `opposite`, `adjacent1`, `adjacent2` (Seiten, `> 0`, gültige Dreiecksungleichung).

`SideLengthsFromVertices` - Berechnet die Seitenlängen aus drei Eckpunkten. Parameter: `a`, `b`, `c` (Eckpunkte als `PointF`). Rückgabe: `[AB, BC, CA]`.

`AreaFromVertices` - Berechnet die Dreiecksfläche aus drei Eckpunkten mit der Shoelace-Formel. Parameter: `a`, `b`, `c` (Eckpunkte als `PointF`).

`PerimeterFromVertices` - Berechnet den Umfang aus drei Eckpunkten als Summe der Seitenlängen. Parameter: `a`, `b`, `c` (Eckpunkte als `PointF`).

`Centroid` - Berechnet den Schwerpunkt (Centroid) aus drei Eckpunkten. Parameter: `a`, `b`, `c` (Eckpunkte als `PointF`).

`IsValidTriangleFromVertices` - Prüft, ob drei Eckpunkte ein gültiges Dreieck mit Fläche größer als Toleranz bilden. Parameter: `a`, `b`, `c` (Eckpunkte als `PointF`), `tolerance` (`> 0`).

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern. Winkelparameter und Rückgabewerte sind im Bogenmaß. Koordinatenmethoden verwenden `System.Drawing.PointF` (Single-Precision bei Rückgabewerten).
