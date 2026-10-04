' --------------------------------------------------------------------------------------------------------
' Datei: Cylinder.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Zylindern bereit.
    ''' </summary>
    Public Class Cylinder

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet das Volumen eines Vollzylinders.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen PI * r^2 * h</returns>
        Public Shared Function Volume(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return Math.PI * radius * radius * height
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines Zylinders.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche 2 * PI * r * h</returns>
        Public Shared Function LateralArea(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return 2.0 * Math.PI * radius * height
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines Vollzylinders.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche 2*PI*r*(r+h)</returns>
        Public Shared Function SurfaceArea(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return 2.0 * Math.PI * radius * (radius + height)
        End Function

        ''' <summary>
        ''' Berechnet den Grundkreisumfang.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>2 * PI * r</returns>
        Public Shared Function BaseCircumference(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 2.0 * Math.PI * radius
        End Function

        ''' <summary>
        ''' Berechnet den Grundkreisflächeninhalt.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>PI * r^2</returns>
        Public Shared Function BaseArea(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return Math.PI * radius * radius
        End Function

        ''' <summary>
        ''' Berechnet den Durchmesser aus dem Radius.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Durchmesser 2 * r</returns>
        Public Shared Function DiameterFromRadius(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 2.0 * radius
        End Function

        ''' <summary>
        ''' Berechnet den Radius aus dem Durchmesser.
        ''' </summary>
        ''' <param name="diameter">Durchmesser (&gt;= 0)</param>
        ''' <returns>Radius d / 2</returns>
        Public Shared Function RadiusFromDiameter(diameter As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diameter < 0 Then
                Throw New ArgumentException(My.Resources.DiameterIsNegative, NameOf(diameter))
            End If
            Return diameter / 2.0
        End Function

#End Region

#Region "Abgeleitete Berechnungen"

        ''' <summary>
        ''' Berechnet das Volumen eines Hohlzylinders.
        ''' </summary>
        ''' <param name="outerRadius">Außenradius (&gt; 0)</param>
        ''' <param name="innerRadius">Innenradius (&gt;= 0 und &lt; außenradius)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen PI * (R^2 - r^2) * h</returns>
        Public Shared Function HollowVolume(outerRadius As Double, innerRadius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateHollowRadii(outerRadius, innerRadius)
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return Math.PI * ((outerRadius * outerRadius) - (innerRadius * innerRadius)) * height
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines Hohlzylinders inklusive Innen- und Außenmantel sowie Ringflächen.
        ''' </summary>
        ''' <param name="outerRadius">Außenradius (&gt; 0)</param>
        ''' <param name="innerRadius">Innenradius (&gt;= 0 und &lt; außenradius)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Gesamtoberfläche</returns>
        Public Shared Function HollowSurfaceArea(outerRadius As Double, innerRadius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateHollowRadii(outerRadius, innerRadius)
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If

            Dim outerLateral = 2.0 * Math.PI * outerRadius * height
            Dim innerLateral = 2.0 * Math.PI * innerRadius * height
            Dim ringEnds = 2.0 * Math.PI * ((outerRadius * outerRadius) - (innerRadius * innerRadius))
            Return outerLateral + innerLateral + ringEnds
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet einen Punkt auf der Mantelfläche eines Zylinders.
        ''' </summary>
        ''' <param name="centerX">Mittelpunkt X der Zylinderachse</param>
        ''' <param name="centerY">Mittelpunkt Y der Zylinderachse</param>
        ''' <param name="baseZ">Z-Koordinate der unteren Grundfläche</param>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <param name="angleRadians">Winkel im Bogenmaß</param>
        ''' <param name="heightOffset">Höhenoffset entlang der Achse (0 bis height)</param>
        ''' <returns>3D-Koordinate als Tuple(X, Y, Z)</returns>
        Public Shared Function PointOnLateralSurface(centerX As Double, centerY As Double, baseZ As Double, radius As Double, height As Double, angleRadians As Double, heightOffset As Double) As Tuple(Of Double, Double, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            If heightOffset < 0 OrElse heightOffset > height Then
                Throw New ArgumentException("Höhenoffset muss im Bereich 0 bis Höhe liegen.", NameOf(heightOffset))
            End If

            Dim x = centerX + (radius * Math.Cos(angleRadians))
            Dim y = centerY + (radius * Math.Sin(angleRadians))
            Dim z = baseZ + heightOffset

            Return Tuple.Create(x, y, z)
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateHollowRadii(outerRadius As Double, innerRadius As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If outerRadius <= 0 Then Throw New ArgumentException("Der Außenradius muss größer als 0 sein.", NameOf(outerRadius))
            If innerRadius < 0 Then Throw New ArgumentException("Der Innenradius darf nicht negativ sein.", NameOf(innerRadius))
            If innerRadius >= outerRadius Then Throw New ArgumentException("Der Innenradius muss kleiner als der Außenradius sein.", NameOf(innerRadius))
        End Sub

#End Region

    End Class

End Namespace
