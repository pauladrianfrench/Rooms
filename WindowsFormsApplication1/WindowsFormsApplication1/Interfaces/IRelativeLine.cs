namespace Rooms
{
    public interface IRelativeLine : ILine
    {
        bool IsCongruentTo(Line line);
        Line.Direction RelativeDirection(Line next);

        bool CrossesOrTouches(Line l);
        bool Crosses(Line l);
        bool FullyOverlaps(Line line);
        bool OverlapsOrTouches(Line line);
    }
}
