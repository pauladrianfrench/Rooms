namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Shape
    {
        int top;
        int bottom;
        int left;
        int right;

        List<Point> points;
        List<Shape> shapes;

        public Shape()
        {
            top = Int32.MinValue;
            bottom = Int32.MaxValue;
            left = Int32.MaxValue;
            right = Int32.MinValue;
            points = new List<Point>();
            shapes = new List<Shape>();
        }

        public bool AddPoint(Point p)
        {
            if (IsStart(p))
                return false;

            points.Add(p);
            
            if (p.X > right)
                right = p.X;

            if (p.X < left)
                left = p.X;

            if (p.Y > top)
                top = p.Y;

            if (p.Y < bottom)
                bottom = p.Y;

            return true;
        }

        public List<Shape> GetFlatListOfShapes()
        {
            List<Shape> list = new List<Shape>();

            foreach (Shape s in shapes)
            {
                list.Add(s);
                list.AddRange(s.GetFlatListOfShapes());
            }
            return list;
        }

        public int ShapeCount()
        {
            int total = 1;
            foreach (Shape s in shapes)
            {
                total += s.ShapeCount();
            }
            return total;
        }

        public bool Equals(Shape s)
        {
            if (this.points.Count != s.points.Count)
                return false;

            foreach (Point p in this.points)
            {
                if (!s.Exists(p))
                    return false;
            }
            return true;
        }

        public bool EqualsOrContains(Shape newShape)
        {
            if (this.Equals(newShape))
                return true;

            foreach (Shape s in shapes)
            {
                if (s.EqualsOrContains(newShape))
                    return true;
            }
            return false;
        }

        public void AddNestedShape(Shape s1)
        {
            foreach (Shape s2 in shapes)
            {
                if (s2.CanContain(s1))
                {
                    s2.AddNestedShape(s1);
                    return;
                }
            }

            int nShapes = shapes.Count;
            for (int i = (nShapes-1); i >= 0; i--)
            {
                if (s1.CanContain(shapes[i]))
                {
                    s1.AddNestedShape(shapes[i]);
                    shapes.RemoveAt(i);
                }
            }
            shapes.Add(s1);
        }

        public bool IsAdjacentTo(Shape s)
        {
            List<ILine> lines1 = this.GetLines();
            int nLine = lines1.Count;

            for (int i = 0; i < nLine; ++i)
            {
                if (s.Contains(lines1[i]))
                    return true;
            }
            return false;
        }

        public bool CanContain(Shape s)
        {
            if (this.LeftEdge > s.LeftEdge
                || this.RightEdge < s.RightEdge
                || this.TopEdge < s.TopEdge
                || this.BottomEdge > s.BottomEdge)
                return false;

            if (this.GetAreaOfSpace() <= s.GetAreaOfSpace())
                return false;

            Point rightest = ShapeMaker.InvalidPoint;

            foreach (Point ps in s.Points)
            {
                if (ps.X == s.RightEdge)
                {
                    rightest = ps;
                    break;
                }
            }
            if (rightest == ShapeMaker.InvalidPoint)
                return false;

            ILine ray = new Line(rightest, new Point(Int32.MaxValue, rightest.Y));

            int intersections = 0;

            foreach (ILine l in this.GetLines())
            {
                if (Line.Crosses(ray, l))
                    intersections++;
            }
            return (intersections % 2) != 0;
        }

        public bool HasLine(ILine l)
        {
            foreach (ILine lin in GetLines())
            {
                if (lin.IsCongruentTo(l))
                    return true;
            }
            foreach (Shape s in shapes)
            {
                if (s.HasLine(l))
                    return true;
            }
            return false;
        }

        public List<Point> Points
        {
            get { return points; }
            private set { }
        }

        public List<ILine> GetLines()
        {
            List<ILine> lines = new List<ILine>();
            if (points.Count < 2)
                return lines;
            for (int i = 0; i < points.Count; i++)
            {
                lines.Add(new Line(points[i], points[(i + 1) % points.Count]));
            }
            return lines;
        }

        public bool Contains(ILine l)
        {
            for (int i = 0; i < points.Count; i++)
            {
                ILine shapeLine = new Line(points[i], points[(i + 1) % points.Count]);
                if (shapeLine.IsCongruentTo(l))
                {
                    return true;
                }
            }
            return false;
        }

        bool Exists(Point p)
        {
            foreach (var point in points)
            {
                if (p == point)
                    return true;
            }
            return false;
        }

        bool IsStart(Point p)
        {
            int nPoint = points.Count;
            if (nPoint <= 0)
                return false;
            if (points[0] == p)
                return true;
            return false;
        }

        public List<Shape> GetShapes()
        {
            return shapes;
        }

        public virtual double GetArea()
        {
            double nestedAreas = 0;

            foreach (Shape s in shapes)
            {
                nestedAreas += s.GetAreaOfSpace();
            }
            return GetAreaOfSpace() - nestedAreas;
        }

        public double GetAreaOfSpace()
        {
            int odds = 0;
            int evens = 0;

            for (int i = 0; i < points.Count; i++)
            {
                Point current = points[i];
                Point next = points[(i + 1) % points.Count];

                odds += current.X * next.Y;
                evens += current.Y * next.X;
            }
            return 0.5 * Math.Abs(odds - evens);
        }

        public int TopEdge { get { return top; } private set { } }
        public int BottomEdge { get { return bottom; } private set { } }
        public int LeftEdge { get { return left; } private set { } }
        public int RightEdge { get { return right; } private set { } }

    }
}
