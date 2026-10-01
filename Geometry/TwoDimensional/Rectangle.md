# Rectangle (TwoDimensional.Rectangle)

Statische Hilfsklasse für Berechnungen zu Rechtecken und Quadraten. Enthält Funktionen für Fläche, Umfang, Diagonalen, Radiusbeziehungen sowie Koordinatenhilfen auf Eckpunktbasis.

## Funktionen

`Area` - Berechnet die Fläche eines Rechtecks aus Breite w und Höhe h. Erwartet w,h >= 0; Rückgabe: w * h.

`Perimeter` - Berechnet den Umfang eines Rechtecks: 2 * (w + h). Enthält Guard-Clauses für negative Werte.

`Diagonal` - Berechnet die Diagonale eines Rechtecks: sqrt(w^2 + h^2).

`AspectRatio` - Liefert das Seitenverhältnis w / h. Wirft ArgumentException, wenn h = 0.

`IsSquare` - Prüft, ob w und h gleich sind (Quadrat).

`Circumradius` - Berechnet den Radius des Umkreises (Diagonale / 2).

`Inradius` - Berechnet den Radius des größten einbeschriebenen Kreises: min(w,h) / 2.

`AreaSquare` - Fläche eines Quadrats mit Seitenlänge s (s >= 0).

`PerimeterSquare` - Umfang eines Quadrats: 4 * s.

`DiagonalSquare` - Diagonale eines Quadrats: s * sqrt(2).

`FromDiagonalToSide` - Berechnet die Seitenlänge eines Quadrats aus der Diagonale d.

`Center` - Berechnet den Mittelpunkt zweier Punkte (Mittelwert der Koordinaten) und gibt ein System.Drawing.PointF zurück.

`VerticesFromCenter` - Liefert die 4 Eckpunkte (PointF) eines möglicherweise rotierten Rechtecks aus Mittelpunkt, Breite, Höhe und Winkel. Reihenfolge: oben links im Uhrzeigersinn.

`AreaFromVertices` - Berechnet die Fläche eines (evtl. konvexen) Polygons über die Shoelace-Formel. Erwartet mindestens 3 Punkte.

`PerimeterFromVertices` - Berechnet den Umfang eines Polygons als Summe der Kantenlängen.

`IsRectangleFromVertices` - Prüft, ob vier gegebene Punkte ein Rechteck bilden (rechte Winkel innerhalb einer Toleranz).

## Hinweise

Viele Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Längen oder Division durch 0). Koordinatenmethoden verwenden System.Drawing.PointF (Single-Precision) zur Rückgabe.
