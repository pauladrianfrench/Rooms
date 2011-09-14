namespace Rooms
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;

    public class IntersectedLine : Line, IIntersectedLine
    {
        private List<Intersect> iSects;

        public IntersectedLine(Point p1, Point p2)
            : base(p1, p2)
        {
        }

        public IntersectedLine(Line l)
            : base(l.Point1, l.Point2)
        {
        }

        public int CountIntersects { get { return iSects.Count; } }

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
    }
}
