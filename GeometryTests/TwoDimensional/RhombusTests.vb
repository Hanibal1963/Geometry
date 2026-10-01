' --------------------------------------------------------------------------------------------------------
' Datei: RhombusTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Rhombus

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class RhombusTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Height_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(12.0, AreaFromBaseHeight(4, 3), 0.000000001)
            Assert.AreEqual(12.0, AreaFromDiagonals(6, 4), 0.000000001)
            Assert.AreEqual(16.0, Perimeter(4), 0.000000001)
            Assert.AreEqual(3.0, HeightFromArea(12, 4), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Diagonal_And_Inradius_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim diags = DiagonalFromSideAndAngle(4, Math.PI / 3.0)
            Assert.AreEqual(2, diags.Length)
            Assert.AreEqual(2.0 * 4.0 * Math.Cos(Math.PI / 6.0), diags(0), 0.000000001)
            Assert.AreEqual(2.0 * 4.0 * Math.Sin(Math.PI / 6.0), diags(1), 0.000000001)
            Assert.AreEqual(1.5, InradiusFromAreaPerimeter(12, 16), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsRhombus_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices = VerticesFromCenter(0, 0, 4, Math.PI / 3.0, 0)
            Assert.AreEqual(4, vertices.Length)
            Assert.IsTrue(AreaFromVertices(vertices) > 0)
            Assert.AreEqual(16.0, PerimeterFromVertices(vertices), 0.000001)
            Assert.IsTrue(IsRhombusFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub IsRhombusFromVertices_Rectangle_IsFalse_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(3, 0),
                New PointF(3, 2),
                New PointF(0, 2)
            }
            Assert.IsFalse(IsRhombusFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_AreaFromBaseHeight_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() AreaFromBaseHeight(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_DiagonalFromSideAndAngle_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() DiagonalFromSideAndAngle(4, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_IsRhombusFromVertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() IsRhombusFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0), New PointF(1, 1)}))
        End Sub

    End Class

End Namespace
