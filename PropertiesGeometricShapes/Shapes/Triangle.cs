using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.ValidationAttributes;

namespace PropertiesGeometricShapes.Shapes
{
    [TriangleValidation]
    public class Triangle : ShapeBase
    {
        public Triangle(TriangleParam param)
        {
            _a = param.A;
            _b = param.B;
            _c = param.C;
        }

        #region Fields

        private readonly double _a, _b, _c;

        private bool? _isRightAngled;

        #endregion

        #region Properties

        [TriangleSideValidation]
        public double A => _a;

        [TriangleSideValidation]
        public double B => _b;

        [TriangleSideValidation]
        public double C => _c;

        public bool IsRightAngled => _isRightAngled ??= CheckRightAngled();

        #endregion

        #region Methods

        private bool CheckRightAngled()
        {
            return Math.Pow(A, 2) == Math.Pow(B, 2) + Math.Pow(C, 2) ||
                   Math.Pow(B, 2) == Math.Pow(A, 2) + Math.Pow(C, 2) ||
                   Math.Pow(C, 2) == Math.Pow(A, 2) + Math.Pow(B, 2);
        }

        #endregion

        #region IShape

        protected override double GetArea()
        {
            var semiPerim = (A + B + C) / 2;
            return Math.Sqrt(semiPerim * (semiPerim - A) * (semiPerim - B) * (semiPerim - C));
        }

        public override Dictionary<string, object> GetProperties()
        {
            var baseProp = base.GetProperties();
            baseProp.Add(nameof(IsRightAngled), IsRightAngled);
            return baseProp;
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
