using PropertiesGeometricShapes.CustomAttributes;
using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.ValidationAttributes;
using System.ComponentModel;

namespace PropertiesGeometricShapes.Shapes
{
    [CircleValidation, DisplayName("Круг"), ShapeParam(typeof(CircleParam))]
    public class Circle : ShapeBase
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

        protected override double GetArea()
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

        [DisplayName("Радиус")]
        public double Radius { get; private set; }
    }
}
