' --------------------------------------------------------------------------------------------------------
' Datei: Cone.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Kegeln bereit.
    ''' </summary>
    Public Class Cone

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet das Volumen eines geraden Kreiskegels.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen (PI * r^2 * h) / 3</returns>
        Public Shared Function Volume(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            End If
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (Math.PI * radius * radius * height) / 3.0
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Mantellinie (Schräghöhe) eines geraden Kegels.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Schräghöhe sqrt(r^2 + h^2)</returns>
        Public Shared Function SlantHeight(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            End If
            Return Math.Sqrt((radius * radius) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines geraden Kegels.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche PI * r * s</returns>
        Public Shared Function LateralArea(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            End If
            Return Math.PI * radius * SlantHeight(radius, height)
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines geraden Kegels.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche PI * r * (r + s)</returns>
        Public Shared Function SurfaceArea(radius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If height < 0 Then
                Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            End If
            Dim s = SlantHeight(radius, height)
            Return Math.PI * radius * (radius + s)
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
        ''' Berechnet das Volumen eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="radiusBottom">Unterer Radius (&gt; 0)</param>
        ''' <param name="radiusTop">Oberer Radius (&gt;= 0 und &lt; radiusBottom)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen (PI * h / 3) * (R^2 + Rr + r^2)</returns>
        Public Shared Function FrustumVolume(radiusBottom As Double, radiusTop As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateFrustumRadii(radiusBottom, radiusTop)
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (Math.PI * height / 3.0) * ((radiusBottom * radiusBottom) + (radiusBottom * radiusTop) + (radiusTop * radiusTop))
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="radiusBottom">Unterer Radius (&gt; 0)</param>
        ''' <param name="radiusTop">Oberer Radius (&gt;= 0 und &lt; radiusBottom)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche PI * (R + r) * s</returns>
        Public Shared Function FrustumLateralArea(radiusBottom As Double, radiusTop As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateFrustumRadii(radiusBottom, radiusTop)
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            Dim s = Math.Sqrt(((radiusBottom - radiusTop) * (radiusBottom - radiusTop)) + (height * height))
            Return Math.PI * (radiusBottom + radiusTop) * s
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="radiusBottom">Unterer Radius (&gt; 0)</param>
        ''' <param name="radiusTop">Oberer Radius (&gt;= 0 und &lt; radiusBottom)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Gesamtoberfläche (Mantel + beide Grundflächen)</returns>
        Public Shared Function FrustumSurfaceArea(radiusBottom As Double, radiusTop As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateFrustumRadii(radiusBottom, radiusTop)
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            Dim lateral = FrustumLateralArea(radiusBottom, radiusTop, height)
            Dim bases = Math.PI * ((radiusBottom * radiusBottom) + (radiusTop * radiusTop))
            Return lateral + bases
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet einen Punkt auf der Mantelfläche eines geraden Kegels.
        ''' </summary>
        ''' <param name="centerX">Mittelpunkt X der Grundfläche</param>
        ''' <param name="centerY">Mittelpunkt Y der Grundfläche</param>
        ''' <param name="baseZ">Z-Koordinate der Grundfläche</param>
        ''' <param name="radius">Grundkreisradius (&gt;= 0)</param>
        ''' <param name="height">Kegelhöhe (&gt;= 0)</param>
        ''' <param name="angleRadians">Winkel in der Grundfläche</param>
        ''' <param name="t">Parameter von 0 (Grundkreis) bis 1 (Spitze)</param>
        ''' <returns>3D-Punkt als Tuple(X,Y,Z)</returns>
        Public Shared Function PointOnLateralSurface(centerX As Double, centerY As Double, baseZ As Double, radius As Double, height As Double, angleRadians As Double, t As Double) As Tuple(Of Double, Double, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If

            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            If t < 0 OrElse t > 1 Then Throw New ArgumentException("t muss im Bereich 0 bis 1 liegen.", NameOf(t))

            Dim currentRadius = radius * (1.0 - t)
            Dim x = centerX + (currentRadius * Math.Cos(angleRadians))
            Dim y = centerY + (currentRadius * Math.Sin(angleRadians))
            Dim z = baseZ + (t * height)
            Return Tuple.Create(x, y, z)
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateFrustumRadii(radiusBottom As Double, radiusTop As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radiusBottom <= 0 Then Throw New ArgumentException("Der untere Radius muss größer als 0 sein.", NameOf(radiusBottom))
            If radiusTop < 0 Then Throw New ArgumentException("Der obere Radius darf nicht negativ sein.", NameOf(radiusTop))
            If radiusTop >= radiusBottom Then Throw New ArgumentException("Der obere Radius muss kleiner als der untere Radius sein.", NameOf(radiusTop))
        End Sub

#End Region

    End Class

End Namespace
