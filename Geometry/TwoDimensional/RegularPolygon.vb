' --------------------------------------------------------------------------------------------------------
' Datei: RegularPolygon.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Imports System.Drawing

Namespace TwoDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung regelmäßiger Polygone bereit.
    ''' </summary>
    Public Class RegularPolygon

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet den Umfang eines regelmäßigen Polygons.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Umfang sideCount * sideLength</returns>
        Public Shared Function Perimeter(sideLength As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideLength < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(sideLength))
            End If
            ValidateSideCount(sideCount)
            Return sideCount * sideLength
        End Function

        ''' <summary>
        ''' Berechnet den Innenwinkel eines regelmäßigen Polygons im Bogenmaß.
        ''' </summary>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Innenwinkel ((n-2)*PI)/n</returns>
        Public Shared Function InteriorAngle(sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSideCount(sideCount)
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return ((sideCount - 2.0) * Math.PI) / sideCount
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet den Außenwinkel eines regelmäßigen Polygons im Bogenmaß.
        ''' </summary>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Außenwinkel 2*PI/n</returns>
        Public Shared Function ExteriorAngle(sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSideCount(sideCount)
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Return (2.0 * Math.PI) / sideCount
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Function

        ''' <summary>
        ''' Berechnet die Apothem-Länge eines regelmäßigen Polygons.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Apothem sideLength / (2*tan(PI/n))</returns>
        Public Shared Function Apothem(sideLength As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideLength < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(sideLength))
            End If
            ValidateSideCount(sideCount)

            If sideLength = 0 Then Return 0
            Return sideLength / (2.0 * Math.Tan(Math.PI / sideCount))
        End Function

        ''' <summary>
        ''' Berechnet den Umkreisradius eines regelmäßigen Polygons.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Umkreisradius sideLength / (2*sin(PI/n))</returns>
        Public Shared Function Circumradius(sideLength As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideLength < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(sideLength))
            End If
            ValidateSideCount(sideCount)

            If sideLength = 0 Then Return 0
            Return sideLength / (2.0 * Math.Sin(Math.PI / sideCount))
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines regelmäßigen Polygons.
        ''' </summary>
        ''' <param name="sideLength">Seitenlänge (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Fläche 0.5 * Umfang * Apothem</returns>
        Public Shared Function Area(sideLength As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim perimeterValue = Perimeter(sideLength, sideCount)
            Dim apothemValue = Apothem(sideLength, sideCount)
            Return 0.5 * perimeterValue * apothemValue
        End Function

        ''' <summary>
        ''' Berechnet die Seitenlänge aus Umfang und Seitenanzahl.
        ''' </summary>
        ''' <param name="perimeter">Umfang (&gt;= 0)</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <returns>Seitenlänge perimeter / sideCount</returns>
        Public Shared Function SideLengthFromPerimeter(perimeter As Double, sideCount As Integer) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If perimeter < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeCircumference, NameOf(perimeter))
            End If
            ValidateSideCount(sideCount)
            Return perimeter / sideCount
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet Eckpunkte eines regelmäßigen Polygons aus Mittelpunkt, Umkreisradius und Rotation.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="sideCount">Anzahl der Seiten (&gt;= 3)</param>
        ''' <param name="circumradius">Umkreisradius (&gt;= 0)</param>
        ''' <param name="rotationRadians">Rotation im Bogenmaß</param>
        ''' <returns>Eckpunkte in umlaufender Reihenfolge</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, sideCount As Integer, circumradius As Double, rotationRadians As Double) As PointF()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateSideCount(sideCount)
            If circumradius < 0 Then
                Throw New ArgumentException(My.Resources.RadiusIsNegative, NameOf(circumradius))
            End If

            Dim result(sideCount - 1) As PointF
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Dim stepAngle = (2.0 * Math.PI) / sideCount
#Enable Warning IDE0047 ' Unnötige Klammern entfernen

            For i = 0 To sideCount - 1
                Dim angle = rotationRadians + (i * stepAngle)
                Dim x = cx + (circumradius * Math.Cos(angle))
                Dim y = cy + (circumradius * Math.Sin(angle))
                result(i) = New PointF(CSng(x), CSng(y))
            Next

            Return result
        End Function

        ''' <summary>
        ''' Berechnet die Fläche eines Polygons aus Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Eckpunkte (mindestens 3)</param>
        ''' <returns>Fläche</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
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
        ''' Berechnet den Umfang eines Polygons aus Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte (mindestens 2)</param>
        ''' <returns>Umfang</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 2)

            Dim total As Double = 0.0
            For i = 0 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                total += Distance(vertices(i), vertices(j))
            Next

            Return total
        End Function

        ''' <summary>
        ''' Prüft, ob Eckpunkte ein regelmäßiges Polygon bilden.
        ''' </summary>
        ''' <param name="vertices">Eckpunkte in umlaufender Reihenfolge (mindestens 3)</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn alle Seitenlängen und Radien zum Mittelpunkt innerhalb der Toleranz gleich sind</returns>
        Public Shared Function IsRegularFromVertices(vertices As PointF(), Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateVertices(vertices, 3)
            If tolerance <= 0 Then
                Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))
            End If

            If AreaFromVertices(vertices) <= tolerance Then Return False

            Dim firstSide = Distance(vertices(0), vertices(1))
            If firstSide <= tolerance Then Return False

            Dim center = AverageCenter(vertices)
            Dim firstRadius = Distance(vertices(0), center)
            If firstRadius <= tolerance Then Return False

            For i = 1 To vertices.Length - 1
                Dim j = (i + 1) Mod vertices.Length
                Dim side = Distance(vertices(i), vertices(j))
                If Math.Abs(side - firstSide) > tolerance Then Return False

                Dim radius = Distance(vertices(i), center)
                If Math.Abs(radius - firstRadius) > tolerance Then Return False
            Next

            Return True
        End Function

#End Region

#Region "Validierung und interne Hilfsmethoden"

        Private Shared Sub ValidateSideCount(sideCount As Integer)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If sideCount < 3 Then
                Throw New ArgumentException("Die Seitenanzahl muss größer oder gleich 3 sein.", NameOf(sideCount))
            End If
        End Sub

        Private Shared Sub ValidateVertices(vertices As PointF(), minCount As Integer)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing Then
                Throw New ArgumentException("Eckpunkte dürfen nicht Nothing sein.", NameOf(vertices))
            End If
            If vertices.Length < minCount Then
                Throw New ArgumentException($"Es müssen mindestens {minCount} Eckpunkte vorhanden sein.", NameOf(vertices))
            End If
        End Sub

        Private Shared Function AverageCenter(vertices As PointF()) As PointF
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim sumX As Double = 0.0
            Dim sumY As Double = 0.0

            For i = 0 To vertices.Length - 1
                sumX += vertices(i).X
                sumY += vertices(i).Y
            Next

            Return New PointF(CSng(sumX / vertices.Length), CSng(sumY / vertices.Length))
        End Function

        Private Shared Function Distance(a As PointF, b As PointF) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Dim dx = b.X - a.X
            Dim dy = b.Y - a.Y
            Return Math.Sqrt((dx * dx) + (dy * dy))
        End Function

#End Region

    End Class

End Namespace
