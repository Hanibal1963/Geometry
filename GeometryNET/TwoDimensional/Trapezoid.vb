' --------------------------------------------------------------------------------------------------------
' Datei: Trapezoid.vb
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
    ''' Stellt Funktionen zur Berechnung von Trapezen bereit.
    ''' </summary>
    Public Class Trapezoid

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Trapezes.
        ''' </summary>
        ''' <param name="baseA">Grundseite a (>= 0)</param>
        ''' <param name="baseB">Grundseite c (>= 0)</param>
        ''' <param name="height">Höhe (>= 0)</param>
        ''' <returns>Fläche ((a + c) / 2) * h</returns>
        Public Shared Function Area(baseA As Double, baseB As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseA < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseA))
            End If
            If baseB < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseB))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(height))
            End If

#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return ((baseA + baseB) / 2.0) * height
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Trapezes.
        ''' </summary>
        ''' <param name="baseA">Grundseite a (> 0)</param>
        ''' <param name="legB">Seite b (> 0)</param>
        ''' <param name="baseC">Grundseite c (> 0)</param>
        ''' <param name="legD">Seite d (> 0)</param>
        ''' <returns>Umfang a + b + c + d</returns>
        Public Shared Function Perimeter(baseA As Double, legB As Double, baseC As Double, legD As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseA <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(baseA))
            End If
            If legB <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(legB))
            End If
            If baseC <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(baseC))
            End If
            If legD <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(legD))
            End If

            Return baseA + legB + baseC + legD
        End Function

        ''' <summary>
        ''' Berechnet die Mittellinie eines Trapezes.
        ''' </summary>
        ''' <param name="baseA">Grundseite a (>= 0)</param>
        ''' <param name="baseB">Grundseite c (>= 0)</param>
        ''' <returns>Mittellinie (a + c) / 2</returns>
        Public Shared Function Midline(baseA As Double, baseB As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseA < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseA))
            End If
            If baseB < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseB))
            End If

            Return (baseA + baseB) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet die Höhe aus Fläche und parallelen Grundseiten.
        ''' </summary>
        ''' <param name="area">Fläche (>= 0)</param>
        ''' <param name="baseA">Grundseite a (>= 0)</param>
        ''' <param name="baseB">Grundseite c (>= 0)</param>
        ''' <returns>Höhe</returns>
        Public Shared Function HeightFromArea(area As Double, baseA As Double, baseB As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If area < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(area))
            End If
            If baseA < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseA))
            End If
            If baseB < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseB))
            End If

            Dim denominator = baseA + baseB
            If denominator <= 0 Then
                Throw New ArgumentException(My.Resources.CheckBasesSumPositive)
            End If

#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (2.0 * area) / denominator
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Schenkellänge eines gleichschenkligen Trapezes.
        ''' </summary>
        ''' <param name="baseA">Grundseite a (>= 0)</param>
        ''' <param name="baseB">Grundseite c (>= 0)</param>
        ''' <param name="height">Höhe (>= 0)</param>
        ''' <returns>Schenkellänge</returns>
        Public Shared Function LegLengthIsosceles(baseA As Double, baseB As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseA < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseA))
            End If
            If baseB < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeSide, NameOf(baseB))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(height))
            End If

            Dim halfDiff = Math.Abs(baseA - baseB) / 2.0
            Return Math.Sqrt((halfDiff * halfDiff) + (height * height))
        End Function

        ''' <summary>
        ''' Prüft, ob ein Trapez gleichschenklig ist.
        ''' </summary>
        ''' <param name="legB">Seite b (> 0)</param>
        ''' <param name="legD">Seite d (> 0)</param>
        ''' <param name="tolerance">Numerische Toleranz (> 0)</param>
        ''' <returns>True, wenn |b-d| innerhalb der Toleranz liegt</returns>
        Public Shared Function IsIsosceles(legB As Double, legD As Double, Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If legB <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(legB))
            End If
            If legD <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(legD))
            End If
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If

            Return Math.Abs(legB - legD) <= tolerance
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet 4 Eckpunkte eines gleichschenkligen Trapezes aus Mittelpunkt, Grundseiten, Höhe und Rotation.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="baseA">Untere Grundseite a (> 0)</param>
        ''' <param name="baseB">Obere Grundseite c (> 0)</param>
        ''' <param name="height">Höhe (> 0)</param>
        ''' <param name="rotationRadians">Rotation im Bogenmaß</param>
        ''' <returns>Array mit 4 Eckpunkten im Uhrzeigersinn</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, baseA As Double, baseB As Double, height As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseA <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(baseA))
            End If
            If baseB <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(baseB))
            End If
            If height <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveHeight, NameOf(height))
            End If

            Dim halfA = baseA / 2.0
            Dim halfB = baseB / 2.0
            Dim halfH = height / 2.0

            Dim local As PointF() = {
                New PointF(CSng(-halfA), CSng(halfH)),
                New PointF(CSng(halfA), CSng(halfH)),
                New PointF(CSng(halfB), CSng(-halfH)),
                New PointF(CSng(-halfB), CSng(-halfH))
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
        ''' Berechnet die Fläche eines Vierecks aus Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte</param>
        ''' <returns>Fläche</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)

            Dim sum As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                sum += (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
            Next

            Return Math.Abs(sum) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang aus vier Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte</param>
        ''' <returns>Umfang</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)

            Dim total As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                total += Distance(vertices(i), vertices(j))
            Next

            Return total
        End Function

        ''' <summary>
        ''' Prüft, ob vier Punkte ein Trapez bilden (mindestens ein Paar gegenüberliegender Seiten parallel).
        ''' </summary>
        ''' <param name="vertices">Vier Eckpunkte in umlaufender Reihenfolge</param>
        ''' <param name="tolerance">Numerische Toleranz (> 0)</param>
        ''' <returns>True, wenn mindestens ein Paar gegenüberliegender Seiten parallel ist</returns>
        Public Shared Function IsTrapezoidFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices)
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If

            Dim ab = New PointF(vertices(1).X - vertices(0).X, vertices(1).Y - vertices(0).Y)
            Dim bc = New PointF(vertices(2).X - vertices(1).X, vertices(2).Y - vertices(1).Y)
            Dim cd = New PointF(vertices(3).X - vertices(2).X, vertices(3).Y - vertices(2).Y)
            Dim da = New PointF(vertices(0).X - vertices(3).X, vertices(0).Y - vertices(3).Y)

            Dim crossABCD = Math.Abs((ab.X * cd.Y) - (ab.Y * cd.X))
            Dim crossBCDA = Math.Abs((bc.X * da.Y) - (bc.Y * da.X))

            Return crossABCD <= tolerance OrElse crossBCDA <= tolerance
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateVertices(vertices As PointF())
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then
                Throw New ArgumentException(My.Resources.CheckVerticesNotNull, NameOf(vertices))
            End If
            If vertices.Length <> 4 Then
                Throw New ArgumentException(My.Resources.RequireExactlyFourVertices, NameOf(vertices))
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
