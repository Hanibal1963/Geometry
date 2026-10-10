' --------------------------------------------------------------------------------------------------------
' Datei: RegularPolygonTests.vb
' Author: Andreas Sauer
' Datum: 12.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.RegularPolygon

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class RegularPolygonTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Apothem_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(12.0, Perimeter(2, 6), 0.000000001)
            Assert.AreEqual(Math.Sqrt(3.0), Apothem(2, 6), 0.000000001)
            Assert.AreEqual(6.0 * Math.Sqrt(3.0), Area(2, 6), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Angle_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((3.0 * Math.PI) / 5.0, InteriorAngle(5), 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
#Disable Warning IDE0047 ' Unnötige Klammern entfernen
            Assert.AreEqual((2.0 * Math.PI) / 5.0, ExteriorAngle(5), 0.000000001)
#Enable Warning IDE0047 ' Unnötige Klammern entfernen
        End Sub

        <TestMethod>
        Public Sub SideLength_And_Circumradius_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(3.0, SideLengthFromPerimeter(15, 5), 0.000000001)
            Assert.AreEqual(2.0, Circumradius(2.0 * 2.0 * Math.Sin(Math.PI / 6.0), 6), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsRegular_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim sideCount As Integer = 5
            Dim radius As Double = 3.0
            Dim vertices = VerticesFromCenter(0, 0, sideCount, radius, 0)
            Dim expectedSide = 2.0 * radius * Math.Sin(Math.PI / sideCount)

            Assert.AreEqual(sideCount, vertices.Length)
            Assert.AreEqual(Perimeter(expectedSide, sideCount), PerimeterFromVertices(vertices), 0.0001)
            Assert.IsTrue(AreaFromVertices(vertices) > 0)
            Assert.IsTrue(IsRegularFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub IsRegularFromVertices_Irregular_IsFalse_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(4, 1),
                New PointF(0, 2)
            }

            Assert.IsFalse(IsRegularFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_Area_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() Area(-1, 5))
            Assert.ThrowsExactly(Of ArgumentException)(Sub() Area(1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_IsRegularFromVertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() IsRegularFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0)}))
        End Sub

    End Class

End Namespace
