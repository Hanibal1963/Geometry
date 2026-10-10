' --------------------------------------------------------------------------------------------------------
' Datei: SquareTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Square

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class SquareTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Diagonal_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.AreEqual(25.0, Area(5), 0.000000001)
            Assert.AreEqual(20.0, Perimeter(5), 0.000000001)
            Assert.AreEqual(5.0 * Math.Sqrt(2.0), Diagonal(5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub SideFromDiagonal_And_Radii_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim diagonalValue = Diagonal(5)
            Assert.AreEqual(5.0, SideFromDiagonal(diagonalValue), 0.000000001)
            Assert.AreEqual(2.5, Inradius(5), 0.000000001)
            Assert.AreEqual(5.0 / Math.Sqrt(2.0), Circumradius(5), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub Vertices_Area_Perimeter_IsSquare_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices = VerticesFromCenter(0, 0, 2, 0)
            Assert.AreEqual(4, vertices.Length)
            Assert.AreEqual(4.0, AreaFromVertices(vertices), 0.000001)
            Assert.AreEqual(8.0, PerimeterFromVertices(vertices), 0.000001)
            Assert.IsTrue(IsSquareFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub IsSquareFromVertices_Rectangle_IsFalse_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(3, 0),
                New PointF(3, 2),
                New PointF(0, 2)
            }
            Assert.IsFalse(IsSquareFromVertices(vertices))
        End Sub

        <TestMethod>
        Public Sub Guards_Area_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() Area(-1))
        End Sub

        <TestMethod>
        Public Sub Guards_IsSquareFromVertices_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsExactly(Of ArgumentException)(Sub() IsSquareFromVertices(New PointF() {New PointF(0, 0), New PointF(1, 0), New PointF(1, 1)}))
        End Sub

        <TestMethod>
        Public Sub Guards_IsSquareFromVerticesTolerance_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim vertices As PointF() = {
                New PointF(0, 0),
                New PointF(1, 0),
                New PointF(1, 1),
                New PointF(0, 1)
            }
            Assert.ThrowsExactly(Of ArgumentException)(Sub() IsSquareFromVertices(vertices, 0))
        End Sub

    End Class

End Namespace
