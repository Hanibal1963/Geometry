' --------------------------------------------------------------------------------------------------------
' Datei: TrapezoidTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Trapezoid

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class TrapezoidTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Midline_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(18.0, Area(8, 4, 3), 0.000000001)
            Assert.AreEqual(22.0, Perimeter(8, 5, 4, 5), 0.000000001)
            Assert.AreEqual(6.0, Midline(8, 4), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub HeightFromArea_And_LegLengthIsosceles_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(3.0, HeightFromArea(18, 8, 4), 0.000000001)
            Assert.AreEqual(Math.Sqrt(13.0), LegLengthIsosceles(8, 4, 3), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub IsIsosceles_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.IsTrue(IsIsosceles(5, 5))
            Assert.IsFalse(IsIsosceles(5, 4.8, 0.000001))
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsTrapezoid_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices = VerticesFromCenter(0, 0, 8, 4, 3, 0)
            Assert.AreEqual(4, vertices.Length)

            Dim areaValue = AreaFromVertices(vertices)
            Dim perimeterValue = PerimeterFromVertices(vertices)

            Assert.AreEqual(18.0, areaValue, 0.000001)
            Assert.AreEqual(8 + 4 + 2 * Math.Sqrt(13.0), perimeterValue, 0.000001)
            Assert.IsTrue(IsTrapezoidFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_Area_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() Area(-1, 4, 3))
        End Sub

        <TestMethod>
        Public Sub Guards_HeightFromArea_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() HeightFromArea(10, 0, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_IsIsosceles_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() IsIsosceles(5, 5, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_AreaFromVertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() AreaFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0), New PointF(1, 1)}))
        End Sub

    End Class

End Namespace
