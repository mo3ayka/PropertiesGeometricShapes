using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.Shapes;

namespace PropertiesGeometricShapes.Factorys
{
    public class CircleFactory : ShapeFactory
    {
        protected override IShape MakeShape(IShapeParam param)
        {
            if (param is not CircleParam circleParam)
                throw new ArgumentException($"{nameof(param)} - CircleFactory got no CircleParam");

            return new Circle(circleParam);
        }
    }
}
