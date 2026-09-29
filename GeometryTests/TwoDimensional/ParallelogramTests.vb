' --------------------------------------------------------------------------------------------------------
' Datei: ParallelogramTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Parallelogram

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class ParallelogramTests

        <TestMethod>
        Public Sub Area_Perimeter_Test()
            Assert.AreEqual(15.0, Area(5, 3), 0.000000001)
            Assert.AreEqual(16.0, Perimeter(5, 3), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub HeightFromArea_And_SideFromPerimeter_Test()
            Assert.AreEqual(3.0, HeightFromArea(15, 5), 0.000000001)
            Assert.AreEqual(3.0, SideFromPerimeter(16, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub DiagonalBySidesAndAngle_Test()
            Dim diags = DiagonalBySidesAndAngle(5, 3, Math.PI / 3.0)
            Assert.AreEqual(2, diags.Length)
            Assert.AreEqual(Math.Sqrt(49.0), diags(0), 0.000000001)
            Assert.AreEqual(Math.Sqrt(19.0), diags(1), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub InteriorAngleFromSidesAndDiagonals_Test()
            Dim angle = InteriorAngleFromSidesAndDiagonals(5, 3, Math.Sqrt(49.0), Math.Sqrt(19.0))
            Assert.AreEqual(Math.PI / 3.0, angle, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Center_Test()
            Dim centerPoint = Center(0, 0, 4, 2)
            Assert.AreEqual(2.0F, centerPoint.X)
            Assert.AreEqual(1.0F, centerPoint.Y)
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsParallelogram_Test()
            Dim verts = VerticesFromCenter(0, 0, 4, 2, Math.PI / 3.0, 0)
            Assert.AreEqual(4, verts.Length)

            Dim area = AreaFromVertices(verts)
            Dim perimeter = PerimeterFromVertices(verts)
            Assert.AreEqual(4 * 2 * Math.Sin(Math.PI / 3.0), area, 0.000001)
            Assert.AreEqual(12.0, perimeter, 0.000001)
            Assert.IsTrue(IsParallelogramFromVertices(verts))
        End Sub

        <TestMethod>
        Public Sub Guards_Area_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() Area(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_DiagonalBySidesAndAngle_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() DiagonalBySidesAndAngle(5, 3, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_InteriorAngleFromSidesAndDiagonals_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() InteriorAngleFromSidesAndDiagonals(5, 3, 100, 1))
        End Sub

        <TestMethod>
        Public Sub Guards_AreaFromVertices_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() AreaFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 1)}))
        End Sub

        <TestMethod>
        Public Sub Guards_IsParallelogramFromVertices_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() IsParallelogramFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0), New PointF(1, 1)}))
        End Sub

    End Class

End Namespace
