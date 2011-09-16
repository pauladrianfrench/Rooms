namespace UnitTests
{
    using NUnit.Framework;
    using Moq;
    using Rooms;
    using System.Drawing;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class TestRooms
    {
        [Test]
        public void TestLine()
        {
            ILine line1 = new Line(new Point(2, 4), new Point(10, 4));
            ILine line2 = new Line(new Point(6, 2), new Point(6, 10));
            ILine line3 = new Line(new Point(6, 2), new Point(8, 2));
            ILine line4 = new Line(new Point(10, 4), new Point(2, 4));
            ILine line5 = new Line(new Point(8, 2), new Point(6, 2));
            ILine line6 = new Line(new Point(6, 10), new Point(6, 2));
            
            // Rectangle
            ILine line7 = new Line(new Point(1, 1), new Point(1, 9));
            ILine line8 = new Line(new Point(1, 9), new Point(10, 9));
            ILine line9 = new Line(new Point(10, 9), new Point(10, 1));
            ILine line10 = new Line(new Point(10, 1), new Point(1, 1));

            // All directions
            ILine line11 = new Line(new Point(2, 4), new Point(2, 10));
            ILine line12 = new Line(new Point(2, 10), new Point(5, 10));
            ILine line13 = new Line(new Point(2, 10), new Point(2, 6));
            ILine line14 = new Line(new Point(2, 10), new Point(1, 10));
            ILine line15 = new Line(new Point(2, 10), new Point(2, 15));

            Assert.AreEqual(8, line1.Length, "line1.Length error");
            Assert.AreEqual(8, line2.Length, "line2.Length error");
            Assert.AreEqual(2, line3.Length, "line3.Length error");

            Assert.False(line1.IsVertical, "line1 vert");
            Assert.True(line2.IsVertical, "line2 vert");

            Assert.True(line1.HasPoint(new Point(6, 4)), "Contains");

            Assert.True(line1.IsCongruentTo(line4), "line1 - line4 congruence");
            Assert.True(line3.IsCongruentTo(line5), "line3 - line5 congruence");
            Assert.True(line4.IsCongruentTo(line1), "line4 - line1 congruence");
            Assert.True(line5.IsCongruentTo(line3), "line5 - line3 congruence");

            Assert.False(line1.IsCongruentTo(line2), "line1 - line2 congruence");

            Assert.AreEqual(Line.Direction.Right, line1.Orientation, "line1 orientation");
            Assert.AreEqual(Line.Direction.Up, line2.Orientation, "line2 orientation");
            Assert.AreEqual(Line.Direction.Left, line4.Orientation, "line4 orientation");
            Assert.AreEqual(Line.Direction.Down, line6.Orientation, "line6 orientation");

            Assert.AreEqual(Line.Direction.Right, line11.RelativeDirection(line12), "line11 - line12 RelativeDirection");
            Assert.AreEqual(Line.Direction.Down, line11.RelativeDirection(line13), "line11 - line13 RelativeDirection");
            Assert.AreEqual(Line.Direction.Left, line11.RelativeDirection(line14), "line11 - line14 RelativeDirection");
            Assert.AreEqual(Line.Direction.Up, line11.RelativeDirection(line15), "line11 - line15 RelativeDirection");

            //statics
            Assert.AreEqual(Line.Direction.Left, Line.Flip(line1).Orientation, "line1 Flip orientation");
            Assert.AreEqual(Line.Direction.Down, Line.Flip(line2).Orientation, "line2 Flip orientation");
            Assert.AreEqual(Line.Direction.Right, Line.Flip(line4).Orientation, "line4 Flip orientation");
            Assert.AreEqual(Line.Direction.Up, Line.Flip(line6).Orientation, "line6 Flip orientation");
            Assert.True(Line.Flip(line1).IsCongruentTo(line1), "Flip congruent");

            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 9), new Point(2, 17))), "Overlaps 1");
            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 9), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 10))), "Overlaps 2");
            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 16), new Point(2, 20))), "Touches");
            Assert.False(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 17), new Point(2, 20))), "No Overlap");

            Assert.True(Line.FullyOverlaps(new Line(new Point(2, 8), new Point(2, 20)), new Line(new Point(2, 9), new Point(2, 17))), "FullyOverlaps 1");
            Assert.True(Line.FullyOverlaps(new Line(new Point(2, 8), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 17))), "FullyOverlaps 2");
            Assert.False(Line.FullyOverlaps(new Line(new Point(2, 9), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 10))), "FullyOverlaps 3");

            ILine jLine = Line.JoinLines(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 9), new Point(2, 17)));

            Assert.True(jLine.IsCongruentTo(new Line(new Point(2, 8), new Point(2, 17))), "Joined line 1");

            Assert.True(Line.CrossesOrTouches(line2, line3), "CrossesOrTouches");
            Assert.True(Line.Crosses(line1, line2), "Crosses");

            Assert.AreEqual(new Point(6, 4), Line.GetIntersect(line1, line2), "GetIntersect");
        }

        [Test]
        public void TestIntersectedLine1()
        {
            IIntersectedLine line1 = new IntersectedLine(new Line(new Point(2, 4), new Point(10, 4)));
            IIntersectedLine line2 = new IntersectedLine(new Line(new Point(6, 2), new Point(6, 10)));
            IIntersectedLine line3 = new IntersectedLine(new Line(new Point(6, 2), new Point(8, 2)));
            IIntersectedLine line4 = new IntersectedLine(new Line(new Point(10, 4), new Point(2, 4)));
            IIntersectedLine line5 = new IntersectedLine(new Line(new Point(8, 2), new Point(6, 2)));
            IIntersectedLine line6 = new IntersectedLine(new Line(new Point(6, 10), new Point(6, 2)));

            // Rectangle
            IIntersectedLine line7 = new IntersectedLine(new Line(new Point(1, 1), new Point(1, 9)));
            IIntersectedLine line8 = new IntersectedLine(new Line(new Point(1, 9), new Point(10, 9)));
            IIntersectedLine line9 = new IntersectedLine(new Line(new Point(10, 9), new Point(10, 1)));
            IIntersectedLine line10 = new IntersectedLine(new Line(new Point(10, 1), new Point(1, 1)));

            // All directions
            IIntersectedLine line11 = new IntersectedLine(new Line(new Point(2, 4), new Point(2, 10)));
            IIntersectedLine line12 = new IntersectedLine(new Line(new Point(2, 10), new Point(5, 10)));
            IIntersectedLine line13 = new IntersectedLine(new Line(new Point(2, 10), new Point(2, 6)));
            IIntersectedLine line14 = new IntersectedLine(new Line(new Point(2, 10), new Point(1, 10)));
            IIntersectedLine line15 = new IntersectedLine(new Line(new Point(2, 10), new Point(2, 15)));

            Assert.AreEqual(8, line1.Length, "line1.Length error");
            Assert.AreEqual(8, line2.Length, "line2.Length error");
            Assert.AreEqual(2, line3.Length, "line3.Length error");

            Assert.False(line1.IsVertical, "line1 vert");
            Assert.True(line2.IsVertical, "line2 vert");

            Assert.True(line1.HasPoint(new Point(6, 4)), "Contains");

            Assert.True(line1.IsCongruentTo(line4), "line1 - line4 congruence");
            Assert.True(line3.IsCongruentTo(line5), "line3 - line5 congruence");
            Assert.True(line4.IsCongruentTo(line1), "line4 - line1 congruence");
            Assert.True(line5.IsCongruentTo(line3), "line5 - line3 congruence");

            Assert.False(line1.IsCongruentTo(line2), "line1 - line2 congruence");

            Assert.AreEqual(Line.Direction.Right, line1.Orientation, "line1 orientation");
            Assert.AreEqual(Line.Direction.Up, line2.Orientation, "line2 orientation");
            Assert.AreEqual(Line.Direction.Left, line4.Orientation, "line4 orientation");
            Assert.AreEqual(Line.Direction.Down, line6.Orientation, "line6 orientation");

            Assert.AreEqual(Line.Direction.Right, line11.RelativeDirection(line12), "line11 - line12 RelativeDirection");
            Assert.AreEqual(Line.Direction.Down, line11.RelativeDirection(line13), "line11 - line13 RelativeDirection");
            Assert.AreEqual(Line.Direction.Left, line11.RelativeDirection(line14), "line11 - line14 RelativeDirection");
            Assert.AreEqual(Line.Direction.Up, line11.RelativeDirection(line15), "line11 - line15 RelativeDirection");

            //statics
            Assert.AreEqual(Line.Direction.Left, Line.Flip(line1).Orientation, "line1 Flip orientation");
            Assert.AreEqual(Line.Direction.Down, Line.Flip(line2).Orientation, "line2 Flip orientation");
            Assert.AreEqual(Line.Direction.Right, Line.Flip(line4).Orientation, "line4 Flip orientation");
            Assert.AreEqual(Line.Direction.Up, Line.Flip(line6).Orientation, "line6 Flip orientation");
            Assert.True(Line.Flip(line1).IsCongruentTo(line1), "Flip congruent");

            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 9), new Point(2, 17))), "Overlaps 1");
            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 9), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 10))), "Overlaps 2");
            Assert.True(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 16), new Point(2, 20))), "Touches");
            Assert.False(Line.OverlapsOrTouches(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 17), new Point(2, 20))), "No Overlap");

            Assert.True(Line.FullyOverlaps(new Line(new Point(2, 8), new Point(2, 20)), new Line(new Point(2, 9), new Point(2, 17))), "FullyOverlaps 1");
            Assert.True(Line.FullyOverlaps(new Line(new Point(2, 8), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 17))), "FullyOverlaps 2");
            Assert.False(Line.FullyOverlaps(new Line(new Point(2, 9), new Point(2, 17)), new Line(new Point(2, 8), new Point(2, 10))), "FullyOverlaps 3");

            ILine jLine = Line.JoinLines(new Line(new Point(2, 8), new Point(2, 16)), new Line(new Point(2, 9), new Point(2, 17)));

            Assert.True(jLine.IsCongruentTo(new Line(new Point(2, 8), new Point(2, 17))), "Joined line 1");

            Assert.True(Line.CrossesOrTouches(line2, line3), "CrossesOrTouches");
            Assert.True(Line.Crosses(line1, line2), "Crosses");

            Assert.AreEqual(new Point(6, 4), Line.GetIntersect(line1, line2), "GetIntersect");
        }

        [Test]
        public void TestIntersectedLine2()
        {
            IIntersectedLine line1 = new IntersectedLine(new Line(new Point(2, 4), new Point(10, 4)));
            IIntersectedLine line2 = new IntersectedLine(new Line(new Point(2, 4), new Point(10, 4)));

            Assert.True(line1.IsCongruentTo(new Line(new Point(2, 4), new Point(10, 4))), "Congruent 1");
            Assert.True(line1.GetLine().IsCongruentTo(new Line(new Point(2, 4), new Point(10, 4))), "Congruent 2");
            Assert.True(line1.GetLine().IsCongruentTo(new Line(new Point(10, 4), new Point(2, 4))), "Congruent 3");

            Assert.True(line1.AddIntersect(new Intersect(new Point(3, 4))), "Add intersect 1");
            Assert.True(line1.AddIntersect(new Intersect(new Point(4, 4))), "Add intersect 2");
            Assert.True(line1.AddIntersect(new Intersect(new Point(6, 4))), "Add intersect 3");
            Assert.True(line1.AddIntersect(new Intersect(new Point(9, 4))), "Add intersect 4");
            Assert.False(line1.AddIntersect(new Intersect(new Point(1, 5))), "Add intersect 5");

            Assert.AreEqual(4, line1.CountIntersects, "count intersects");

            Assert.True(line1.TrimToIntersects(), "Trim OK");

            Assert.AreEqual(6, line1.Length, "Trimmed line length");

            List<ILine> lines = line1.Split();

            Assert.AreEqual(3, lines.Count, "Split lines count");

            Assert.AreEqual(1, lines[0].Length, "Split lines[0] length");
            Assert.AreEqual(2, lines[1].Length, "Split lines[1] length");
            Assert.AreEqual(3, lines[2].Length, "Split lines[2] length");

            Assert.True(line2.AddIntersect(new Intersect(new Point(6, 4))), "Add line2 intersect 3");
            Assert.True(line2.AddIntersect(new Intersect(new Point(3, 4))), "Add line2 intersect 1");
            Assert.True(line2.AddIntersect(new Intersect(new Point(9, 4))), "Add line2 intersect 4");
            Assert.False(line2.AddIntersect(new Intersect(new Point(1, 5))), "Add line2 intersect 5");
            Assert.True(line2.AddIntersect(new Intersect(new Point(4, 4))), "Add line2 intersect 2");

            Assert.AreEqual(4, line2.CountIntersects, "count intersects");

            Assert.True(line2.TrimToIntersects(), "Trim line2 OK");

            Assert.AreEqual(6, line1.Length, "Trimmed line2 length");

            List<ILine> lines2 = line1.Split();

            Assert.AreEqual(3, lines2.Count, "Split lines count");

            Assert.AreEqual(1, lines2[0].Length, "Split lines2[0] length");
            Assert.AreEqual(2, lines2[1].Length, "Split lines2[1] length");
            Assert.AreEqual(3, lines2[2].Length, "Split lines2[2] length");
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
                System.Collections.Generic.List<ILine> lines = LineReader.GetLines(dirPath + fileName);
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
