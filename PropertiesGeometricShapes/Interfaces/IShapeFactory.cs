using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Interfaces
{
    /// <summary>
    /// Factory for creating shapes
    /// </summary>
    public interface IShapeFactory
    {
        /// <summary>
        /// Create shape with validation
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException">When <paramref name="param"/> create not valid shape.</exception>
        /// <exception cref="ArgumentException">When factory got incorrect <paramref name="param"/> type</exception>
        IShape CreateShape(IShapeParam param);
    }
}
