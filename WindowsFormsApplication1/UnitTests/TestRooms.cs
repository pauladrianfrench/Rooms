namespace UnitTests
{
    using NUnit.Framework;
    using Moq;
    using Rooms;

    [TestFixture]
    public class TestRooms
    {
        [Test]
        public void Test1()
        {
            var mock = new Mock<Shape>();

            mock.Setup(s => s.GetArea()).Returns(25.7);

            Assert.AreEqual(1, 1, "Test 1");
            Assert.AreEqual((double)25.7, mock.Object.GetArea(), "Test 2");
        }
    }
}
