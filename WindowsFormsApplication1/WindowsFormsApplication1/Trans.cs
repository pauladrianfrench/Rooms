namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Trans
    {
        public int XScale { get; set; }
        public int YScale { get; set; }
        public Point Origin { get; set; }

        public int ScaleX(int x)
        {
            return x * XScale;
        }

        public int ScaleY(int y)
        {
            return y * YScale;
        }

        public Point TransPoint(Point p)
        {
            p.X *= XScale;
            p.Y *= YScale;

            p.X += Origin.X;
            p.Y = Origin.Y - p.Y;

            return p;
        }

        public Shape TransShape(Shape s)
        {
            Shape ret = new Shape();
            int nPoint = s.Points.Count;
            for (int i = 0; i < nPoint; i++)
            {
                ret.Points.Add(TransPoint(s.Points[i]));   
            }

            foreach (Shape s1 in s.GetShapes())
            {
                ret.AddNestedShape(TransShape(s1));
            }
            return ret;
        }

        public Line TransLine(Line l)
        {
            return new Line(TransPoint(l.Point1), TransPoint(l.Point2));
        }
    }
}
