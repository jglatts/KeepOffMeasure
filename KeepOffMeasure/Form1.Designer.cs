namespace KeepOffMeasure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainFeedPicBox = new System.Windows.Forms.PictureBox();
            this.btnStartLiveFeed = new System.Windows.Forms.Button();
            this.btnCalibratePixPerMill = new System.Windows.Forms.Button();
            this.btnMeasureKeepOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxPixPerInch = new System.Windows.Forms.TextBox();
            this.txtBoxPixPerMil = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCannyThresh1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCannyThresh2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnManualMeasureXAxis = new System.Windows.Forms.Button();
            this.txtBoxTol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxNomKeepoff = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnManualMeasure = new System.Windows.Forms.Button();
            this.txtBoxMsrdKeepOff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Thresholds = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Thresholds.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFeedPicBox
            // 
            this.mainFeedPicBox.Location = new System.Drawing.Point(403, 90);
            this.mainFeedPicBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainFeedPicBox.Name = "mainFeedPicBox";
            this.mainFeedPicBox.Size = new System.Drawing.Size(700, 472);
            this.mainFeedPicBox.TabIndex = 0;
            this.mainFeedPicBox.TabStop = false;
            this.mainFeedPicBox.Click += new System.EventHandler(this.mainFeedPicBox_Click);
            // 
            // btnStartLiveFeed
            // 
            this.btnStartLiveFeed.Location = new System.Drawing.Point(44, 38);
            this.btnStartLiveFeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartLiveFeed.Name = "btnStartLiveFeed";
            this.btnStartLiveFeed.Size = new System.Drawing.Size(261, 68);
            this.btnStartLiveFeed.TabIndex = 1;
            this.btnStartLiveFeed.Text = "Start Live Feed";
            this.btnStartLiveFeed.UseVisualStyleBackColor = true;
            this.btnStartLiveFeed.Click += new System.EventHandler(this.btnStartLiveFeed_Click);
            // 
            // btnCalibratePixPerMill
            // 
            this.btnCalibratePixPerMill.Location = new System.Drawing.Point(44, 188);
            this.btnCalibratePixPerMill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalibratePixPerMill.Name = "btnCalibratePixPerMill";
            this.btnCalibratePixPerMill.Size = new System.Drawing.Size(261, 51);
            this.btnCalibratePixPerMill.TabIndex = 2;
            this.btnCalibratePixPerMill.Text = "Calibrate Pix-Per-Mil";
            this.btnCalibratePixPerMill.UseVisualStyleBackColor = true;
            this.btnCalibratePixPerMill.Click += new System.EventHandler(this.btnCalibratePixPerMill_Click);
            // 
            // btnMeasureKeepOff
            // 
            this.btnMeasureKeepOff.Location = new System.Drawing.Point(44, 121);
            this.btnMeasureKeepOff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMeasureKeepOff.Name = "btnMeasureKeepOff";
            this.btnMeasureKeepOff.Size = new System.Drawing.Size(261, 51);
            this.btnMeasureKeepOff.TabIndex = 3;
            this.btnMeasureKeepOff.Text = "Measure Keep-Off";
            this.btnMeasureKeepOff.UseVisualStyleBackColor = true;
            this.btnMeasureKeepOff.Click += new System.EventHandler(this.btnMeasureKeepOff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(711, 617);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pix-Per-Inch";
            // 
            // txtBoxPixPerInch
            // 
            this.txtBoxPixPerInch.Location = new System.Drawing.Point(730, 647);
            this.txtBoxPixPerInch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxPixPerInch.Name = "txtBoxPixPerInch";
            this.txtBoxPixPerInch.Size = new System.Drawing.Size(70, 31);
            this.txtBoxPixPerInch.TabIndex = 5;
            // 
            // txtBoxPixPerMil
            // 
            this.txtBoxPixPerMil.Location = new System.Drawing.Point(979, 645);
            this.txtBoxPixPerMil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxPixPerMil.Name = "txtBoxPixPerMil";
            this.txtBoxPixPerMil.Size = new System.Drawing.Size(73, 31);
            this.txtBoxPixPerMil.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(963, 617);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pix-Per-Mil";
            // 
            // txtCannyThresh1
            // 
            this.txtCannyThresh1.Location = new System.Drawing.Point(194, 58);
            this.txtCannyThresh1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCannyThresh1.Name = "txtCannyThresh1";
            this.txtCannyThresh1.Size = new System.Drawing.Size(95, 31);
            this.txtCannyThresh1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Canny-Thresh1";
            // 
            // txtCannyThresh2
            // 
            this.txtCannyThresh2.Location = new System.Drawing.Point(194, 108);
            this.txtCannyThresh2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCannyThresh2.Name = "txtCannyThresh2";
            this.txtCannyThresh2.Size = new System.Drawing.Size(95, 31);
            this.txtCannyThresh2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Canny-Thresh2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnManualMeasureXAxis);
            this.groupBox1.Controls.Add(this.txtBoxTol);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBoxNomKeepoff);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnManualMeasure);
            this.groupBox1.Controls.Add(this.btnStartLiveFeed);
            this.groupBox1.Controls.Add(this.btnCalibratePixPerMill);
            this.groupBox1.Controls.Add(this.btnMeasureKeepOff);
            this.groupBox1.Location = new System.Drawing.Point(17, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(359, 513);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btnManualMeasureXAxis
            // 
            this.btnManualMeasureXAxis.Location = new System.Drawing.Point(44, 334);
            this.btnManualMeasureXAxis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManualMeasureXAxis.Name = "btnManualMeasureXAxis";
            this.btnManualMeasureXAxis.Size = new System.Drawing.Size(261, 55);
            this.btnManualMeasureXAxis.TabIndex = 17;
            this.btnManualMeasureXAxis.Text = "Manual Measure (X-Axis)";
            this.btnManualMeasureXAxis.UseVisualStyleBackColor = true;
            this.btnManualMeasureXAxis.Click += new System.EventHandler(this.btnManualMeasureXAxis_Click);
            // 
            // txtBoxTol
            // 
            this.txtBoxTol.Location = new System.Drawing.Point(197, 458);
            this.txtBoxTol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxTol.Name = "txtBoxTol";
            this.txtBoxTol.Size = new System.Drawing.Size(95, 31);
            this.txtBoxTol.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 465);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tolerance";
            // 
            // txtBoxNomKeepoff
            // 
            this.txtBoxNomKeepoff.Location = new System.Drawing.Point(194, 410);
            this.txtBoxNomKeepoff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxNomKeepoff.Name = "txtBoxNomKeepoff";
            this.txtBoxNomKeepoff.Size = new System.Drawing.Size(95, 31);
            this.txtBoxNomKeepoff.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 417);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nominal Keep-Off";
            // 
            // btnManualMeasure
            // 
            this.btnManualMeasure.Location = new System.Drawing.Point(44, 256);
            this.btnManualMeasure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManualMeasure.Name = "btnManualMeasure";
            this.btnManualMeasure.Size = new System.Drawing.Size(261, 57);
            this.btnManualMeasure.TabIndex = 12;
            this.btnManualMeasure.Text = "Manual Measure (Y-Axis)";
            this.btnManualMeasure.UseVisualStyleBackColor = true;
            this.btnManualMeasure.Click += new System.EventHandler(this.btnManualMeasure_Click);
            // 
            // txtBoxMsrdKeepOff
            // 
            this.txtBoxMsrdKeepOff.Location = new System.Drawing.Point(466, 645);
            this.txtBoxMsrdKeepOff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxMsrdKeepOff.Name = "txtBoxMsrdKeepOff";
            this.txtBoxMsrdKeepOff.Size = new System.Drawing.Size(90, 31);
            this.txtBoxMsrdKeepOff.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 615);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Measured Keep-Off";
            // 
            // Thresholds
            // 
            this.Thresholds.Controls.Add(this.txtCannyThresh2);
            this.Thresholds.Controls.Add(this.label3);
            this.Thresholds.Controls.Add(this.txtCannyThresh1);
            this.Thresholds.Controls.Add(this.label4);
            this.Thresholds.Location = new System.Drawing.Point(17, 580);
            this.Thresholds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Thresholds.Name = "Thresholds";
            this.Thresholds.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Thresholds.Size = new System.Drawing.Size(359, 167);
            this.Thresholds.TabIndex = 15;
            this.Thresholds.TabStop = false;
            this.Thresholds.Text = "Thresholds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 793);
            this.Controls.Add(this.Thresholds);
            this.Controls.Add(this.txtBoxMsrdKeepOff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxPixPerMil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxPixPerInch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainFeedPicBox);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Keep-Off Measure";
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Thresholds.ResumeLayout(false);
            this.Thresholds.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox mainFeedPicBox;
        private Button btnStartLiveFeed;
        private Button btnCalibratePixPerMill;
        private Button btnMeasureKeepOff;
        private Label label1;
        private TextBox txtBoxPixPerInch;
        private TextBox txtBoxPixPerMil;
        private Label label2;
        private TextBox txtCannyThresh1;
        private Label label3;
        private TextBox txtCannyThresh2;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnManualMeasure;
        private TextBox txtBoxMsrdKeepOff;
        private Label label5;
        private TextBox txtBoxTol;
        private Label label7;
        private TextBox txtBoxNomKeepoff;
        private Label label6;
        private GroupBox Thresholds;
        private Button btnManualMeasureXAxis;
    }
}