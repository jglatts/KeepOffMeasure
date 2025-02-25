using Microsoft.VisualBasic;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepOffMeasure
{
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

        private List<System.Drawing.Point> measure_points;
        private Mat? frame;

        public CamMeasure()
        {
            measure_points = new List<System.Drawing.Point>();
        }

        private PixelInfo computePixCalculations(Mat src_frame, int height)
        {
            PixelInfo ret = new PixelInfo();

            Mat frame = src_frame.Clone();
            Cv2.Line(frame, measure_points[0].X, 0, measure_points[0].X, frame.Rows, new Scalar(0, 255), thickness: 3);
            Cv2.Line(frame, measure_points[1].X, 0, measure_points[1].X, frame.Rows, new Scalar(0, 255), thickness: 3);
            int pix_dist = Math.Abs(measure_points[1].X - measure_points[0].X);
            Cv2.Line(frame, measure_points[0].X, height / 2, measure_points[1].X, height / 2, new Scalar(0, 255), thickness: 3);
            MessageBox.Show("Pixel Distance: " + pix_dist, Form1.msg_title_str);
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
                MessageBox.Show(s, Form1.msg_title_str);
            }

            Cv2.ImShow("test", frame);

            return ret;
        }

        public PixelInfo? addPoint(Mat src_frame, System.Drawing.Point point, int height)
        {
            PixelInfo? ret = null;

            if (src_frame == null)
            {
                MessageBox.Show("error with CamMeasure.addpoint()\n cam == null", Form1.msg_title_str);
                return ret;
            }

            measure_points.Add(point);
            if (measure_points.Count == 2)
            {
                ret = computePixCalculations(src_frame, height);
                if (ret.pix_per_mill == -1)
                {
                    MessageBox.Show("error with calculations!", Form1.msg_title_str);
                }
                measure_points.Clear();
            }

            return ret;
        }

        public List<System.Drawing.Point> getPoints()
        {
            return measure_points;
        }
    }

}
