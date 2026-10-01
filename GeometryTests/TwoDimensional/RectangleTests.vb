' --------------------------------------------------------------------------------------------------------
' Datei: RectangleTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Rectangle

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class RectangleTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = Area(3, 4)
            Assert.AreEqual(12.0, a, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Perimeter_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim p = Perimeter(3, 4)
            Assert.AreEqual(14.0, p, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Diagonal_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim d = Diagonal(3, 4)
            Assert.AreEqual(5.0, d, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub AspectRatio_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim ar = AspectRatio(4, 2)
            Assert.AreEqual(2.0, ar, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub IsSquare_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.IsTrue(IsSquare(5, 5))
            Assert.IsFalse(IsSquare(5, 4))
        End Sub

        <TestMethod>
        Public Sub Circum_Inradius_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim cr = Circumradius(3, 4)
            Dim ir = Inradius(3, 4)
            Assert.AreEqual(2.5, cr, 0.000000001) ' diagonal 5 /2
            Assert.AreEqual(1.5, ir, 0.000000001) ' min(3,4)/2
        End Sub

        <TestMethod>
        Public Sub Center_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim c = Center(0, 0, 2, 2)
            Assert.AreEqual(1.0F, c.X)
            Assert.AreEqual(1.0F, c.Y)
        End Sub

        <TestMethod>
        Public Sub VerticesFromCenter_NoRotation_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim verts = VerticesFromCenter(0, 0, 2, 2, 0)
            Assert.AreEqual(4, verts.Length)
            ' erwartet oben links (-1,-1) als erstes Element
            Assert.AreEqual(-1.0F, verts(0).X, 0.000001)
            Assert.AreEqual(-1.0F, verts(0).Y, 0.000001)
        End Sub

        <TestMethod>
        Public Sub AreaFromVertices_PerimeterFromVertices_IsRectangle_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim verts As PointF() = {New PointF(0, 0), New PointF(3, 0), New PointF(3, 4), New PointF(0, 4)}
            Dim area = AreaFromVertices(verts)
            Dim perim = PerimeterFromVertices(verts)
            Assert.AreEqual(12.0, area, 0.000000001)
            Assert.AreEqual(14.0, perim, 0.000000001)
            Assert.IsTrue(IsRectangleFromVertices(verts))
        End Sub

        <TestMethod>
        Public Sub SquareHelpers_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim s = 5.0
            Assert.AreEqual(25.0, AreaSquare(s), 0.000000001)
            Assert.AreEqual(20.0, PerimeterSquare(s), 0.000000001)
            Assert.AreEqual(s * Math.Sqrt(2.0), DiagonalSquare(s), 0.000000001)
            Dim fromD = FromDiagonalToSide(DiagonalSquare(s))
            Assert.AreEqual(s, fromD, 0.000000001)
        End Sub

    End Class

End Namespace
