namespace Rooms
{
    using System.Drawing;

    interface ILine
    {
        Point Point1 {get; set; }
        Point Point2{get; set; }
        int Length{get; }
        bool IsVertical{get; }
        Line.Direction Orientation { get; }

        bool IsCongruentTo(Line line);
        Line Flip();
        Line.Direction RelativeDirection(Line next);

        bool CrossesOrTouches(Line l);
        bool Crosses(Line l);
        bool FullyOverlaps(Line line);
        bool OverlapsOrTouches(Line line);
    }
}
