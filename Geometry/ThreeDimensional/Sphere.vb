' --------------------------------------------------------------------------------------------------------
' Datei: Sphere.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Kugeln bereit.
    ''' </summary>
    Public Class Sphere

        ''' <summary>
        ''' Berechnet das Volumen einer Kugel.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Volumen 4/3 * PI * r^3</returns>
        Public Shared Function Volume(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche einer Kugel.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Oberfläche 4 * PI * r^2</returns>
        Public Shared Function SurfaceArea(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
            Return 4.0 * Math.PI * radius * radius
        End Function

        ''' <summary>
        ''' Berechnet den Durchmesser aus dem Radius.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Durchmesser 2 * r</returns>
        Public Shared Function DiameterFromRadius(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
            Return 2.0 * radius
        End Function

        ''' <summary>
        ''' Berechnet den Radius aus dem Durchmesser.
        ''' </summary>
        ''' <param name="diameter">Durchmesser (&gt;= 0)</param>
        ''' <returns>Radius d / 2</returns>
        Public Shared Function RadiusFromDiameter(diameter As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diameter < 0 Then Throw New ArgumentException("Der Durchmesser darf nicht negativ sein.", NameOf(diameter))
            Return diameter / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang des Großkreises einer Kugel.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Umfang 2 * PI * r</returns>
        Public Shared Function GreatCircleCircumference(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
            Return 2.0 * Math.PI * radius
        End Function

        ''' <summary>
        ''' Berechnet die Fläche des Großkreises einer Kugel.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Fläche PI * r^2</returns>
        Public Shared Function GreatCircleArea(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
            Return Math.PI * radius * radius
        End Function

        ''' <summary>
        ''' Berechnet das Volumen einer Kugelkappe.
        ''' </summary>
        ''' <param name="radius">Kugelradius (&gt; 0)</param>
        ''' <param name="capHeight">Kappenhöhe (&gt;= 0 und &lt;= 2r)</param>
        ''' <returns>Volumen PI * h^2 * (r - h/3)</returns>
        Public Shared Function SphericalCapVolume(radius As Double, capHeight As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateCapInputs(radius, capHeight)
            Return Math.PI * capHeight * capHeight * (radius - (capHeight / 3.0))
        End Function

        ''' <summary>
        ''' Berechnet die gekrümmte Oberfläche einer Kugelkappe.
        ''' </summary>
        ''' <param name="radius">Kugelradius (&gt; 0)</param>
        ''' <param name="capHeight">Kappenhöhe (&gt;= 0 und &lt;= 2r)</param>
        ''' <returns>Fläche 2 * PI * r * h</returns>
        Public Shared Function SphericalCapArea(radius As Double, capHeight As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateCapInputs(radius, capHeight)
            Return 2.0 * Math.PI * radius * capHeight
        End Function

        ''' <summary>
        ''' Berechnet einen Punkt auf der Kugeloberfläche aus sphärischen Winkeln.
        ''' </summary>
        ''' <param name="centerX">Mittelpunkt X</param>
        ''' <param name="centerY">Mittelpunkt Y</param>
        ''' <param name="centerZ">Mittelpunkt Z</param>
        ''' <param name="radius">Kugelradius (>= 0)</param>
        ''' <param name="polarAngleRadians">Polarwinkel theta (0 bis PI)</param>
        ''' <param name="azimuthRadians">Azimutwinkel phi (beliebig)</param>
        ''' <returns>3D-Koordinate als Tuple(X, Y, Z)</returns>
        Public Shared Function PointOnSphere(centerX As Double, centerY As Double, centerZ As Double, radius As Double, polarAngleRadians As Double, azimuthRadians As Double) As Tuple(Of Double, Double, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then Throw New ArgumentException("Der Radius darf nicht negativ sein.", NameOf(radius))
            If polarAngleRadians < 0 OrElse polarAngleRadians > Math.PI Then
                Throw New ArgumentException("Der Polarwinkel muss im Bereich 0 bis PI liegen.", NameOf(polarAngleRadians))
            End If

            Dim sinTheta = Math.Sin(polarAngleRadians)
            Dim x = centerX + (radius * sinTheta * Math.Cos(azimuthRadians))
            Dim y = centerY + (radius * sinTheta * Math.Sin(azimuthRadians))
            Dim z = centerZ + (radius * Math.Cos(polarAngleRadians))

            Return Tuple.Create(x, y, z)
        End Function

        Private Shared Sub ValidateCapInputs(radius As Double, capHeight As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius <= 0 Then Throw New ArgumentException("Der Radius muss größer als 0 sein.", NameOf(radius))
            If capHeight < 0 Then Throw New ArgumentException("Die Kappenhöhe darf nicht negativ sein.", NameOf(capHeight))
            If capHeight > 2.0 * radius Then Throw New ArgumentException("Die Kappenhöhe darf maximal 2 * Radius sein.", NameOf(capHeight))
        End Sub

    End Class

End Namespace
