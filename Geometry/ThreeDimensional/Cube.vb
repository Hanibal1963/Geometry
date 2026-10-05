' --------------------------------------------------------------------------------------------------------
' Datei: Cube.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung von Würfeln bereit.
    ''' </summary>
    Public Class Cube

#Region "Grundlegende Berechnungen"

        ''' <summary>
        ''' Berechnet das Volumen eines Würfels.
        ''' </summary>
        ''' <param name="side">Kantenlänge (&gt;= 0)</param>
        ''' <returns>Volumen side^3</returns>
        Public Shared Function Volume(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side * side * side
        End Function

        ''' <summary>
        ''' Berechnet die Oberfläche eines Würfels.
        ''' </summary>
        ''' <param name="side">Kantenlänge (&gt;= 0)</param>
        ''' <returns>Oberfläche 6 * side^2</returns>
        Public Shared Function SurfaceArea(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return 6.0 * side * side
        End Function

        ''' <summary>
        ''' Berechnet die Raumdiagonale eines Würfels.
        ''' </summary>
        ''' <param name="side">Kantenlänge (&gt;= 0)</param>
        ''' <returns>Raumdiagonale side * sqrt(3)</returns>
        Public Shared Function SpaceDiagonal(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side * Math.Sqrt(3.0)
        End Function

        ''' <summary>
        ''' Berechnet die Flächendiagonale eines Würfels.
        ''' </summary>
        ''' <param name="side">Kantenlänge (&gt;= 0)</param>
        ''' <returns>Flächendiagonale side * sqrt(2)</returns>
        Public Shared Function FaceDiagonal(side As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If
            Return side * Math.Sqrt(2.0)
        End Function

        ''' <summary>
        ''' Berechnet die Kantenlänge aus dem Volumen.
        ''' </summary>
        ''' <param name="volume">Volumen (&gt;= 0)</param>
        ''' <returns>Kantenlänge cubic-root(volume)</returns>
        Public Shared Function SideFromVolume(volume As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If volume < 0 Then
                Throw New ArgumentException("Das Volumen darf nicht negativ sein.", NameOf(volume))
            End If
            Return Math.Pow(volume, 1.0 / 3.0)
        End Function

        ''' <summary>
        ''' Berechnet die Kantenlänge aus der Oberfläche.
        ''' </summary>
        ''' <param name="surfaceArea">Oberfläche (&gt;= 0)</param>
        ''' <returns>Kantenlänge sqrt(surfaceArea / 6)</returns>
        Public Shared Function SideFromSurfaceArea(surfaceArea As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If surfaceArea < 0 Then
                Throw New ArgumentException(My.Resources.CheckNonNegativeArea, NameOf(surfaceArea))
            End If
            Return Math.Sqrt(surfaceArea / 6.0)
        End Function

        ''' <summary>
        ''' Berechnet die Kantenlänge aus der Raumdiagonale.
        ''' </summary>
        ''' <param name="spaceDiagonal">Raumdiagonale (&gt;= 0)</param>
        ''' <returns>Kantenlänge spaceDiagonal / sqrt(3)</returns>
        Public Shared Function SideFromSpaceDiagonal(spaceDiagonal As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If spaceDiagonal < 0 Then
                Throw New ArgumentException("Die Raumdiagonale darf nicht negativ sein.", NameOf(spaceDiagonal))
            End If
            Return spaceDiagonal / Math.Sqrt(3.0)
        End Function

#End Region

#Region "Koordinatenbasierte Hilfsmethoden"

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
        ''' Berechnet 8 Eckpunkte eines achsenparallelen Würfels aus Mittelpunkt und Kantenlänge.
        ''' </summary>
        ''' <param name="cx">Mittelpunkt X</param>
        ''' <param name="cy">Mittelpunkt Y</param>
        ''' <param name="cz">Mittelpunkt Z</param>
        ''' <param name="side">Kantenlänge (&gt;= 0)</param>
        ''' <returns>Array mit 8 Eckpunkten als Tuple(X,Y,Z)</returns>
        Public Shared Function VerticesFromCenter(cx As Double, cy As Double, cz As Double, side As Double) As Tuple(Of Double, Double, Double)()
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If side < 0 Then
                Throw New ArgumentException(My.Resources.LengthIsNegative, NameOf(side))
            End If

            Dim h = side / 2.0
            Return New Tuple(Of Double, Double, Double)() {
                Tuple.Create(cx - h, cy - h, cz - h),
                Tuple.Create(cx + h, cy - h, cz - h),
                Tuple.Create(cx + h, cy + h, cz - h),
                Tuple.Create(cx - h, cy + h, cz - h),
                Tuple.Create(cx - h, cy - h, cz + h),
                Tuple.Create(cx + h, cy - h, cz + h),
                Tuple.Create(cx + h, cy + h, cz + h),
                Tuple.Create(cx - h, cy + h, cz + h)
            }
        End Function

#End Region

    End Class

End Namespace
