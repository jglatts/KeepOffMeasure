using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Drawing;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;



namespace KeepOffMeasure
{
    public partial class Form1 : Form
    {
        private Mat frame;
        private CancellationTokenSource cancelTokenSource;
        private CancellationToken token;
        private VideoCapture capture;
        private Bitmap image;
        private CamMeasure camMeasure;
        private int camIndex;
        private bool startPixCalibrate;
        private int pix_per_inch;

        public Form1()
        {
            InitializeComponent();
            camIndex = 0;
            pix_per_inch = 0;
            startPixCalibrate = false;
            txtBoxPixPerInch.Enabled = false;
            txtBoxPixPerMil.Enabled = false;
            camMeasure = new CamMeasure();
            openWebCam();
        }

        private void openWebCam()
        {
            try
            {
                capture = new VideoCapture(camIndex);
                capture.Open(camIndex);
                MessageBox.Show("Camera Found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException);
                return;
            }
        }

        private void btnStartLiveFeed_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Task task = new Task(startLiveFeed, token);
            task.Start();
        }

        private void startLiveFeed()
        {
            frame = new Mat();

            if (!capture.IsOpened())
            {
                MessageBox.Show("webcam not open!");
                return;
            }

            // forever loop to run the webcam
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                getAndDisplayFrame(5);
            }
        }

        private void getAndDisplayFrame(int msDelay)
        {
            try
            {
                capture.Read(frame);
                image = BitmapConverter.ToBitmap(frame);
                if (mainFeedPicBox.Image != null)
                {
                    mainFeedPicBox.Image.Dispose();
                }
                mainFeedPicBox.Image = image;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCalibratePixPerMill_Click(object sender, EventArgs e)
        {
            if (!startPixCalibrate)
                startPixCalibrate = true;
        }

        private void mainFeedPicBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (!startPixCalibrate)
            {
                return;
            }

            PixelInfo? ret = camMeasure.addPoint(frame, me.Location, mainFeedPicBox.Height);
            if (ret != null)
            {
                pix_per_inch = ret.pix_per_inch;
                txtBoxPixPerInch.Enabled = true;
                txtBoxPixPerMil.Enabled = true;
                txtBoxPixPerInch.Text = ret.pix_per_inch.ToString();
                txtBoxPixPerMil.Text = Math.Round(ret.pix_per_mill, 3).ToString();
                txtBoxPixPerInch.Enabled = false;
                txtBoxPixPerMil.Enabled = false;
                startPixCalibrate = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMeasureKeepOff_Click(object sender, EventArgs e)
        {
            if (pix_per_inch == 0)
            {
                MessageBox.Show("error\nplease calibrate pix-per-inch");
                return;
            }

            // image processing here
        }
    }
}