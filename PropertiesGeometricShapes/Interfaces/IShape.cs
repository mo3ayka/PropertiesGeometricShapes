namespace PropertiesGeometricShapes.Interfaces
{
    public interface IShape
    {
        double Area { get; }

        /// <summary>
        /// Get dictionary of properties
        /// </summary>
        /// <returns>key - prop name, value - prop value</returns>
        Dictionary<string, object> GetProperties();
    }
}
