namespace Rooms
{
    using System.Drawing;
    using System.Collections.Generic;

    interface IIntersectedLine
    {
        int CountIntersects { get; }

         bool AddIntersect(Intersect ix);
         bool TrimToIntersects();
         List<Line> Split();
    }
}
