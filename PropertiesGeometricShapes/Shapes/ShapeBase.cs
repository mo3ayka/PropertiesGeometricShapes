using PropertiesGeometricShapes.Interfaces;

namespace PropertiesGeometricShapes.Shapes
{
    public abstract class ShapeBase : IShape
    {
        private double? _area;

        public double Area => _area ??= GetArea();

        protected abstract double GetArea();

        public virtual Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                { nameof(Area), Area },
            };
        }
    }
}
