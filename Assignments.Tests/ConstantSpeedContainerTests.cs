namespace Assignments.Tests
{
    [TestFixture]
    public class ConstantSpeedContainerTests
    {
        [Test]
        public void TestAddFront()
        {
            var container = new ConstantSpeedContainer<int>();
            container.AddFront(1);
            Assert.AreEqual(1, container.Count);
            container.AddFront(2);
            Assert.AreEqual(2, container.Count);
            CollectionAssert.AreEqual(new List<int> { 2, 1 }, container.ToList());
        }
        [Test]
        public void TestAddBack()
        {
            var container = new ConstantSpeedContainer<int>();
            container.AddBack(1);
            Assert.AreEqual(1, container.Count);
            container.AddBack(2);
            Assert.AreEqual(2, container.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2 }, container.ToList());
        }
        [Test]
        public void TestInsertBefore()
        {
            var container = new ConstantSpeedContainer<int>();
            container.AddBack(1);
            container.AddBack(3);
            container.InsertBefore(2, 3);
            Assert.AreEqual(3, container.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, container.ToList());
        }
        [Test]
        public void TestDelete()
        {
            var container = new ConstantSpeedContainer<int>();
            container.AddBack(1); container.AddBack(2);
            container.Delete(1); Assert.AreEqual(1, container.Count);
            CollectionAssert.AreEqual(new List<int> { 2 }, container.ToList());
        }
    }
}