' --------------------------------------------------------------------------------------------------------
' Datei: CircleTests.vb
' Author: Andreas Sauer
' Datum: 11.09.2026
' --------------------------------------------------------------------------------------------------------

Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Drawing
Imports SchlumpfSoft.Geometry.TwoDimensional.Circle

Namespace TwoDimensional.Tests

    ''' <summary>
    ''' Unit-Tests für die Kreisberechnungen in TwoDimensional.Circle
    ''' </summary>
    <TestClass()>
    Public Class CircleTests

        <TestMethod()>
        Public Sub Area_FromRadius_Test()
            Dim r As Double = 2.0
            Dim expected As Double = Math.PI * r * r
            Dim actual As Double = Area(r)
            Assert.AreEqual(expected, actual, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub Area_FromDiameter_Test()
            Dim d As Double = 4.0
            Dim expected As Double = Math.PI * 4.0
            Dim actual As Double = AreaFromDiameter(d)
            Assert.AreEqual(expected, actual, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub Circumference_FromRadius_Test()
            Dim r As Double = 3.0
            Dim expected As Double = 2.0 * Math.PI * r
            Dim actual As Double = Circumference(r)
            Assert.AreEqual(expected, actual, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub Circumference_FromDiameter_Test()
            Dim d As Double = 6.0
            Dim expected As Double = 2.0 * Math.PI * 3.0
            Dim actual As Double = CircumferenceFromDiameter(d)
            Assert.AreEqual(expected, actual, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub DiameterRadiusConversion_Test()
            Dim r As Double = 2.5
            Assert.AreEqual(5.0, DiameterFromRadius(r), 0.000000001)
            Assert.AreEqual(r, RadiusFromDiameter(5.0), 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub ArcLength_And_Degrees_Test()
            Dim r As Double = 2.0
            Dim angleRad As Double = Math.PI / 2.0 ' 90°
            Dim expected As Double = r * angleRad
            Assert.AreEqual(expected, ArcLength(r, angleRad), 0.000000001)
            Assert.AreEqual(expected, ArcLengthDegrees(r, 90.0), 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub SectorArea_And_Degrees_Test()
            Dim r As Double = 3.0
            Dim angleDeg As Double = 60.0
            Dim angleRad As Double = angleDeg * Math.PI / 180.0
            Dim expected As Double = 0.5 * r * r * angleRad
            Assert.AreEqual(expected, SectorArea(r, angleRad), 0.000000001)
            Assert.AreEqual(expected, SectorAreaDegrees(r, angleDeg), 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub ChordLength_And_FromSagitta_Test()
            Dim r As Double = 5.0
            Dim angleRad As Double = Math.PI / 3.0 ' 60°
            Dim chord As Double = ChordLength(r, angleRad)
            ' ch = 2 r sin(angle/2)
            Dim expectedChord As Double = 2.0 * r * Math.Sin(angleRad / 2.0)
            Assert.AreEqual(expectedChord, chord, 0.000000001)

            ' teste Sehne aus Sagitta
            Dim sagitta As Double = r - Math.Sqrt((r * r) - ((expectedChord / 2.0) ^ 2))
            Dim chordFromSagitta As Double = ChordLengthFromSagitta(r, sagitta)
            Assert.AreEqual(expectedChord, chordFromSagitta, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub AngleFromArcAndChord_Test()
            Dim r As Double = 4.0
            Dim arcLen As Double = 2.0
            Dim angleFromArc As Double = AngleFromArcLength(r, arcLen)
            Assert.AreEqual(arcLen / r, angleFromArc, 0.000000001)

            Dim chord As Double = 2.0 * r * Math.Sin(0.7 / 2.0)
            Dim angleFromChord As Double = AngleFromChordLength(r, chord)
            Assert.AreEqual(0.7, angleFromChord, 0.000000001)
        End Sub

        <TestMethod()>
        Public Sub PointOnCircle_And_BoundingBox_Test()
            Dim cx As Double = 1.0
            Dim cy As Double = -2.0
            Dim r As Double = 3.0
            Dim angle As Double = 0.0 ' Punkt rechts vom Zentrum
            Dim p As PointF = PointOnCircle(cx, cy, r, angle)
            Assert.AreEqual(CSng(cx + r), p.X, 0.000001)
            Assert.AreEqual(CSng(cy), p.Y, 0.000001)

            Dim bbox As RectangleF = BoundingBox(cx, cy, r)
            Assert.AreEqual(CSng(cx - r), bbox.X, 0.000001)
            Assert.AreEqual(CSng(cy - r), bbox.Y, 0.000001)
            Assert.AreEqual(CSng(2.0 * r), bbox.Width, 0.000001)
            Assert.AreEqual(CSng(2.0 * r), bbox.Height, 0.000001)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub NegativeRadius_Throws_Test()
            Dim unused = Area(-1.0)
        End Sub

    End Class

End Namespace

