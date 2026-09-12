# Ellipse (TwoDimensional.Ellipse)

Beschreibung

Statische Hilfsklasse zur Arbeit mit Ellipsen (Geometrie, Tangenten/Normalen, Perimeter-Approximationen, numerische Integration, nächster Punkt, Anomalienkonversionen).

## Öffentliche Mitglieder und Strukturen

- Public Structure LineEquation
  - Repräsentiert eine Gerade: entweder y = m*x + c (IsVertical = False, Slope = m, Intercept = c) oder x = X (IsVertical = True, X = konstante x).

- Public Shared Function Area(a As Double, b As Double) As Double
  - Fläche der Ellipse: π * a * b. Erwartet a,b > 0.

- Public Shared Function Eccentricity(a As Double, b As Double) As Double
  - Exzentrizität e = sqrt(1 - (b^2 / a^2)). Intern wird a >= b sichergestellt.

- Public Shared Function FocalDistance(a As Double, b As Double) As Double
  - Abstand der Brennpunkte vom Zentrum: c = sqrt(a^2 - b^2) (setzt a >= b voraus).

- Public Shared Function IsCircle(a As Double, b As Double) As Boolean
  - Prüft, ob a und b praktisch gleich sind (Kreis).

- Public Shared Function PointOnEllipse(a As Double, b As Double, theta As Double) As System.Drawing.PointF
  - Punkt (x,y) auf Ellipse für Parameter theta: x = a*cos(theta), y = b*sin(theta).

- Public Shared Function TangentAt(a As Double, b As Double, theta As Double) As LineEquation
  - Liefert die Tangentengleichung an der Ellipse im Parameter theta. Bei vertikaler Tangente ist IsVertical = True.

- Public Shared Function NormalAt(a As Double, b As Double, theta As Double) As LineEquation
  - Liefert die Normale an der Ellipse im Parameter theta.

- Public Shared Function RadiusOfCurvature(a As Double, b As Double, theta As Double) As Double
  - Krümmungsradius an der Ellipse im Parameter theta. Gibt Infinity zurück, falls degeneriert.

- Public Shared Function PerimeterRamanujan(a As Double, b As Double) As Double
  - Ramanujan 1. Näherung für Umfang.

- Public Shared Function PerimeterRamanujan2(a As Double, b As Double) As Double
  - Ramanujan 2. Näherung (genauer bei hoher Exzentrizität).

- Public Shared Function PerimeterNumeric(a As Double, b As Double, Optional subdivisions As Integer = 1024) As Double
  - Numerische Simpson-Integration zur genauen Bestimmung des Umfangs. subdivisions muss gerade und >= 2 sein.

- Public Shared Function ArcLength(a As Double, b As Double, theta1 As Double, theta2 As Double, Optional subdivisions As Integer = 1024) As Double
  - Numerische Berechnung der Bogenlänge zwischen zwei Parametern (Simpson).

- Public Shared Function ClosestPointOnEllipse(a As Double, b As Double, px As Double, py As Double, Optional initialTheta As Double = 0.0, Optional maxIter As Integer = 1000, Optional tol As Double = 1E-15) As Tuple(Of System.Drawing.PointF, Double)
  - Findet iterativ (Newton) den nächsten Punkt auf der Ellipse zum Punkt (px,py). Rückgabe: Tuple(PointF closestPoint, Double distance).

- Public Shared Function EccentricToTrueAnomaly(E As Double, a As Double, b As Double) As Double
  - Konvertiert exzentrische Anomalie E in wahre Anomalie ν.

- Public Shared Function TrueToEccentricAnomaly(v As Double, a As Double, b As Double) As Double
  - Konvertiert wahre Anomalie ν in exzentrische Anomalie E.

Hinweise

- Validierung: Fast alle öffentlichen Funktionen prüfen a,b > 0 und werfen ArgumentException bei invaliden Achsen.
- Numerische Integrationen verwenden interne SimpsonIntegrate-Hilfsmethode.
- LineEquation ist eine einfache Struktur, die Tangenten/Normalen bequem repräsentiert.
