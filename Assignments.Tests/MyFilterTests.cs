namespace Assignments.Tests
{
    [TestFixture]
    public class MyFilterTests
    {
        [Test]
        public void TestReturnsCorrectValues()
        {
            double average, stdDev;
            var input = new List<double?> { 10, 20, 30, null, 40 };
            var result = MyFilter.Filter(input, 15, 35, 2, out average, out stdDev);

            var expectedResult = new List<double> { 15, 20 };

            CollectionAssert.AreEqual(expectedResult, result);

            Assert.AreEqual(17.5, average, 0.0001);
            Assert.AreEqual(3.5355339059327378, stdDev, 0.0001);
        }

        [Test]
        public void TestReturnsEmptyForEmptyInput()
        {
            double average, stdDev;
            var result = MyFilter.Filter(null, 10, 20, 2, out average, out stdDev);

            Assert.IsEmpty(result);
            Assert.IsTrue(double.IsNaN(average));
            Assert.IsTrue(double.IsNaN(stdDev));
        }

        [Test]
        public void TestHandlesZeroDivisor()
        {
            double average, stdDev;
            var input = new List<double?> { 10, 20, 30 };
            var result = MyFilter.Filter(input, 5, 50, 0, out average, out stdDev);

            Assert.IsEmpty(result);
            Assert.IsTrue(double.IsNaN(average));
            Assert.IsTrue(double.IsNaN(stdDev));
        }

        [Test]
        public void TestNoLimitsReturnsAllDividedValues()
        {
            double average, stdDev;
            var input = new List<double?> { 10, 20, 30 };
            var result = MyFilter.Filter(input, null, null, 2, out average, out stdDev);

            Assert.AreEqual(new List<double> { 5, 10, 15 }, result);
            Assert.AreEqual(10, average, 0.0001);
            Assert.AreEqual(5, stdDev, 0.0001);
        }
    }
}