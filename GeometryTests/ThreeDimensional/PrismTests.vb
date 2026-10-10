' --------------------------------------------------------------------------------------------------------
' Datei: PrismTests.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SchlumpfSoft.Geometry.ThreeDimensional.Prism

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class PrismTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub GeneralPrism_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(50.0, Volume(10, 5), 0.000000001)
            Assert.AreEqual(70.0, LateralArea(14, 5), 0.000000001)
            Assert.AreEqual(90.0, SurfaceArea(10, 14, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub TriangularPrism_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(6.0, TriangularBaseArea(3, 4, 5), 0.000000001)
            Assert.AreEqual(30.0, TriangularPrismVolume(3, 4, 5, 5), 0.000000001)
            Assert.AreEqual(72.0, TriangularPrismSurfaceArea(3, 4, 5, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub RegularPolygonPrism_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim baseArea = RegularPolygonBaseArea(2, 6)
            Assert.AreEqual(6.0 * Math.Sqrt(3.0), baseArea, 0.000000001)
            Assert.AreEqual(30.0 * Math.Sqrt(3.0), RegularPolygonPrismVolume(2, 6, 5), 0.000000001)
            Assert.AreEqual((2.0 * 6.0 * Math.Sqrt(3.0)) + (12.0 * 5.0), RegularPolygonPrismSurfaceArea(2, 6, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_General_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() Volume(-1, 1))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() LateralArea(1, -1))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() SurfaceArea(1, -1, 1))
        End Sub

        <TestMethod>
        Public Sub Guards_Triangular_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() TriangularBaseArea(1, 2, 3))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() TriangularPrismVolume(3, 4, 5, -1))
        End Sub

        <TestMethod>
        Public Sub Guards_RegularPolygon_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() RegularPolygonBaseArea(1, 2))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() RegularPolygonPrismVolume(-1, 6, 1))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() RegularPolygonPrismSurfaceArea(1, 6, -1))
        End Sub

    End Class

End Namespace
