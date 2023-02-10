using PropertiesGeometricShapes.Interfaces;
using System.ComponentModel;
using System.Reflection;

namespace PropGeometricShapesUI
{
    /// <summary>
    /// Wrapper over <see cref="IShapeParam"/>
    /// </summary>
    internal class RequiredPropertiesInfo
    {
        public RequiredPropertiesInfo(PropertyInfo propertyInfo)
        {
            Name = propertyInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        }

        public string Name { get; private set; }

        public double Value { get; set; }
    }
}