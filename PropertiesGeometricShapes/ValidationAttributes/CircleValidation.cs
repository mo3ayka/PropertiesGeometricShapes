using PropertiesGeometricShapes.Shapes;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.ValidationAttributes
{
    internal class CircleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not Circle circle)
                return false;

            if (circle.Radius <= 0)
            {
                ErrorMessage = $"Radius of circle can`t be negative or 0 (Value - {circle.Radius})";
                return false;
            }

            return true;
        }
    }
}
