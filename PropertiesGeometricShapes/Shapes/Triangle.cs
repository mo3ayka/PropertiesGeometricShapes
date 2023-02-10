using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.ValidationAttributes;

namespace PropertiesGeometricShapes.Shapes
{
    [TriangleValidation]
    public class Triangle : IShape
    {
        public Triangle(TriangleParam param)
        {
            _a = param.A;
            _b = param.B;
            _c = param.C;
        }

        #region Fields

        private readonly double _a, _b, _c;

        #endregion

        #region Properties

        [TriangleSideValidation]
        public double A => _a;

        [TriangleSideValidation]
        public double B => _b;

        [TriangleSideValidation]
        public double C => _c;

        #endregion

        #region IShape

        public double GetArea()
        {
            var semiPerim = (_a + _b + _c) / 2;
            return Math.Sqrt(semiPerim * (semiPerim - _a) * (semiPerim - _b) * (semiPerim - _c));
        }

        #endregion
    }

    public class TriangleParam : IShapeParam
    {
        /// <remarks>a, b, c - sides</remarks>
        public TriangleParam(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        
        public double A { get; private set; }

        public double B { get; private set; }

        public double C { get; private set; }
    }
}
