namespace Rooms
{
    using System.Windows.Forms;
    using System.Drawing;

    public class DrawParams
    {
        public Graphics Graphics { get; set; }
        public Pen Pen { get; set; }
        public Trans Trans { get; set; }
        public Brush FillBrush { get; set; }
    }
}
