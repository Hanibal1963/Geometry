# Geometry

## Inhalt

- [1. Beschreibung](#1-beschreibung)
- [2. Schnellstart](#2-schnellstart)
- [3. Fehlerbehandlung](#3-fehlerbehandlung)
- [4. Namespaces](#4-namespaces)
  - [4.1 ThreeDimensional](#41-threedimensional)
  - [4.2 TwoDimensional](#42-twodimensional)

## 1. Beschreibung

`GeometryNET` ist eine VB.NET-Bibliothek für mathematische Berechnungen in der Ebenen- und Raumgeometrie.

Sie stellt statische Hilfsklassen für 2D- und 3D-Objekte bereit und enthält neben Basiswerten (z. B. Fläche, Umfang, Volumen, Oberfläche) auch abgeleitete Standardgrößen sowie Koordinatenhilfen.

Die Bibliothek ist so aufgebaut, dass Eingaben über Guard-Clauses validiert werden und bei ungültigen Werten konsistente `ArgumentException`-Fehler ausgelöst werden.

Die Bibliothek ist kompatibel mit **.NET Framework 4.6.2, .NET Framework 4.7.2, .NET Framework 4.8.1, .NET 8.0 (Windows), .NET 9.0 (Windows)** und **.NET 10.0 (Windows)**.

## 2. Schnellstart

Beispiel für die Verwendung in VB.NET:

```vb
Imports SchlumpfSoft.GeometryNET.TwoDimensional
Imports SchlumpfSoft.GeometryNET.ThreeDimensional

Module Example

    Sub Main()

        Dim circleArea = Circle.Area(5)        
        Dim rectanglePerimeter = Rectangle.Perimeter(4, 3)
        Dim sphereVolume = Sphere.Volume(2)

        Console.WriteLine($"Kreisfläche: {circleArea}")        
        Console.WriteLine($"Kreisfläche: {circleArea}")
        Console.WriteLine($"Rechteckumfang: {rectanglePerimeter}")        
        Console.WriteLine($"Rechteckumfang: {rectanglePerimeter}")
        Console.WriteLine($"Kugelvolumen: {sphereVolume}")        
        Console.WriteLine($"Kugelvolumen: {sphereVolume}")

    End Sub

End Module
```

## 3. Fehlerbehandlung

Die Methoden validieren Eingaben über Guard-Clauses und werfen bei ungültigen Werten `ArgumentException`.

Typische Beispiele:

- Negative Längenwerte, z. B. `Circle.Area(-1)`
- Ungültige Seitenanzahl bei regelmäßigen Polygonen, z. B. `RegularPolygon.Area(2, 2)`
- Ungültige Stumpfparameter, z. B. `Frustum.ConeFrustumVolume(2, 2, 5)` (oberer Radius muss kleiner als unterer Radius sein)

## 4. Namespaces

- ThreeDimensional - Klassen zur Berechnung von Körpern
- TwoDimensional - Klassen zur Berechnung von Flächen

### 4.1. ThreeDimensional

- [Cone](GeometryNET/Doc/ThreeDimensional/Cone.md) - Berechnungen für Kegel (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cube](GeometryNET/Doc/ThreeDimensional/Cube.md) - Berechnungen für Würfel (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cuboid](GeometryNET/Doc/ThreeDimensional/Cuboid.md) - Berechnungen für Quader (Volumen, Oberfläche und weiteren Eigenschaften)
- [Cylinder](GeometryNET/Doc/ThreeDimensional/Cylinder.md) - Berechnungen für Zylinder (Volumen, Oberfläche und weiteren Eigenschaften)
- [Frustum](GeometryNET/Doc/ThreeDimensional/Frustum.md) - Berechnungen für Kegelstumpf, rechteckigen Pyramidenstumpf und Prisma-Stumpf (jeweils Volumen, Mantelfläche und Oberfläche)
- [Prism](GeometryNET/Doc/ThreeDimensional/Prism.md) - Berechnungen für gerade Prismen allgemein, Dreiecksprismen sowie regelmäßige n-Eck-Prismen (jeweils Volumen und Oberfläche)
- [Pyramid](GeometryNET/Doc/ThreeDimensional/Pyramid.md) - Berechnungen für Pyramiden (Volumen, Oberfläche und weiteren Eigenschaften)
- [Sphere](GeometryNET/Doc/ThreeDimensional/Sphere.md) - Berechnungen für Kugeln (Volumen, Oberfläche und weiteren Eigenschaften)

### 4.2. TwoDimensional

- [Circle](GeometryNET/Doc/TwoDimensional/Circle.md) - Berechnungen für Kreise (Fläche, Umfang und weiteren Eigenschaften)
- [Ellipse](GeometryNET/Doc/TwoDimensional/Ellipse.md) - Berechnungen für Ellipsen (Fläche, Umfang und weiteren Eigenschaften)
- [Kite](GeometryNET/Doc/TwoDimensional/Kite.md) - Berechnungen für Drachen (Fläche, Umfang und weiteren Eigenschaften)
- [Parallelogram](GeometryNET/Doc/TwoDimensional/Parallelogram.md) - Berechnung von Parallelogrammflächen
- [Polygon](GeometryNET/Doc/TwoDimensional/Polygon.md) - Berechnung von Polygonflächen
- [Rectangle](GeometryNET/Doc/TwoDimensional/Rectangle.md) - Berechnung von Rechteckflächen
- [RegularPolygon](GeometryNET/Doc/TwoDimensional/RegularPolygon.md) - Berechnung von regelmäßigen Polygonflächen
- [Rhombus](GeometryNET/Doc/TwoDimensional/Rhombus.md) - Berechnung von Rauteflächen
- [Square](GeometryNET/Doc/TwoDimensional/Square.md) - Berechnungen für Quadrate (Fläche, Umfang und weiteren Eigenschaften)
- [Trapezoid](GeometryNET/Doc/TwoDimensional/Trapezoid.md) - Berechnungen für Trapeze (Fläche, Umfang und weiteren Eigenschaften)
- [Triangle](GeometryNET/Doc/TwoDimensional/Triangle.md) - Berechnungen für Dreiecke (Fläche, Umfang und weiteren Eigenschaften)