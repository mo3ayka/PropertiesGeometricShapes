using PropertiesGeometricShapes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Shapes
{
    internal abstract class ShapeWithValidate : IShape, IValidatableObject
    {
        public ShapeWithValidate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

        public abstract double GetArea();

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
