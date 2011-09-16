namespace Rooms
{
    using System.Collections.Generic;
    using System.IO;
    using System.Drawing;
    using System;

    public static class LineReader
    {
        public static List<ILine> GetLines(string filePath)
        {
            List<ILine> lines = new List<ILine>();

            StreamReader sw = new StreamReader(filePath);

            string textLine;

            while((textLine =  sw.ReadLine()) !=  null)
            {
                if (textLine.Length >= 7)
                {
                    string[] points = textLine.Split(':');
                    string[] coords1 = points[0].Split(',');
                    string[] coords2 = points[1].Split(',');

                    Point p1 = new Point(Convert.ToInt32(coords1[0]), Convert.ToInt32(coords1[1]));
                    Point p2 = new Point(Convert.ToInt32(coords2[0]), Convert.ToInt32(coords2[1]));

                    lines.Add(new Line(p1, p2));
                }
            }

            return lines;
        }
    }
}
