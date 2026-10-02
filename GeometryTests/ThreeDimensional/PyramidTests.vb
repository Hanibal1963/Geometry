' --------------------------------------------------------------------------------------------------------
' Datei: PyramidTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SchlumpfSoft.Geometry.ThreeDimensional.Pyramid

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class PyramidTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub BaseArea_Volume_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(12.0, BaseArea(4, 3), 0.000000001)
            Assert.AreEqual(20.0, Volume(4, 3, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub SlantHeights_Lateral_Surface_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual(Math.Sqrt((3.0 / 2.0) * (3.0 / 2.0) + 25.0), SlantHeightLengthFace(3, 5), 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual(Math.Sqrt((4.0 / 2.0) * (4.0 / 2.0) + 25.0), SlantHeightWidthFace(4, 5), 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((4.0 * SlantHeightLengthFace(3, 5)) + (3.0 * SlantHeightWidthFace(4, 5)), LateralArea(4, 3, 5), 0.000000001)
            Assert.AreEqual(BaseArea(4, 3) + LateralArea(4, 3, 5), SurfaceArea(4, 3, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Frustum_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim volumeValue = FrustumVolume(6, 4, 2, 1, 5)
            Dim a1 = 24.0
            Dim a2 = 2.0
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((5.0 / 3.0) * (a1 + a2 + Math.Sqrt(a1 * a2)), volumeValue, 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen

            Dim lateral = FrustumLateralArea(6, 4, 2, 1, 5)
            Dim surface = FrustumSurfaceArea(6, 4, 2, 1, 5)
            Assert.IsTrue(lateral > 0)
            Assert.AreEqual((6.0 * 4.0) + (2.0 * 1.0) + lateral, surface, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Center_And_Vertices_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim centerPoint = Center(0, 0, 0, 2, 4, 6)
            Assert.AreEqual(1.0, centerPoint.Item1, 0.000000001)
            Assert.AreEqual(2.0, centerPoint.Item2, 0.000000001)
            Assert.AreEqual(3.0, centerPoint.Item3, 0.000000001)

            Dim vertices = VerticesFromCenter(0, 0, 0, 4, 2, 6)
            Assert.AreEqual(5, vertices.Length)
            Assert.AreEqual(3.0, vertices(4).Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_BaseArea_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() BaseArea(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_Frustum_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() FrustumVolume(4, 3, 4, 2, 5))
        End Sub

        <TestMethod>
        Public Sub Guards_Vertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() VerticesFromCenter(0, 0, 0, -1, 1, 1))
        End Sub

    End Class

End Namespace
