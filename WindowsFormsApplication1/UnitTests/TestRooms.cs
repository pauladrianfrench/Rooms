namespace UnitTests
{
    using NUnit.Framework;
    using Moq;
    using Rooms;
    using System.Drawing;
    using System.Collections;

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

        [Test]
        public void TestShapeMaker()
        {
            int areaWidth = 20;
            int areaHeight = 15;
            ShapeMaker shapeMaker = new ShapeMaker(areaWidth, areaHeight, new Trans { XScale = 20, YScale = 20, Origin = new Point(10, 16) });
            string dirPath = @"C:\Projects\Rooms\WindowsFormsApplication1\UnitTests\TestFiles\";

            int[,] expectRes = new int[,]
            {
                {14,2,91,125},
                {9,2,28,40},
                {4,12,135,233},
                {5,2,135,233},
                {5,3,135,233},
                {2,70,230,300},
                {2,10,70,0},
                {3,65,130,235},
                {1,300,300,0},
                {29,1,49,91},
                {1,300,300,0},
                {2,15,35,0},
                {12,2,18,24}
            };

            for (int i  = 0; i  < expectRes.Length/4; i ++)
            {
                shapeMaker.Reset();
                string fileName = @"Lines" + (i + 1).ToString() + @".txt";
                System.Collections.Generic.List<Line> lines = LineReader.GetLines(dirPath + fileName);
                shapeMaker.MakeShapes(lines);
                System.Collections.Generic.List<Shape> flatList = shapeMaker.GetFlatListOfShapes();
               
                Assert.AreEqual(expectRes[i,0], flatList.Count, "Error in ShapeMaker, number of shapes, file: " + fileName);
                Assert.AreEqual(expectRes[i, 1], shapeMaker.CalculateSmallestArea(flatList), "Error in ShapeMaker, number of shapes, file: " + fileName);
                Assert.AreEqual(expectRes[i, 2], shapeMaker.CalculateLargestArea(flatList), "Error in ShapeMaker, number of shapes, file: " + fileName);
                Assert.AreEqual(expectRes[i, 3], shapeMaker.CalculateLargestAdjacentArea(flatList), "Error in ShapeMaker, number of shapes, file: " + fileName);
            }
        }
    }
}
