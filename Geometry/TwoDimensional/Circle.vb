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

        ' ----------------------------------------------------------------------------------
        ' Grundlegende Kreisberechnungen
        ' ----------------------------------------------------------------------------------

        ''' <summary>
        ''' Berechnet die Fläche eines Kreises aus dem Radius.
        ''' </summary>
        ''' <param name="r">Radius (>= 0)</param>
        ''' <returns>Fläche = π * r^2</returns>
        Public Shared Function Area(r As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return Math.PI * r * r
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Kreises aus dem Durchmesser.
        ''' </summary>
        ''' <param name="d">Durchmesser (>= 0)</param>
        ''' <returns>Fläche</returns>
        Public Shared Function AreaFromDiameter(d As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Area(RadiusFromDiameter(d))
        End Function

        ''' <summary>
        ''' Berechnet den Umfang (Kreisumfang) aus dem Radius.
        ''' </summary>
        ''' <param name="r">Radius (>= 0)</param>
        ''' <returns>Umfang = 2 * π * r</returns>
        Public Shared Function Circumference(r As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return 2.0 * Math.PI * r
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus dem Durchmesser.
        ''' </summary>
        Public Shared Function CircumferenceFromDiameter(d As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Circumference(RadiusFromDiameter(d))
        End Function

        ''' <summary>
        ''' Konvertiert Radius in Durchmesser.
        ''' </summary>
        Public Shared Function DiameterFromRadius(r As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return 2.0 * r
        End Function

        ''' <summary>
        ''' Konvertiert Durchmesser in Radius.
        ''' </summary>
        Public Shared Function RadiusFromDiameter(d As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If d < 0 Then Throw New ArgumentException("Durchmesser darf nicht negativ sein.", NameOf(d))
            Return d / 2.0
        End Function

        ' ----------------------------------------------------------------------------------
        ' Bogensegment, Sektor, Sehne und Winkel
        ' ----------------------------------------------------------------------------------

        ''' <summary>
        ''' Berechnet die Bogenlänge für einen gegebenen Zentralwinkel (im Bogenmaß).
        ''' </summary>
        ''' <param name="r">Radius</param>
        ''' <param name="angleRadians">Winkel in Bogenmaß</param>
        ''' <returns>Bogenlänge = r * angle</returns>
        Public Shared Function ArcLength(r As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return r * angleRadians
        End Function

        ''' <summary>
        ''' Berechnet die Bogenlänge für einen Winkel in Grad.
        ''' </summary>
        Public Shared Function ArcLengthDegrees(r As Double, angleDegrees As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim rad As Double = angleDegrees * Math.PI / 180.0
            Return ArcLength(r, rad)
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Kreissektors für einen gegebenen Zentralwinkel (Bogenmaß).
        ''' </summary>
        ''' <returns>Sektorfläche = 0.5 * r^2 * angle</returns>
        Public Shared Function SectorArea(r As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return 0.5 * r * r * angleRadians
        End Function

        ''' <summary>
        ''' Sektorfläche für Winkel in Grad.
        ''' </summary>
        Public Shared Function SectorAreaDegrees(r As Double, angleDegrees As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim rad As Double = angleDegrees * Math.PI / 180.0
            Return SectorArea(r, rad)
        End Function

        ''' <summary>
        ''' Berechnet die Länge einer Sehne für einen gegebenen Zentralwinkel (Bogenmaß).
        ''' </summary>
        ''' <returns>Sehnenlänge = 2 * r * sin(angle/2)</returns>
        Public Shared Function ChordLength(r As Double, angleRadians As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Return 2.0 * r * Math.Sin(angleRadians / 2.0)
        End Function

        ''' <summary>
        ''' Berechnet die Sehnenlänge aus der Sehnenhöhe (Sagitta).
        ''' </summary>
        ''' <param name="sagitta">Sehnenhöhe (Abstand von Kreisrand zur Sehnenmitte)</param>
        Public Shared Function ChordLengthFromSagitta(r As Double, sagitta As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            If sagitta < 0 Or sagitta > r Then Throw New ArgumentException("Sehnenhöhe ungültig.", NameOf(sagitta))

            ' Abstand vom Mittelpunkt zur Sehne (h) = r - sagitta
            Dim h As Double = r - sagitta
            ' Halbe Sehnenlänge = sqrt(r^2 - h^2)
            Dim half As Double = Math.Sqrt((r * r) - (h * h))
            Return 2.0 * half
        End Function

        ''' <summary>
        ''' Berechnet den Zentralwinkel (Bogenmaß) aus Bogenlänge.
        ''' </summary>
        Public Shared Function AngleFromArcLength(r As Double, arcLength As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r <= 0 Then Throw New ArgumentException("Radius muss > 0 sein.", NameOf(r))
            Return arcLength / r
        End Function

        ''' <summary>
        ''' Berechnet den Zentralwinkel (Bogenmaß) aus Sehnenlänge.
        ''' </summary>
        Public Shared Function AngleFromChordLength(r As Double, chordLength As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r <= 0 Then Throw New ArgumentException("Radius muss > 0 sein.", NameOf(r))
            If chordLength < 0 OrElse chordLength > 2.0 * r Then Throw New ArgumentException("Sehnenlänge ungültig.", NameOf(chordLength))
            ' chord = 2 r sin(theta/2) => theta = 2 * asin(chord/(2r))
            Return 2.0 * Math.Asin(chordLength / (2.0 * r))
        End Function

        ' ----------------------------------------------------------------------------------
        ' Hilfsfunktionen für Koordinaten
        ' ----------------------------------------------------------------------------------

        ''' <summary>
        ''' Berechnet einen Punkt auf dem Kreis am gegebenen Winkel (Bogenmaß).
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="r">Radius</param>
        ''' <param name="angleRadians">Winkel im Bogenmaß (0 = rechts)</param>
        ''' <returns>PointF mit Koordinaten des Punktes</returns>
        Public Shared Function PointOnCircle(cx As Double, cy As Double, r As Double, angleRadians As Double) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Dim x As Single = CSng(cx + (r * Math.Cos(angleRadians)))
            Dim y As Single = CSng(cy + (r * Math.Sin(angleRadians)))
            Return New PointF(x, y)
        End Function

        ''' <summary>
        ''' Liefert das Achsen-ausgerichtete BoundingBox-Rechteck für einen Kreis.
        ''' </summary>
        Public Shared Function BoundingBox(cx As Double, cy As Double, r As Double) As RectangleF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If r < 0 Then Throw New ArgumentException("Radius darf nicht negativ sein.", NameOf(r))
            Dim x As Single = CSng(cx - r)
            Dim y As Single = CSng(cy - r)
            Dim size As Single = CSng(2.0 * r)
            Return New RectangleF(x, y, size, size)
        End Function

    End Class

End Namespace
