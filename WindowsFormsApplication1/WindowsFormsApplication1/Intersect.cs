namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Intersect
    {
        Point point;

        public Intersect(Point p)
        {
            point = p;
        }
        public int X { get { return P.X; } }
        public int Y { get { return P.Y; } }
        public Point P { get { return point; } }
    } 
}
