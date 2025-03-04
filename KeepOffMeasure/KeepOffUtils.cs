﻿/**
 *          ///,        ////
 *          \  /,      /  >.
 *           \  /,   _/  /.
 *            \_  /_/   /.
 *             \__/_   <
 *             /<<< \_\_
 *            /,)^>>_._ \
 *            (/   \\ /\\\
 *                 // ````
 *                ((`
 *                
 */
using Microsoft.VisualBasic;
using OpenCvSharp;

namespace KeepOffMeasure
{

    public class Utils
    {
        public static readonly string msg_title_str = "Z-Axis Connector Company";
        public static readonly int wire_contour_const = 30;
        public static readonly string log_path_prod = "\\\\don-pc\\MfgBackups\\SharedDocs\\KeepOffMeasure\\logs\\";
        public static readonly string log_path_test = "C:\\Users\\jglatts\\source\\repos\\KeepOffMeasure\\KeepOffMeasure\\logs\\";
    }

    public class PixelInfo
    {
        public int pix_per_inch;
        public double pix_per_mill;
        public double mill_per_pix;
        
        public PixelInfo()
        {
            pix_per_inch = -1;
            pix_per_mill = -1;
            mill_per_pix = -1;
        }
    }

    public class CamMeasure
    {
        private List<System.Drawing.Point> calib_points;
        private List<System.Drawing.Point> manual_measure_points;
        private List<System.Drawing.Point> manual_measure_points_x_axis;

        public CamMeasure()
        {
            manual_measure_points = new List<System.Drawing.Point>();
            manual_measure_points_x_axis = new List<System.Drawing.Point>();
            calib_points = new List<System.Drawing.Point>();
        }

        private PixelInfo computePixCalculations(Mat src_frame, int height)
        {
            PixelInfo ret = new PixelInfo();

            Mat frame = src_frame.Clone();
            Cv2.Line(frame, calib_points[0].X, 0, calib_points[0].X, frame.Rows, new Scalar(255, 0), thickness: 3);
            Cv2.Line(frame, calib_points[1].X, 0, calib_points[1].X, frame.Rows, new Scalar(255, 0), thickness: 3);
            int pix_dist = Math.Abs(calib_points[1].X - calib_points[0].X);
            Cv2.Line(frame, calib_points[0].X, height / 2, calib_points[1].X, height / 2, new Scalar(255, 0), thickness: 3);
            MessageBox.Show("Pixel Distance: " + pix_dist, Utils.msg_title_str);
            string ret_input = Interaction.InputBox("Enter Pitch Of Measurements");

            // compute pix-per-inch and others
            if (Double.TryParse(ret_input, out double test_pitch))
            {
                ret.pix_per_inch = Convert.ToInt32(pix_dist / test_pitch);
                ret.pix_per_mill = (pix_dist / test_pitch) / 1000;
                ret.mill_per_pix = test_pitch / pix_dist;
                string s = "Pixels-Per-Inch:\t" + ret.pix_per_inch;
                s += "\nPixels-Per-Mill:\t" + Math.Round(ret.pix_per_mill, 7);
                s += "\nMills-Per-Pixel:\t" + Math.Round(ret.mill_per_pix, 7);
                MessageBox.Show(s, Utils.msg_title_str);
            }

            Cv2.ImShow("test", frame);

            return ret;
        }

        public (bool, int) addPointManualMeasure(Mat src_frame, System.Drawing.Point point)
        {
            bool ret = false;
            int dist = 0;

            if (src_frame == null)
            {
                MessageBox.Show("error with CamMeasure", Utils.msg_title_str);
                return (ret, 0);
            }

            manual_measure_points.Add(point);
            if (manual_measure_points.Count == 2)
            {
                System.Drawing.Point point_one = manual_measure_points[0];
                System.Drawing.Point point_two = manual_measure_points[1];
                Mat copy = src_frame.Clone();
                int x_val = point_one.X;
                dist = Math.Abs(point_one.Y - point_two.Y);
                manual_measure_points.Clear();
                Cv2.Line(copy, x_val, point_one.Y, x_val, point_two.Y, new Scalar(255, 0), thickness:2);
                Cv2.ImShow("manual-measure", copy);
                ret = true;
            }

            return (ret, dist);
        }

        public (bool, int) addPointManualMeasureXAxis(Mat src_frame, System.Drawing.Point point)
        {
            bool ret = false;
            int dist = 0;

            if (src_frame == null)
            {
                MessageBox.Show("error with CamMeasure", Utils.msg_title_str);
                return (ret, 0);
            }

            manual_measure_points_x_axis.Add(point);
            if (manual_measure_points_x_axis.Count == 2)
            {
                System.Drawing.Point point_one = manual_measure_points_x_axis[0];
                System.Drawing.Point point_two = manual_measure_points_x_axis[1];
                Mat copy = src_frame.Clone();
                dist = Math.Abs(point_one.X - point_two.X);
                manual_measure_points_x_axis.Clear();
                Cv2.Line(copy, point_one.X, point_one.Y, point_two.X, point_one.Y, new Scalar(255, 0), thickness:2);
                Cv2.Line(copy, point_one.X, 0, point_one.X, copy.Height, new Scalar(255, 0), thickness: 2);
                Cv2.Line(copy, point_two.X, 0, point_two.X, copy.Height, new Scalar(255, 0), thickness: 2);
                Cv2.ImShow("x-axis", copy);
                ret = true;
            }

            return (ret, dist);
        }


        public PixelInfo? addPoint(Mat src_frame, System.Drawing.Point point, int height)
        {
            PixelInfo? ret = null;

            if (src_frame == null)
            {
                MessageBox.Show("error with CamMeasure", Utils.msg_title_str);
                return ret;
            }

            calib_points.Add(point);
            if (calib_points.Count == 2)
            {
                ret = computePixCalculations(src_frame, height);
                if (ret.pix_per_mill == -1)
                {
                    MessageBox.Show("error with calculations!", Utils.msg_title_str);
                }
                calib_points.Clear();
            }

            return ret;
        }

        public List<System.Drawing.Point> getCalibPoints()
        {
            return calib_points;
        }
    }

}
