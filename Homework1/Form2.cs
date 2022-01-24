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
using Emgu.Util;

namespace Homework1
{
    public partial class Form2 : Form
    {

        Image<Bgr, byte> input;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                input = new Image<Bgr, byte>(opf.FileName);
                imageBox1.Image = input;
            }
        }

        private void stortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> output;
            output = input.Convert<Gray, byte>().ThresholdBinaryInv(new Gray(150), new Gray(255));
            Emgu.CV.Util.VectorOfVectorOfPoint contour = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat heir = new Mat();
            CvInvoke.FindContours(output, contour, heir, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            Dictionary<int, double> dict = new Dictionary<int, double>();
            if (contour.Size > 0)
            {
                for (int i = 0;i < contour.Size; i++)
                {
                    double area = CvInvoke.ContourArea(contour[i]);
                    dict.Add(i, area);
                }
                var item = dict.OrderByDescending(v => v.Value).Take(3);
                foreach (var it in item)
                {
                    int key = int.Parse(it.Key.ToString());
                    Rectangle rect = CvInvoke.BoundingRectangle(contour[key]);
                    CvInvoke.Rectangle(input, rect, new MCvScalar(255, 0, 0), 3);
                }
                imageBox2.Image = input;
            }
        }
    }
}
