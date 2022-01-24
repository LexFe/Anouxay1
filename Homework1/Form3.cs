using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;


namespace Homework1
{
    public partial class Form3 : Form
    {
        Image<Bgr, byte> inputImage;
        public Form3()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                inputImage = new Image<Bgr, byte>(opf.FileName);
                imageBox1.Image = inputImage;

            }
        }

        private void shapeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                return;
            }
            int countTriangle = 0;
            var temp = inputImage.SmoothGaussian(5).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(200), new Gray(255));
            VectorOfVectorOfPoint contour = new VectorOfVectorOfPoint();
            Mat m = new Mat();
            CvInvoke.FindContours(temp, contour, m, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            for (int i = 0; i < contour.Size; i++)
            {
                double perimeter = CvInvoke.ArcLength(contour[i], true);
                VectorOfPoint approx = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contour[i], approx, 0.04 * perimeter, true);
                CvInvoke.DrawContours(inputImage, contour, i, new MCvScalar(100, 255, 255), 2);
                imageBox2.Image = imageBox1.Image;

                
                var moments = CvInvoke.Moments(contour[i]);
                int x = (int)(moments.M10 / moments.M00);
                int y = (int)(moments.M01 / moments.M00);

                if (approx.Size == 3)
                {
                    CvInvoke.PutText(inputImage, "Triangle", new Point(x, y),
                        FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                    countTriangle++;
                }
                if (approx.Size == 4)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contour[i]);
                    double ar = rect.Width / rect.Height;
                    if (ar == 1)
                    {
                        CvInvoke.PutText(inputImage, "Square", new Point(x, y),
                           FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                    }
                    else
                    {
                        CvInvoke.PutText(inputImage, "Rectangle", new Point(x, y),
                           FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                    }
                }
                if (approx.Size == 6)
                {
                    CvInvoke.PutText(inputImage, "Hexagon", new Point(x, y),
                       FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                }
            }
            MessageBox.Show("Number of triangle:" + countTriangle + "\nNumber of Objects:" + contour.Size);
        }

    }
}
