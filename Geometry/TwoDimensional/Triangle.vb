' --------------------------------------------------------------------------------------------------------
' Datei: Triangle.vb
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
    ''' Stellt Funktionen zur berechnung von Dreiecken bereit.
    ''' </summary>
    Public Class Triangle

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Dreiecks.
        ''' </summary>
        ''' <param name="b">Grundseite (>= 0)</param>
        ''' <param name="h">Höhe zur Grundseite (>= 0)</param>
        ''' <returns>Fläche b * h / 2</returns>
        Public Shared Function Area(b As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If b < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(b))
            End If
            If h < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(h))
            End If

#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (b * h) / 2.0
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Dreiecks aus drei Seiten.
        ''' </summary>
        ''' <param name="a">Seite a (&gt; 0)</param>
        ''' <param name="b">Seite b (&gt; 0)</param>
        ''' <param name="c">Seite c (&gt; 0)</param>
        ''' <returns>Umfang a + b + c</returns>
        Public Shared Function Perimeter(a As Double, b As Double, c As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSides(a, b, c)
            Return a + b + c
        End Function

        ''' <summary>
        ''' Berechnet die Höhe aus Fläche und Grundseite.
        ''' </summary>
        ''' <param name="area">Fläche (>= 0)</param>
        ''' <param name="b">Grundseite (&gt; 0)</param>
        ''' <returns>Höhe 2 * area / b</returns>
        Public Shared Function HeightFromArea(area As Double, b As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(area))
            End If
            If b <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(b))
            End If

#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (2.0 * area) / b
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Fläche mit der Heron-Formel aus den Seitenlängen.
        ''' </summary>
        ''' <param name="a">Seite a (&gt; 0)</param>
        ''' <param name="b">Seite b (&gt; 0)</param>
        ''' <param name="c">Seite c (&gt; 0)</param>
        ''' <returns>Fläche nach Heron</returns>
        Public Shared Function AreaHeron(a As Double, b As Double, c As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSides(a, b, c)

            Dim s = (a + b + c) / 2.0
            Return Math.Sqrt(s * (s - a) * (s - b) * (s - c))
        End Function

        ''' <summary>
        ''' Berechnet einen Innenwinkel eines Dreiecks mit dem Kosinussatz.
        ''' </summary>
        ''' <param name="opposite">Gegenüberliegende Seite zum gesuchten Winkel (&gt; 0)</param>
        ''' <param name="adjacent1">Anliegende Seite 1 (&gt; 0)</param>
        ''' <param name="adjacent2">Anliegende Seite 2 (&gt; 0)</param>
        ''' <returns>Winkel im Bogenmaß</returns>
        Public Shared Function AngleFromSides(opposite As Double, adjacent1 As Double, adjacent2 As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSides(opposite, adjacent1, adjacent2)

            Dim denominator = 2.0 * adjacent1 * adjacent2
            Dim cosValue = ((adjacent1 * adjacent1) + (adjacent2 * adjacent2) - (opposite * opposite)) / denominator

            If cosValue < -1.0 OrElse cosValue > 1.0 Then
                Throw New ArgumentException(My.Resources.InvalidTriangleSides)
            End If

            Return Math.Acos(cosValue)
        End Function

        ''' <summary>
        ''' Berechnet die Seitenlängen aus drei Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Drei Eckpunkte</param>
        ''' <returns>Array mit Seitenlängen [AB, BC, CA]</returns>
        Public Shared Function SideLengthsFromVertices(vertices As PointF()) As Double()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)

            Dim ab = Distance(vertices(0), vertices(1))
            Dim bc = Distance(vertices(1), vertices(2))
            Dim ca = Distance(vertices(2), vertices(0))

            Return New Double() {ab, bc, ca}
        End Function

        ''' <summary>
        ''' Berechnet die Fläche aus drei Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Drei Eckpunkte</param>
        ''' <returns>Dreiecksfläche</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)

            Dim area = Math.Abs(
                (vertices(0).X * (vertices(1).Y - vertices(2).Y)) +
                (vertices(1).X * (vertices(2).Y - vertices(0).Y)) +
                (vertices(2).X * (vertices(0).Y - vertices(1).Y))
            ) / 2.0

            Return area
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus drei Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Drei Eckpunkte</param>
        ''' <returns>Umfang als Summe der Seitenlängen</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim sides = SideLengthsFromVertices(vertices)
            Return sides(0) + sides(1) + sides(2)
        End Function

        ''' <summary>
        ''' Berechnet den Schwerpunkt (Centroid) eines Dreiecks aus den Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Drei Eckpunkte</param>
        ''' <returns>Schwerpunkt als PointF</returns>
        Public Shared Function Centroid(vertices As PointF()) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)

            Dim cx = CSng((vertices(0).X + vertices(1).X + vertices(2).X) / 3.0)
            Dim cy = CSng((vertices(0).Y + vertices(1).Y + vertices(2).Y) / 3.0)
            Return New PointF(cx, cy)
        End Function

        ''' <summary>
        ''' Prüft, ob die Eckpunkte ein gültiges Dreieck bilden.
        ''' </summary>
        ''' <param name="vertices">Drei Eckpunkte</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn die Fläche größer als die Toleranz ist</returns>
        Public Shared Function IsValidTriangleFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If
            ValidateVertices(vertices)

            Return AreaFromVertices(vertices) > tolerance
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateSides(a As Double, b As Double, c As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If a <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(a))
            End If
            If b <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(b))
            End If
            If c <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(c))
            End If
            If a + b <= c OrElse a + c <= b OrElse b + c <= a Then
                Throw New ArgumentException(My.Resources.InvalidTriangleSides)
            End If
        End Sub

        Private Shared Sub ValidateVertices(vertices As PointF())
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then
                Throw New ArgumentException(My.Resources.CheckVerticesNotNull, NameOf(vertices))
            End If
            If vertices.Length <> 3 Then
                Throw New ArgumentException("Es müssen genau 3 Eckpunkte angegeben werden.", NameOf(vertices))
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
