Option Strict On
Option Explicit On
Option Infer On
Option Compare Binary

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports System
Imports System.Drawing

Imports SchlumpfSoft.Geometry.TwoDimensional.Ellipse

Namespace TwoDimensional.Tests

    <TestClass>
    Public Class EllipseTests
        ' Gruppiert Testfälle für die zugehörige Geometrieklasse.

        Private Const Tolerance As Double = 0.000000001

        <TestMethod>
        Public Sub Area_IsCorrect()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 3.0
            Dim b = 2.0
            Dim expected = Math.PI * a * b
            Dim actual = Area(a, b)
            Assert.AreEqual(expected, actual, 0.000000000001)
        End Sub

        <TestMethod>
        Public Sub Eccentricity_KnownValue()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 5.0
            Dim b = 3.0
            Dim expected = 0.8 ' sqrt(1 - 9/25) = sqrt(16/25) = 0.8
            Dim actual = Eccentricity(a, b)
            Assert.AreEqual(expected, actual, 0.000000000001)
        End Sub

        <TestMethod>
        Public Sub FocalDistance_KnownValue()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 5.0
            Dim b = 3.0
            Dim expected = 4.0
            Dim actual = FocalDistance(a, b)
            Assert.AreEqual(expected, actual, 0.000000000001)
        End Sub

        <TestMethod>
        Public Sub IsCircle_DetectsCircle()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Assert.IsTrue(IsCircle(1.0, 1.0))
            Assert.IsFalse(IsCircle(1.0, 2.0))
        End Sub

        <TestMethod>
        Public Sub PointOnEllipse_AtZeroAngle()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim p = PointOnEllipse(2.0, 1.0, 0.0)
            Assert.AreEqual(2.0F, p.X, CSng(0.0000001))
            Assert.AreEqual(0.0F, p.Y, CSng(0.0000001))
        End Sub

        <TestMethod>
        Public Sub Perimeter_Ramanujan_CloseToNumeric()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 3.0
            Dim b = 2.0
            Dim pRam = PerimeterRamanujan(a, b)
            Dim pNum = PerimeterNumeric(a, b, 2048)
            Dim relErr = Math.Abs(pRam - pNum) / pNum
            Assert.IsTrue(relErr < 0.000001, "Ramanujan-Approximation sollte numerischem Wert sehr nahe kommen.")
        End Sub

        <TestMethod>
        Public Sub ClosestPoint_ReturnsZeroDistanceForPointOnEllipse()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 4.0
            Dim b = 2.5
            Dim theta = 1.2345
            Dim px = a * Math.Cos(theta)
            Dim py = b * Math.Sin(theta)
            Dim res = ClosestPointOnEllipse(a, b, px, py)
            Dim dist = res.Item2
            Assert.IsTrue(dist < 0.00000001, "Abstand sollte (nahe) 0 sein für Punkt auf der Ellipse")
        End Sub

        <TestMethod>
        Public Sub RadiusOfCurvature_AtZeroAngle()
            ' Führt den Testfall aus und prüft das erwartete Ergebnis.
            Dim a = 3.0
            Dim b = 2.0
            Dim expected = b * b / a
            Dim actual = RadiusOfCurvature(a, b, 0.0)
            Assert.AreEqual(expected, actual, 0.000000000001)
        End Sub

    End Class

End Namespace
