# PropertiesGeometricShapes

Library for calculating properties of geometric shapes, such as area, etc.

IShape - interface all shapes
  Contains:
    Properties:
      - Area - area of the shape
    Methods:
      - GetProperties - return dictionary of properties, where Key is property name and Value is property value. Pair like { "Area", 10 }
      
IShapeParam - interface for shape param(side/radius/diameter/etc.)

IShapeFactory - interface for create shape
  Contains:
    Methods:
      - CreateShape(IShapeParam) - create shape by IShapeParam. Call validating shape after create. May throw ValidationException or ArgumentException

Shapes:
  - ShapeBase - abstract class, contains property for all shape, like area (perimeter/volume in the future).
    Contains:
      Properties:
        - Area - IShape.Area. Save cache after calculating
      Methods:
        - GetArea - protected abstract method for calculate area
  - Circle - hm.... Circle)
  - Triangle - Triangle with RightAngled property, which is output in IShape.GetProperties
  
Add new shape:
  - create shape class inherited from ShapeBase and implement GetArea method
  - override GetProperties if need add custom property
  - create factory class inherited from ShapeFactory and implement MakeShape method
  - Enjoy 😉

Validation:
  Validation is performed via attributes and System.ComponentModel.DataAnnotations (call in IShapeFactory.CreateShape)
  Some attributes:
  - CircleValidationAttribute/TriangleValidationAttribute/TriangleSideValidationAttribute
