' --------------------------------------------------------------------------------------------------------
' Datei: Rectangle.vb
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
    ''' Stellt Funktionen zur Berechnung von Rechtecken und Quadraten bereit.
    ''' </summary>
    Public Class Rectangle

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet die Fläche eines Rechtecks.
        ''' </summary>
        ''' <param name="w">Breite (>= 0)</param>
        ''' <param name="h">Höhe (>= 0)</param>
        ''' <returns>Fläche (w * h)</returns>
        Public Shared Function Area(w As Double, h As Double) As Double
            ' Guard-Clauses: negative Werte sind nicht erlaubt
            If w < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeWidth, NameOf(w))
            End If
            If h < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(h))
            End If
            Return w * h
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Rechtecks.
        ''' </summary>
        ''' <param name="w">Breite (>= 0)</param>
        ''' <param name="h">Höhe (>= 0)</param>
        ''' <returns>Umfang (2 * (w + h))</returns>
        Public Shared Function Perimeter(w As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If w < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeWidth, NameOf(w))
            End If
            If h < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeHeight, NameOf(h))
            End If
            Return 2.0 * (w + h)
        End Function

        ''' <summary>
        ''' Berechnet die Länge der Diagonalen eines Rechtecks.
        ''' </summary>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe</param>
        ''' <returns>Diagonale = sqrt(w^2 + h^2)</returns>
        Public Shared Function Diagonal(w As Double, h As Double) As Double
            ' Pythagoras
            Return Math.Sqrt((w * w) + (h * h))
        End Function

        ''' <summary>
        ''' Berechnet das Seitenverhältnis (width / height).
        ''' </summary>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe (darf nicht 0 sein)</param>
        ''' <returns>Seitenverhältnis w / h</returns>
        ''' <exception cref="ArgumentException">Wenn h = 0</exception>
        Public Shared Function AspectRatio(w As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If h = 0 Then
                Throw New ArgumentException("Höhe darf nicht 0 sein.", NameOf(h))
            End If
            Return w / h
        End Function

        ''' <summary>
        ''' Prüft, ob Breite und Höhe ein Quadrat bilden.
        ''' </summary>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe</param>
        ''' <returns>True wenn w = h</returns>
        Public Shared Function IsSquare(w As Double, h As Double) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return w = h
        End Function

        ''' <summary>
        ''' Berechnet den Umkreisradius (Radius des kreisförmigen Umkreises) des Rechtecks.
        ''' </summary>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe</param>
        ''' <returns>Umkreisradius = Diagonale / 2</returns>
        Public Shared Function Circumradius(w As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Diagonal(w, h) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Inkreisradius (Radius des größten einbeschriebenen Kreises) des Rechtecks.
        ''' </summary>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe</param>
        ''' <returns>Inkreisradius = min(w,h) / 2</returns>
        Public Shared Function Inradius(w As Double, h As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Math.Min(w, h) / 2.0
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

        ''' <summary>
        ''' Berechnet den Mittelpunkt zweier Punkte.
        ''' </summary>
        ''' <param name="x1">X-Koordinate Punkt 1</param>
        ''' <param name="y1">Y-Koordinate Punkt 1</param>
        ''' <param name="x2">X-Koordinate Punkt 2</param>
        ''' <param name="y2">Y-Koordinate Punkt 2</param>
        ''' <returns>Mittelpunkt als PointF</returns>
        Public Shared Function Center(x1 As Double, y1 As Double, x2 As Double, y2 As Double) As PointF
            ' Mittelwert der Koordinaten
            Dim cx As Single = CSng((x1 + x2) / 2.0)
            Dim cy As Single = CSng((y1 + y2) / 2.0)
            Return New PointF(cx, cy)
        End Function

        ''' <summary>
        ''' Berechnet die 4 Eckpunkte eines (möglicherweise rotierten) Rechtecks aus Mittelpunkt, Breite, Höhe und Winkel.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="w">Breite</param>
        ''' <param name="h">Höhe</param>
        ''' <param name="angleRadians">Rotation im Bogenmaß (gegen den Uhrzeigersinn)</param>
        ''' <returns>Array mit 4 Eckpunkten im Uhrzeigersinn beginnend oben links (ungeordnet wenn Breite/Höhe negativ)</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, w As Double, h As Double, angleRadians As Double) As PointF()
            ' Halbe Abstände vom Zentrum zu den Seiten
            Dim halfW As Double = w / 2.0
            Dim halfH As Double = h / 2.0

            ' Unrotierte Eckpunkte relativ zum Mittelpunkt (Reihenfolge: oben links, oben rechts, unten rechts, unten links)
            Dim corners As Double(,) = New Double(3, 1) {{-halfW, -halfH}, {halfW, -halfH}, {halfW, halfH}, {-halfW, halfH}}

            Dim cosA As Double = Math.Cos(angleRadians)
            Dim sinA As Double = Math.Sin(angleRadians)

            Dim result As PointF() = New PointF(3) {}

            For i As Integer = 0 To 3
                Dim rx As Double = (corners(i, 0) * cosA) - (corners(i, 1) * sinA)
                Dim ry As Double = (corners(i, 0) * sinA) + (corners(i, 1) * cosA)

                ' Auf absolute Koordinaten translateiren
                result(i) = New PointF(CSng(cx + rx), CSng(cy + ry))
            Next

            Return result
        End Function

        ''' <summary>
        ''' Berechnet die Fläche aus einer Folge von Eckpunkten (Shoelace-Formel).
        ''' </summary>
        ''' <param name="vertices">Array mit Eckpunkten (beliebige Orientierung, geschlossener Polygon wird angenommen)</param>
        ''' <returns>Fläche (immer positiv)</returns>
        Public Shared Function AreaFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing OrElse vertices.Length < 3 Then Return 0.0

            Dim n As Integer = vertices.Length
            Dim sum As Double = 0.0

            For i As Integer = 0 To n - 1
                Dim j As Integer = (i + 1) Mod n
                sum += (vertices(i).X * vertices(j).Y) - (vertices(j).X * vertices(i).Y)
            Next

            ' absolute und halbieren
            Return Math.Abs(sum) / 2.0
        End Function

        ''' <summary>
        ''' Berechnet den Umfang eines Polygons aus den Eckpunkten.
        ''' </summary>
        ''' <param name="vertices">Array mit Eckpunkten</param>
        ''' <returns>Perimeter als Double</returns>
        Public Shared Function PerimeterFromVertices(vertices As PointF()) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing OrElse vertices.Length < 2 Then Return 0.0

            Dim n As Integer = vertices.Length
            Dim perim As Double = 0.0

            For i As Integer = 0 To n - 1
                Dim j As Integer = (i + 1) Mod n
                Dim dx As Double = vertices(j).X - vertices(i).X
                Dim dy As Double = vertices(j).Y - vertices(i).Y
                perim += Math.Sqrt((dx * dx) + (dy * dy))
            Next

            Return perim
        End Function

        ''' <summary>
        ''' Prüft, ob vier gegebene Punkte ein Rechteck bilden (rechter Winkel zwischen benachbarten Seiten).
        ''' </summary>
        ''' <param name="vertices">Array mit genau 4 Punkten in Reihenfolge</param>
        ''' <returns>True, wenn alle Innenwinkel rechte Winkel sind (innerhalb einer Toleranz)</returns>
        Public Shared Function IsRectangleFromVertices(vertices As PointF()) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If vertices Is Nothing OrElse vertices.Length <> 4 Then Return False

            ' Toleranz für numerische Ungenauigkeiten
            Const tol As Double = 0.000000001

            ' Prüfe jeden Winkel: Dot( v_i, v_{i+1} ) ~= 0
            For i As Integer = 0 To 3
                Dim p0 As PointF = vertices(i)
                Dim p1 As PointF = vertices((i + 1) Mod 4)
                Dim p2 As PointF = vertices((i + 2) Mod 4)

                Dim vx As Double = p1.X - p0.X
                Dim vy As Double = p1.Y - p0.Y

                Dim wx As Double = p2.X - p1.X
                Dim wy As Double = p2.Y - p1.Y

                Dim dot As Double = (vx * wx) + (vy * wy)
                Dim normProd As Double = Math.Sqrt(((vx * vx) + (vy * vy)) * ((wx * wx) + (wy * wy)))

                ' Wenn eine Seite sehr kurz ist, dann ist die Norm klein; vermeide Division durch 0
                If normProd = 0 Then Return False

                If Math.Abs(dot) > tol * normProd Then
                    Return False
                End If
            Next

            Return True
        End Function

#End Region

#Region "Abgeleitete Berechnungen"

        ''' <summary>
        ''' Fläche eines Quadrats mit Seitenlänge s.
        ''' </summary>
        Public Shared Function AreaSquare(s As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If s < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeLength, NameOf(s))
            End If
            Return s * s
        End Function

        ''' <summary>
        ''' Umfang eines Quadrats.
        ''' </summary>
        Public Shared Function PerimeterSquare(s As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If s < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeLength, NameOf(s))
            End If
            Return 4.0 * s
        End Function

        ''' <summary>
        ''' Diagonale eines Quadrats.
        ''' </summary>
        Public Shared Function DiagonalSquare(s As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return s * Math.Sqrt(2.0)
        End Function

        ''' <summary>
        ''' Berechnet die Seitenlänge eines Quadrats aus der Diagonale.
        ''' </summary>
        Public Shared Function FromDiagonalToSide(d As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If d < 0 Then
                Throw New ArgumentException("Diagonale darf nicht negativ sein.", NameOf(d))
            End If
            Return d / Math.Sqrt(2.0)
        End Function

#End Region

    End Class

End Namespace
