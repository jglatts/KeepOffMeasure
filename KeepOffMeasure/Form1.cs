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
        public static readonly string msg_title_str = "Z-Axis Connector Company";
        private static readonly int wire_contour_const = 30;

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
            txtCannyThresh1.Text = "770"; // increase this to leave out image noise
            txtCannyThresh2.Text = "300";
            this.ActiveControl = btnStartLiveFeed;
        }

        private void openWebCam()
        {
            try
            {
                capture = new VideoCapture(camIndex);
                capture.Open(camIndex);
                MessageBox.Show("Camera Found!", msg_title_str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException, msg_title_str);
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
                MessageBox.Show(ex.ToString(), msg_title_str);
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
                MessageBox.Show("error\nplease calibrate pix-per-inch", msg_title_str);
                return;
            }

            if (!getThreshValues())
            {
                MessageBox.Show("error\nplease check thresh values!", msg_title_str);
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
            Mat debug_mat = new Mat(mainFeedPicBox.Height, mainFeedPicBox.Width, MatType.CV_8UC1);
            Mat src_roi = frame.Clone();
            OpenCvSharp.Point[][] found_contours;
            int wire_end_y = 10000;
            int core_end_y = 10000;
            int keep_off_pix = -1;
            double keep_off_dist = 0;


            // filter the image and remove noise
            // could also consider shaperning or blurring
            // https://stackoverflow.com/questions/4993082/how-can-i-sharpen-an-image-in-opencv
            Cv2.CvtColor(src_roi, src_gray, ColorConversionCodes.BGR2GRAY);

            // perform canny alg for edges
            // https://docs.opencv.org/4.x/da/d22/tutorial_py_canny.html
            Cv2.Canny(src_gray, src_canny, thresh_one, thresh_two);

            // find the countours of this frame
            Cv2.FindContours(src_canny, out found_contours, out hierarchyIndexes,
                             mode: RetrievalModes.CComp,
                             method: ContourApproximationModes.ApproxNone);

            /*
                https://stackoverflow.com/questions/8461612/using-hierarchy-in-findcontours-in-opencv
                https://docs.opencv.org/4.x/d9/d8b/tutorial_py_contours_hierarchy.html
                should test using differnet hierachy methods 
             */

            // first loop for keep off measurment
            // loop through all contours where child != 1
            //      get the smallest y-value
            //      that value is where the wire ENDS
            for (int i = 0; i < hierarchyIndexes.Length; i++)
            {

                // working OK with .Child != -1
                // test out other values
                if (hierarchyIndexes[i].Child != -1)
                {
                    // test this out, can check if we have wire end
                    OpenCvSharp.Point[] check_contours = found_contours[i];
                    if (check_contours.Length < wire_contour_const)
                        continue;
                    
                    Cv2.DrawContours(debug_mat, found_contours, i, new Scalar(255, 0),
                                     thickness: 2, hierarchy: hierarchyIndexes);

                    for (int j = 0; j < found_contours[i].Length; j++)
                    {
                        int check_y = found_contours[i][j].Y;
                        if (check_y < wire_end_y)
                            wire_end_y = check_y;
                    }

                }

            }

            // second loop
            // will need to find where CORE ends
            // naive:
            //  (go through all contours and lowest y is the core end)
            for (int i = 0; i < found_contours.Length; i++)
            {
                for (int j = 0; j < found_contours[i].Length; j++)
                { 
                    int curr_y = found_contours[i][j].Y;
                    if (curr_y < core_end_y)
                        core_end_y = curr_y;
                }
            }

            keep_off_pix = wire_end_y - core_end_y;
            if (keep_off_pix > 0)
            {
                Cv2.Line(debug_mat, debug_mat.Width/2, core_end_y, debug_mat.Width/2, wire_end_y, 
                         new Scalar(255, 0), thickness:2);

                keep_off_dist = Math.Round(keep_off_pix / (double)pix_per_inch, 6);

            }

            Cv2.Circle(debug_mat, debug_mat.Width/2, wire_end_y, 5, new Scalar(255, 0), thickness:2);
            Cv2.Circle(debug_mat, debug_mat.Width/2, core_end_y, 5, new Scalar(255, 0), thickness:2);
            Cv2.ImShow("canny", src_canny);
            Cv2.ImShow("heirachy", debug_mat);

            if (keep_off_dist != 0)
                MessageBox.Show("keep off distance: " + keep_off_dist, msg_title_str);
        }

    }
}