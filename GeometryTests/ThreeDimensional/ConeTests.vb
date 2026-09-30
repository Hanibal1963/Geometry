' --------------------------------------------------------------------------------------------------------
' Datei: ConeTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SchlumpfSoft.Geometry.ThreeDimensional.Cone

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class ConeTests

        <TestMethod>
        Public Sub Volume_Slant_Lateral_Surface_Test()
            Assert.AreEqual((Math.PI * 4.0 * 3.0) / 3.0, Volume(2, 3), 0.000000001)
            Assert.AreEqual(Math.Sqrt(13.0), SlantHeight(2, 3), 0.000000001)
            Assert.AreEqual(Math.PI * 2.0 * Math.Sqrt(13.0), LateralArea(2, 3), 0.000000001)
            Assert.AreEqual(Math.PI * 2.0 * (2.0 + Math.Sqrt(13.0)), SurfaceArea(2, 3), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Diameter_Radius_Conversion_Test()
            Assert.AreEqual(10.0, DiameterFromRadius(5), 0.000000001)
            Assert.AreEqual(5.0, RadiusFromDiameter(10), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Frustum_Test()
            Assert.AreEqual((Math.PI * 9.0 / 3.0) * (25.0 + 15.0 + 9.0), FrustumVolume(5, 3, 9), 0.000000001)

            Dim s = Math.Sqrt(((5.0 - 3.0) * (5.0 - 3.0)) + (9.0 * 9.0))
            Assert.AreEqual(Math.PI * (5.0 + 3.0) * s, FrustumLateralArea(5, 3, 9), 0.000000001)

            Dim expectedSurface = (Math.PI * (5.0 + 3.0) * s) + (Math.PI * (25.0 + 9.0))
            Assert.AreEqual(expectedSurface, FrustumSurfaceArea(5, 3, 9), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub PointOnLateralSurface_Test()
            Dim p = PointOnLateralSurface(0, 0, 0, 4, 10, 0, 0.25)
            Assert.AreEqual(3.0, p.Item1, 0.000000001)
            Assert.AreEqual(0.0, p.Item2, 0.000000001)
            Assert.AreEqual(2.5, p.Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Volume_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() Volume(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_Frustum_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() FrustumVolume(3, 3, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_PointOnLateralSurface_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() PointOnLateralSurface(0, 0, 0, 3, 5, 0, 1.1))
        End Sub

    End Class

End Namespace
