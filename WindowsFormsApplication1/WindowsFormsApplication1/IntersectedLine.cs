namespace Rooms
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;

    public class IntersectedLine : IIntersectedLine
    {
        private List<Intersect> iSects;
        private ILine line;

        public Point Point1 { get { return line.Point1; } set { line.Point1 = value; } }
        public Point Point2 { get { return line.Point2; } set { line.Point2 = value; } }
        public int Length { get { return line.Length; } }
        public bool IsVertical { get { return line.IsVertical; } }
        public Line.Direction Orientation { get { return line.Orientation;  } }

        public IntersectedLine(ILine l)
        {
            List<Intersect> iSects = new List<Intersect>();
            line = l;    
        }

        public int CountIntersects { get { return iSects.Count; } }

        public bool AddIntersect(Intersect ix)
        {
            for (int i = 0; i < iSects.Count; ++i)
            {
                if (ix == iSects[i])
                    return false;

                if (Line.DistanceBetween(ix.P, line.Point1) < Line.DistanceBetween(iSects[i].P, line.Point1))
                {
                    iSects.Insert(i, ix);
                    return true;
                }
            }
            iSects.Add(ix);
            return true;
        }

        public List<ILine> Split()
        {
            List<Line> ret = new List<Line>();

            if (iSects.Count <= 2)
            {
                iSects.Clear();
                ret.Add(this.line);
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
                if (Line.DistanceBetween(iSects[i].P, line.Point1) <= dist1)
                {
                    c1 = i;
                    dist1 = Line.DistanceBetween(iSects[i].P, line.Point1);
                }
                if (Line.DistanceBetween(iSects[i].P, line.Point2) <= dist2)
                {
                    c2 = i;
                    dist2 = Line.DistanceBetween(iSects[i].P, line.Point2);
                }
            }
            line.Point1 = iSects[c1].P;
            line.Point2 = iSects[c2].P;
            return true;
        }

        private bool TrimPoint(Point point)
        {
            int dist = Int32.MaxValue;
            Point p = new Point(point.X, point.Y);

            foreach (Intersect ix in iSects)
            {
                if (Line.DistanceBetween(point, ix.P) <= dist)
                {
                    dist = Line.DistanceBetween(point, ix.P);
                    p = ix.P;
                }
            }
            point = p;
            return true;
        }
    }
}
