namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    
    public class Line : ILine
    {
        public enum Direction { Up = 0, Right, Down, Left, Undef = 99999 }

        public Line(Point p1, Point p2)
        {
            Point1 = p1;
            Point2 = p2;
        }
        public Line(ILine l)
        { 
            this.Point1 = l.Point1; this.Point2 = l.Point2; 
        }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public int Length { get { return DistanceBetween(Point1, Point2); } }
        public bool IsVertical { get { return (Point1.X == Point2.X); } }
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
        public Direction RelativeDirection(ILine next)
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
        public bool IsCongruentTo(ILine line)
        {
            return (this.Point1 == line.Point1 && this.Point2 == line.Point2)
                || (this.Point1 == line.Point2 && this.Point2 == line.Point1);
        }
       
        public static ILine JoinLines(ILine line1, ILine line2)
        {
            if (!Line.OverlapsOrTouches(line1, line2))
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
        public static int DistanceBetween(Point p1, Point p2)
        {
            return (p1.X == p2.X) ? Math.Abs(p1.Y - p2.Y) : Math.Abs(p1.X - p2.X);
        }
        public static ILine Flip(ILine l) { return new Line(l.Point2, l.Point1); }
        public static bool CrossesOrTouches(ILine line1, ILine line2)
        {
            if (line1.IsVertical == line2.IsVertical)
                return false;

            ILine vert = (line1.IsVertical) ? line1 : line2;
            ILine horiz = (line2.IsVertical) ? line1 : line2;

            int l1X = vert.Point1.X;
            int l2X1 = horiz.Point1.X;
            int l2X2 = horiz.Point2.X;

            int l2Y = horiz.Point1.Y;
            int l1Y1 = vert.Point1.Y;
            int l1Y2 = vert.Point2.Y;

            return Utils.Max(Math.Abs(l1X - l2X1), Math.Abs(l1X - l2X2)) <= horiz.Length
                && Utils.Max(Math.Abs(l2Y - l1Y1), Math.Abs(l2Y - l1Y2)) <= vert.Length;
        }
        public static bool Crosses(ILine line1, ILine line2)
        {
            if (line1.IsVertical == line2.IsVertical)
                return false;

            ILine vert = (line1.IsVertical) ? line1 : line2;
            ILine horiz = (line2.IsVertical) ? line1 : line2;

            int l1X = vert.Point1.X;
            int l2X1 = horiz.Point1.X;
            int l2X2 = horiz.Point2.X;

            int l2Y = horiz.Point1.Y;
            int l1Y1 = vert.Point1.Y;
            int l1Y2 = vert.Point2.Y;

            return Utils.Max(Math.Abs(l1X - l2X1), Math.Abs(l1X - l2X2)) < horiz.Length
                && Utils.Max(Math.Abs(l2Y - l1Y1), Math.Abs(l2Y - l1Y2)) < vert.Length;
        }
        public static bool FullyOverlaps(ILine line1, ILine line2)
        {
            if (line1.Equals(line2))
                return true;

            if (line1.IsVertical != line2.IsVertical || line1.Length < line2.Length)
            {
                return false;
            }

            if (line1.IsVertical)
            {
                if (line1.Point1.X != line2.Point1.X)
                {
                    return false;
                }

                return ((line1.Point1.Y <= line2.Point1.Y && line1.Point2.Y >= line2.Point2.Y)
                    || (line1.Point2.Y <= line2.Point2.Y && line1.Point1.Y >= line2.Point1.Y));
            }
            else
            {
                if (line1.Point1.Y != line2.Point1.Y)
                {
                    return false;
                }
                return ((line1.Point1.X <= line2.Point1.X && line1.Point2.X >= line2.Point2.X)
                    || (line1.Point2.X <= line2.Point2.X && line1.Point1.X >= line2.Point1.X));
            }
        }
        public static bool OverlapsOrTouches(ILine line1, ILine line2)
        {
            if (line1.IsVertical != line2.IsVertical)
            {
                return false;
            }

            if (line1.IsVertical)
            {
                if (line1.Point1.X != line2.Point1.X)
                {
                    return false;
                }

                int lo = Utils.Min(line1.Point1.Y, line1.Point2.Y, line2.Point1.Y, line2.Point2.Y);
                int hi = Utils.Max(line1.Point1.Y, line1.Point2.Y, line2.Point1.Y, line2.Point2.Y);

                return (line1.Length + line2.Length) >= (hi - lo);
            }
            else
            {
                if (line1.Point1.Y != line2.Point1.Y)
                {
                    return false;
                }

                int lo = Utils.Min(line1.Point1.X, line1.Point2.X, line2.Point1.X, line2.Point2.X);
                int hi = Utils.Max(line1.Point1.X, line1.Point2.X, line2.Point1.X, line2.Point2.X);

                return (line1.Length + line2.Length) >= (hi - lo);
            }
        }
        public static Point GetIntersect(ILine line1, ILine line2)
        {
            if (Line.CrossesOrTouches(line1, line2))
            {
                int x = (line1.IsVertical) ? line1.Point1.X : line2.Point1.X;
                int y = (line2.IsVertical) ? line1.Point1.Y : line2.Point1.Y;
                return new Point(x, y);
            }
            return new Point(Int32.MinValue, Int32.MinValue);
        }
    }
}
