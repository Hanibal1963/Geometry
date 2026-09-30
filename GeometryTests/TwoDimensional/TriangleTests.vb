' --------------------------------------------------------------------------------------------------------
' Datei: TriangleTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Triangle

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class TriangleTests

        <TestMethod>
        Public Sub Area_Perimeter_Test()
            Assert.AreEqual(6.0, Area(4, 3), 0.000000001)
            Assert.AreEqual(12.0, Perimeter(3, 4, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub HeightFromArea_AreaHeron_Test()
            Assert.AreEqual(3.0, HeightFromArea(6, 4), 0.000000001)
            Assert.AreEqual(6.0, AreaHeron(3, 4, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub AngleFromSides_Test()
            Dim angle = AngleFromSides(1, 1, 1)
            Assert.AreEqual(Math.PI / 3.0, angle, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Vertices_Methods_Test()
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(0, 3)
            }

            Dim sides = SideLengthsFromVertices(vertices)
            Assert.AreEqual(4.0, sides(0), 0.000000001)
            Assert.AreEqual(5.0, sides(1), 0.000000001)
            Assert.AreEqual(3.0, sides(2), 0.000000001)

            Assert.AreEqual(6.0, AreaFromVertices(vertices), 0.000000001)
            Assert.AreEqual(12.0, PerimeterFromVertices(vertices), 0.000000001)

            Dim centroidPoint = Centroid(vertices)
            Assert.AreEqual(CSng(4.0 / 3.0), centroidPoint.X, 0.000001)
            Assert.AreEqual(1.0F, centroidPoint.Y, 0.000001)

            Assert.IsTrue(IsValidTriangleFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub IsValidTriangleFromVertices_Collinear_IsFalse_Test()
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(1, 1),
                New PointF(2, 2)
            }

            Assert.IsFalse(IsValidTriangleFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_Perimeter_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() Perimeter(1, 2, 3))
        End Sub

        <TestMethod>
        Public Sub Guards_HeightFromArea_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() HeightFromArea(2, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_AngleFromSides_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() AngleFromSides(10, 1, 1))
        End Sub

        <TestMethod>
        Public Sub Guards_AreaFromVertices_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() AreaFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 1)}))
        End Sub

        <TestMethod>
        Public Sub Guards_IsValidTriangleFromVertices_Throws_Test()
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(0, 3)
            }

            Assert.ThrowsException(Of ArgumentException)(Sub() IsValidTriangleFromVertices(vertices, 0))
        End Sub

    End Class

End Namespace
