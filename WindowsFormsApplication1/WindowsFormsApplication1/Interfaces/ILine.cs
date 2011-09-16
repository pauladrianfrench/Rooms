namespace Rooms
{
    using System.Drawing;

    public interface ILine
    {
        Point Point1 {get; set; }
        Point Point2{get; set; }
        int Length{get; }
        bool IsVertical{get; }
        Line.Direction Orientation { get; }
        bool IsCongruentTo(ILine line);
        Line.Direction RelativeDirection(ILine next);
        bool HasPoint(Point p);
    }
}
