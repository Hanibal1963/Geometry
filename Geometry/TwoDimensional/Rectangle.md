# Rectangle (TwoDimensional.Rectangle)

Beschreibung

Statische Hilfsklasse für Berechnungen zu Rechtecken und Quadraten (Flächen, Umfang, Diagonale, Koordinatenbasisfunktionen).

## Öffentliche Mitglieder

- Public Shared Function Area(w As Double, h As Double) As Double
  - Berechnet die Fläche eines Rechtecks. Erwartet w,h >= 0. Rückgabe: w * h.

- Public Shared Function Perimeter(w As Double, h As Double) As Double
  - Berechnet den Umfang: 2 * (w + h). Guard-Clauses für negative Werte.

- Public Shared Function Diagonal(w As Double, h As Double) As Double
  - Berechnet die Diagonale: sqrt(w^2 + h^2).

- Public Shared Function AspectRatio(w As Double, h As Double) As Double
  - Seitenverhältnis (w / h). Wirft ArgumentException wenn h = 0.

- Public Shared Function IsSquare(w As Double, h As Double) As Boolean
  - Prüft, ob w = h (Quadrat).

- Public Shared Function Circumradius(w As Double, h As Double) As Double
  - Radius des Umkreises: Diagonale / 2.

- Public Shared Function Inradius(w As Double, h As Double) As Double
  - Radius des größten einbeschriebenen Kreises: min(w,h) / 2.

- Public Shared Function Center(x1 As Double, y1 As Double, x2 As Double, y2 As Double) As System.Drawing.PointF
  - Berechnet den Mittelpunkt zweier Punkte (Mittelwert der Koordinaten).

- Public Shared Function VerticesFromCenter(cx As Double, cy As Double, w As Double, h As Double, angleRadians As Double) As System.Drawing.PointF()
  - Liefert die 4 Eckpunkte (PointF) eines möglicherweise rotierten Rechtecks aus Mittelpunkt, Breite, Höhe und Winkel. Reihenfolge: oben links im Uhrzeigersinn.

- Public Shared Function AreaFromVertices(vertices As System.Drawing.PointF()) As Double
  - Berechnet die Fläche eines (evtl. konvexen) Polygons über die Shoelace-Formel. Erwartet mindestens 3 Punkte.

- Public Shared Function PerimeterFromVertices(vertices As System.Drawing.PointF()) As Double
  - Berechnet den Umfang eines Polygons als Summe der Kantenlängen.

- Public Shared Function IsRectangleFromVertices(vertices As System.Drawing.PointF()) As Boolean
  - Prüft, ob vier gegebene Punkte ein Rechteck bilden (rechte Winkel innerhalb Toleranz).

- Public Shared Function AreaSquare(s As Double) As Double
  - Fläche eines Quadrats mit Seitenlänge s (s >= 0).

- Public Shared Function PerimeterSquare(s As Double) As Double
  - Umfang eines Quadrats: 4 * s.

- Public Shared Function DiagonalSquare(s As Double) As Double
  - Diagonale eines Quadrats: s * sqrt(2).

- Public Shared Function FromDiagonalToSide(d As Double) As Double
  - Berechnet die Seitenlänge eines Quadrats aus der Diagonale d.

Hinweise

- Viele Methoden werfen ArgumentException bei ungültigen Parametern (z. B. negative Längen oder Division durch 0).
- Koordinatenmethoden verwenden System.Drawing.PointF (Single-Precision) zur Rückgabe.
