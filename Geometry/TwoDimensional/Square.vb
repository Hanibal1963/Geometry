' --------------------------------------------------------------------------------------------------------
' Datei: Square.vb
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
    ''' Stellt Funktionen zur Berechnung von Quadraten bereit.
    ''' </summary>
    Public Class Square

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Quadrats.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Fläche side * side</returns>
        Public Shared Function Area(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side * side
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Quadrats.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Umfang 4 * side</returns>
        Public Shared Function Perimeter(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return 4.0 * side
        End Function

        ''' <summary>
        ''' Berechnet die Diagonale eines Quadrats.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Diagonale side * sqrt(2)</returns>
        Public Shared Function Diagonal(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side * Math.Sqrt(2.0)
        End Function

        ''' <summary>
        ''' Berechnet die Seitenlänge aus der Diagonale.
        ''' </summary>
        ''' <param name="diagonal">Diagonale (&gt;= 0)</param>
        ''' <returns>Seitenlänge diagonal / sqrt(2)</returns>
        Public Shared Function SideFromDiagonal(diagonal As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diagonal < 0 Then
                Throw New ArgumentException("Diagonale darf nicht negativ sein.", NameOf(diagonal))
            End If
            Return diagonal / Math.Sqrt(2.0)
        End Function

        ''' <summary>
        ''' Berechnet den Inkreisradius eines Quadrats.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Inkreisradius side / 2</returns>
        Public Shared Function Inradius(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umkreisradius eines Quadrats.
        ''' </summary>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <returns>Umkreisradius side / sqrt(2)</returns>
        Public Shared Function Circumradius(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side / Math.Sqrt(2.0)
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet die Eckpunkte eines (optional rotierten) Quadrats aus dem Mittelpunkt.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="side">Seitenlänge (&gt;= 0)</param>
        ''' <param name="rotationRadians">Rotation im Bogenmaß</param>
        ''' <returns>Array mit 4 Eckpunkten im Uhrzeigersinn</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, side As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If

            Dim halfSide = side / 2.0
            Dim local As PointF() = {
                New PointF(CSng(-halfSide), CSng(-halfSide)),
                New PointF(CSng(halfSide), CSng(-halfSide)),
                New PointF(CSng(halfSide), CSng(halfSide)),
                New PointF(CSng(-halfSide), CSng(halfSide))
            }

            Dim cosA = Math.Cos(rotationRadians)
            Dim sinA = Math.Sin(rotationRadians)
            Dim result(3) As PointF

            For i = 0 To local.Length - 1
                Dim rx = (local(i).X * cosA) - (local(i).Y * sinA) + cx
                Dim ry = (local(i).X * sinA) + (local(i).Y * cosA) + cy
                result(i) = New PointF(CSng(rx), CSng(ry))
            Next

            Return result
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
        ''' Prüft, ob 4 Eckpunkte ein Quadrat bilden.
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte in umlaufender Reihenfolge</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn alle Seiten gleich lang und alle Winkel rechtwinklig sind</returns>
        Public Shared Function IsSquareFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            If tolerance <= 0 Then
                Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))
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

            For i = 0 To 3
                Dim p0 = vertices(i)
                Dim p1 = vertices((i + 1) Mod 4)
                Dim p2 = vertices((i + 2) Mod 4)

                Dim vx = p1.X - p0.X
                Dim vy = p1.Y - p0.Y
                Dim wx = p2.X - p1.X
                Dim wy = p2.Y - p1.Y
                Dim dot = (vx * wx) + (vy * wy)
                Dim normProduct = Math.Sqrt(((vx * vx) + (vy * vy)) * ((wx * wx) + (wy * wy)))
                If normProduct <= tolerance Then Return False
                If Math.Abs(dot) > tolerance * normProduct Then Return False
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
