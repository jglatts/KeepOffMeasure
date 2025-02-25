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
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFeedPicBox
            // 
            this.mainFeedPicBox.Location = new System.Drawing.Point(282, 31);
            this.mainFeedPicBox.Name = "mainFeedPicBox";
            this.mainFeedPicBox.Size = new System.Drawing.Size(491, 283);
            this.mainFeedPicBox.TabIndex = 0;
            this.mainFeedPicBox.TabStop = false;
            this.mainFeedPicBox.Click += new System.EventHandler(this.mainFeedPicBox_Click);
            // 
            // btnStartLiveFeed
            // 
            this.btnStartLiveFeed.Location = new System.Drawing.Point(36, 95);
            this.btnStartLiveFeed.Name = "btnStartLiveFeed";
            this.btnStartLiveFeed.Size = new System.Drawing.Size(183, 64);
            this.btnStartLiveFeed.TabIndex = 1;
            this.btnStartLiveFeed.Text = "Start Live Feed";
            this.btnStartLiveFeed.UseVisualStyleBackColor = true;
            this.btnStartLiveFeed.Click += new System.EventHandler(this.btnStartLiveFeed_Click);
            // 
            // btnCalibratePixPerMill
            // 
            this.btnCalibratePixPerMill.Location = new System.Drawing.Point(36, 250);
            this.btnCalibratePixPerMill.Name = "btnCalibratePixPerMill";
            this.btnCalibratePixPerMill.Size = new System.Drawing.Size(183, 40);
            this.btnCalibratePixPerMill.TabIndex = 2;
            this.btnCalibratePixPerMill.Text = "Calibrate Pix-Per-Mil";
            this.btnCalibratePixPerMill.UseVisualStyleBackColor = true;
            this.btnCalibratePixPerMill.Click += new System.EventHandler(this.btnCalibratePixPerMill_Click);
            // 
            // btnMeasureKeepOff
            // 
            this.btnMeasureKeepOff.Location = new System.Drawing.Point(36, 184);
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
            this.label1.Location = new System.Drawing.Point(321, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pix-Per-Inch";
            // 
            // txtBoxPixPerInch
            // 
            this.txtBoxPixPerInch.Location = new System.Drawing.Point(400, 326);
            this.txtBoxPixPerInch.Name = "txtBoxPixPerInch";
            this.txtBoxPixPerInch.Size = new System.Drawing.Size(122, 23);
            this.txtBoxPixPerInch.TabIndex = 5;
            // 
            // txtBoxPixPerMil
            // 
            this.txtBoxPixPerMil.Location = new System.Drawing.Point(624, 326);
            this.txtBoxPixPerMil.Name = "txtBoxPixPerMil";
            this.txtBoxPixPerMil.Size = new System.Drawing.Size(122, 23);
            this.txtBoxPixPerMil.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pix-Per-Mil";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.txtBoxPixPerMil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxPixPerInch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMeasureKeepOff);
            this.Controls.Add(this.btnCalibratePixPerMill);
            this.Controls.Add(this.btnStartLiveFeed);
            this.Controls.Add(this.mainFeedPicBox);
            this.Name = "Form1";
            this.Text = "Keep-Off Measure";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainFeedPicBox)).EndInit();
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
    }
}