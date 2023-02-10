using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesGeometricShapes.Factorys;
using PropertiesGeometricShapes.Interfaces;

namespace PropertiesGeometricShapes.Shapes.Tests
{
    [TestClass]
    public class CircleTest
    {
        private static IShapeFactory _factory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _factory = new CircleFactory();
        }

        [TestMethod]
        public void InfinityAreaAtMaxRadiusTest()
        {
            const double radius = double.MaxValue;
            const double expected = double.PositiveInfinity;

            var circle = _factory.CreateShape(new CircleParam(radius));

            Assert.AreEqual(expected, circle.Area, "Expected area at a radius of {0} is {1}", radius, expected);
        }

        [TestMethod]
        public void AreaAtRadius2Test()
        {
            const double radius = 2;
            const double expected = 12.56637;

            var circle = _factory.CreateShape(new CircleParam(radius));

            Assert.AreEqual(expected, circle.Area, 0.0001, "Expected area at a radius of {0} is {1}", radius, expected);
        }

        [TestMethod]
        public void AreaAtRadius43_235Test()
        {
            const double radius = 43.235;
            const double expected = 5_872.4698;

            var circle = _factory.CreateShape(new CircleParam(radius));

            Assert.AreEqual(expected, circle.Area, 0.0001, "Expected area at a radius of {0} is {1}", radius, expected);
        }

        [TestMethod]
        public void GetPropDicTest()
        {
            const double radius = 43.235;
            const int coutProp = 1;

            var circle = _factory.CreateShape(new CircleParam(radius));
            var circleProps = circle.GetProperties();

            Assert.AreEqual(coutProp, circleProps.Count);
            CollectionAssert.AllItemsAreNotNull(circleProps);
        }
    }
}
