' --------------------------------------------------------------------------------------------------------
' Datei: Prism.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung verschiedener Prismen bereit.
    ''' </summary>
    Public Class Prism

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet das Volumen eines geraden Prismas.
        ''' </summary>
        ''' <param name="baseArea">Grundfläche (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen baseArea * height</returns>
        Public Shared Function Volume(baseArea As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseArea < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(baseArea))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return baseArea * height
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines geraden Prismas.
        ''' </summary>
        ''' <param name="basePerimeter">Umfang der Grundfläche (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche basePerimeter * height</returns>
        Public Shared Function LateralArea(basePerimeter As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If basePerimeter < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeCircumference, NameOf(basePerimeter))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return basePerimeter * height
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines geraden Prismas.
        ''' </summary>
        ''' <param name="baseArea">Grundfläche (&gt;= 0)</param>
        ''' <param name="basePerimeter">Umfang der Grundfläche (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche 2 * baseArea + basePerimeter * height</returns>
        Public Shared Function SurfaceArea(baseArea As Double, basePerimeter As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If baseArea < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(baseArea))
            End If
            If basePerimeter < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeCircumference, NameOf(basePerimeter))
            End If
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return (2.0 * baseArea) + LateralArea(basePerimeter, height)
        End Function

#End Region

#Region "Abgeleitete Berechnungen"

        ''' <summary>
        ''' Berechnet die Grundfläche eines Dreiecks über die drei Seitenlängen (Heron-Formel).
        ''' </summary>
        ''' <param name="sideA">Seite A (&gt; 0)</param>
        ''' <param name="sideB">Seite B (&gt; 0)</param>
        ''' <param name="sideC">Seite C (&gt; 0)</param>
        ''' <returns>Dreiecksfläche</returns>
        Public Shared Function TriangularBaseArea(sideA As Double, sideB As Double, sideC As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateTriangleSides(sideA, sideB, sideC)

            Dim s = (sideA + sideB + sideC) / 2.0
            Return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC))
        End Function

        ''' <summary>
        ''' Berechnet das Volumen eines Dreiecksprismas.
        ''' </summary>
        ''' <param name="sideA">Seite A der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="sideB">Seite B der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="sideC">Seite C der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="height">Prismahöhe (&gt;= 0)</param>
        ''' <returns>Volumen Dreiecksgrundfläche * height</returns>
        Public Shared Function TriangularPrismVolume(sideA As Double, sideB As Double, sideC As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Return Volume(TriangularBaseArea(sideA, sideB, sideC), height)
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines Dreiecksprismas.
        ''' </summary>
        ''' <param name="sideA">Seite A der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="sideB">Seite B der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="sideC">Seite C der Dreiecksgrundfläche (&gt; 0)</param>
        ''' <param name="height">Prismahöhe (&gt;= 0)</param>
        ''' <returns>Oberfläche 2 * Dreiecksgrundfläche + (a+b+c) * height</returns>
        Public Shared Function TriangularPrismSurfaceArea(sideA As Double, sideB As Double, sideC As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Dim baseArea = TriangularBaseArea(sideA, sideB, sideC)
            Dim basePerimeter = sideA + sideB + sideC
            Return SurfaceArea(baseArea, basePerimeter, height)
        End Function

        ''' <summary>
        ''' Berechnet die Grundfläche eines regelmäßigen n-Ecks.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Fläche n*s^2/(4*tan(PI/n))</returns>
        Public Shared Function RegularPolygonBaseArea(sideLength As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideLength < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(sideLength))
            End If
            ValidateSideCount(sideCount)

            If sideLength = 0 Then Return 0
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (sideCount * sideLength * sideLength) / (4.0 * Math.Tan(Math.PI / sideCount))
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet das Volumen eines regelmäßigen n-Eck-Prismas.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge der n-Eck-Grundfläche (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <param name="height">Prismahöhe (&gt;= 0)</param>
        ''' <returns>Volumen Grundfläche * Höhe</returns>
        Public Shared Function RegularPolygonPrismVolume(sideLength As Double, sideCount As Integer, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Dim baseArea = RegularPolygonBaseArea(sideLength, sideCount)
            Return Volume(baseArea, height)
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines regelmäßigen n-Eck-Prismas.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge der n-Eck-Grundfläche (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <param name="height">Prismahöhe (&gt;= 0)</param>
        ''' <returns>Oberfläche 2 * Grundfläche + Umfang * Höhe</returns>
        Public Shared Function RegularPolygonPrismSurfaceArea(sideLength As Double, sideCount As Integer, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If height < 0 Then
                Throw New ArgumentException(My.Resources.HeightIsNegative, NameOf(height))
            End If
            Dim baseArea = RegularPolygonBaseArea(sideLength, sideCount)
            Dim basePerimeter = sideCount * sideLength
            Return SurfaceArea(baseArea, basePerimeter, height)
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateTriangleSides(sideA As Double, sideB As Double, sideC As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideA <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(sideA))
            End If
            If sideB <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(sideB))
            End If
            If sideC <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveSide, NameOf(sideC))
            End If

            If sideA + sideB <= sideC OrElse sideA + sideC <= sideB OrElse sideB + sideC <= sideA Then
                Throw New ArgumentException(My.Resources.String1, NameOf(sideC))
            End If
        End Sub

        Private Shared Sub ValidateSideCount(sideCount As Integer)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideCount < 3 Then
                Throw New ArgumentException(My.Resources.RequireAtLeastThreeSides, NameOf(sideCount))
            End If
        End Sub

#End Region

    End Class

End Namespace
