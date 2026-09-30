' --------------------------------------------------------------------------------------------------------
' Datei: SphereTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SchlumpfSoft.Geometry.ThreeDimensional.Sphere

Namespace ThreeDimensional.Tests

    <TestClass>
    Public Class SphereTests

        <TestMethod>
        Public Sub Volume_SurfaceArea_Test()
            Assert.AreEqual((4.0 / 3.0) * Math.PI * 8.0, Volume(2), 0.000000001)
            Assert.AreEqual(4.0 * Math.PI * 4.0, SurfaceArea(2), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Diameter_Radius_Conversion_Test()
            Assert.AreEqual(10.0, DiameterFromRadius(5), 0.000000001)
            Assert.AreEqual(5.0, RadiusFromDiameter(10), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub GreatCircle_Test()
            Assert.AreEqual(2.0 * Math.PI * 3.0, GreatCircleCircumference(3), 0.000000001)
            Assert.AreEqual(Math.PI * 9.0, GreatCircleArea(3), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub SphericalCap_Test()
            Dim volumeValue = SphericalCapVolume(5, 2)
            Dim areaValue = SphericalCapArea(5, 2)

            Assert.AreEqual(Math.PI * 4.0 * (5.0 - (2.0 / 3.0)), volumeValue, 0.000000001)
            Assert.AreEqual(20.0 * Math.PI, areaValue, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub PointOnSphere_Test()
            Dim p = PointOnSphere(0, 0, 0, 2, Math.PI / 2.0, 0)
            Assert.AreEqual(2.0, p.Item1, 0.000000001)
            Assert.AreEqual(0.0, p.Item2, 0.000000001)
            Assert.AreEqual(0.0, p.Item3, 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Volume_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() Volume(-1))
        End Sub

        <TestMethod>
        Public Sub Guards_SphericalCapVolume_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() SphericalCapVolume(2, 5))
        End Sub

        <TestMethod>
        Public Sub Guards_PointOnSphere_Throws_Test()
            Assert.ThrowsException(Of ArgumentException)(Sub() PointOnSphere(0, 0, 0, 2, -0.1, 0))
        End Sub

    End Class

End Namespace
