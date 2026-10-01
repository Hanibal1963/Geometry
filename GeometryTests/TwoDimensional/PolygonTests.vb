' --------------------------------------------------------------------------------------------------------
' Datei: PolygonTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Polygon

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class PolygonTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        <TestMethod>
        Public Sub Area_Perimeter_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim rect As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(4, 3),
                New PointF(0, 3)
            }

            Assert.AreEqual(12.0, Area(rect), 0.000000001)
            Assert.AreEqual(14.0, Perimeter(rect), 0.000000001)
        End Sub

        <TestMethod>
        Public Sub IsConvex_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim convex As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(4, 3),
                New PointF(0, 3)
            }

            Dim concave As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(2, 1),
                New PointF(4, 3),
                New PointF(0, 3)
            }

            Assert.IsTrue(IsConvex(convex))
            Assert.IsFalse(IsConvex(concave))
        End Sub

        <TestMethod>
        Public Sub IsRegular_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim square As PointF() = {
                New PointF(-1, -1),
                New PointF(1, -1),
                New PointF(1, 1),
                New PointF(-1, 1)
            }

            Dim rectangle As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(4, 2),
                New PointF(0, 2)
            }

            Assert.IsTrue(IsRegular(square))
            Assert.IsFalse(IsRegular(rectangle))
        End Sub

        <TestMethod>
        Public Sub Centroid_BoundingBox_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim rect As PointF() = {
                New PointF(0, 0),
                New PointF(4, 0),
                New PointF(4, 3),
                New PointF(0, 3)
            }

            Dim center = Centroid(rect)
            Assert.AreEqual(2.0F, center.X, 0.000001)
            Assert.AreEqual(1.5F, center.Y, 0.000001)

            Dim box = BoundingBox(rect)
            Assert.AreEqual(0.0F, box.Left, 0.000001)
            Assert.AreEqual(0.0F, box.Top, 0.000001)
            Assert.AreEqual(4.0F, box.Right, 0.000001)
            Assert.AreEqual(3.0F, box.Bottom, 0.000001)
        End Sub

        <TestMethod>
        Public Sub Translate_Rotate_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim triangle As PointF() = {
                New PointF(0, 0),
                New PointF(2, 0),
                New PointF(0, 2)
            }

            Dim moved = Translate(triangle, 1, -1)
            Assert.AreEqual(1.0F, moved(0).X, 0.000001)
            Assert.AreEqual(-1.0F, moved(0).Y, 0.000001)

            Dim rotated = Rotate(triangle, Math.PI / 2.0, New PointF(0, 0))
            Assert.AreEqual(0.0F, rotated(0).X, 0.000001)
            Assert.AreEqual(0.0F, rotated(0).Y, 0.000001)
            Assert.AreEqual(0.0F, rotated(1).X, 0.000001)
            Assert.AreEqual(2.0F, rotated(1).Y, 0.000001)
        End Sub

        <TestMethod>
        Public Sub Guards_Area_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.ThrowsException(Of ArgumentException)(Sub() Area(New PointF() {New PointF(0, 0), New PointF(1, 1)}))
        End Sub

        <TestMethod>
        Public Sub Guards_IsConvex_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim points As PointF() = {
                New PointF(0, 0),
                New PointF(1, 0),
                New PointF(0, 1)
            }

            Assert.ThrowsException(Of ArgumentException)(Sub() IsConvex(points, 0))
        End Sub

        <TestMethod>
        Public Sub Guards_Centroid_Throws_Test()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim collinear As PointF() = {
                New PointF(0, 0),
                New PointF(1, 1),
                New PointF(2, 2)
            }

            Assert.ThrowsException(Of ArgumentException)(Sub() Centroid(collinear))
        End Sub

    End Class

End Namespace
