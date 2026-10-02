' --------------------------------------------------------------------------------------------------------
' Datei: FrustumTests.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SchlumpfSoft.Geometry.ThreeDimensional.Frustum

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class FrustumTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub ConeFrustum_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim volumeValue = ConeFrustumVolume(4, 2, 5)
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((Math.PI * 5.0 / 3.0) * (16.0 + 8.0 + 4.0), volumeValue, 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen

            Dim lateral = ConeFrustumLateralArea(4, 2, 5)
            Dim surface = ConeFrustumSurfaceArea(4, 2, 5)
            Assert.IsTrue(lateral > 0)
            Assert.AreEqual(lateral + (Math.PI * (16.0 + 4.0)), surface, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub PyramidFrustum_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim volumeValue = PyramidFrustumVolume(6, 4, 2, 1, 5)
            Dim a1 = 24.0
            Dim a2 = 2.0
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((5.0 / 3.0) * (a1 + a2 + Math.Sqrt(a1 * a2)), volumeValue, 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen

            Dim lateral = PyramidFrustumLateralArea(6, 4, 2, 1, 5)
            Dim surface = PyramidFrustumSurfaceArea(6, 4, 2, 1, 5)
            Assert.IsTrue(lateral > 0)
            Assert.AreEqual(a1 + a2 + lateral, surface, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub PrismFrustum_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(30.0, PrismFrustumVolume(8, 4, 5), 0.000000001)
            Assert.AreEqual(45.0, PrismFrustumLateralArea(10, 8, 5), 0.000000001)
            Assert.AreEqual(57.0, PrismFrustumSurfaceArea(8, 4, 10, 8, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_ConeFrustum_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() ConeFrustumVolume(2, 2, 1))
            Assert.ThrowsException(Of ArgumentException)(Sub() ConeFrustumLateralArea(-1, 0, 1))
        End Sub

        <TestMethod>
        Public Sub Guards_PyramidFrustum_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() PyramidFrustumVolume(4, 3, 4, 2, 5))
            Assert.ThrowsException(Of ArgumentException)(Sub() PyramidFrustumSurfaceArea(4, 3, 1, 0, -1))
        End Sub

        <TestMethod>
        Public Sub Guards_PrismFrustum_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() PrismFrustumVolume(-1, 2, 1))
            Assert.ThrowsException(Of ArgumentException)(Sub() PrismFrustumLateralArea(1, -1, 1))
            Assert.ThrowsException(Of ArgumentException)(Sub() PrismFrustumSurfaceArea(1, 1, 1, 1, -1))
        End Sub

    End Class

End Namespace
