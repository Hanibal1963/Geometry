# Triangle (TwoDimensional.Triangle)

Statische Hilfsklasse für Berechnungen zu Dreiecken (Fläche, Umfang, Winkel, Seitenbeziehungen und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus Grundseite und Höhe. Parameter: `b` (Grundseite, `>= 0`), `h` (Höhe, `>= 0`). Rückgabe: `(b * h) / 2`.

`Perimeter` - Berechnet den Umfang aus drei Seiten. Parameter: `a`, `b`, `c` (Seiten, `> 0`, gültige Dreiecksungleichung). Rückgabe: `a + b + c`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite. Parameter: `area` (`>= 0`), `b` (`> 0`). Rückgabe: `(2 * area) / b`.

`AreaHeron` - Berechnet die Fläche mit der Heron-Formel aus den Seitenlängen. Parameter: `a`, `b`, `c` (Seiten, `> 0`, gültige Dreiecksungleichung).

`AngleFromSides` - Berechnet einen Innenwinkel (Bogenmaß) über den Kosinussatz. Parameter: `opposite`, `adjacent1`, `adjacent2` (Seiten, `> 0`, gültige Dreiecksungleichung).

`SideLengthsFromVertices` - Berechnet die Seitenlängen aus drei Eckpunkten. Parameter: `vertices` (Array mit genau drei Eckpunkten als `PointF`). Rückgabe: `[AB, BC, CA]`.

`AreaFromVertices` - Berechnet die Dreiecksfläche aus drei Eckpunkten mit der Shoelace-Formel. Parameter: `vertices` (Array mit genau drei Eckpunkten als `PointF`).

`PerimeterFromVertices` - Berechnet den Umfang aus drei Eckpunkten als Summe der Seitenlängen. Parameter: `vertices` (Array mit genau drei Eckpunkten als `PointF`).

`Centroid` - Berechnet den Schwerpunkt (Centroid) aus drei Eckpunkten. Parameter: `vertices` (Array mit genau drei Eckpunkten als `PointF`).

`IsValidTriangleFromVertices` - Prüft, ob drei Eckpunkte ein gültiges Dreieck mit Fläche größer als Toleranz bilden. Parameter: `vertices` (Array mit genau drei Eckpunkten als `PointF`), `tolerance` (`> 0`, optional).

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern. Winkelparameter und Rückgabewerte sind im Bogenmaß. Koordinatenmethoden verwenden `System.Drawing.PointF` (Single-Precision bei Rückgabewerten).
