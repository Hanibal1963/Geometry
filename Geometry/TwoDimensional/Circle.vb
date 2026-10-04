' --------------------------------------------------------------------------------------------------------
' Datei: Circle.vb
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
    ''' Stellt Funktionen zur Berechnung von Kreisen bereit.
    ''' </summary>
    Public Class Circle

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Kreises aus dem Radius.
        ''' </summary>
        ''' <param name="radius">Radius (>= 0)</param>
        ''' <returns>Fläche = π * radius^2</returns>
        Public Shared Function Area(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If

            Return Math.PI * radius * radius
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Kreises aus dem Durchmesser.
        ''' </summary>
        ''' <param name="diameter">Durchmesser (>= 0)</param>
        ''' <returns>Fläche</returns>
        Public Shared Function AreaFromDiameter(diameter As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Area(RadiusFromDiameter(diameter))
        End Function

        ''' <summary>
        ''' Berechnet den Umfang (Kreisumfang) aus dem Radius.
        ''' </summary>
        ''' <param name="radius">Radius (>= 0)</param>
        ''' <returns>Umfang = 2 * π * radius</returns>
        Public Shared Function Circumference(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 2.0 * Math.PI * radius
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus dem Durchmesser.
        ''' </summary>
        ''' <param name="diameter">Durchmesser (&gt;= 0)</param>
        ''' <returns>Umfang</returns>
        Public Shared Function CircumferenceFromDiameter(diameter As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Circumference(RadiusFromDiameter(diameter))
        End Function

        ''' <summary>
        ''' Konvertiert Radius in Durchmesser.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Durchmesser 2 * radius</returns>
        Public Shared Function DiameterFromRadius(radius As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 2.0 * radius
        End Function

        ''' <summary>
        ''' Konvertiert Durchmesser in Radius.
        ''' </summary>
        ''' <param name="diameter">Durchmesser (&gt;= 0)</param>
        ''' <returns>Radius diameter / 2</returns>
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
        ''' Berechnet die Bogenlänge für einen gegebenen Zentralwinkel (im Bogenmaß).
        ''' </summary>
        ''' <param name="radius">Radius</param>
        ''' <param name="angleRadians">Winkel in Bogenmaß</param>
        ''' <returns>Bogenlänge = radius * angle</returns>
        Public Shared Function ArcLength(radius As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return radius * angleRadians
        End Function

        ''' <summary>
        ''' Berechnet die Bogenlänge für einen Winkel in Grad.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="angleDegrees">Winkel in Grad</param>
        ''' <returns>Bogenlänge</returns>
        Public Shared Function ArcLengthDegrees(radius As Double, angleDegrees As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim rad As Double = angleDegrees * Math.PI / 180.0
            Return ArcLength(radius, rad)
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Kreissektors für einen gegebenen Zentralwinkel (Bogenmaß).
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="angleRadians">Winkel in Bogenmaß</param>
        ''' <returns>Sektorfläche = 0.5 * radius^2 * angle</returns>
        Public Shared Function SectorArea(radius As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 0.5 * radius * radius * angleRadians
        End Function

        ''' <summary>
        ''' Sektorfläche für Winkel in Grad.
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="angleDegrees">Winkel in Grad</param>
        ''' <returns>Sektorfläche</returns>
        Public Shared Function SectorAreaDegrees(radius As Double, angleDegrees As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim rad As Double = angleDegrees * Math.PI / 180.0
            Return SectorArea(radius, rad)
        End Function

        ''' <summary>
        ''' Berechnet die Länge einer Sehne für einen gegebenen Zentralwinkel (Bogenmaß).
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="angleRadians">Winkel in Bogenmaß</param>
        ''' <returns>Sehnenlänge = 2 * radius * sin(angle/2)</returns>
        Public Shared Function ChordLength(radius As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Return 2.0 * radius * Math.Sin(angleRadians / 2.0)
        End Function

        ''' <summary>
        ''' Berechnet die Sehnenlänge aus der Sehnenhöhe (Sagitta).
        ''' </summary>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <param name="sagitta">Sehnenhöhe (Abstand von Kreisrand zur Sehnenmitte)</param>
        ''' <returns>Sehnenlänge</returns>
        Public Shared Function ChordLengthFromSagitta(radius As Double, sagitta As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            If sagitta < 0 Or sagitta > radius Then
                Throw New ArgumentException("Sehnenhöhe ungültig.", NameOf(sagitta))
            End If

            ' Abstand vom Mittelpunkt zur Sehne (h) = radius - sagitta
            Dim h As Double = radius - sagitta
            ' Halbe Sehnenlänge = sqrt(radius^2 - h^2)
            Dim half As Double = Math.Sqrt((radius * radius) - (h * h))
            Return 2.0 * half
        End Function

        ''' <summary>
        ''' Berechnet den Zentralwinkel (Bogenmaß) aus Bogenlänge.
        ''' </summary>
        ''' <param name="radius">Radius (&gt; 0)</param>
        ''' <param name="arcLength">Bogenlänge</param>
        ''' <returns>Zentralwinkel im Bogenmaß</returns>
        Public Shared Function AngleFromArcLength(radius As Double, arcLength As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius <= 0 Then
                Throw New ArgumentException(My.Resources.RadiusIfZeroOrLess, NameOf(radius))
            End If
            Return arcLength / radius
        End Function

        ''' <summary>
        ''' Berechnet den Zentralwinkel (Bogenmaß) aus Sehnenlänge.
        ''' </summary>
        ''' <param name="radius">Radius (&gt; 0)</param>
        ''' <param name="chordLength">Sehnenlänge</param>
        ''' <returns>Zentralwinkel im Bogenmaß</returns>
        Public Shared Function AngleFromChordLength(radius As Double, chordLength As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius <= 0 Then
                Throw New ArgumentException(My.Resources.RadiusIfZeroOrLess, NameOf(radius))
            End If
            If chordLength < 0 OrElse chordLength > 2.0 * radius Then
                Throw New ArgumentException("Sehnenlänge ungültig.", NameOf(chordLength))
            End If
            ' chord = 2 radius sin(theta/2) => theta = 2 * asin(chord/(2*radius))
            Return 2.0 * Math.Asin(chordLength / (2.0 * radius))
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet einen Punkt auf dem Kreis am gegebenen Winkel (Bogenmaß).
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="radius">Radius</param>
        ''' <param name="angleRadians">Winkel im Bogenmaß (0 = rechts)</param>
        ''' <returns>PointF mit Koordinaten des Punktes</returns>
        Public Shared Function PointOnCircle(cx As Double, cy As Double, radius As Double, angleRadians As Double) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If

            Dim x As Single = CSng(cx + (radius * Math.Cos(angleRadians)))
            Dim y As Single = CSng(cy + (radius * Math.Sin(angleRadians)))
            Return New PointF(x, y)
        End Function

        ''' <summary>
        ''' Liefert das Achsen-ausgerichtete BoundingBox-Rechteck für einen Kreis.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="radius">Radius (&gt;= 0)</param>
        ''' <returns>Achsenparalleles BoundingBox-Rechteck</returns>
        Public Shared Function BoundingBox(cx As Double, cy As Double, radius As Double) As RectangleF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If radius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(radius))
            End If
            Dim x As Single = CSng(cx - radius)
            Dim y As Single = CSng(cy - radius)
            Dim size As Single = CSng(2.0 * radius)
            Return New RectangleF(x, y, size, size)
        End Function

#End Region

    End Class

End Namespace
