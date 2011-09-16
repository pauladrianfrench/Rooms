namespace Rooms
{
    using System.Drawing;
    using System.Collections.Generic;

    public interface IIntersectedLine : ILine
    {
         int CountIntersects { get; }
         bool AddIntersect(Intersect ix);
         bool TrimToIntersects();
         List<ILine> Split();
         ILine GetLine();
    }
}
