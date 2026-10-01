# Geometry

`Geometry` ist eine VB.NET-Bibliothek (.NET Framework 4.7.2) für mathematische Berechnungen in der Ebenen- und Raumgeometrie.
Sie stellt statische Hilfsklassen für 2D- und 3D-Objekte bereit und enthält neben Basiswerten (z. B. Fläche, Umfang, Volumen, Oberfläche) auch abgeleitete Standardgrößen sowie Koordinatenhilfen.
Die Bibliothek ist so aufgebaut, dass Eingaben über Guard-Clauses validiert werden und bei ungültigen Werten konsistente `ArgumentException`-Fehler ausgelöst werden.

## Schnellstart

Beispiel für die Verwendung in VB.NET:

```vb
Imports SchlumpfSoft.Geometry.TwoDimensional
Imports SchlumpfSoft.Geometry.ThreeDimensional

Module Example
    Sub Main()
        Dim circleArea = Circle.Area(5)        Dim circleArea = Circle.Area(5)
        Dim rectanglePerimeter = Rectangle.Perimeter(4, 3)        Dim rectanglePerimeter = Rectangle.Perimeter(4, 3)
        Dim sphereVolume = Sphere.Volume(2)        Dim sphereVolume = Sphere.Volume(2)

        Console.WriteLine($"Kreisfläche: {circleArea}")        Console.WriteLine($"Kreisfläche: {circleArea}")
        Console.WriteLine($"Rechteckumfang: {rectanglePerimeter}")        Console.WriteLine($"Rechteckumfang: {rectanglePerimeter}")
        Console.WriteLine($"Kugelvolumen: {sphereVolume}")        Console.WriteLine($"Kugelvolumen: {sphereVolume}")
    End Sub
End Module
```

## Fehlerverhalten

Die Methoden validieren Eingaben über Guard-Clauses und werfen bei ungültigen Werten `ArgumentException`.

Typische Beispiele:

- Negative Längenwerte, z. B. `Circle.Area(-1)`
- Ungültige Seitenanzahl bei regelmäßigen Polygonen, z. B. `RegularPolygon.Area(2, 2)`
- Ungültige Stumpfparameter, z. B. `Frustum.ConeFrustumVolume(2, 2, 5)` (oberer Radius muss kleiner als unterer Radius sein)

## Namespaces

- ThreeDimensional - Klassen zur Berechnung von Körpern
- TwoDimensional - Klassen zur Berechnung von Flächen

### ThreeDimensional

- [Cone](Geometry/ThreeDimensional/Cone.md) - Berechnungen für Kegel (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cube](Geometry/ThreeDimensional/Cube.md) - Berechnungen für Würfel (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cuboid](Geometry/ThreeDimensional/Cuboid.md) - Berechnungen für Quader (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cylinder](Geometry/ThreeDimensional/Cylinder.md) - Berechnungen für Zylinder (Volumen, Oberfläche und weiteren Eigenschaften)
- [Frustum](Geometry/ThreeDimensional/Frustum.md) - Berechnungen für Kegelstumpf, rechteckigen Pyramidenstumpf und Prisma-Stumpf (jeweils Volumen, Mantelfläche und Oberfläche)
- [Prism](Geometry/ThreeDimensional/Prism.md) - Berechnungen für gerade Prismen allgemein, Dreiecksprismen sowie regelmäßige n-Eck-Prismen (jeweils Volumen und Oberfläche)
- [Pyramid](Geometry/ThreeDimensional/Pyramid.md) - Berechnungen für Pyramiden (Volumen, Oberfläche und weiteren Eigenschaften)
- [Sphere](Geometry/ThreeDimensional/Sphere.md) - Berechnungen für Kugeln (Volumen, Oberfläche und weiteren Eigenschaften)

### TwoDimensional

- [Circle](Geometry/TwoDimensional/Circle.md) - Berechnungen für Kreise (Fläche, Umfang und weiteren Eigenschaften)
- [Ellipse](Geometry/TwoDimensional/Ellipse.md) - Berechnungen für Ellipsen (Fläche, Umfang und weiteren Eigenschaften)
- [Kite](Geometry/TwoDimensional/Kite.md) - Berechnungen für Drachen (Fläche, Umfang und weiteren Eigenschaften)
- [Parallelogram](Geometry/TwoDimensional/Parallelogram.md) - Berechnung von Parallelogrammflächen
- [Polygon](Geometry/TwoDimensional/Polygon.md) - Berechnung von Polygonflächen
- [Rectangle](Geometry/TwoDimensional/Rectangle.md) - Berechnung von Rechteckflächen
- [RegularPolygon](Geometry/TwoDimensional/RegularPolygon.md) - Berechnung von regelmäßigen Polygonflächen
- [Rhombus](Geometry/TwoDimensional/Rhombus.md) - Berechnung von Rauteflächen
- [Square](Geometry/TwoDimensional/Square.md) - Berechnungen für Quadrate (Fläche, Umfang und weiteren Eigenschaften)
- [Trapezoid](Geometry/TwoDimensional/Trapezoid.md) - Berechnungen für Trapeze (Fläche, Umfang und weiteren Eigenschaften)
- [Triangle](Geometry/TwoDimensional/Triangle.md) - Berechnungen für Dreiecke (Fläche, Umfang und weiteren Eigenschaften)