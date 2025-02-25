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
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFeedPicBox
            // 
            this.mainFeedPicBox.Location = new System.Drawing.Point(282, 31);
            this.mainFeedPicBox.Name = "mainFeedPicBox";
            this.mainFeedPicBox.Size = new System.Drawing.Size(490, 283);
            this.mainFeedPicBox.TabIndex = 0;
            this.mainFeedPicBox.TabStop = false;
            this.mainFeedPicBox.Click += new System.EventHandler(this.mainFeedPicBox_Click);
            // 
            // btnStartLiveFeed
            // 
            this.btnStartLiveFeed.Location = new System.Drawing.Point(31, 43);
            this.btnStartLiveFeed.Name = "btnStartLiveFeed";
            this.btnStartLiveFeed.Size = new System.Drawing.Size(183, 64);
            this.btnStartLiveFeed.TabIndex = 1;
            this.btnStartLiveFeed.Text = "Start Live Feed";
            this.btnStartLiveFeed.UseVisualStyleBackColor = true;
            this.btnStartLiveFeed.Click += new System.EventHandler(this.btnStartLiveFeed_Click);
            // 
            // btnCalibratePixPerMill
            // 
            this.btnCalibratePixPerMill.Location = new System.Drawing.Point(31, 154);
            this.btnCalibratePixPerMill.Name = "btnCalibratePixPerMill";
            this.btnCalibratePixPerMill.Size = new System.Drawing.Size(183, 40);
            this.btnCalibratePixPerMill.TabIndex = 2;
            this.btnCalibratePixPerMill.Text = "Calibrate Pix-Per-Mil";
            this.btnCalibratePixPerMill.UseVisualStyleBackColor = true;
            this.btnCalibratePixPerMill.Click += new System.EventHandler(this.btnCalibratePixPerMill_Click);
            // 
            // btnMeasureKeepOff
            // 
            this.btnMeasureKeepOff.Location = new System.Drawing.Point(31, 110);
            this.btnMeasureKeepOff.Name = "btnMeasureKeepOff";
            this.btnMeasureKeepOff.Size = new System.Drawing.Size(183, 40);
            this.btnMeasureKeepOff.TabIndex = 3;
            this.btnMeasureKeepOff.Text = "Measure Keep-Off";
            this.btnMeasureKeepOff.UseVisualStyleBackColor = true;
            this.btnMeasureKeepOff.Click += new System.EventHandler(this.btnMeasureKeepOff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pix-Per-Inch";
            // 
            // txtBoxPixPerInch
            // 
            this.txtBoxPixPerInch.Location = new System.Drawing.Point(389, 320);
            this.txtBoxPixPerInch.Name = "txtBoxPixPerInch";
            this.txtBoxPixPerInch.Size = new System.Drawing.Size(122, 23);
            this.txtBoxPixPerInch.TabIndex = 5;
            // 
            // txtBoxPixPerMil
            // 
            this.txtBoxPixPerMil.Location = new System.Drawing.Point(613, 320);
            this.txtBoxPixPerMil.Name = "txtBoxPixPerMil";
            this.txtBoxPixPerMil.Size = new System.Drawing.Size(122, 23);
            this.txtBoxPixPerMil.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pix-Per-Mil";
            // 
            // txtCannyThresh1
            // 
            this.txtCannyThresh1.Location = new System.Drawing.Point(146, 252);
            this.txtCannyThresh1.Name = "txtCannyThresh1";
            this.txtCannyThresh1.Size = new System.Drawing.Size(68, 23);
            this.txtCannyThresh1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Canny-Thresh1";
            // 
            // txtCannyThresh2
            // 
            this.txtCannyThresh2.Location = new System.Drawing.Point(146, 291);
            this.txtCannyThresh2.Name = "txtCannyThresh2";
            this.txtCannyThresh2.Size = new System.Drawing.Size(68, 23);
            this.txtCannyThresh2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Canny-Thresh2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartLiveFeed);
            this.groupBox1.Controls.Add(this.btnCalibratePixPerMill);
            this.groupBox1.Controls.Add(this.btnMeasureKeepOff);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 310);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 353);
            this.Controls.Add(this.txtCannyThresh2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCannyThresh1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxPixPerMil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxPixPerInch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainFeedPicBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Keep-Off Measure";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
    }
}