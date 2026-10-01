' --------------------------------------------------------------------------------------------------------
' Datei: Pyramid.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Pyramiden bereit.
    ''' </summary>
    Public Class Pyramid

        ''' <summary>
        ''' Berechnet die Grundfläche einer rechteckigen Pyramide.
        ''' </summary>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <returns>Grundfläche length * width</returns>
        Public Shared Function BaseArea(length As Double, width As Double) As Double
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            Return length * width
        End Function

        ''' <summary>
        ''' Berechnet das Volumen einer rechteckigen Pyramide.
        ''' </summary>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen (Grundfläche * Höhe) / 3</returns>
        Public Shared Function Volume(length As Double, width As Double, height As Double) As Double
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return (BaseArea(length, width) * height) / 3.0
        End Function

        ''' <summary>
        ''' Berechnet die Schräghöhe der Seitenflächen mit Grundkante Länge.
        ''' </summary>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Schräghöhe sqrt((width/2)^2 + h^2)</returns>
        Public Shared Function SlantHeightLengthFace(width As Double, height As Double) As Double
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Dim halfWidth = width / 2.0
            Return Math.Sqrt((halfWidth * halfWidth) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet die Schräghöhe der Seitenflächen mit Grundkante Breite.
        ''' </summary>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Schräghöhe sqrt((length/2)^2 + h^2)</returns>
        Public Shared Function SlantHeightWidthFace(length As Double, height As Double) As Double
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Dim halfLength = length / 2.0
            Return Math.Sqrt((halfLength * halfLength) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche einer rechteckigen Pyramide.
        ''' </summary>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche aus 4 Dreiecksflächen</returns>
        Public Shared Function LateralArea(length As Double, width As Double, height As Double) As Double
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Dim slantLen = SlantHeightLengthFace(width, height)
            Dim slantWid = SlantHeightWidthFace(length, height)
            Return (length * slantLen) + (width * slantWid)
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche einer rechteckigen Pyramide.
        ''' </summary>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Gesamtoberfläche Grundfläche + Mantelfläche</returns>
        Public Shared Function SurfaceArea(length As Double, width As Double, height As Double) As Double
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return BaseArea(length, width) + LateralArea(length, width, height)
        End Function

        ''' <summary>
        ''' Berechnet das Volumen eines rechteckigen Pyramidenstumpfs.
        ''' </summary>
        ''' <param name="bottomLength">Untere Grundlänge (&gt; 0)</param>
        ''' <param name="bottomWidth">Untere Grundbreite (&gt; 0)</param>
        ''' <param name="topLength">Obere Grundlänge (&gt;= 0 und &lt; bottomLength)</param>
        ''' <param name="topWidth">Obere Grundbreite (&gt;= 0 und &lt; bottomWidth)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen h/3 * (A1 + A2 + sqrt(A1*A2))</returns>
        Public Shared Function FrustumVolume(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ValidateFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

            Dim a1 = bottomLength * bottomWidth
            Dim a2 = topLength * topWidth
            Return (height / 3.0) * (a1 + a2 + Math.Sqrt(a1 * a2))
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines rechteckigen Pyramidenstumpfs.
        ''' </summary>
        ''' <param name="bottomLength">Untere Grundlänge (&gt; 0)</param>
        ''' <param name="bottomWidth">Untere Grundbreite (&gt; 0)</param>
        ''' <param name="topLength">Obere Grundlänge (&gt;= 0 und &lt; bottomLength)</param>
        ''' <param name="topWidth">Obere Grundbreite (&gt;= 0 und &lt; bottomWidth)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche als Summe der 4 Trapezflächen</returns>
        Public Shared Function FrustumLateralArea(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ValidateFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

            Dim slantAlongLength = Math.Sqrt(Math.Pow((bottomWidth - topWidth) / 2.0, 2) + (height * height))
            Dim slantAlongWidth = Math.Sqrt(Math.Pow((bottomLength - topLength) / 2.0, 2) + (height * height))

            Return ((bottomLength + topLength) * slantAlongLength) + ((bottomWidth + topWidth) * slantAlongWidth)
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines rechteckigen Pyramidenstumpfs.
        ''' </summary>
        ''' <param name="bottomLength">Untere Grundlänge (&gt; 0)</param>
        ''' <param name="bottomWidth">Untere Grundbreite (&gt; 0)</param>
        ''' <param name="topLength">Obere Grundlänge (&gt;= 0 und &lt; bottomLength)</param>
        ''' <param name="topWidth">Obere Grundbreite (&gt;= 0 und &lt; bottomWidth)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Gesamtoberfläche Grundflächen + Mantel</returns>
        Public Shared Function FrustumSurfaceArea(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ValidateFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

            Dim baseAreas = (bottomLength * bottomWidth) + (topLength * topWidth)
            Return baseAreas + FrustumLateralArea(bottomLength, bottomWidth, topLength, topWidth, height)
        End Function

        ''' <summary>
        ''' Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten.
        ''' </summary>
        ''' <param name="x1">X von Punkt 1</param>
        ''' <param name="y1">Y von Punkt 1</param>
        ''' <param name="z1">Z von Punkt 1</param>
        ''' <param name="x2">X von Punkt 2</param>
        ''' <param name="y2">Y von Punkt 2</param>
        ''' <param name="z2">Z von Punkt 2</param>
        ''' <returns>Mittelpunkt als Tuple(X,Y,Z)</returns>
        Public Shared Function Center(x1 As Double, y1 As Double, z1 As Double, x2 As Double, y2 As Double, z2 As Double) As Tuple(Of Double, Double, Double)
            Return Tuple.Create((x1 + x2) / 2.0, (y1 + y2) / 2.0, (z1 + z2) / 2.0)
        End Function

        ''' <summary>
        ''' Berechnet die 5 Eckpunkte einer geraden rechteckigen Pyramide aus Mittelpunkt und Abmessungen.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="cz">Mittelpunkt Z</param>
        ''' <param name="length">Grundlänge (&gt;= 0)</param>
        ''' <param name="width">Grundbreite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Array mit 5 Punkten: 4 Grundpunkte + Spitze</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, cz As Double, length As Double, width As Double, height As Double) As Tuple(Of Double, Double, Double)()
            If length < 0 Then Throw New ArgumentException("Die Grundlänge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Grundbreite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Dim halfLength = length / 2.0
            Dim halfWidth = width / 2.0
            Dim halfHeight = height / 2.0

            Return New Tuple(Of Double, Double, Double)() {
                Tuple.Create(cx - halfLength, cy - halfWidth, cz - halfHeight),
                Tuple.Create(cx + halfLength, cy - halfWidth, cz - halfHeight),
                Tuple.Create(cx + halfLength, cy + halfWidth, cz - halfHeight),
                Tuple.Create(cx - halfLength, cy + halfWidth, cz - halfHeight),
                Tuple.Create(cx, cy, cz + halfHeight)
            }
        End Function

        Private Shared Sub ValidateFrustumInputs(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double)
            If bottomLength <= 0 Then Throw New ArgumentException("Die untere Grundlänge muss größer als 0 sein.", NameOf(bottomLength))
            If bottomWidth <= 0 Then Throw New ArgumentException("Die untere Grundbreite muss größer als 0 sein.", NameOf(bottomWidth))
            If topLength < 0 Then Throw New ArgumentException("Die obere Grundlänge darf nicht negativ sein.", NameOf(topLength))
            If topWidth < 0 Then Throw New ArgumentException("Die obere Grundbreite darf nicht negativ sein.", NameOf(topWidth))
            If topLength >= bottomLength Then Throw New ArgumentException("Die obere Grundlänge muss kleiner als die untere Grundlänge sein.", NameOf(topLength))
            If topWidth >= bottomWidth Then Throw New ArgumentException("Die obere Grundbreite muss kleiner als die untere Grundbreite sein.", NameOf(topWidth))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
        End Sub

    End Class

End Namespace
