' --------------------------------------------------------------------------------------------------------
' Datei: Rhombus.vb
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
    ''' Stellt Funktionen zur Berechnung von Rauten bereit.
    ''' </summary>
    Public Class Rhombus

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche aus Seitenlänge und Höhe.
        ''' </summary>
        ''' <param name="baseLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Fläche baseLength * height</returns>
        Public Shared Function AreaFromBaseHeight(baseLength As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseLength < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeLength, NameOf(baseLength))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(height))
            End If
            Return baseLength * height
        End Function

        ''' <summary>
        ''' Berechnet die Fläche aus den Diagonalen.
        ''' </summary>
        ''' <param name="diagonal1">Diagonale 1 (&gt;= 0)</param>
        ''' <param name="diagonal2">Diagonale 2 (&gt;= 0)</param>
        ''' <returns>Fläche (d1 * d2) / 2</returns>
        Public Shared Function AreaFromDiagonals(diagonal1 As Double, diagonal2 As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diagonal1 < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeDiagonal, NameOf(diagonal1))
            End If
            If diagonal2 < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeDiagonal, NameOf(diagonal2))
            End If
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (diagonal1 * diagonal2) / 2.0
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet den Umfang einer Raute.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Umfang 4 * side</returns>
        Public Shared Function Perimeter(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeLength, NameOf(side))
            End If
            Return 4.0 * side
        End Function

        ''' <summary>
        ''' Berechnet die Höhe aus Fläche und Seitenlänge.
        ''' </summary>
        ''' <param name="area">Fläche (&gt;= 0)</param>
        ''' <param name="side">Seitenlänge (&gt; 0)</param>
        ''' <returns>Höhe area / side</returns>
        Public Shared Function HeightFromArea(area As Double, side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(area))
            End If
            If side <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveLength, NameOf(side))
            End If
            Return area / side
        End Function

        ''' <summary>
        ''' Berechnet die beiden Diagonalen aus Seitenlänge und Innenwinkel.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt; 0)</param>
        ''' <param name="interiorAngleRadians">Innenwinkel im Bogenmaß (0 &lt; Winkel &lt; PI)</param>
        ''' <returns>Array [d1, d2]</returns>
        Public Shared Function DiagonalFromSideAndAngle(side As Double, interiorAngleRadians As Double) As Double()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveLength, NameOf(side))
            End If
            If interiorAngleRadians <= 0 OrElse interiorAngleRadians >= Math.PI Then
                Throw New ArgumentException("Der Innenwinkel muss zwischen 0 und PI liegen.", NameOf(interiorAngleRadians))
            End If

            Dim halfAngle = interiorAngleRadians / 2.0
            Dim d1 = 2.0 * side * Math.Cos(halfAngle)
            Dim d2 = 2.0 * side * Math.Sin(halfAngle)
            Return New Double() {d1, d2}
        End Function

        ''' <summary>
        ''' Berechnet den Inkreisradius aus Fläche und Umfang.
        ''' </summary>
        ''' <param name="area">Fläche (&gt;= 0)</param>
        ''' <param name="perimeter">Umfang (&gt; 0)</param>
        ''' <returns>Inkreisradius 2 * area / perimeter</returns>
        Public Shared Function InradiusFromAreaPerimeter(area As Double, perimeter As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(area))
            End If
            If perimeter <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveCircumference, NameOf(perimeter))
            End If
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (2.0 * area) / perimeter
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet die 4 Eckpunkte einer Raute aus Mittelpunkt, Seitenlänge, Innenwinkel und Rotation.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="side">Seitenlänge (&gt; 0)</param>
        ''' <param name="interiorAngleRadians">Innenwinkel im Bogenmaß (0 &lt; Winkel &lt; PI)</param>
        ''' <param name="rotationRadians">Rotation im Bogenmaß</param>
        ''' <returns>Array mit 4 Eckpunkten in umlaufender Reihenfolge</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, side As Double, interiorAngleRadians As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveLength, NameOf(side))
            End If
            If interiorAngleRadians <= 0 OrElse interiorAngleRadians >= Math.PI Then
                Throw New ArgumentException("Der Innenwinkel muss zwischen 0 und PI liegen.", NameOf(interiorAngleRadians))
            End If

            Dim halfA = side / 2.0
            Dim halfB = side / 2.0

            Dim ux = halfA * Math.Cos(rotationRadians)
            Dim uy = halfA * Math.Sin(rotationRadians)
            Dim vx = halfB * Math.Cos(rotationRadians + interiorAngleRadians)
            Dim vy = halfB * Math.Sin(rotationRadians + interiorAngleRadians)

            Return New PointF() {
                New PointF(CSng(cx - ux - vx), CSng(cy - uy - vy)),
                New PointF(CSng(cx + ux - vx), CSng(cy + uy - vy)),
                New PointF(CSng(cx + ux + vx), CSng(cy + uy + vy)),
                New PointF(CSng(cx - ux + vx), CSng(cy - uy + vy))
            }
        End Function

        ''' <summary>
        ''' Berechnet die Fläche aus 4 Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte</param>
        ''' <returns>Fläche</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            Dim sum As Double = 0.0
            For i = 0 To 3
                Dim j = (i + 1) Mod 4
                sum += (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
            Next
            Return Math.Abs(sum) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus 4 Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte</param>
        ''' <returns>Umfang</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            Dim total As Double = 0.0
            For i = 0 To 3
                Dim j = (i + 1) Mod 4
                total += Distance(vertices(i), vertices(j))
            Next
            Return total
        End Function

        ''' <summary>
        ''' Prüft, ob vier Eckpunkte eine Raute bilden.
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte in umlaufender Reihenfolge</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn alle Seitenlängen innerhalb der Toleranz gleich sind</returns>
        Public Shared Function IsRhombusFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If

            Dim lengths(3) As Double
            For i = 0 To 3
                Dim j = (i + 1) Mod 4
                lengths(i) = Distance(vertices(i), vertices(j))
                If lengths(i) <= tolerance Then Return False
            Next

            For i = 1 To 3
                If Math.Abs(lengths(i) - lengths(0)) > tolerance Then Return False
            Next

            Return True
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateVertices(vertices As PointF())
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then
                Throw New ArgumentException("Die Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            End If
            If vertices.Length <> 4 Then
                Throw New ArgumentException("Es müssen genau 4 Eckpunkte angegeben werden.", NameOf(vertices))
            End If
        End Sub

        Private Shared Function Distance(p1 As PointF, p2 As PointF) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim dx = p2.X - p1.X
            Dim dy = p2.Y - p1.Y
            Return Math.Sqrt((dx * dx) + (dy * dy))
        End Function

#End Region

    End Class

End Namespace
