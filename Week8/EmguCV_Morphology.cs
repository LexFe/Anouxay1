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


namespace WindowsFormsApp1.Week8
{
    public partial class EmguCV_Morphology : Form
    {
        public EmguCV_Morphology()
        {
            InitializeComponent();
        }
        Image<Bgr, byte> inputImage;
        Image<Bgr, byte> colorImage;
        Image<Gray, byte> binaryImage, morphoImage;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputImage = new Image<Bgr, byte>(openFile.FileName);
                pictureBox1.Image = inputImage.ToBitmap();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.Title = "Save Gray Image";
            saveImage.DefaultExt = "*.jpg";
            saveImage.Filter = "Jpeg Files (*.jpg)|*.jpg|PNG files(*.png) *.png|BMP files(*.bmp)|*.bmp"; 

       if (saveImage.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveImage.FileName);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                return;
            }
            pictureBox2.Image = inputImage.Dilate(3).ToBitmap();

        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                return;
            }
            pictureBox2.Image = inputImage.Erode(1).ToBitmap();

        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new Size(7, 7), //pien
                    new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Close, 
                    kernel, 
                    new Point(-1, -1), 1, 
                    BorderType.Default, 
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }

        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new Size(3, 3), //pien
                    new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Gradient, 
                    kernel,
                    new Point(-1, -1), 1, 
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(3, 3), //pien
                    new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Tophat, 
                    kernel,
                    new Point(-1, -1), 1, 
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }

        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(3, 3), //pien
                    new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Blackhat, 
                    kernel, 
                    new Point(-1, -1), 1, 
                    BorderType.Default, 
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }

        }

        private void dilationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width,
                    inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(150), 
                    new Gray(255)).Dilate(1);
                pictureBox2.Image = binaryImage.ToBitmap();
            }

        }

        private void erosionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width,
                    inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(150), 
                    new Gray(255)).Erode(1);
                pictureBox2.Image = binaryImage.ToBitmap();
            }

        }

        private void openingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(150), 
                    new Gray(255));

                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(3, 3), //pien
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Open, 
                    kernel,
                    new Point(-1, -1), 1, 
                    BorderType.Default, 
                    new MCvScalar(1.0));
                pictureBox2.Image = morphoImage.ToBitmap();
            }

        }

        private void closingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(150), 
                    new Gray(255));

                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(3, 3), 
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Close, 
                    kernel,
                    new Point(-1, -1), 1, 
                    BorderType.Default, 
                    new MCvScalar(1.0));
                pictureBox2.Image = morphoImage.ToBitmap();
            }

        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new Size(3, 3), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Gradient, 
                    kernel, 
                    new Point(-1, -1), 1, 
                    BorderType.Default, 
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }

        }
    }
}
