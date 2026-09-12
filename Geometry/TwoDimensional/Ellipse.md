# Ellipse (TwoDimensional.Ellipse)

Statische Hilfsklasse zur Arbeit mit Ellipsen (Geometrie, Tangenten/Normalen, Umfangsapproximationen, numerische Integration, nächster Punkt, Anomalienkonversionen).

## Funktionen

`Area` - Berechnet die Fläche der Ellipse: π * a * b. Erwartet a,b > 0.

`Eccentricity` - Berechnet die Exzentrizität e = sqrt(1 - (b^2 / a^2)). Intern wird a >= b sichergestellt.

`FocalDistance` - Abstand der Brennpunkte vom Zentrum: c = sqrt(a^2 - b^2) (setzt a >= b voraus).

`IsCircle` - Prüft, ob a und b praktisch gleich sind (Kreis).

`PerimeterRamanujan` - Ramanujan 1. Näherung für den Umfang einer Ellipse.

`PerimeterRamanujan2` - Ramanujan 2. Näherung, genauer bei hoher Exzentrizität.

`PerimeterNumeric` - Numerische Simpson-Integration zur genauen Bestimmung des Umfangs. Der Parameter subdivisions muss gerade und >= 2 sein.

`PointOnEllipse` - Berechnet den Punkt (x,y) auf der Ellipse für den Parameter theta: x = a*cos(theta), y = b*sin(theta).

`TangentAt` - Liefert die Tangentengleichung an der Ellipse im Parameter theta. Bei vertikaler Tangente ist IsVertical = True.

`NormalAt` - Liefert die Normale an der Ellipse im Parameter theta.

`RadiusOfCurvature` - Berechnet den Krümmungsradius an der Ellipse im Parameter theta. Gibt Infinity zurück, falls degeneriert.

`ArcLength` - Numerische Berechnung der Bogenlänge zwischen zwei Parametern (Simpson-Integration).

`ClosestPointOnEllipse` - Findet iterativ (Newton) den nächsten Punkt auf der Ellipse zum Punkt (px,py). Rückgabe: Tuple(PointF closestPoint, Double distance).

`EccentricToTrueAnomaly` - Konvertiert exzentrische Anomalie E in wahre Anomalie ν.

`TrueToEccentricAnomaly` - Konvertiert wahre Anomalie ν in exzentrische Anomalie E.

## Strukturen

`LineEquation` - Struktur zur Darstellung einer Geradengleichung: entweder y = m*x + c (IsVertical = False) oder x = X (IsVertical = True).

## Hinweise

Fast alle Funktionen prüfen a,b > 0 und werfen ArgumentException bei invaliden Achsen. Numerische Integrationen verwenden interne SimpsonIntegrate-Hilfsmethoden.
