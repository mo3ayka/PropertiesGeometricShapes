using PropertiesGeometricShapes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Factorys
{
    public abstract class ShapeFactory : IShapeFactory
    {
        protected abstract IShape MakeShape(IShapeParam param);

        public IShape CreateShape(IShapeParam param)
        {
            if (param is null)
                throw new ArgumentNullException(nameof(param));
            
            var shape = MakeShape(param);
            Validator.ValidateObject(shape, new ValidationContext(shape), true);
            return shape;
        }
    }
}
