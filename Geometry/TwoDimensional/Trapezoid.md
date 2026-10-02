# Trapezoid (TwoDimensional.Trapezoid)

Statische Hilfsklasse für Berechnungen zu Trapezen (Fläche, Umfang, Mittellinie, gleichschenklige Eigenschaften und koordinatenbasierte Hilfsfunktionen).

## Funktionen

`Area` - Berechnet die Fläche aus den parallelen Grundseiten und der Höhe. Parameter: `baseA` (`>= 0`), `baseB` (`>= 0`), `height` (`>= 0`). Rückgabe: `((baseA + baseB) / 2) * height`.

`Perimeter` - Berechnet den Umfang aus allen vier Seiten. Parameter: `baseA` (`> 0`), `legB` (`> 0`), `baseC` (`> 0`), `legD` (`> 0`). Rückgabe: `baseA + legB + baseC + legD`.

`Midline` - Berechnet die Mittellinie. Parameter: `baseA` (`>= 0`), `baseB` (`>= 0`). Rückgabe: `(baseA + baseB) / 2`.

`HeightFromArea` - Berechnet die Höhe aus Fläche und Grundseiten. Parameter: `area` (`>= 0`), `baseA` (`>= 0`), `baseB` (`>= 0`). Rückgabe: `(2 * area) / (baseA + baseB)`.

`LegLengthIsosceles` - Berechnet die Schenkellänge eines gleichschenkligen Trapezes aus Grundseiten und Höhe. Parameter: `baseA`, `baseB` (Grundseiten, `>= 0`), `height` (`>= 0`).

`IsIsosceles` - Prüft, ob ein Trapez gleichschenklig ist (`|legB - legD| <= tolerance`). Parameter: `legB` (`> 0`), `legD` (`> 0`), `tolerance` (`> 0`).

`VerticesFromCenter` - Berechnet 4 Eckpunkte eines gleichschenkligen Trapezes aus Mittelpunkt, beiden Grundseiten, Höhe und Rotation (Bogenmaß). Parameter: `cx`, `cy` (Mittelpunkt), `baseA`, `baseB` (Grundseiten, `>= 0`), `height` (`>= 0`), `rotationRadians`.

`AreaFromVertices` - Berechnet die Fläche aus 4 Eckpunkten über die Shoelace-Formel. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`PerimeterFromVertices` - Berechnet den Umfang aus 4 Eckpunkten als Summe der Kantenlängen. Parameter: `vertices` (4 Eckpunkte als `PointF()`).

`IsTrapezoidFromVertices` - Prüft, ob 4 Eckpunkte ein Trapez bilden (mindestens ein Paar gegenüberliegender Seiten parallel, innerhalb einer Toleranz). Parameter: `vertices` (4 Eckpunkte), `tolerance` (`> 0`).

## Hinweise

Die Methoden nutzen Guard-Clauses und werfen `ArgumentException` bei ungültigen Parametern (`Nothing`, falsche Eckpunktanzahl, negative Längen, ungültige Toleranz). Koordinatenfunktionen verwenden `System.Drawing.PointF`.
