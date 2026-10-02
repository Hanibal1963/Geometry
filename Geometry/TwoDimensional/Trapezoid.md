# Trapezoid (TwoDimensional.Trapezoid)

Statische Hilfsklasse für Berechnungen zu Trapezen (Fläche, Umfang, Mittellinie, gleichschenklige Eigenschaften und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus den parallelen Grundseiten `baseA`, `baseB` und der Höhe `height`: `((baseA + baseB) / 2) * height`. Erwartet `baseA, baseB, height >= 0`.

`Perimeter` - Berechnet den Umfang aus allen vier Seiten: `baseA + legB + baseC + legD`. Erwartet alle Seiten `> 0`.

`Midline` - Berechnet die Mittellinie: `(baseA + baseB) / 2`. Erwartet `baseA, baseB >= 0`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseiten: `(2 * area) / (baseA + baseB)`. Wirft `ArgumentException` bei ungültigen Eingaben oder wenn `baseA + baseB <= 0`.

`LegLengthIsosceles` - Berechnet die Schenkellänge eines gleichschenkligen Trapezes aus Grundseiten und Höhe.

`IsIsosceles` - Prüft, ob ein Trapez gleichschenklig ist (`|legB - legD| <= tolerance`). Erwartet `legB, legD > 0` und `tolerance > 0`.

`VerticesFromCenter` - Berechnet 4 Eckpunkte eines gleichschenkligen Trapezes aus Mittelpunkt, beiden Grundseiten, Höhe und Rotation (Bogenmaß).

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten über die Shoelace-Formel.

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen.

`IsTrapezoidFromVertices` - Prüft, ob 4 Eckpunkte ein Trapez bilden (mindestens ein Paar gegenüberliegender Seiten parallel, innerhalb einer Toleranz).

## Hinweise

Die Methoden nutzen Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (`Nothing`, falsche Eckpunktanzahl, negative Längen, ungültige Toleranz). Koordinatenfunktionen verwenden `System.Drawing.PointF`.
