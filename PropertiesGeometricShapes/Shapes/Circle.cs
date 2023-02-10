using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.ValidationAttributes;

namespace PropertiesGeometricShapes.Shapes
{
    [CircleValidation]
    public class Circle : IShape
    {
        public Circle(CircleParam param)
        {
            _radius = param.Radius;
        }

        #region Fields

        private readonly double _radius;

        #endregion

        #region Properties

        public double Radius => _radius;

        #endregion

        #region IShape

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        #endregion
    }

    public class CircleParam : IShapeParam
    {
        public CircleParam(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }
    }
}
