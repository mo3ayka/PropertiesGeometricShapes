using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.Shapes;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Factorys.Tests
{
    [TestClass]
    public class CircleFactoryTests
    {
        private static IShapeFactory _factory;
        
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _factory = new CircleFactory();
        }
        
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CreateCircleWithIncorrectParamTest()
        {
            _ = _factory.CreateShape(new TriangleParam(0, 0, 0));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateCircleWithZeroParamTest()
        {
            _ = _factory.CreateShape(new CircleParam(0));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateCircleWithNegativeParamTest()
        {
            _ = _factory.CreateShape(new CircleParam(-10));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CreateCircleWithNullParamTest()
        {
            _ = _factory.CreateShape(null);
        }

        [TestMethod]
        public void CreateCorrectCircle()
        {
            var circle = _factory.CreateShape(new CircleParam(10.5423));
            Assert.IsNotNull(circle, "CreateShape return null circle");
        }

        [TestMethod]
        public void CreateTwoCorrectCircleWithDifRef()
        {
            var circle1 = _factory.CreateShape(new CircleParam(7.32));
            var circle2 = _factory.CreateShape(new CircleParam(7.32));
            Assert.AreNotSame(circle1, circle2, "CreateShape not create new circle obj on the second call");
        }
    }
}