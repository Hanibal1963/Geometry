' --------------------------------------------------------------------------------------------------------
' Datei: CylinderTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SchlumpfSoft.Geometry.ThreeDimensional.Cylinder

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class CylinderTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Volume_Lateral_Surface_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(Math.PI * 4.0 * 5.0, Volume(2, 5), 0.000000001)
            Assert.AreEqual(2.0 * Math.PI * 2.0 * 5.0, LateralArea(2, 5), 0.000000001)
            Assert.AreEqual(2.0 * Math.PI * 2.0 * (2.0 + 5.0), SurfaceArea(2, 5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Base_And_Diameter_Radius_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(2.0 * Math.PI * 3.0, BaseCircumference(3), 0.000000001)
            Assert.AreEqual(Math.PI * 9.0, BaseArea(3), 0.000000001)
            Assert.AreEqual(8.0, DiameterFromRadius(4), 0.000000001)
            Assert.AreEqual(4.0, RadiusFromDiameter(8), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub HollowCylinder_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(Math.PI * (25.0 - 9.0) * 10.0, HollowVolume(5, 3, 10), 0.000000001)

            Dim expectedArea = (2.0 * Math.PI * 5.0 * 10.0) + (2.0 * Math.PI * 3.0 * 10.0) + (2.0 * Math.PI * (25.0 - 9.0))
            Assert.AreEqual(expectedArea, HollowSurfaceArea(5, 3, 10), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub PointOnLateralSurface_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim p = PointOnLateralSurface(0, 0, 0, 2, 5, 0, 3)
            Assert.AreEqual(2.0, p.Item1, 0.000000001)
            Assert.AreEqual(0.0, p.Item2, 0.000000001)
            Assert.AreEqual(3.0, p.Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Volume_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() Volume(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_Hollow_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() HollowVolume(3, 3, 1))
        End Sub

        <TestMethod>
        Public Sub Guards_PointOnLateralSurface_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() PointOnLateralSurface(0, 0, 0, 2, 5, 0, 6))
        End Sub

    End Class

End Namespace
