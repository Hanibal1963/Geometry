# Ellipse (TwoDimensional.Ellipse)

Statische Hilfsklasse zur Arbeit mit Ellipsen (Geometrie, Tangenten/Normalen, Umfangsapproximationen, numerische Integration, nächster Punkt, Anomalienkonversionen).

## Funktionen

`Area` - Berechnet die Fläche der Ellipse. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`). Rückgabe: `π * a * b`.

`Eccentricity` - Berechnet die Exzentrizität. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`). Formel: `sqrt(1 - (b^2 / a^2))`, intern mit `a >= b`.

`FocalDistance` - Berechnet den Abstand der Brennpunkte vom Zentrum. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`). Formel: `sqrt(a^2 - b^2)`, intern mit `a >= b`.

`IsCircle` - Prüft, ob die Ellipse praktisch ein Kreis ist. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`).

`PerimeterRamanujan` - Berechnet die 1. Ramanujan-Näherung des Umfangs. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`).

`PerimeterRamanujan2` - Berechnet die 2. Ramanujan-Näherung des Umfangs. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`).

`PerimeterNumeric` - Berechnet den Umfang numerisch mit Simpson-Integration. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `subdivisions` (Unterteilungen, wird auf gerade Zahl `>= 2` normalisiert).

`PointOnEllipse` - Berechnet einen Punkt auf der Ellipse. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `theta` (Parameterwinkel im Bogenmaß). Rückgabe: `PointF(x, y)` mit `x = a*cos(theta)`, `y = b*sin(theta)`.

`TangentAt` - Liefert die Tangentengleichung an der Ellipse. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `theta` (Parameterwinkel im Bogenmaß). Bei vertikaler Tangente ist `IsVertical = True`.

`NormalAt` - Liefert die Normale an der Ellipse. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `theta` (Parameterwinkel im Bogenmaß).

`RadiusOfCurvature` - Berechnet den Krümmungsradius an der Ellipse. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `theta` (Parameterwinkel im Bogenmaß). Gibt `Infinity` zurück, falls degeneriert.

`ArcLength` - Berechnet die Bogenlänge numerisch zwischen zwei Parametern. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `theta1` (Startwinkel), `theta2` (Endwinkel), `subdivisions` (Unterteilungen, wird auf gerade Zahl `>= 2` normalisiert).

`ClosestPointOnEllipse` - Findet iterativ (Newton) den nächsten Punkt auf der Ellipse zu einem Referenzpunkt. Parameter: `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`), `px` (X des Referenzpunkts), `py` (Y des Referenzpunkts), `initialTheta` (optional Startwert), `maxIter` (max. Iterationen), `tol` (Abbruch-Toleranz). Rückgabe: `Tuple(PointF closestPoint, Double distance)`.

`EccentricToTrueAnomaly` - Konvertiert exzentrische Anomalie `E` in wahre Anomalie `ν`. Parameter: `E` (exzentrische Anomalie), `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`).

`TrueToEccentricAnomaly` - Konvertiert wahre Anomalie `ν` in exzentrische Anomalie `E`. Parameter: `v` (wahre Anomalie), `a` (Halbachse a, `a > 0`), `b` (Halbachse b, `b > 0`).

## Strukturen

`LineEquation` - Struktur zur Darstellung einer Geradengleichung: entweder y = m*x + c (IsVertical = False) oder x = X (IsVertical = True).

## Hinweise

Fast alle Funktionen prüfen a,b > 0 und werfen ArgumentException bei invaliden Achsen. Numerische Integrationen verwenden interne SimpsonIntegrate-Hilfsmethoden.
