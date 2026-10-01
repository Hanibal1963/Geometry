' --------------------------------------------------------------------------------------------------------
' Datei: CubeTests.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SchlumpfSoft.Geometry.ThreeDimensional.Cube

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class CubeTests

        <TestMethod>
        Public Sub Volume_Surface_Diagonals_Test()
            Assert.AreEqual(27.0, Volume(3), 0.000000001)
            Assert.AreEqual(54.0, SurfaceArea(3), 0.000000001)
            Assert.AreEqual(3.0 * Math.Sqrt(3.0), SpaceDiagonal(3), 0.000000001)
            Assert.AreEqual(3.0 * Math.Sqrt(2.0), FaceDiagonal(3), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub SideFromDerivedValues_Test()
            Assert.AreEqual(3.0, SideFromVolume(27), 0.000000001)
            Assert.AreEqual(3.0, SideFromSurfaceArea(54), 0.000000001)
            Assert.AreEqual(3.0, SideFromSpaceDiagonal(3.0 * Math.Sqrt(3.0)), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Center_And_Vertices_Test()
            Dim centerPoint = Center(0, 0, 0, 2, 2, 2)
            Assert.AreEqual(1.0, centerPoint.Item1, 0.000000001)
            Assert.AreEqual(1.0, centerPoint.Item2, 0.000000001)
            Assert.AreEqual(1.0, centerPoint.Item3, 0.000000001)

            Dim vertices = VerticesFromCenter(0, 0, 0, 2)
            Assert.AreEqual(8, vertices.Length)
            Assert.AreEqual(-1.0, vertices(0).Item1, 0.000000001)
            Assert.AreEqual(-1.0, vertices(0).Item2, 0.000000001)
            Assert.AreEqual(-1.0, vertices(0).Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() Volume(-1))
            Assert.ThrowsException(Of ArgumentException)(Sub() SideFromVolume(-1))
            Assert.ThrowsException(Of ArgumentException)(Sub() SideFromSurfaceArea(-1))
            Assert.ThrowsException(Of ArgumentException)(Sub() SideFromSpaceDiagonal(-1))
            Assert.ThrowsException(Of ArgumentException)(Sub() VerticesFromCenter(0, 0, 0, -1))
        End Sub

    End Class

End Namespace
