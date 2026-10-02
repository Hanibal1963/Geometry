' --------------------------------------------------------------------------------------------------------
' Datei: Kite.vb
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
    ''' Stellt Funktionen zur Berechnung von Drachenvierecken bereit.
    ''' </summary>
    Public Class Kite

        ''' <summary>
        ''' Berechnet die Fläche aus zwei Diagonalen.
        ''' </summary>
        ''' <param name="diagonal1">Diagonale 1 (&gt;= 0)</param>
        ''' <param name="diagonal2">Diagonale 2 (&gt;= 0)</param>
        ''' <returns>Fläche (d1 * d2) / 2</returns>
        Public Shared Function AreaFromDiagonals(diagonal1 As Double, diagonal2 As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diagonal1 < 0 Then Throw New ArgumentException("Diagonale 1 darf nicht negativ sein.", NameOf(diagonal1))
            If diagonal2 < 0 Then Throw New ArgumentException("Diagonale 2 darf nicht negativ sein.", NameOf(diagonal2))
            Return (diagonal1 * diagonal2) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus zwei Seitenpaaren eines Drachenvierecks.
        ''' </summary>
        ''' <param name="sideA">Seitenlänge des ersten gleichen Paares (&gt;= 0)</param>
        ''' <param name="sideB">Seitenlänge des zweiten gleichen Paares (&gt;= 0)</param>
        ''' <returns>Umfang 2 * (sideA + sideB)</returns>
        Public Shared Function Perimeter(sideA As Double, sideB As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideA < 0 Then Throw New ArgumentException("Seitenlänge A darf nicht negativ sein.", NameOf(sideA))
            If sideB < 0 Then Throw New ArgumentException("Seitenlänge B darf nicht negativ sein.", NameOf(sideB))
            Return 2.0 * (sideA + sideB)
        End Function

        ''' <summary>
        ''' Berechnet die Fläche aus Grundseite und Höhe.
        ''' </summary>
        ''' <param name="baseLength">Grundseite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Fläche baseLength * height</returns>
        Public Shared Function AreaFromBaseHeight(baseLength As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseLength < 0 Then Throw New ArgumentException("Die Grundseite darf nicht negativ sein.", NameOf(baseLength))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            Return baseLength * height
        End Function

        ''' <summary>
        ''' Berechnet die Höhe aus Fläche und Grundseite.
        ''' </summary>
        ''' <param name="area">Fläche (&gt;= 0)</param>
        ''' <param name="baseLength">Grundseite (&gt; 0)</param>
        ''' <returns>Höhe area / baseLength</returns>
        Public Shared Function HeightFromArea(area As Double, baseLength As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then Throw New ArgumentException("Die Fläche darf nicht negativ sein.", NameOf(area))
            If baseLength <= 0 Then Throw New ArgumentException("Die Grundseite muss größer als 0 sein.", NameOf(baseLength))
            Return area / baseLength
        End Function

        ''' <summary>
        ''' Prüft, ob vier Seitenlängen ein symmetrisches Drachenmuster bilden (a,a,b,b in zyklischer Reihenfolge).
        ''' </summary>
        ''' <param name="sideA">Seite 1 (&gt;= 0)</param>
        ''' <param name="sideB">Seite 2 (&gt;= 0)</param>
        ''' <param name="sideC">Seite 3 (&gt;= 0)</param>
        ''' <param name="sideD">Seite 4 (&gt;= 0)</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn |A-B| und |C-D| innerhalb der Toleranz sind</returns>
        Public Shared Function IsSymmetricBySides(sideA As Double, sideB As Double, sideC As Double, sideD As Double, Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideA < 0 Then Throw New ArgumentException("Seite A darf nicht negativ sein.", NameOf(sideA))
            If sideB < 0 Then Throw New ArgumentException("Seite B darf nicht negativ sein.", NameOf(sideB))
            If sideC < 0 Then Throw New ArgumentException("Seite C darf nicht negativ sein.", NameOf(sideC))
            If sideD < 0 Then Throw New ArgumentException("Seite D darf nicht negativ sein.", NameOf(sideD))
            If tolerance <= 0 Then Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))

            Dim firstPair = Math.Abs(sideA - sideB) <= tolerance AndAlso Math.Abs(sideC - sideD) <= tolerance
            Dim secondPair = Math.Abs(sideB - sideC) <= tolerance AndAlso Math.Abs(sideD - sideA) <= tolerance
            Return firstPair OrElse secondPair
        End Function

        ''' <summary>
        ''' Berechnet 4 Eckpunkte eines Drachenvierecks aus Mittelpunkt, Diagonalen und Rotation.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="diagonal1">Länge der Hauptdiagonale (&gt;= 0)</param>
        ''' <param name="diagonal2">Länge der Nebendiagonale (&gt;= 0)</param>
        ''' <param name="rotationRadians">Rotation im Bogenmaß</param>
        ''' <returns>Array mit 4 Eckpunkten in umlaufender Reihenfolge</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, diagonal1 As Double, diagonal2 As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If diagonal1 < 0 Then Throw New ArgumentException("Diagonale 1 darf nicht negativ sein.", NameOf(diagonal1))
            If diagonal2 < 0 Then Throw New ArgumentException("Diagonale 2 darf nicht negativ sein.", NameOf(diagonal2))

            Dim halfD1 = diagonal1 / 2.0
            Dim halfD2 = diagonal2 / 2.0

            Dim local As PointF() = {
                New PointF(0.0F, CSng(-halfD1)),
                New PointF(CSng(halfD2), 0.0F),
                New PointF(0.0F, CSng(halfD1)),
                New PointF(CSng(-halfD2), 0.0F)
            }

            Dim cosA = Math.Cos(rotationRadians)
            Dim sinA = Math.Sin(rotationRadians)
            Dim result(3) As PointF

            For i = 0 To 3
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
        ''' Prüft, ob vier Eckpunkte ein Drachenviereck bilden (zwei benachbarte Seitenpaare gleich lang).
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte in umlaufender Reihenfolge</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn zwei benachbarte Seitenpaare gleich lang sind</returns>
        Public Shared Function IsKiteFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            If tolerance <= 0 Then Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))

            Dim l0 = Distance(vertices(0), vertices(1))
            Dim l1 = Distance(vertices(1), vertices(2))
            Dim l2 = Distance(vertices(2), vertices(3))
            Dim l3 = Distance(vertices(3), vertices(0))

            Dim patternA = Math.Abs(l0 - l1) <= tolerance AndAlso Math.Abs(l2 - l3) <= tolerance
            Dim patternB = Math.Abs(l1 - l2) <= tolerance AndAlso Math.Abs(l3 - l0) <= tolerance
            Return patternA OrElse patternB
        End Function

        Private Shared Sub ValidateVertices(vertices As PointF())
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then Throw New ArgumentException("Die Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            If vertices.Length <> 4 Then Throw New ArgumentException("Es müssen genau 4 Eckpunkte angegeben werden.", NameOf(vertices))
        End Sub

        Private Shared Function Distance(p1 As PointF, p2 As PointF) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim dx = p2.X - p1.X
            Dim dy = p2.Y - p1.Y
            Return Math.Sqrt((dx * dx) + (dy * dy))
        End Function

    End Class

End Namespace
