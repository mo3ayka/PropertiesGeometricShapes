using PropertiesGeometricShapes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Shapes
{
    [TriangleValidation]
    internal class Triangle : ShapeWithValidate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>a, b, c - sides</remarks>
        public Triangle(double a, double b, double c)
            : base()
        {
            _a = a;
            _b = b;
            _c = c;
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

        public override double GetArea()
        {
            var semiPerim = (_a + _b + _c) / 2;
            return Math.Sqrt(semiPerim * (semiPerim - _a) * (semiPerim - _b) * (semiPerim - _c));
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return base.Validate(validationContext);
        }

        #endregion
    }
}
