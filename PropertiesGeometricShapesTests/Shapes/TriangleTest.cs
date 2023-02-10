using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesGeometricShapes.Factorys;
using PropertiesGeometricShapes.Interfaces;

namespace PropertiesGeometricShapes.Shapes.Tests
{
    [TestClass]
    public class TriangleTest
    {
        private static IShapeFactory _factory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _factory = new TriangleFactory();
        }

        [TestMethod]
        public void InfinityAreaAtMaxSidesTest()
        {
            const double sideA = double.MaxValue;
            const double sideB = double.MaxValue;
            const double sideC = double.MaxValue;
            const double expected = double.PositiveInfinity;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC));

            Assert.AreEqual(expected, triangle.Area, "Expected area at a sides(A - {0}, B - {1}, C - {2}) is {3}", sideA, sideB, sideC, expected);
        }

        [TestMethod]
        public void AreaAtSide_5_7_9Test()
        {
            const double sideA = 5;
            const double sideB = 7;
            const double sideC = 9;
            const double expected = 17.412280;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC));

            Assert.AreEqual(expected, triangle.Area, 0.00001, "Expected area at a sides(A - {0}, B - {1}, C - {2}) is {3}", sideA, sideB, sideC, expected);
        }

        [TestMethod]
        public void AreaAtSide64_24_45Test()
        {
            const double sideA = 64.32;
            const double sideB = 24.547;
            const double sideC = 45.52173;
            const double expected = 422.51228889;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC));

            Assert.AreEqual(expected, triangle.Area, 0.00001, "Expected area at a sides(A - {0}, B - {1}, C - {2}) is {3}", sideA, sideB, sideC, expected);
        }

        [TestMethod]
        public void RightAngledTriangleAtSide3_4_5Test()
        {
            const double sideA = 3;
            const double sideB = 4;
            const double sideC = 5;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC)) as Triangle;

            Assert.IsTrue(triangle.IsRightAngled, "Expected right angled triangle at a sides(A - {0}, B - {1}, C - {2})", sideA, sideB, sideC);
        }

        [TestMethod]
        public void RightAngledTriangleAtSide26_34_43Test()
        {
            const double sideA = 26.24;
            const double sideB = 34.31767;
            const double sideC = 43.2;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC)) as Triangle;

            Assert.IsTrue(triangle.IsRightAngled, "Expected right angled triangle at a sides(A - {0}, B - {1}, C - {2})", sideA, sideB, sideC);
        }

        [TestMethod]
        public void GetPropDicTest()
        {
            const double sideA = 5;
            const double sideB = 7.31;
            const double sideC = 7.2361;
            const int coutProp = 2;

            var triangle = _factory.CreateShape(new TriangleParam(sideA, sideB, sideC));
            var triangleProps = triangle.GetProperties();

            Assert.AreEqual(coutProp, triangleProps.Count);
            CollectionAssert.AllItemsAreNotNull(triangleProps);
        }
    }
}
