' --------------------------------------------------------------------------------------------------------
' Datei: Cuboid.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Quadern bereit.
    ''' </summary>
    Public Class Cuboid

        ''' <summary>
        ''' Berechnet das Volumen eines Quaders.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen length * width * height</returns>
        Public Shared Function Volume(length As Double, width As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return length * width * height
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines Quaders.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche 2 * (lw + lh + wh)</returns>
        Public Shared Function SurfaceArea(length As Double, width As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return 2.0 * ((length * width) + (length * height) + (width * height))
        End Function

        ''' <summary>
        ''' Berechnet die Raumdiagonale eines Quaders.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Raumdiagonale sqrt(l^2 + w^2 + h^2)</returns>
        Public Shared Function SpaceDiagonal(length As Double, width As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return Math.Sqrt((length * length) + (width * width) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet die Flächendiagonale der Seitenfläche Länge-Breite.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <returns>Flächendiagonale sqrt(l^2 + w^2)</returns>
        Public Shared Function FaceDiagonalLengthWidth(length As Double, width As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            Return Math.Sqrt((length * length) + (width * width))
        End Function

        ''' <summary>
        ''' Berechnet die Flächendiagonale der Seitenfläche Länge-Höhe.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Flächendiagonale sqrt(l^2 + h^2)</returns>
        Public Shared Function FaceDiagonalLengthHeight(length As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            Return Math.Sqrt((length * length) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet die Flächendiagonale der Seitenfläche Breite-Höhe.
        ''' </summary>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Flächendiagonale sqrt(w^2 + h^2)</returns>
        Public Shared Function FaceDiagonalWidthHeight(width As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            Return Math.Sqrt((width * width) + (height * height))
        End Function

        ''' <summary>
        ''' Berechnet eine fehlende Kante aus Volumen und zwei bekannten Kanten.
        ''' </summary>
        ''' <param name="volume">Volumen (&gt;= 0)</param>
        ''' <param name="edge1">Kante 1 (&gt; 0)</param>
        ''' <param name="edge2">Kante 2 (&gt; 0)</param>
        ''' <returns>Fehlende Kante volume / (edge1 * edge2)</returns>
        Public Shared Function EdgeFromVolume(volume As Double, edge1 As Double, edge2 As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If volume < 0 Then Throw New ArgumentException("Das Volumen darf nicht negativ sein.", NameOf(volume))
            If edge1 <= 0 Then Throw New ArgumentException("Kante 1 muss größer als 0 sein.", NameOf(edge1))
            If edge2 <= 0 Then Throw New ArgumentException("Kante 2 muss größer als 0 sein.", NameOf(edge2))
            Return volume / (edge1 * edge2)
        End Function

        ''' <summary>
        ''' Prüft, ob die drei Kantenlängen einen Würfel bilden.
        ''' </summary>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <param name="tolerance">Numerische Toleranz (&gt; 0)</param>
        ''' <returns>True, wenn alle drei Kanten innerhalb der Toleranz gleich sind</returns>
        Public Shared Function IsCube(length As Double, width As Double, height As Double, Optional tolerance As Double = 0.000001) As Boolean
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
            If tolerance <= 0 Then Throw New ArgumentException("Die Toleranz muss größer als 0 sein.", NameOf(tolerance))

            Return Math.Abs(length - width) <= tolerance AndAlso Math.Abs(length - height) <= tolerance
        End Function

        ''' <summary>
        ''' Berechnet den Mittelpunkt aus zwei gegenüberliegenden Eckpunkten.
        ''' </summary>
        ''' <param name="x1">X-Koordinate Punkt 1</param>
        ''' <param name="y1">Y-Koordinate Punkt 1</param>
        ''' <param name="z1">Z-Koordinate Punkt 1</param>
        ''' <param name="x2">X-Koordinate Punkt 2</param>
        ''' <param name="y2">Y-Koordinate Punkt 2</param>
        ''' <param name="z2">Z-Koordinate Punkt 2</param>
        ''' <returns>Mittelpunkt als Tuple(X,Y,Z)</returns>
        Public Shared Function Center(x1 As Double, y1 As Double, z1 As Double, x2 As Double, y2 As Double, z2 As Double) As Tuple(Of Double, Double, Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            Return Tuple.Create((x1 + x2) / 2.0, (y1 + y2) / 2.0, (z1 + z2) / 2.0)
        End Function

        ''' <summary>
        ''' Berechnet 8 Eckpunkte eines achsenparallelen Quaders aus Mittelpunkt und Kantenlängen.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="cz">Mittelpunkt Z</param>
        ''' <param name="length">Länge (&gt;= 0)</param>
        ''' <param name="width">Breite (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Array mit 8 Eckpunkten als Tuple(X,Y,Z)</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, cz As Double, length As Double, width As Double, height As Double) As Tuple(Of Double, Double, Double)()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If length < 0 Then Throw New ArgumentException("Die Länge darf nicht negativ sein.", NameOf(length))
            If width < 0 Then Throw New ArgumentException("Die Breite darf nicht negativ sein.", NameOf(width))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Dim lx = length / 2.0
            Dim wy = width / 2.0
            Dim hz = height / 2.0

            Return New Tuple(Of Double, Double, Double)() {
                Tuple.Create(cx - lx, cy - wy, cz - hz),
                Tuple.Create(cx + lx, cy - wy, cz - hz),
                Tuple.Create(cx + lx, cy + wy, cz - hz),
                Tuple.Create(cx - lx, cy + wy, cz - hz),
                Tuple.Create(cx - lx, cy - wy, cz + hz),
                Tuple.Create(cx + lx, cy - wy, cz + hz),
                Tuple.Create(cx + lx, cy + wy, cz + hz),
                Tuple.Create(cx - lx, cy + wy, cz + hz)
            }
        End Function

    End Class

End Namespace
