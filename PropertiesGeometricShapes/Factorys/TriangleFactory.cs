using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.Shapes;

namespace PropertiesGeometricShapes.Factorys
{
    public class TriangleFactory : ShapeFactory
    {
        protected override IShape MakeShape(IShapeParam param)
        {
            if (param is not TriangleParam triangleParam)
                throw new ArgumentException($"{nameof(param)} - TriangleFactory got no TriangleParam");
            
            return new Triangle(triangleParam);
        }
    }
}
