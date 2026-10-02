' --------------------------------------------------------------------------------------------------------
' Datei: Frustum.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Namespace ThreeDimensional

    ''' <summary>
    ''' Stellt Funktionen zur Berechnung gängiger Stumpfkörper bereit.
    ''' </summary>
    Public Class Frustum

        ''' <summary>
        ''' Berechnet das Volumen eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="bottomRadius">Unterer Radius (&gt; 0)</param>
        ''' <param name="topRadius">Oberer Radius (&gt;= 0 und &lt; bottomRadius)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen PI*h/3 * (R^2 + R*r + r^2)</returns>
        Public Shared Function ConeFrustumVolume(bottomRadius As Double, topRadius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateConeFrustumInputs(bottomRadius, topRadius, height)
            Return (Math.PI * height / 3.0) * ((bottomRadius * bottomRadius) + (bottomRadius * topRadius) + (topRadius * topRadius))
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="bottomRadius">Unterer Radius (&gt; 0)</param>
        ''' <param name="topRadius">Oberer Radius (&gt;= 0 und &lt; bottomRadius)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche PI * (R + r) * s mit s als Mantellinie</returns>
        Public Shared Function ConeFrustumLateralArea(bottomRadius As Double, topRadius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateConeFrustumInputs(bottomRadius, topRadius, height)
            Dim slantHeight = Math.Sqrt((bottomRadius - topRadius) * (bottomRadius - topRadius) + (height * height))
            Return Math.PI * (bottomRadius + topRadius) * slantHeight
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines Kegelstumpfs.
        ''' </summary>
        ''' <param name="bottomRadius">Unterer Radius (&gt; 0)</param>
        ''' <param name="topRadius">Oberer Radius (&gt;= 0 und &lt; bottomRadius)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche Mantel + zwei Kreisflächen</returns>
        Public Shared Function ConeFrustumSurfaceArea(bottomRadius As Double, topRadius As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidateConeFrustumInputs(bottomRadius, topRadius, height)
            Dim baseAreas = Math.PI * ((bottomRadius * bottomRadius) + (topRadius * topRadius))
            Return ConeFrustumLateralArea(bottomRadius, topRadius, height) + baseAreas
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
        Public Shared Function PyramidFrustumVolume(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidatePyramidFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

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
        ''' <returns>Mantelfläche aus vier Trapezflächen</returns>
        Public Shared Function PyramidFrustumLateralArea(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidatePyramidFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

            Dim dLength = (bottomLength - topLength) / 2.0
            Dim dWidth = (bottomWidth - topWidth) / 2.0
            Dim slantLengthFace = Math.Sqrt((dWidth * dWidth) + (height * height))
            Dim slantWidthFace = Math.Sqrt((dLength * dLength) + (height * height))

            Dim areaLengthFaces = (bottomLength + topLength) * slantLengthFace
            Dim areaWidthFaces = (bottomWidth + topWidth) * slantWidthFace
            Return areaLengthFaces + areaWidthFaces
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines rechteckigen Pyramidenstumpfs.
        ''' </summary>
        ''' <param name="bottomLength">Untere Grundlänge (&gt; 0)</param>
        ''' <param name="bottomWidth">Untere Grundbreite (&gt; 0)</param>
        ''' <param name="topLength">Obere Grundlänge (&gt;= 0 und &lt; bottomLength)</param>
        ''' <param name="topWidth">Obere Grundbreite (&gt;= 0 und &lt; bottomWidth)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche untere Fläche + obere Fläche + Mantel</returns>
        Public Shared Function PyramidFrustumSurfaceArea(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            ValidatePyramidFrustumInputs(bottomLength, bottomWidth, topLength, topWidth, height)

            Dim baseArea = bottomLength * bottomWidth
            Dim topArea = topLength * topWidth
            Return baseArea + topArea + PyramidFrustumLateralArea(bottomLength, bottomWidth, topLength, topWidth, height)
        End Function

        ''' <summary>
        ''' Berechnet das Volumen eines Prisma-Stumpfs über Endflächenmittel.
        ''' </summary>
        ''' <param name="bottomArea">Untere Endfläche (&gt;= 0)</param>
        ''' <param name="topArea">Obere Endfläche (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Volumen ((bottomArea + topArea)/2) * height</returns>
        Public Shared Function PrismFrustumVolume(bottomArea As Double, topArea As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If bottomArea < 0 Then Throw New ArgumentException("Die untere Endfläche darf nicht negativ sein.", NameOf(bottomArea))
            If topArea < 0 Then Throw New ArgumentException("Die obere Endfläche darf nicht negativ sein.", NameOf(topArea))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return ((bottomArea + topArea) / 2.0) * height
        End Function

        ''' <summary>
        ''' Berechnet die Mantelfläche eines Prisma-Stumpfs.
        ''' </summary>
        ''' <param name="bottomPerimeter">Unterer Umfang (&gt;= 0)</param>
        ''' <param name="topPerimeter">Oberer Umfang (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Mantelfläche ((bottomPerimeter + topPerimeter)/2) * height</returns>
        Public Shared Function PrismFrustumLateralArea(bottomPerimeter As Double, topPerimeter As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If bottomPerimeter < 0 Then Throw New ArgumentException("Der untere Umfang darf nicht negativ sein.", NameOf(bottomPerimeter))
            If topPerimeter < 0 Then Throw New ArgumentException("Der obere Umfang darf nicht negativ sein.", NameOf(topPerimeter))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return ((bottomPerimeter + topPerimeter) / 2.0) * height
        End Function

        ''' <summary>
        ''' Berechnet die Gesamtoberfläche eines Prisma-Stumpfs.
        ''' </summary>
        ''' <param name="bottomArea">Untere Endfläche (&gt;= 0)</param>
        ''' <param name="topArea">Obere Endfläche (&gt;= 0)</param>
        ''' <param name="bottomPerimeter">Unterer Umfang (&gt;= 0)</param>
        ''' <param name="topPerimeter">Oberer Umfang (&gt;= 0)</param>
        ''' <param name="height">Höhe (&gt;= 0)</param>
        ''' <returns>Oberfläche Endflächen + Mantelfläche</returns>
        Public Shared Function PrismFrustumSurfaceArea(bottomArea As Double, topArea As Double, bottomPerimeter As Double, topPerimeter As Double, height As Double) As Double
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If bottomArea < 0 Then Throw New ArgumentException("Die untere Endfläche darf nicht negativ sein.", NameOf(bottomArea))
            If topArea < 0 Then Throw New ArgumentException("Die obere Endfläche darf nicht negativ sein.", NameOf(topArea))
            If bottomPerimeter < 0 Then Throw New ArgumentException("Der untere Umfang darf nicht negativ sein.", NameOf(bottomPerimeter))
            If topPerimeter < 0 Then Throw New ArgumentException("Der obere Umfang darf nicht negativ sein.", NameOf(topPerimeter))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))

            Return bottomArea + topArea + PrismFrustumLateralArea(bottomPerimeter, topPerimeter, height)
        End Function

        Private Shared Sub ValidateConeFrustumInputs(bottomRadius As Double, topRadius As Double, height As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If bottomRadius <= 0 Then Throw New ArgumentException("Der untere Radius muss größer als 0 sein.", NameOf(bottomRadius))
            If topRadius < 0 Then Throw New ArgumentException("Der obere Radius darf nicht negativ sein.", NameOf(topRadius))
            If topRadius >= bottomRadius Then Throw New ArgumentException("Der obere Radius muss kleiner als der untere Radius sein.", NameOf(topRadius))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
        End Sub

        Private Shared Sub ValidatePyramidFrustumInputs(bottomLength As Double, bottomWidth As Double, topLength As Double, topWidth As Double, height As Double)
            ' Prüft Eingaben und führt den Berechnungsschritt dieser Methode aus.
            If bottomLength <= 0 Then Throw New ArgumentException("Die untere Grundlänge muss größer als 0 sein.", NameOf(bottomLength))
            If bottomWidth <= 0 Then Throw New ArgumentException("Die untere Grundbreite muss größer als 0 sein.", NameOf(bottomWidth))
            If topLength < 0 Then Throw New ArgumentException("Die obere Grundlänge darf nicht negativ sein.", NameOf(topLength))
            If topWidth < 0 Then Throw New ArgumentException("Die obere Grundbreite darf nicht negativ sein.", NameOf(topWidth))
            If topLength >= bottomLength Then Throw New ArgumentException("Die obere Grundlänge muss kleiner als die untere sein.", NameOf(topLength))
            If topWidth >= bottomWidth Then Throw New ArgumentException("Die obere Grundbreite muss kleiner als die untere sein.", NameOf(topWidth))
            If height < 0 Then Throw New ArgumentException("Die Höhe darf nicht negativ sein.", NameOf(height))
        End Sub

    End Class

End Namespace
