namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    
    public class Line : ILine
    {
        public enum Direction { Up = 0, Right, Down, Left, Undef = 99999 }

        private List<Intersect> iSects;

        public Line(Point p1, Point p2)
        {
            Point1 = p1;
            Point2 = p2;
            iSects = new List<Intersect>();
        }

        public static bool operator ==(Line l1, Line l2)
        {
            return l1.IsCongruentTo(l2);
        }
        public static bool operator !=(Line l1, Line l2)
        {
            return !l1.IsCongruentTo(l2);
        }

        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public int Length { get { return DistanceBetween(Point1, Point2); } }
        public bool IsVertical { get { return (Point1.X == Point2.X); } }
        public int CountIntersects { get { return iSects.Count; } }

        public Direction Orientation
        {
            get
            {
                if (IsVertical)
                {
                    if (Point1.Y < Point2.Y)
                        return Direction.Up;
                    else
                        return Direction.Down;
                }
                else
                {
                    if (Point1.X < Point2.X)
                        return Direction.Right;
                    else
                        return Direction.Left;
                }
            }
        }

        public Line Flip() { return new Line(Point2, Point1); }
        public Direction RelativeDirection(Line next)
        {
            if (this.Point2 != next.Point1)
                return Direction.Undef;

            int offset = 0;

            while (((int)this.Orientation + offset) % 4 != (int)next.Orientation)
                offset++;

            return (Direction)(offset % 4);
        }
        public bool HasPoint(Point p)
        {
            if (IsVertical)
            {
                if (Point1.X == p.X)
                {
                    if ((p.Y >= Point1.Y && p.Y <= Point2.Y) || (p.Y >= Point2.Y && p.Y <= Point1.Y))
                        return true;
                }
            }
            else
            {
                if (Point1.Y == p.Y)
                {
                    if ((p.X >= Point1.X && p.X <= Point2.X) || (p.X >= Point2.X && p.X <= Point1.X))
                        return true;
                }
            }
            return false;
        }
        public bool AddIntersect(Intersect ix)
        {
            for (int i = 0; i < iSects.Count; ++i)
            {
                if (ix == iSects[i])
                    return false;

                if (DistanceBetween(ix.P, Point1) < DistanceBetween(iSects[i].P, Point1))
                {
                    iSects.Insert(i, ix);
                    return true;
                }
            }
            iSects.Add(ix);
            return true;
        }

        public List<Line> Split()
        {
            List<Line> ret = new List<Line>();

            if (iSects.Count <= 2)
            {
                iSects.Clear();
                ret.Add(this);
                return ret;
            }
            for (int i = 0; i < iSects.Count - 1; ++i)
            {
                ret.Add(new Line(iSects[i].P, iSects[i + 1].P));
            }
            return ret;
        }

        public bool IsCongruentTo(Line line)
        {
            return (this.Point1 == line.Point1 && this.Point2 == line.Point2)
                || (this.Point1 == line.Point2 && this.Point2 == line.Point1);
        }

        public bool FullyOverlaps(Line line)
        {
            if (this.Equals(line))
                return true;

            if (this.IsVertical != line.IsVertical || this.Length < line.Length)
            {
                return false;
            }

            if (this.IsVertical)
            {
                if (this.Point1.X != line.Point1.X)
                {
                    return false;
                }

                return ((this.Point1.Y <= line.Point1.Y && this.Point2.Y >= line.Point2.Y)
                    || (this.Point2.Y <= line.Point2.Y && this.Point1.Y >= line.Point1.Y));
            }
            else
            {
                if (this.Point1.Y != line.Point1.Y)
                {
                    return false;
                }
                return ((this.Point1.X <= line.Point1.X && this.Point2.X >= line.Point2.X)
                    || (this.Point2.X <= line.Point2.X && this.Point1.X >= line.Point1.X));
            }
        }

        public bool OverlapsOrTouches(Line line)
        {
            if (this.IsVertical != line.IsVertical)
            {
                return false;
            }

            if (this.IsVertical)
            {
                if (this.Point1.X != line.Point1.X)
                {
                    return false;
                }

                int lo = Utils.Min(this.Point1.Y, this.Point2.Y, line.Point1.Y, line.Point2.Y);
                int hi = Utils.Max(this.Point1.Y, this.Point2.Y, line.Point1.Y, line.Point2.Y);

                return (this.Length + line.Length) >= (hi - lo);
            }
            else
            {
                if (this.Point1.Y != line.Point1.Y)
                {
                    return false;
                }

                int lo = Utils.Min(this.Point1.X, this.Point2.X, line.Point1.X, line.Point2.X);
                int hi = Utils.Max(this.Point1.X, this.Point2.X, line.Point1.X, line.Point2.X);

                return (this.Length + line.Length) >= (hi - lo);
            }
        }

        public static Line JoinLines(Line line1, Line line2)
        {
            if (!line1.OverlapsOrTouches(line2))
            {
                return new Line(new Point(0, 0), new Point(0, 0));
            }
            if (line1.IsVertical)
            {
                int x = line1.Point1.X;
                int lo = Utils.Min(line1.Point1.Y, line1.Point2.Y, line2.Point1.Y, line2.Point2.Y);
                int hi = Utils.Max(line1.Point1.Y, line1.Point2.Y, line2.Point1.Y, line2.Point2.Y);
                return new Line(new Point(x, lo), new Point(x, hi));
            }
            else
            {
                int y = line1.Point1.Y;
                int lo = Utils.Min(line1.Point1.X, line1.Point2.X, line2.Point1.X, line2.Point2.X);
                int hi = Utils.Max(line1.Point1.X, line1.Point2.X, line2.Point1.X, line2.Point2.X);
                return new Line(new Point(lo, y), new Point(hi, y));
            } 
        }

        public bool TrimToIntersects()
        {
            if (iSects.Count <= 0)
                return true;

            int dist1 = Int32.MaxValue;
            int dist2 = Int32.MaxValue;

            int c1 = 0;
            int c2 = 0;
            for (int i = 0; i < iSects.Count; ++i)
            {
                if (DistanceBetween(iSects[i].P, Point1) <= dist1)
                {
                    c1 = i;
                    dist1 = DistanceBetween(iSects[i].P, Point1);
                }
                if (DistanceBetween(iSects[i].P, Point2) <= dist2)
                {
                    c2 = i;
                    dist2 = DistanceBetween(iSects[i].P, Point2);
                }
            }
            Point1 = iSects[c1].P;
            Point2 = iSects[c2].P;
            return true;
        }

        private int DistanceBetween(Point p1, Point p2)
        {
            return (IsVertical) ? Math.Abs(p1.Y - p2.Y) : Math.Abs(p1.X - p2.X);
        }

        private bool TrimPoint(Point point)
        {
            int dist = Int32.MaxValue;
            Point p = new Point(point.X, point.Y);

            foreach (Intersect ix in iSects)
            {
                if (DistanceBetween(point, ix.P) <= dist)
                {
                    dist = DistanceBetween(point, ix.P);
                    p = ix.P;
                }
            }
            point = p;
            return true;
        }

        public bool CrossesOrTouches(Line l)
        {
            if (this.IsVertical == l.IsVertical)
                return false;

            Line vert = (this.IsVertical) ? this : l;
            Line horiz = (l.IsVertical) ? this : l;

            int l1X = vert.Point1.X;
            int l2X1 = horiz.Point1.X;
            int l2X2 = horiz.Point2.X;

            int l2Y = horiz.Point1.Y;
            int l1Y1 = vert.Point1.Y;
            int l1Y2 = vert.Point2.Y;

            return Utils.Max(Math.Abs(l1X - l2X1), Math.Abs(l1X - l2X2)) <= horiz.Length
                && Utils.Max(Math.Abs(l2Y - l1Y1), Math.Abs(l2Y - l1Y2)) <= vert.Length;
        }

        public bool Crosses(Line l)
        {
            if (this.IsVertical == l.IsVertical)
                return false;

            Line vert = (this.IsVertical) ? this : l;
            Line horiz = (l.IsVertical) ? this : l;

            int l1X = vert.Point1.X;
            int l2X1 = horiz.Point1.X;
            int l2X2 = horiz.Point2.X;

            int l2Y = horiz.Point1.Y;
            int l1Y1 = vert.Point1.Y;
            int l1Y2 = vert.Point2.Y;

            return Utils.Max(Math.Abs(l1X - l2X1), Math.Abs(l1X - l2X2)) < horiz.Length
                && Utils.Max(Math.Abs(l2Y - l1Y1), Math.Abs(l2Y - l1Y2)) < vert.Length;
        }
    }
}
