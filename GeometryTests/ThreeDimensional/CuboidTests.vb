' --------------------------------------------------------------------------------------------------------
' Datei: CuboidTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SchlumpfSoft.Geometry.ThreeDimensional.Cuboid

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class CuboidTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Volume_Surface_SpaceDiagonal_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(24.0, Volume(2, 3, 4), 0.000000001)
            Assert.AreEqual(52.0, SurfaceArea(2, 3, 4), 0.000000001)
            Assert.AreEqual(Math.Sqrt(29.0), SpaceDiagonal(2, 3, 4), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub FaceDiagonals_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(Math.Sqrt(13.0), FaceDiagonalLengthWidth(2, 3), 0.000000001)
            Assert.AreEqual(Math.Sqrt(20.0), FaceDiagonalLengthHeight(2, 4), 0.000000001)
            Assert.AreEqual(Math.Sqrt(25.0), FaceDiagonalWidthHeight(3, 4), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub EdgeFromVolume_And_IsCube_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(4.0, EdgeFromVolume(24, 2, 3), 0.000000001)
            Assert.IsTrue(IsCube(5, 5, 5))
            Assert.IsFalse(IsCube(5, 5, 4.9))
        End Sub

        <TestMethod>
        Public Sub Center_And_Vertices_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim centerPoint = Center(0, 0, 0, 2, 4, 6)
            Assert.AreEqual(1.0, centerPoint.Item1, 0.000000001)
            Assert.AreEqual(2.0, centerPoint.Item2, 0.000000001)
            Assert.AreEqual(3.0, centerPoint.Item3, 0.000000001)

            Dim vertices = VerticesFromCenter(0, 0, 0, 2, 4, 6)
            Assert.AreEqual(8, vertices.Length)
            Assert.AreEqual(-1.0, vertices(0).Item1, 0.000000001)
            Assert.AreEqual(-2.0, vertices(0).Item2, 0.000000001)
            Assert.AreEqual(-3.0, vertices(0).Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Volume_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() Volume(-1, 2, 3))
        End Sub

        <TestMethod>
        Public Sub Guards_EdgeFromVolume_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() EdgeFromVolume(10, 0, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_IsCube_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() IsCube(1, 1, 1, 0))
        End Sub

    End Class

End Namespace
