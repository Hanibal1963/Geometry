' --------------------------------------------------------------------------------------------------------
' Datei: Polygon.vb
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
    ''' Stellt Funktionen zur Berechnung von Polygonen bereit.
    ''' </summary>
    Public Class Polygon

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Polygons über die Shoelace-Formel.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 3)</param>
        ''' <returns>Fläche des Polygons</returns>
        Public Shared Function Area(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 3)

            Dim sum As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                sum += (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
            Next

            Return Math.Abs(sum) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Polygons als Summe der Kantenlängen.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 2)</param>
        ''' <returns>Umfang des Polygons</returns>
        Public Shared Function Perimeter(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 2)

            Dim totalPerimeter As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                totalPerimeter += Distance(vertices(i), vertices(j))
            Next

            Return totalPerimeter
        End Function

        ''' <summary>
        ''' Prüft, ob ein Polygon konvex ist.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 3)</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn das Polygon konvex ist</returns>
        Public Shared Function IsConvex(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 3)
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If

            Dim hasPositive As Boolean = False
            Dim hasNegative As Boolean = False

            For i = 0 To vertices.Length - 1
                Dim p0 = vertices(i)
                Dim p1 = vertices((i + 1) Mod vertices.Length)
                Dim p2 = vertices((i + 2) Mod vertices.Length)

                Dim cross = CrossZ(p0, p1, p2)
                If cross > tolerance Then hasPositive = True
                If cross < -tolerance Then hasNegative = True

                If hasPositive AndAlso hasNegative Then
                    Return False
                End If
            Next

            Return True
        End Function

        ''' <summary>
        ''' Prüft, ob ein Polygon regelmäßig ist (gleiche Seitenlängen und gleiche Abstände zum Schwerpunkt).
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 3)</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn das Polygon regelmäßig ist</returns>
        Public Shared Function IsRegular(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 3)
            If tolerance <= 0 Then
                Throw New ArgumentException(My.Resources.CheckPositiveTolerance, NameOf(tolerance))
            End If
            If Not IsConvex(vertices, tolerance) Then Return False

            Dim firstSide = Distance(vertices(0), vertices(1))
            Dim center = Centroid(vertices)
            Dim firstRadius = Distance(vertices(0), center)

            For i = 1 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                Dim side = Distance(vertices(i), vertices(j))
                If Math.Abs(side - firstSide) > tolerance Then Return False

                Dim radius = Distance(vertices(i), center)
                If Math.Abs(radius - firstRadius) > tolerance Then Return False
            Next

            Return True
        End Function

        ''' <summary>
        ''' Berechnet den Schwerpunkt eines Polygons.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 3)</param>
        ''' <returns>Schwerpunkt als PointF</returns>
        Public Shared Function Centroid(vertices As PointF()) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 3)

            Dim signedArea2 As Double = 0.0
            Dim cx As Double = 0.0
            Dim cy As Double = 0.0

            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                Dim cross = (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
                signedArea2 += cross
                cx += (vertices(i).X + vertices(j).X) * cross
                cy += (vertices(i).Y + vertices(j).Y) * cross
            Next

            If Math.Abs(signedArea2) <= Double.Epsilon Then
                Throw New ArgumentException(My.Resources.CheckPolygonNonDegenerate, NameOf(vertices))
            End If

            Dim factor = 1.0 / (3.0 * signedArea2)
            Return New PointF(CSng(cx * factor), CSng(cy * factor))
        End Function

        ''' <summary>
        ''' Berechnet das achsenparallele Begrenzungsrechteck eines Polygons.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 1)</param>
        ''' <returns>Begrenzungsrechteck als RectangleF</returns>
        Public Shared Function BoundingBox(vertices As PointF()) As RectangleF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 1)

            Dim minX = vertices(0).X
            Dim minY = vertices(0).Y
            Dim maxX = vertices(0).X
            Dim maxY = vertices(0).Y

            For i = 1 To vertices.Length - 1
                minX = Math.Min(minX, vertices(i).X)
                minY = Math.Min(minY, vertices(i).Y)
                maxX = Math.Max(maxX, vertices(i).X)
                maxY = Math.Max(maxY, vertices(i).Y)
            Next

            Return RectangleF.FromLTRB(minX, minY, maxX, maxY)
        End Function

        ''' <summary>
        ''' Verschiebt alle Eckpunkte um einen Vektor.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 1)</param>
        ''' <param name="dx">Verschiebung in X-Richtung</param>
        ''' <param name="dy">Verschiebung in Y-Richtung</param>
        ''' <returns>Neue, verschobene Eckpunkte</returns>
        Public Shared Function Translate(vertices As PointF(), dx As Double, dy As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 1)

            Dim result(vertices.Length - 1) As PointF
            For i = 0 To vertices.Length - 1
                result(i) = New PointF(CSng(vertices(i).X + dx), CSng(vertices(i).Y + dy))
            Next

            Return result
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        ''' <summary>
        ''' Rotiert alle Eckpunkte um einen Mittelpunkt.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte des Polygons (mindestens 1)</param>
        ''' <param name="angleRadians">Rotationswinkel im Bogenmaß</param>
        ''' <param name="center">Rotationszentrum</param>
        ''' <returns>Neue, rotierte Eckpunkte</returns>
        Public Shared Function Rotate(vertices As PointF(), angleRadians As Double, center As PointF) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 1)

            Dim cosA = Math.Cos(angleRadians)
            Dim sinA = Math.Sin(angleRadians)
            Dim result(vertices.Length - 1) As PointF

            For i = 0 To vertices.Length - 1
                Dim x = vertices(i).X - center.X
                Dim y = vertices(i).Y - center.Y

                Dim rx = (x * cosA) - (y * sinA) + center.X
                Dim ry = (x * sinA) + (y * cosA) + center.Y

                result(i) = New PointF(CSng(rx), CSng(ry))
            Next

            Return result
        End Function

        Private Shared Sub ValidateVertices(vertices As PointF(), minCount As Integer)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then
                Throw New ArgumentException(My.Resources.CheckVerticesNotNull, NameOf(vertices))
            End If
            If vertices.Length < minCount Then
                Throw New ArgumentException(My.Resources.CheckVerticesMinimumCount.Replace("{0}", minCount.ToString()), NameOf(vertices))
            End If
        End Sub

        Private Shared Function CrossZ(p0 As PointF, p1 As PointF, p2 As PointF) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim ax = p1.X - p0.X
            Dim ay = p1.Y - p0.Y
            Dim bx = p2.X - p1.X
            Dim by = p2.Y - p1.Y
            Return (ax * by) - (ay * bx)
        End Function

        Private Shared Function Distance(p1 As PointF, p2 As PointF) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim dx = p2.X - p1.X
            Dim dy = p2.Y - p1.Y
            Return Math.Sqrt((dx * dx) + (dy * dy))
        End Function

#End Region

    End Class

End Namespace
