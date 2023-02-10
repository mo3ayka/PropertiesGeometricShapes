using PropertiesGeometricShapes.CustomAttributes;
using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.ValidationAttributes;
using System.ComponentModel;

namespace PropertiesGeometricShapes.Shapes
{
    [TriangleValidation, DisplayName("Треугольник"), ShapeParam(typeof(TriangleParam))]
    public class Triangle : ShapeBase
    {
        internal Triangle(TriangleParam param)
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

        /// <summary>
        /// Side A
        /// </summary>
        [TriangleSideValidation]
        public double A => _a;

        /// <summary>
        /// Side B
        /// </summary>
        [TriangleSideValidation]
        public double B => _b;

        /// <summary>
        /// Side C
        /// </summary>
        [TriangleSideValidation]
        public double C => _c;

        /// <summary>
        /// Triangle has a right angle
        /// </summary>
        public bool IsRightAngled => _isRightAngled ??= CheckRightAngled();

        #endregion

        #region Methods

        private bool CheckRightAngled()
        {
            return Math.Round(Math.Pow(A, 2), 3) == Math.Round(Math.Pow(B, 2), 3) + Math.Round(Math.Pow(C, 2), 3) ||
                   Math.Round(Math.Pow(B, 2), 3) == Math.Round(Math.Pow(A, 2), 3) + Math.Round(Math.Pow(C, 2), 3) ||
                   Math.Round(Math.Pow(C, 2), 3) == Math.Round(Math.Pow(A, 2), 3) + Math.Round(Math.Pow(B, 2), 3);
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

        /// <summary>
        /// Side A
        /// </summary>
        [DisplayName("Сторона А")]
        public double A { get; private set; }

        /// <summary>
        /// Side B
        /// </summary>
        [DisplayName("Сторона B")]
        public double B { get; private set; }

        /// <summary>
        /// Side C
        /// </summary>
        [DisplayName("Сторона C")]
        public double C { get; private set; }
    }
}
