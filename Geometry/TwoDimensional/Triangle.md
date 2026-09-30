# Triangle (TwoDimensional.Triangle)

Statische Hilfsklasse für Berechnungen zu Dreiecken (Fläche, Umfang, Winkel, Seitenbeziehungen und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus Grundseite `b` und Höhe `h`: `(b * h) / 2`. Erwartet `b,h >= 0`.

`Perimeter` - Berechnet den Umfang aus drei Seiten: `a + b + c`. Erwartet `a,b,c > 0` und gültige Dreiecksungleichung.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseite: `(2 * area) / b`. Wirft `ArgumentException` bei `area < 0` oder `b <= 0`.

`AreaHeron` - Berechnet die Fläche mit der Heron-Formel aus den Seitenlängen. Erwartet gültige Seiten.

`AngleFromSides` - Berechnet einen Innenwinkel (Bogenmaß) über den Kosinussatz aus `opposite`, `adjacent1`, `adjacent2`.

`SideLengthsFromVertices` - Berechnet die Seitenlängen aus drei Eckpunkten (`PointF`) und liefert `[AB, BC, CA]`.

`AreaFromVertices` - Berechnet die Dreiecksfläche aus drei Eckpunkten mit der Shoelace-Formel.

`PerimeterFromVertices` - Berechnet den Umfang aus drei Eckpunkten als Summe der Seitenlängen.

`Centroid` - Berechnet den Schwerpunkt (Centroid) aus drei Eckpunkten.

`IsValidTriangleFromVertices` - Prüft, ob drei Eckpunkte ein gültiges Dreieck mit Fläche größer als Toleranz bilden.

## Hinweise

Viele Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern. Winkelparameter und Rückgabewerte sind im Bogenmaß. Koordinatenmethoden verwenden `System.Drawing.PointF` (Single-Precision bei Rückgabewerten).
