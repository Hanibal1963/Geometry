' --------------------------------------------------------------------------------------------------------
' Datei: KiteTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Kite

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class KiteTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Height_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(12.0, AreaFromDiagonals(6, 4), 0.000000001)
            Assert.AreEqual(14.0, Perimeter(4, 3), 0.000000001)
            Assert.AreEqual(12.0, AreaFromBaseHeight(4, 3), 0.000000001)
            Assert.AreEqual(3.0, HeightFromArea(12, 4), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Symmetry_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.IsTrue(IsSymmetricBySides(4, 4, 3, 3))
            Assert.IsTrue(IsSymmetricBySides(4, 3, 3, 4))
            Assert.IsFalse(IsSymmetricBySides(4, 4, 3, 2))
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsKite_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices = VerticesFromCenter(0, 0, 6, 4, 0)
            Assert.AreEqual(4, vertices.Length)
            Assert.AreEqual(12.0, AreaFromVertices(vertices), 0.000001)
            Assert.AreEqual(2.0 * Math.Sqrt(13.0) + 2.0 * Math.Sqrt(13.0), PerimeterFromVertices(vertices), 0.000001)
            Assert.IsTrue(IsKiteFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub IsKiteFromVertices_Rectangle_IsFalse_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(3, 0),
                New PointF(3, 2),
                New PointF(0, 2)
            }
            Assert.IsFalse(IsKiteFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_AreaFromDiagonals_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() AreaFromDiagonals(-1, 2))
        End Sub

        <TestMethod>
        Public Sub Guards_HeightFromArea_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() HeightFromArea(10, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_IsKiteFromVertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() IsKiteFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0), New PointF(1, 1)}))
        End Sub

    End Class

End Namespace
