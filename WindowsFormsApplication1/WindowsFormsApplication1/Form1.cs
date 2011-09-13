namespace Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        ShapeMaker shapeMaker;
        List<Line> userLines;

        public Form1()
        {
            InitializeComponent();

            int areaWidth  = 20;
            int areaHeight = 15;

            userLines = new List<Line>();
            shapeMaker = new ShapeMaker(areaWidth, areaHeight, new Trans { XScale = 20, YScale = 20, Origin = new Point(10, 16) });

            // set up x y selector controls (spin boxes)
            this.point1X.Maximum = new decimal(new int[] { areaWidth,  0, 0, 0 });
            this.point2X.Maximum = new decimal(new int[] { areaWidth,  0, 0, 0 });
            this.point1Y.Maximum = new decimal(new int[] { areaHeight, 0, 0, 0 });
            this.point2Y.Maximum = new decimal(new int[] { areaHeight, 0, 0, 0 });
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArea(SelectShapeEnum.None);
        }

        private void AddLine_Click(object sender, EventArgs e)
        {
           ////  Manually add lines - DO NOT DELETE!!
            Line l = new Line(new Point(Convert.ToInt32(this.point1X.Value),
                                            Convert.ToInt32(this.point1Y.Value)),
                                  new Point(Convert.ToInt32(this.point2X.Value),
                                            Convert.ToInt32(this.point2Y.Value)));

            userLines.Add(l);
           // shapeMaker.AddLine(l); 

            DrawArea(SelectShapeEnum.None);
        }

        private void DrawArea(SelectShapeEnum fill)
        {
            DrawParams dp = new DrawParams();

            dp.Graphics = this.CreateGraphics();
            dp.Graphics.Clear(Color.White);
            dp.Trans = new Trans { XScale = 20, YScale = 20, Origin = new Point(240, 350) };
            dp.Pen = new Pen(Color.Blue);
            dp.FillBrush = new SolidBrush(Color.GreenYellow);

            Sketcher.Draw(shapeMaker, dp, fill, userLines);

            List<Shape> flatList = shapeMaker.GetFlatListOfShapes();
            int nShapes = flatList.Count;
            label5.Text = nShapes.ToString();

            if (nShapes > 0)
            {
                label10.Text = shapeMaker.CalculateSmallestArea(flatList).ToString();
                label11.Text = shapeMaker.CalculateLargestArea(flatList).ToString();
                label12.Text = shapeMaker.CalculateLargestAdjacentArea(flatList).ToString();
            }
        }

        private void radioVert_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVert.Checked)
            {
                point2X.Enabled = false;
                point2Y.Enabled = true;
                point2X.Value = point1X.Value;
            }
            else
            {
                point2X.Enabled = true;
                point2Y.Enabled = false;
                point2Y.Value = point1Y.Value;
            }
        }

        private void point1X_ValueChanged(object sender, EventArgs e)
        {
            if (radioVert.Checked)
            {
                point2X.Value = point1X.Value;
            }
        }

        private void point1Y_ValueChanged(object sender, EventArgs e)
        {
            if (radioHoriz.Checked)
            {
                point2Y.Value = point1Y.Value;
            }
        }

        private void buttonFillet_Click(object sender, EventArgs e)
        {
            shapeMaker.MakeShapes(userLines);
            buttonFillet.Enabled = false;
            buttonReset.Enabled = true;
            useFileButton.Enabled = false;
            AddLine.Enabled = false;
            DrawArea(SelectShapeEnum.None);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shapeMaker.Reset();
            buttonFillet.Enabled = true;
            AddLine.Enabled = true;
            useFileButton.Enabled = true;
            DrawArea(SelectShapeEnum.None);
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.Smallest);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.None);
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.Largest);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.None);
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.LargestAdjacentPair);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            DrawArea(SelectShapeEnum.None);
        }

        private void useFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                userLines = LineReader.GetLines(openFileDialog1.FileName);

                shapeMaker.Reset();
               // shapeMaker.Lines = userLines;
                AddLine.Enabled = false;
                useFileButton.Enabled = false;
                DrawArea(SelectShapeEnum.None);
            }
        }
    }
}
