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
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;


namespace Homework1
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> Ipimage;



        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                Ipimage = new Image<Bgr, byte>(opf.FileName);
                imageBox1.Image = Ipimage;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                Ipimage = new Image<Bgr, byte>(opf.FileName);
                imageBox1.Image = Ipimage;
            }
        }

        private void findConfiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> outImage;
            outImage = Ipimage.Convert<Gray, byte>().ThresholdBinaryInv(new Gray(150), new Gray(255));

            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            Mat heir = new Mat();

            CvInvoke.FindContours(outImage, contours, heir, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            Image<Gray, byte> outimage2 = new Image<Gray, byte>(Ipimage.Width, Ipimage.Height, new Gray(0));

            CvInvoke.DrawContours(outimage2, contours, -1, new MCvScalar(255, 0, 0), 2);
            imageBox2.Image = outimage2;

        }

    }
}
