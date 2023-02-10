using PropertiesGeometricShapes.Shapes;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.ValidationAttributes
{
    internal class TriangleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not Triangle triangle)
                return false;

            if (triangle.B + triangle.C <= triangle.A ||
                triangle.A + triangle.C <= triangle.B ||
                triangle.A + triangle.B <= triangle.C)
            {
                ErrorMessage = $"Sum of two side lengths has to exceed the length of the third side (A - {triangle.A}, B - {triangle.B}, C - {triangle.C})";
                return false;
            }

            return true;
        }
    }

    internal class TriangleSideValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not double side)
                return false;

            if (side <= 0)
            {
                ErrorMessage = $"Side of triangle can`t be negative or 0 (Value - {side})";
                return false;
            }

            return true;
        }
    }
}
