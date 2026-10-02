' --------------------------------------------------------------------------------------------------------
' Datei: Ellipse.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------
Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Imports System.Drawing

Namespace TwoDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Ellipsen bereit.
    ''' </summary>
    Public Class Ellipse


        ''' <summary>
        ''' Repräsentiert eine Geradengleichung der Form y = m*x + c oder eine vertikale Gerade x = X.
        ''' </summary>
        Public Structure LineEquation
            Public IsVertical As Boolean
            Public Slope As Double
            Public Intercept As Double
            Public X As Double
        End Structure

        ' --- Validierungshilfe ---
        Private Shared Sub ValidateAxes(a As Double, b As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a <= 0 OrElse b <= 0 Then
                Throw New ArgumentException("Die Halbachsen müssen größer als 0 sein (a>0, b>0).")
            End If
        End Sub

        ''' <summary>
        ''' Fläche der Ellipse (A = π * a * b)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Fläche der Ellipse</returns>
        Public Shared Function Area(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Return Math.PI * a * b
        End Function

        ''' <summary>
        ''' Eccentricity e = sqrt(1 - (b^2 / a^2)). Sortiert intern so, dass a >= b.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Exzentrizität der Ellipse</returns>
        Public Shared Function Eccentricity(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim aa = Math.Max(a, b)
            Dim bb = Math.Min(a, b)
            Return Math.Sqrt(Math.Max(0.0, 1.0 - (bb * bb / (aa * aa))))
        End Function

        ''' <summary>
        ''' Abstand der Brennpunkte vom Zentrum: c = sqrt(a^2 - b^2) (setzt a >= b voraus)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Brennpunktabstand vom Zentrum</returns>
        Public Shared Function FocalDistance(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim aa = Math.Max(a, b)
            Dim bb = Math.Min(a, b)
            Return Math.Sqrt(Math.Max(0.0, (aa * aa) - (bb * bb)))
        End Function

        ''' <summary>
        ''' Prüft, ob die Ellipse tatsächlich ein Kreis ist (a == b).
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>True, wenn a und b innerhalb Toleranz gleich sind</returns>
        Public Shared Function IsCircle(a As Double, b As Double) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Return Math.Abs(a - b) <= (Math.Max(a, b) * 0.000000000001)
        End Function

        ''' <summary>
        ''' Punkt auf der Ellipse für Parameter theta (rad): x = a*cos(theta), y = b*sin(theta)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="theta">Parameterwinkel im Bogenmaß</param>
        ''' <returns>Punkt auf der Ellipse als PointF</returns>
        Public Shared Function PointOnEllipse(a As Double, b As Double, theta As Double) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim x = a * Math.Cos(theta)
            Dim y = b * Math.Sin(theta)
            Return New PointF(CSng(x), CSng(y))
        End Function

        ''' <summary>
        ''' Punkt auf der Ellipse als Double-Präzision (x,y)
        ''' </summary>
        Private Shared Function PointOnEllipseD(a As Double, b As Double, theta As Double) As (Double, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim x = a * Math.Cos(theta)
            Dim y = b * Math.Sin(theta)
            Return (x, y)
        End Function

        ''' <summary>
        ''' Tangentengleichung an der Ellipse im Parameter theta.
        ''' Gibt eine LineEquation-Struktur zurück. Bei vertikaler Tangente ist IsVertical = True und X ausgefüllt.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="theta">Parameterwinkel im Bogenmaß</param>
        ''' <returns>Tangentengleichung als LineEquation</returns>
        Public Shared Function TangentAt(a As Double, b As Double, theta As Double) As LineEquation
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim x = a * Math.Cos(theta)
            Dim y = b * Math.Sin(theta)
            ' Ableitungen: dx/dt = -a*sin t, dy/dt = b*cos t
            Dim dx = -a * Math.Sin(theta)
            Dim dy = b * Math.Cos(theta)
            If Math.Abs(dx) < 0.00000000000001 Then
                Return New LineEquation With {.IsVertical = True, .X = x}
            End If
            Dim m = dy / dx
            Dim c = y - (m * x)
            Return New LineEquation With {.IsVertical = False, .Slope = m, .Intercept = c}
        End Function

        ''' <summary>
        ''' Normale an der Ellipse im Parameter theta.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="theta">Parameterwinkel im Bogenmaß</param>
        ''' <returns>Normalengleichung als LineEquation</returns>
        Public Shared Function NormalAt(a As Double, b As Double, theta As Double) As LineEquation
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim t = TangentAt(a, b, theta)
            If t.IsVertical Then
                ' Tangente x = const => Normale ist horizontale y = const
                Return New LineEquation With {.IsVertical = False, .Slope = 0.0, .Intercept = PointOnEllipse(a, b, theta).Y}
            End If
            If Math.Abs(t.Slope) < 0.00000000000001 Then
                ' Tangente horizontal => Normale vertikal
                Return New LineEquation With {.IsVertical = True, .X = PointOnEllipse(a, b, theta).X}
            End If
            Dim nm = -1.0 / t.Slope
            Dim p = PointOnEllipse(a, b, theta)
            Dim nc = p.Y - (nm * p.X)
            Return New LineEquation With {.IsVertical = False, .Slope = nm, .Intercept = nc}
        End Function

        ''' <summary>
        ''' Krümmungsradius an der Ellipse im Parameter theta.
        ''' Formel: rho = (a^2*sin^2 + b^2*cos^2)^(3/2) / (a*b)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="theta">Parameterwinkel im Bogenmaß</param>
        ''' <returns>Krümmungsradius am Punkt theta</returns>
        Public Shared Function RadiusOfCurvature(a As Double, b As Double, theta As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim s = a * Math.Sin(theta)
            Dim c = b * Math.Cos(theta)
            Dim denom = Math.Pow((s * s) + (c * c), 1.5)
            If denom = 0 Then Return Double.PositiveInfinity
            Return denom / (a * b)
        End Function

        ''' <summary>
        ''' Fläche und Umfassungsmaß (Perimeter) - Ramanujan-Approximation (1. Näherung)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Näherungswert für den Umfang</returns>
        Public Shared Function PerimeterRamanujan(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim aa = a
            Dim bb = b
            Dim h = Math.Pow(aa - bb, 2) / Math.Pow(aa + bb, 2)
            Return Math.PI * (aa + bb) * (1 + (3 * h / (10 + Math.Sqrt(4 - (3 * h)))))
        End Function

        ''' <summary>
        ''' Ramanujan zweite Näherung (etwas genauer für starke Exzentrizität)
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Näherungswert für den Umfang</returns>
        Public Shared Function PerimeterRamanujan2(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim aa = a
            Dim bb = b
            Return Math.PI * ((3 * (aa + bb)) - Math.Sqrt(((3 * aa) + bb) * (aa + (3 * bb))))
        End Function

        ''' <summary>
        ''' Numerische Berechnung des Umfangs durch Simpson-Integration: 4 * ∫_0^{π/2} sqrt(a^2 cos^2 t + b^2 sin^2 t) dt
        ''' subdivisions muss gerade und >= 2 sein.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="subdivisions">Anzahl Integrationsunterteilungen (wird auf gerade Zahl normalisiert)</param>
        ''' <returns>Numerisch berechneter Umfang</returns>
        Public Shared Function PerimeterNumeric(a As Double, b As Double, Optional subdivisions As Integer = 1024) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            If subdivisions < 2 Then subdivisions = 2
            If subdivisions Mod 2 = 1 Then subdivisions += 1
            Dim f As Func(Of Double, Double) = Function(t) Math.Sqrt((a * a * Math.Cos(t) * Math.Cos(t)) + (b * b * Math.Sin(t) * Math.Sin(t)))
            Dim integral = SimpsonIntegrate(f, 0.0, Math.PI / 2.0, subdivisions)
            Return 4.0 * integral
        End Function

        ''' <summary>
        ''' Arc-Länge zwischen zwei Parametern theta1 und theta2 (rad) – numerisch mit Simpson.
        ''' Liefert positiven Wert; Ordung der Winkel ist beliebig.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="theta1">Startwinkel im Bogenmaß</param>
        ''' <param name="theta2">Endwinkel im Bogenmaß</param>
        ''' <param name="subdivisions">Anzahl Integrationsunterteilungen (wird auf gerade Zahl normalisiert)</param>
        ''' <returns>Bogenlänge zwischen theta1 und theta2</returns>
        Public Shared Function ArcLength(a As Double, b As Double, theta1 As Double, theta2 As Double, Optional subdivisions As Integer = 1024) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            Dim t1 = theta1
            Dim t2 = theta2
            If Math.Abs(t2 - t1) < 0.000000000000001 Then Return 0.0
            If t2 < t1 Then
                Dim tmp = t1
                t1 = t2
                t2 = tmp
            End If
            Dim f As Func(Of Double, Double) = Function(t) Math.Sqrt(((-a * Math.Sin(t)) ^ 2) + ((b * Math.Cos(t)) ^ 2))
            If subdivisions < 2 Then subdivisions = 2
            If subdivisions Mod 2 = 1 Then subdivisions += 1
            Return SimpsonIntegrate(f, t1, t2, subdivisions)
        End Function

        ''' <summary>
        ''' Findet den nächsten Punkt auf der Ellipse zum Punkt (px,py) mittels iterativer Lösung (Newton).
        ''' Rückgabe: nächster Punkt (PointF) und minimaler Abstand (Double) in einem Tuple.
        ''' </summary>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <param name="px">X-Koordinate des Referenzpunkts</param>
        ''' <param name="py">Y-Koordinate des Referenzpunkts</param>
        ''' <param name="initialTheta">Optionaler Startwert für das Newton-Verfahren</param>
        ''' <param name="maxIter">Maximale Iterationsanzahl</param>
        ''' <param name="tol">Abbruch-Toleranz für die Iteration</param>
        ''' <returns>Tuple aus nächstem Ellipsenpunkt und Abstand</returns>
        Public Shared Function ClosestPointOnEllipse(a As Double, b As Double, px As Double, py As Double, Optional initialTheta As Double = 0.0, Optional maxIter As Integer = 1000, Optional tol As Double = 0.000000000000001) As Tuple(Of PointF, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateAxes(a, b)
            ' Wenn der Punkt bereits auf der Ellipse liegt, sofort zurückgeben (vermeidet numerische Probleme)
            Dim onEllipse = Math.Abs(((px * px) / (a * a)) + ((py * py) / (b * b)) - 1.0)
            If onEllipse < 0.000000000000001 Then
                Return Tuple.Create(New PointF(CSng(px), CSng(py)), 0.0)
            End If

            ' Newton-Verfahren auf Variable t (Parameter). Startwert use atan2(b*y, a*x)
            Dim t As Double = Math.Atan2(b * py, a * px)
            If Double.IsNaN(t) Then t = initialTheta
            For i = 0 To maxIter - 1
                Dim cosT = Math.Cos(t)
                Dim sinT = Math.Sin(t)
                Dim x = a * cosT
                Dim y = b * sinT
                Dim dx = x - px
                Dim dy = y - py
                Dim dxdT = -a * sinT
                Dim dydT = b * cosT
                Dim f = (dx * dxdT) + (dy * dydT)
                Dim fprime = (dxdT * dxdT) + (dx * (-a * cosT)) + (dydT * dydT) + (dy * (-b * sinT))
                If Math.Abs(fprime) < 1.0E-20 Then Exit For
                Dim dt = -f / fprime
                t += dt
                If Math.Abs(dt) < tol Then Exit For
            Next
            Dim res = PointOnEllipse(a, b, t)
            Dim dist = Math.Sqrt(((res.X - px) * (res.X - px)) + ((res.Y - py) * (res.Y - py)))
            Return Tuple.Create(res, dist)
        End Function

        ''' <summary>
        ''' Umrechnung: Exzentrische Anomalie E -> wahre Anomalie ν (true anomaly). Parameter a,b werden benötigt zur Berechnung e.
        ''' </summary>
        ''' <param name="E">Exzentrische Anomalie im Bogenmaß</param>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Wahre Anomalie im Bogenmaß</returns>
        Public Shared Function EccentricToTrueAnomaly(E As Double, a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim ecc = Eccentricity(a, b)
            Dim tanHalfV = Math.Sqrt((1 + ecc) / (1 - ecc)) * Math.Tan(E / 2.0)
            Return 2.0 * Math.Atan(tanHalfV)
        End Function

        ''' <summary>
        ''' Umrechnung: wahre Anomalie ν -> exzentrische Anomalie E
        ''' </summary>
        ''' <param name="v">Wahre Anomalie im Bogenmaß</param>
        ''' <param name="a">Halbachse a (&gt; 0)</param>
        ''' <param name="b">Halbachse b (&gt; 0)</param>
        ''' <returns>Exzentrische Anomalie im Bogenmaß</returns>
        Public Shared Function TrueToEccentricAnomaly(v As Double, a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim e = Eccentricity(a, b)
            Dim tanHalfE = Math.Sqrt((1 - e) / (1 + e)) * Math.Tan(v / 2.0)
            Return 2.0 * Math.Atan(tanHalfE)
        End Function

        ' --- Numerische Hilfsfunktionen ---
        Private Shared Function SimpsonIntegrate(f As Func(Of Double, Double), a As Double, b As Double, n As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If n < 2 Then n = 2
            If n Mod 2 = 1 Then n += 1
            Dim h = (b - a) / n
            Dim s = f(a) + f(b)
            For i = 1 To n - 1
                Dim x = a + (i * h)
                s += If(i Mod 2 = 0, 2.0 * f(x), 4.0 * f(x))
            Next
            Return s * h / 3.0
        End Function

    End Class

End Namespace
