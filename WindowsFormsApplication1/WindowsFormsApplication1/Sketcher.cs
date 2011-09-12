namespace Rooms
{
    using System.Drawing;
    using System;
    using System.Collections.Generic;
    
    public static class Sketcher
    {
        public static void Draw(ShapeMaker a, DrawParams dParams, SelectShapeEnum fillMode)
        {
            if (a.Shapes.Count == 0)
            {
                foreach (Line line in a.Lines)
                {
                    Draw(line, dParams);
                }
            }
            else
            {
                List<Shape> flatList = a.GetFlatListOfShapes();

                int [] fill = {-1, -1};
                
                switch (fillMode)
                {
                    case SelectShapeEnum.Largest:
                        fill[0] = a.FindLargestShape(flatList);
                        break;
                    case SelectShapeEnum.Smallest:
                        fill[0] = a.FindSmallestShape(flatList);
                        break;
                    case SelectShapeEnum.LargestAdjacentPair:
                        fill = a.FindLargestAdjacentPair(flatList);
                        break;
                }

                int nShape = flatList.Count;

                for (int i = 0; i < nShape; i++)
                {
                    Draw(flatList[i], dParams, fill[0] == i || fill[1] == i);
                }
            }
        }

        public static void Draw(Shape s, DrawParams dParams, bool fill = false)
        {
            if (fill)
            {
                Fill(s, dParams, dParams.FillBrush);
                foreach (Shape s2 in s.GetShapes())
                {
                    Draw(s2, dParams);
                    Fill(s2, dParams, new SolidBrush(Color.White));
                }
            }

            Point[] pArray = new Point[s.Points.Count];
            for (int i = 0; i < s.Points.Count; i++)
            {
                pArray[i] = dParams.Trans.TransPoint(s.Points[i]);
            }

            for (int i = 0; i < s.Points.Count; i++)
            {
                dParams.Graphics.DrawLine(dParams.Pen, pArray[i], pArray[(i + 1) % s.Points.Count]);
            }

            
        }

        public static void Fill(Shape s, DrawParams dParams, Brush fillBrush)
        {
            Point[] pArray = new Point[s.Points.Count];
            for (int i = 0; i < s.Points.Count; i++)
            {
                pArray[i] = dParams.Trans.TransPoint(s.Points[i]);
            }
            dParams.Graphics.FillPolygon(fillBrush, pArray);
        }

        public static void Draw(Line l, DrawParams dParams)
        {
            dParams.Graphics.DrawLine(dParams.Pen, dParams.Trans.TransPoint(l.Point1), dParams.Trans.TransPoint(l.Point2));
        }
    }
}
