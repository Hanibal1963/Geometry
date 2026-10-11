# Polygon (TwoDimensional.Polygon)

Statische Hilfsklasse für Polygonberechnungen und Koordinatenoperationen. Behandelt allgemeine Polygone und stellt dafür Flächen-, Umfangs-, Formeigenschafts- sowie Transformationsfunktionen bereit.

## Funktionen

`Area` - Berechnet die Fläche eines Polygons mit der Shoelace-Formel. Parameter: `vertices` (mindestens 3 Eckpunkte als `PointF()`).

`Perimeter` - Berechnet den Umfang als Summe aller Kantenlängen. Parameter: `vertices` (mindestens 2 Eckpunkte als `PointF()`).

`IsConvex` - Prüft, ob ein Polygon konvex ist (Vorzeichenprüfung der Kreuzprodukte). Parameter: `vertices` (mindestens 3 Eckpunkte), `tolerance` (`> 0`, optional).

`IsRegular` - Prüft, ob ein Polygon regelmäßig ist (gleich lange Seiten und gleicher Radius zum Schwerpunkt innerhalb der Toleranz). Parameter: `vertices` (mindestens 3 Eckpunkte), `tolerance` (`> 0`, optional).

`Centroid` - Berechnet den Flächenschwerpunkt des Polygons. Parameter: `vertices` (mindestens 3 Eckpunkte). Wirft `ArgumentException` bei degenerierten Polygonen.

`BoundingBox` - Berechnet das achsenparallele Begrenzungsrechteck. Parameter: `vertices` (mindestens 1 Eckpunkt). Rückgabe: `System.Drawing.RectangleF`.

`Translate` - Verschiebt alle Eckpunkte um den Vektor `(dx, dy)`. Parameter: `vertices` (mindestens 1 Eckpunkt), `dx` (X-Verschiebung), `dy` (Y-Verschiebung).

`Rotate` - Rotiert alle Eckpunkte um ein Rotationszentrum. Parameter: `vertices` (mindestens 1 Eckpunkt), `angleRadians` (Bogenmaß), `center` (Rotationszentrum als `PointF`).

## Hinweise

Die Methoden verwenden Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (z. B. `Nothing`, zu wenige Eckpunkte, ungültige Toleranz). Koordinatenoperationen arbeiten mit `System.Drawing.PointF` und geben Single-Precision-Werte zurück.
