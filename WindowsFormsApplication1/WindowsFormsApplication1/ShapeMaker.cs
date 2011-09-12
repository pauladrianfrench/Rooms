namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class ShapeMaker
    {
        private static Pen pen1;
        
        public static Point InvalidPoint;

        private List<Line>  lines;
        private List<Shape> shapes;

        private Trans areaTrans;

        public List<Shape> Shapes { get { return shapes; } }
        public List<Line> Lines { get { return lines; } set { lines = value; } }

        public ShapeMaker(int width, int height, Trans t)
        {
            pen1 = new Pen(System.Drawing.Color.Red, 2);
            InvalidPoint = new Point(Int32.MinValue, Int32.MinValue);

            Width = width;
            Height = height;

            areaTrans = t;

            lines = new List<Line>();
            shapes = new List<Shape>();
        }

        public bool AddLine(Line l)
        {
            lines.Add(l);
            return true;
        }

        public void MakeShapes()
        {
            ResolveOverLappingLines();
            FilletLines();
            RemoveZeroLengthLines();
            SeparateShapes();
            BuildShapes();
        }

        private void ResolveOverLappingLines()
        {
        Restart:
            for (int i = 0; i < lines.Count; ++i)
            {
                for (int j = 0; j < lines.Count; ++j)
                {
                    if (i != j)
                    {
                        if (lines[i].OverlapsOrTouches(lines[j]))
                        {
                            Line replace = Line.JoinLines(lines[i], lines[j]);
                            lines.RemoveAt(Utils.Max(i, j));
                            lines[Utils.Min(i, j)] = replace;
                            goto Restart; // hooray! My first ever goto
                        }
                    }
                }
            }
        }

        private bool RemoveZeroLengthLines()
        {
            List<Line> temp = new List<Line>(); 

            for (int i = 0; i < lines.Count; ++i)
            {
                if (lines[i].Length > 0 && lines[i].CountIntersects > 0)
                    temp.Add(lines[i]);
            }

            lines.Clear();
            lines = temp;

            return true;
        }

        public void RemoveFullyOverlappedLines()
        {
        Restart:
            for (int i = 0; i < lines.Count; ++i)
            {
                for (int j = 0; j < lines.Count; ++j)
                {
                    if (i != j)
                    {
                        if (lines[i].FullyOverlaps(lines[j]))
                        {
                            lines.RemoveAt(j);
                            goto Restart; // hooray! My first ever goto
                        }
                    }
                }
            }
        }

        public void FilletLines()
        {
            for (int i = 0; i < lines.Count; ++i )
            {
                for (int j = i+1; j < lines.Count; ++j)
                {
                    Point p = GetIntersect(lines[i], lines[j]);
                    if (p != ShapeMaker.InvalidPoint)
                    {
                        lines[i].AddIntersect(new Intersect(p));
                        lines[j].AddIntersect(new Intersect(p));
                    }
                }
            }

            for (int i = 0; i < lines.Count; ++i)
            {
                lines[i].TrimToIntersects();
            }
        }

        private bool SeparateShapes()
        {
            List<Line> temp = new List<Line>();
            
            for (int i = 0; i < lines.Count; i++)
            {
                List<Line> s = lines[i].Split();
                for (int j = 0; j < s.Count; ++j)
                {
                    if (s[j].Length > 0)
                        temp.Add(s[j]);
                }
            }
            lines.Clear();
            lines = temp;
            return true;
        }

        private Point GetIntersect(Line line1, Line line2)
        {
            if (line1.CrossesOrTouches(line2))
            {
                int x = (line1.IsVertical) ? line1.Point1.X : line2.Point1.X;
                int y = (line2.IsVertical) ? line1.Point1.Y : line2.Point1.Y;
                return new Point(x, y);
            }
            return ShapeMaker.InvalidPoint;
        }

        private void BuildShapes()
        {
            if (lines.Count == 0)
                return;
            
            MyLineQueue q = new MyLineQueue();

            q.Enqueue(lines[0], shapes);
            
            while (q.Count > 0)
            {
                MapShape(q);

                if (q.Count == 0)
                {
                    int iLine = FindUnusedLine();
                    if (iLine > -1)
                    {
                        q.Enqueue(lines[iLine], shapes);
                    }
                }
            }
        }

        private void MapShape(MyLineQueue q)
        {
            Shape s = new Shape();
            try
            {
                Line start = q.Dequeue();
                int qSize = q.Count;
                
                FollowLine(start, s, q);

                if (ShapeAlreadyExists(s))
                {
                    int nRemove = q.Count - qSize;
                    if (nRemove > 0)
                        q.Remove(nRemove);
                }
                else if (ResolveDuplicateLines(s))
                {
                    int remove = q.Count - qSize;
                    if (remove > 0)
                        q.Remove(remove);
                }
                else if (!ShapeIsValid(s))
                {
                    int remove = q.Count - qSize;
                    if (remove > 0)
                        q.Remove(remove);
                    q.Enqueue(((s.GetLines())[0]).Flip(), shapes);
                }
                else
                {
                    AddShape(s);
                }
            }
            catch
            {
            }
        }

        private bool ShapeAlreadyExists(Shape newShape)
        {
            foreach (Shape s in shapes)
            {
                if (s.EqualsOrContains(newShape))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ResolveDuplicateLines(Shape s)
        {
            bool ret = false;
            List<Line> l = s.GetLines();
            int nLine = l.Count;
            for (int i = 0; i < nLine; i++)
            {
                for (int j = i+1; j < nLine; j++)
                {
                    if (l[i] == l[j])
                    {
                        KillLine(l[i]);
                        ret = true;
                    }
                }
            }
            return ret;
        }

        private void KillLine(Line l)
        {
            int nLine = lines.Count;
            int kill = -1;
            for (int i = 0; i < nLine; i++)
            {
                if (lines[i] == l)
                    kill = i;
            }
            if (kill >= 0)
                lines.RemoveAt(kill);
        }

        private void AddShape(Shape s)
        {
            int nShape = shapes.Count;
            for (int i = nShape-1; i >= 0; i--)
            {
                if (shapes[i].CanContain(s))
                {
                    shapes[i].AddNestedShape(s);
                    return;
                }
                else if (s.CanContain(shapes[i]))
                {
                    s.AddNestedShape(shapes[i]);
                    shapes.RemoveAt(i);
                }
            }
            shapes.Add(s);
        }

        int FindUnusedLine()
        {
            int nLine = lines.Count;
            for (int i = 0; i < nLine; i++)
            {
                bool found = false;
                foreach (Shape s in shapes)
                {
                    if (s.HasLine(lines[i]))
                        found = true;
                }
                if (!found)
                    return i;
            }
            return -1;
        }

        private bool ShapeIsValid(Shape s)
        {
            if (s.Points.Count < 4)
                return false;

            int left = 0;
            int right = 0;

            for (int i = 0; i < s.Points.Count; i++)
            {
                Line l1 = new Line(s.Points[i], s.Points[(i + 1) % s.Points.Count]);
                Line l2 = new Line(s.Points[(i + 1) % s.Points.Count], s.Points[(i + 2) % s.Points.Count]);

                switch (l1.RelativeDirection(l2))
                {
                    case Line.Direction.Left: left++;
                        break;
                    case Line.Direction.Right: right++;
                        break;
                    default:
                        break;
                }
            }
            return ((right - left) == 4);
        }

        public int ShapeCount()
        {
            int total = 0;
            foreach (Shape s in shapes)
            {
                total += s.ShapeCount();
            }
            return total;
        }

        public List<Shape> GetFlatListOfShapes()
        {
            List<Shape> list = new List<Shape>();

            foreach(Shape s in shapes)
            {
                list.Add(s);
                list.AddRange(s.GetFlatListOfShapes());
            }

            return list;
        }

        private void FollowLine(Line start, Shape s, MyLineQueue q)
        {
           // q.Remove(start);

            if (!s.AddPoint(start.Point1))
                return;

            List<Line> l = new List<Line>();

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] != start)
                {
                    if (lines[i].HasPoint(start.Point2))
                    {
                        if (start.Point2 != lines[i].Point1)
                            lines[i] = lines[i].Flip();
                        
                        l.Add(lines[i]);
                    }
                }
            }

            if (l.Count == 1)
            {
                FollowLine(l[0], s, q);
            }
            else
            {
                int iR = -1;
                int iL = -1;
                int iU = -1;
                for (int i = 0; i < l.Count; i++)
                {
                    switch (start.RelativeDirection(l[i]))
                    {
                        case Line.Direction.Right: iR = i; break;
                        case Line.Direction.Left: iL = i; break;
                        case Line.Direction.Up: iU = i; break;
                        case Line.Direction.Down: iU = i; break;
                        case Line.Direction.Undef: iU = i; break;
                        default: break;
                    }
                }

                if (iR > -1)
                {
                    if (iU > -1)
                        q.Enqueue(l[iU], shapes);
                    if (iL > -1)
                        q.Enqueue(l[iL], shapes);

                    FollowLine(l[iR], s, q);

                }
                else if (iU > -1)
                {
                    if (iL > -1)
                        q.Enqueue(l[iL], shapes);
                    FollowLine(l[iU], s, q);
                }
                else if (iL > -1)
                {
                    FollowLine(l[iL], s, q);
                }
            }
            return;
        }        

        public int   Width   { get; set; }
        public int   Height  { get; set; }

        public void Reset()
        {
            lines.Clear();
            shapes.Clear();
        }

        public int FindLargestShape(List<Shape> list)
        {
            int ret = -1;
            double smallArea = double.MinValue;
            for (int i = 0; i < list.Count; ++i)
            {
                double a = list[i].GetArea();
                if (smallArea < a)
                {
                    smallArea = a;
                    ret = i;
                }
            }
            return ret;
        }

        public int FindSmallestShape(List<Shape> list)
        {
            int ret = -1;
            double bigArea = double.MaxValue;
            for (int i = 0; i < list.Count; ++i)
            {
                double a = list[i].GetArea();
                if (bigArea > a)
                {
                    bigArea = a;
                    ret = i;
                }
            }
            return ret;
        }

        public double CalculateSmallestArea(List<Shape> list)
        {
            int i = FindSmallestShape(list);
            return (i < 0) ? 0.0 : list[i].GetArea();
        }

        public double CalculateLargestArea(List<Shape> list)
        {
            int i = FindLargestShape(list);
            return (i < 0) ? 0.0 : list[i].GetArea();
        }

        public int[] FindLargestAdjacentPair(List<Shape> list)
        {
            int[] pair = new int [] { -1, -1 };
            double combinedArea = 0;

            int nShape = list.Count;
            for (int i = 0; i < nShape; i++)
            {
                for (int j = 0; j < nShape; j++ )
                {
                    if (i != j && (list[i].IsAdjacentTo(list[j]) || list[i].CanContain(list[j])))
                    {
                        double totalArea = list[i].GetArea() + list[j].GetArea();
                        if (totalArea > combinedArea)
                        {
                            combinedArea = totalArea;
                            pair[0] = i;
                            pair[1] = j;
                        }
                    }
                }
            }
            return pair;
        }

        public double CalculateLargestAdjacentArea(List<Shape> list)
        {
            int[] pair = FindLargestAdjacentPair(list);

            if (pair[0] == -1 || pair[1] == -1)
                return 0;

            return list[pair[0]].GetArea() + list[pair[1]].GetArea();
        }
    }
}
