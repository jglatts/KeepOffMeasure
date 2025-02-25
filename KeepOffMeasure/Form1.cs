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
        private HierarchyIndex[] hierarchyIndexes;
        private int camIndex;
        private bool startPixCalibrate;
        private int pix_per_inch;
        private int thresh_one;
        private int thresh_two;

        public Form1()
        {
            InitializeComponent();
            setFormObjects();
            openWebCam();
        }

        private void setFormObjects()
        {
            camIndex = 0;
            pix_per_inch = 0;
            startPixCalibrate = false;
            txtBoxPixPerInch.Enabled = false;
            txtBoxPixPerMil.Enabled = false;
            camMeasure = new CamMeasure();
            txtCannyThresh1.Text = "65";
            txtCannyThresh2.Text = "75";
            this.ActiveControl = btnStartLiveFeed;
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

        private bool getThreshValues()
        {
            bool ret = true;
         
            if (!Int32.TryParse(txtCannyThresh1.Text, out thresh_one) ||
                !Int32.TryParse(txtCannyThresh2.Text, out thresh_two))
            {
                ret = false;
            }

            if (thresh_one < 0 || thresh_two < 0)
                ret = false;

            return ret;
        }

        private void btnMeasureKeepOff_Click(object sender, EventArgs e)
        {
            if (pix_per_inch == 0)
            {
                MessageBox.Show("error\nplease calibrate pix-per-inch");
                return;
            }

            if (!getThreshValues())
            {
                MessageBox.Show("error\nplease check thresh values!");
                return;
            }

            calcKeepOff();
        }

        /*
            In OpenCV's Canny edge detection, two threshold values, 
            threshold1 and threshold2, play a crucial role in the hysteresis thresholding stage. 
            This stage aims to eliminate weak edges while preserving significant ones.
                threshold1: 
                    It is the lower threshold. 
                    Any edge with a gradient magnitude below this value is immediately discarded.
                threshold2: 
                    It is the higher threshold. 
                    Any edge with a gradient magnitude above this value is considered a strong edge and is preserved.
        */
        private void calcKeepOff()
        {
            // test thresh values
            // also test smaller AOI
            Mat src_gray = new Mat();
            Mat src_canny = new Mat();
            Mat src_roi = frame.Clone();
            OpenCvSharp.Point[][] contours;
            OpenCvSharp.Point[][] found_contours;

            // filter the image and remove noise
            // could also consider shaperning or blurring
            // https://stackoverflow.com/questions/4993082/how-can-i-sharpen-an-image-in-opencv
            Cv2.CvtColor(src_roi, src_gray, ColorConversionCodes.BGR2GRAY);

            // perform canny alg for edges
            // https://docs.opencv.org/4.x/da/d22/tutorial_py_canny.html
            Cv2.Canny(src_gray, src_canny, thresh_one, thresh_two, 3, false);

            // find the countours of this frame
            Cv2.FindContours(src_canny, out found_contours, out hierarchyIndexes,
                             mode: RetrievalModes.External,
                             method: ContourApproximationModes.ApproxNone);

            Cv2.ImShow("contours", src_canny);
        }

    }
}