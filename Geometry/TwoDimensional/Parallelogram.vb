' --------------------------------------------------------------------------------------------------------
' Datei: Parallelogram.vb
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
    ''' Stellt Funktionen zur Berechnung von Parallelogrammen bereit.
    ''' </summary>
    Public Class Parallelogram

        ''' <summary>
        ''' Berechnet die Fläche eines Parallelogramms.
        ''' </summary>
        ''' <param name="b">Grundseite (>= 0)</param>
        ''' <param name="h">Höhe zur Grundseite (>= 0)</param>
        ''' <returns>Fläche b * h</returns>
        Public Shared Function Area(b As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If b < 0 Then Throw New ArgumentException("Grundseite darf nicht negativ sein.", NameOf(b))
            If h < 0 Then Throw New ArgumentException("Höhe darf nicht negativ sein.", NameOf(h))

            Return b * h
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Parallelogramms.
        ''' </summary>
        ''' <param name="a">Seite a (>= 0)</param>
        ''' <param name="b">Seite b (>= 0)</param>
        ''' <returns>Umfang 2 * (a + b)</returns>
        Public Shared Function Perimeter(a As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a < 0 Then Throw New ArgumentException("Seite a darf nicht negativ sein.", NameOf(a))
            If b < 0 Then Throw New ArgumentException("Seite b darf nicht negativ sein.", NameOf(b))

            Return 2.0 * (a + b)
        End Function

        ''' <summary>
        ''' Berechnet die Höhe aus Fläche und Grundseite.
        ''' </summary>
        ''' <param name="area">Fläche (>= 0)</param>
        ''' <param name="b">Grundseite (> 0)</param>
        ''' <returns>Höhe area / b</returns>
        Public Shared Function HeightFromArea(area As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then Throw New ArgumentException("Fläche darf nicht negativ sein.", NameOf(area))
            If b <= 0 Then Throw New ArgumentException("Grundseite muss größer als 0 sein.", NameOf(b))

            Return area / b
        End Function

        ''' <summary>
        ''' Berechnet die fehlende Seitenlänge aus Umfang und bekannter Seite.
        ''' </summary>
        ''' <param name="perimeter">Umfang (>= 0)</param>
        ''' <param name="knownSide">Bekannte Seitenlänge (>= 0)</param>
        ''' <returns>Fehlende Seitenlänge</returns>
        Public Shared Function SideFromPerimeter(perimeter As Double, knownSide As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If perimeter < 0 Then Throw New ArgumentException("Umfang darf nicht negativ sein.", NameOf(perimeter))
            If knownSide < 0 Then Throw New ArgumentException("Bekannte Seite darf nicht negativ sein.", NameOf(knownSide))
            If perimeter <= 2.0 * knownSide Then Throw New ArgumentException("Umfang ist für die angegebene Seite zu klein.", NameOf(perimeter))

            Return (perimeter / 2.0) - knownSide
        End Function

        ''' <summary>
        ''' Berechnet die beiden Diagonalen eines Parallelogramms aus Seiten und eingeschlossenem Winkel.
        ''' </summary>
        ''' <param name="a">Seite a (> 0)</param>
        ''' <param name="b">Seite b (> 0)</param>
        ''' <param name="includedAngleRadians">Eingeschlossener Winkel im Bogenmaß (0 &lt; Winkel &lt; PI)</param>
        ''' <returns>Array mit zwei Diagonalen: [|u+v|, |u-v|]</returns>
        Public Shared Function DiagonalBySidesAndAngle(a As Double, b As Double, includedAngleRadians As Double) As Double()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a <= 0 Then Throw New ArgumentException("Seite a muss größer als 0 sein.", NameOf(a))
            If b <= 0 Then Throw New ArgumentException("Seite b muss größer als 0 sein.", NameOf(b))
            If includedAngleRadians <= 0 OrElse includedAngleRadians >= Math.PI Then
                Throw New ArgumentException("Der eingeschlossene Winkel muss zwischen 0 und PI liegen.", NameOf(includedAngleRadians))
            End If

            Dim cosValue = Math.Cos(includedAngleRadians)
            Dim diagonal1 = Math.Sqrt((a * a) + (b * b) + (2.0 * a * b * cosValue))
            Dim diagonal2 = Math.Sqrt((a * a) + (b * b) - (2.0 * a * b * cosValue))

            Return New Double() {diagonal1, diagonal2}
        End Function

        ''' <summary>
        ''' Berechnet den eingeschlossenen Innenwinkel aus Seiten und Diagonalen.
        ''' </summary>
        ''' <param name="a">Seite a (> 0)</param>
        ''' <param name="b">Seite b (> 0)</param>
        ''' <param name="d1">Diagonale d1 (> 0)</param>
        ''' <param name="d2">Diagonale d2 (> 0)</param>
        ''' <returns>Innenwinkel im Bogenmaß</returns>
        Public Shared Function InteriorAngleFromSidesAndDiagonals(a As Double, b As Double, d1 As Double, d2 As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a <= 0 Then Throw New ArgumentException("Seite a muss größer als 0 sein.", NameOf(a))
            If b <= 0 Then Throw New ArgumentException("Seite b muss größer als 0 sein.", NameOf(b))
            If d1 <= 0 Then Throw New ArgumentException("Diagonale d1 muss größer als 0 sein.", NameOf(d1))
            If d2 <= 0 Then Throw New ArgumentException("Diagonale d2 muss größer als 0 sein.", NameOf(d2))

            Dim denominator = 4.0 * a * b
            Dim cosValue = ((d1 * d1) - (d2 * d2)) / denominator

            If cosValue < -1.0 OrElse cosValue > 1.0 Then
                Throw New ArgumentException("Die angegebenen Seiten und Diagonalen bilden kein gültiges Parallelogramm.")
            End If

            Return Math.Acos(cosValue)
        End Function

        ''' <summary>
        ''' Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten.
        ''' </summary>
        ''' <param name="x1">X-Koordinate des ersten Eckpunkts</param>
        ''' <param name="y1">Y-Koordinate des ersten Eckpunkts</param>
        ''' <param name="x3">X-Koordinate des gegenüberliegenden Eckpunkts</param>
        ''' <param name="y3">Y-Koordinate des gegenüberliegenden Eckpunkts</param>
        ''' <returns>Mittelpunkt als PointF</returns>
        Public Shared Function Center(x1 As Double, y1 As Double, x3 As Double, y3 As Double) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return New PointF(CSng((x1 + x3) / 2.0), CSng((y1 + y3) / 2.0))
        End Function

        ''' <summary>
        ''' Berechnet die vier Eckpunkte eines Parallelogramms aus Mittelpunkt, Seitenlängen und Winkeln.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="a">Seite a (> 0)</param>
        ''' <param name="b">Seite b (> 0)</param>
        ''' <param name="includedAngleRadians">Eingeschlossener Winkel zwischen den Seiten (0 &lt; Winkel &lt; PI)</param>
        ''' <param name="rotationRadians">Rotation der Seite a gegen den Uhrzeigersinn im Bogenmaß</param>
        ''' <returns>Array mit 4 Eckpunkten in umlaufender Reihenfolge</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, a As Double, b As Double, includedAngleRadians As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a <= 0 Then Throw New ArgumentException("Seite a muss größer als 0 sein.", NameOf(a))
            If b <= 0 Then Throw New ArgumentException("Seite b muss größer als 0 sein.", NameOf(b))
            If includedAngleRadians <= 0 OrElse includedAngleRadians >= Math.PI Then
                Throw New ArgumentException("Der eingeschlossene Winkel muss zwischen 0 und PI liegen.", NameOf(includedAngleRadians))
            End If

            Dim halfA = a / 2.0
            Dim halfB = b / 2.0

            Dim ux = halfA * Math.Cos(rotationRadians)
            Dim uy = halfA * Math.Sin(rotationRadians)

            Dim vx = halfB * Math.Cos(rotationRadians + includedAngleRadians)
            Dim vy = halfB * Math.Sin(rotationRadians + includedAngleRadians)

            Return New PointF() {
                New PointF(CSng(cx - ux - vx), CSng(cy - uy - vy)),
                New PointF(CSng(cx + ux - vx), CSng(cy + uy - vy)),
                New PointF(CSng(cx + ux + vx), CSng(cy + uy + vy)),
                New PointF(CSng(cx - ux + vx), CSng(cy - uy + vy))
            }
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Polygons aus dessen Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Eckpunkte (mindestens 3)</param>
        ''' <returns>Polygonfläche</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then Throw New ArgumentException("Die Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            If vertices.Length < 3 Then Throw New ArgumentException("Es müssen mindestens 3 Eckpunkte angegeben werden.", NameOf(vertices))

            Dim sum As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                sum += (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
            Next

            Return Math.Abs(sum) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Polygons aus dessen Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte (mindestens 2)</param>
        ''' <returns>Umfang als Summe der Kantenlängen</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then Throw New ArgumentException("Die Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            If vertices.Length < 2 Then Throw New ArgumentException("Es müssen mindestens 2 Eckpunkte angegeben werden.", NameOf(vertices))

            Dim perimeter As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                Dim dx = vertices(j).X - vertices(i).X
                Dim dy = vertices(j).Y - vertices(i).Y
                perimeter += Math.Sqrt((dx * dx) + (dy * dy))
            Next

            Return perimeter
        End Function

        ''' <summary>
        ''' Prüft, ob 4 Punkte ein Parallelogramm bilden.
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte in umlaufender Reihenfolge</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn die Diagonalen denselben Mittelpunkt besitzen</returns>
        Public Shared Function IsParallelogramFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then Throw New ArgumentException("Die Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            If vertices.Length <> 4 Then Throw New ArgumentException("Es müssen genau 4 Eckpunkte angegeben werden.", NameOf(vertices))
            If tolerance <= 0 Then Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))

            Dim midpointDiagonal1 = Center(vertices(0).X, vertices(0).Y, vertices(2).X, vertices(2).Y)
            Dim midpointDiagonal2 = Center(vertices(1).X, vertices(1).Y, vertices(3).X, vertices(3).Y)

            Return Math.Abs(midpointDiagonal1.X - midpointDiagonal2.X) <= tolerance AndAlso
                   Math.Abs(midpointDiagonal1.Y - midpointDiagonal2.Y) <= tolerance
        End Function

    End Class

End Namespace
