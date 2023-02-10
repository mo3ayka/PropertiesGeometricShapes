using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.Shapes;
using System.ComponentModel.DataAnnotations;

namespace PropertiesGeometricShapes.Factorys.Tests
{
    [TestClass]
    public class TriangleFactoryTests
    {
        private static IShapeFactory _factory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _factory = new TriangleFactory();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CreateTrianglWithIncorrectParamTest()
        {
            _ = _factory.CreateShape(new CircleParam(0));
        }

        #region Zero param

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithZeroParamTest_1()
        {
            _ = _factory.CreateShape(new TriangleParam(0, 2, 3));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithZeroParamTest_2()
        {
            _ = _factory.CreateShape(new TriangleParam(1, 0, 3));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithZeroParamTest_3()
        {
            _ = _factory.CreateShape(new TriangleParam(2, 2, 0));
        }

        #endregion

        #region Negative param

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithNegativeParamTest_1()
        {
            _ = _factory.CreateShape(new TriangleParam(-10, 2, 4));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithNegativeParamTest_2()
        {
            _ = _factory.CreateShape(new TriangleParam(3, -2, 5));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithNegativeParamTest_3()
        {
            _ = _factory.CreateShape(new TriangleParam(3, 4, -2));
        }

        #endregion

        #region Impossible param

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithImpossibleParamTest_1()
        {
            _ = _factory.CreateShape(new TriangleParam(10, 3, 1));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithImpossibleParamTest_2()
        {
            _ = _factory.CreateShape(new TriangleParam(1, 30, 2));
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void CreateTrianglWithImpossibleParamTest_3()
        {
            _ = _factory.CreateShape(new TriangleParam(2, 3, 10));
        }

        #endregion

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CreateTrianglWithNullParamTest()
        {
            _ = _factory.CreateShape(null);
        }

        [TestMethod]
        public void CreateCorrectTriangle()
        {
            var triangle = _factory.CreateShape(new TriangleParam(10.54, 4.4, 8));
            Assert.IsNotNull(triangle, "CreateShape return null triangle");
        }

        [TestMethod]
        public void CreateTwoCorrectTrianglWithDifRef()
        {
            var triangle1 = _factory.CreateShape(new TriangleParam(3.4, 2.84, 4.2));
            var triangle2 = _factory.CreateShape(new TriangleParam(1, 4.2, 5));
            Assert.AreNotSame(triangle1, triangle2, "CreateShape not create new triangle obj on the second call");
        }
    }
}
