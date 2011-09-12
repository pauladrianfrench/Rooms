namespace Rooms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddLine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.useFileButton = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFillet = new System.Windows.Forms.Button();
            this.groupVH = new System.Windows.Forms.GroupBox();
            this.radioHoriz = new System.Windows.Forms.RadioButton();
            this.radioVert = new System.Windows.Forms.RadioButton();
            this.point2Y = new System.Windows.Forms.NumericUpDown();
            this.point2X = new System.Windows.Forms.NumericUpDown();
            this.point1Y = new System.Windows.Forms.NumericUpDown();
            this.point1X = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupVH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.point2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point1X)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Point1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Point2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y";
            // 
            // AddLine
            // 
            this.AddLine.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.AddLine.Location = new System.Drawing.Point(16, 150);
            this.AddLine.Name = "AddLine";
            this.AddLine.Size = new System.Drawing.Size(154, 38);
            this.AddLine.TabIndex = 8;
            this.AddLine.Text = "Add Manual Line";
            this.AddLine.UseVisualStyleBackColor = false;
            this.AddLine.Click += new System.EventHandler(this.AddLine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useFileButton);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFillet);
            this.groupBox1.Controls.Add(this.groupVH);
            this.groupBox1.Controls.Add(this.point2Y);
            this.groupBox1.Controls.Add(this.point2X);
            this.groupBox1.Controls.Add(this.point1Y);
            this.groupBox1.Controls.Add(this.point1X);
            this.groupBox1.Controls.Add(this.AddLine);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 521);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Line";
            // 
            // useFileButton
            // 
            this.useFileButton.Location = new System.Drawing.Point(16, 194);
            this.useFileButton.Name = "useFileButton";
            this.useFileButton.Size = new System.Drawing.Size(154, 41);
            this.useFileButton.TabIndex = 23;
            this.useFileButton.Text = "Select lines from file";
            this.useFileButton.UseVisualStyleBackColor = true;
            this.useFileButton.Click += new System.EventHandler(this.useFileButton_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(16, 285);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(154, 40);
            this.buttonReset.TabIndex = 17;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFillet
            // 
            this.buttonFillet.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonFillet.Location = new System.Drawing.Point(16, 241);
            this.buttonFillet.Name = "buttonFillet";
            this.buttonFillet.Size = new System.Drawing.Size(154, 38);
            this.buttonFillet.TabIndex = 16;
            this.buttonFillet.Text = "BuildRooms";
            this.buttonFillet.UseVisualStyleBackColor = false;
            this.buttonFillet.Click += new System.EventHandler(this.buttonFillet_Click);
            // 
            // groupVH
            // 
            this.groupVH.Controls.Add(this.radioHoriz);
            this.groupVH.Controls.Add(this.radioVert);
            this.groupVH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVH.Location = new System.Drawing.Point(16, 17);
            this.groupVH.Name = "groupVH";
            this.groupVH.Size = new System.Drawing.Size(139, 59);
            this.groupVH.TabIndex = 15;
            this.groupVH.TabStop = false;
            this.groupVH.Text = "Orientation";
            // 
            // radioHoriz
            // 
            this.radioHoriz.AutoSize = true;
            this.radioHoriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioHoriz.Location = new System.Drawing.Point(37, 36);
            this.radioHoriz.Name = "radioHoriz";
            this.radioHoriz.Size = new System.Drawing.Size(82, 17);
            this.radioHoriz.TabIndex = 14;
            this.radioHoriz.TabStop = true;
            this.radioHoriz.Text = "Horizontal";
            this.radioHoriz.UseVisualStyleBackColor = true;
            // 
            // radioVert
            // 
            this.radioVert.AutoSize = true;
            this.radioVert.Checked = true;
            this.radioVert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioVert.Location = new System.Drawing.Point(37, 19);
            this.radioVert.Name = "radioVert";
            this.radioVert.Size = new System.Drawing.Size(68, 17);
            this.radioVert.TabIndex = 13;
            this.radioVert.TabStop = true;
            this.radioVert.Text = "Vertical";
            this.radioVert.UseVisualStyleBackColor = true;
            this.radioVert.CheckedChanged += new System.EventHandler(this.radioVert_CheckedChanged);
            // 
            // point2Y
            // 
            this.point2Y.Location = new System.Drawing.Point(104, 124);
            this.point2Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.point2Y.Name = "point2Y";
            this.point2Y.Size = new System.Drawing.Size(36, 20);
            this.point2Y.TabIndex = 12;
            // 
            // point2X
            // 
            this.point2X.Enabled = false;
            this.point2X.Location = new System.Drawing.Point(53, 124);
            this.point2X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.point2X.Name = "point2X";
            this.point2X.Size = new System.Drawing.Size(36, 20);
            this.point2X.TabIndex = 11;
            // 
            // point1Y
            // 
            this.point1Y.Location = new System.Drawing.Point(104, 98);
            this.point1Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.point1Y.Name = "point1Y";
            this.point1Y.Size = new System.Drawing.Size(36, 20);
            this.point1Y.TabIndex = 10;
            this.point1Y.ValueChanged += new System.EventHandler(this.point1Y_ValueChanged);
            // 
            // point1X
            // 
            this.point1X.Location = new System.Drawing.Point(53, 96);
            this.point1X.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.point1X.Name = "point1X";
            this.point1X.Size = new System.Drawing.Size(36, 20);
            this.point1X.TabIndex = 9;
            this.point1X.ValueChanged += new System.EventHandler(this.point1X_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(0, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 181);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shape Data (Mouse Over)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(141, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Number of Shapes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Smallest Shape";
            this.label7.MouseEnter += new System.EventHandler(this.label7_MouseEnter);
            this.label7.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Largest Shape";
            this.label8.MouseEnter += new System.EventHandler(this.label8_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.label8_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Largest Adjacent Pair";
            this.label9.MouseEnter += new System.EventHandler(this.label9_MouseEnter);
            this.label9.MouseLeave += new System.EventHandler(this.label9_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(856, 527);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupVH.ResumeLayout(false);
            this.groupVH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.point2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point1X)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown point2Y;
        private System.Windows.Forms.NumericUpDown point2X;
        private System.Windows.Forms.NumericUpDown point1Y;
        private System.Windows.Forms.NumericUpDown point1X;
        private System.Windows.Forms.GroupBox groupVH;
        private System.Windows.Forms.RadioButton radioHoriz;
        private System.Windows.Forms.RadioButton radioVert;
        private System.Windows.Forms.Button buttonFillet;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button useFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

