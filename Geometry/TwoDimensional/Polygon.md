# Polygon (TwoDimensional.Polygon)

Statische Hilfsklasse für Berechnungen und Koordinatenoperationen an Polygonen (Fläche, Umfang, Formeigenschaften und Transformationen).

## Funktionen

`Area` - Berechnet die Fläche eines Polygons mit der Shoelace-Formel. Erwartet mindestens 3 Eckpunkte.

`Perimeter` - Berechnet den Umfang als Summe aller Kantenlängen. Erwartet mindestens 2 Eckpunkte.

`IsConvex` - Prüft, ob ein Polygon konvex ist (Vorzeichenprüfung der Kreuzprodukte). Erwartet mindestens 3 Eckpunkte und `tolerance > 0`.

`IsRegular` - Prüft, ob ein Polygon regelmäßig ist (gleich lange Seiten und gleicher Radius zum Schwerpunkt innerhalb der Toleranz). Erwartet mindestens 3 Eckpunkte und `tolerance > 0`.

`Centroid` - Berechnet den Flächenschwerpunkt des Polygons. Wirft `ArgumentException` bei degenerierten Polygonen (nahe Nullfläche).

`BoundingBox` - Berechnet das achsenparallele Begrenzungsrechteck als `System.Drawing.RectangleF`.

`Translate` - Verschiebt alle Eckpunkte um den Vektor `(dx, dy)` und liefert ein neues `PointF`-Array.

`Rotate` - Rotiert alle Eckpunkte um ein Rotationszentrum `center` mit Winkel `angleRadians` (Bogenmaß) und liefert ein neues `PointF`-Array.

## Hinweise

Die Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (z. B. `Nothing`, zu wenige Eckpunkte, ungültige Toleranz). Koordinatenoperationen arbeiten mit `System.Drawing.PointF` und geben Single-Precision-Werte zurück.
