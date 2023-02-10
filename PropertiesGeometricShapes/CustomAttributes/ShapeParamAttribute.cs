namespace PropertiesGeometricShapes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ShapeParamAttribute : Attribute
    {
        public ShapeParamAttribute(Type typeParam)
        {
            TypeParam = typeParam;
        }

        public Type TypeParam { get; private set; }
    }
}
