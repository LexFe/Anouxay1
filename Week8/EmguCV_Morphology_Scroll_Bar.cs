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
    public partial class EmguCV_Morphology_Scroll_Bar : Form
    {
        int dlt, ers, op, cl, gra, th, bh;
        int dltbinary, ersbinary, opbinary, clbinary, ThresholdBinaryDlt, ThresholdBinaryErs, ThresholdBinaryOp, ThresholdBinaryCl;

        Image<Bgr, byte> inputImage;
        Image<Bgr, byte> colorImage;
        Image<Gray, byte> binaryImage, morphoImage;
        public EmguCV_Morphology_Scroll_Bar()
        {
            InitializeComponent();
            dlt = trackBar_RoundDilation.Value;
            ers = trackBar_RoundErosion.Value;
            op = trackBar_Size_Opening.Value;
            cl = trackBar_Size_Closing.Value;
            gra = trackBar_Size_Gra.Value;
            th = trackBar_Size_Top_Hat.Value;
            bh = trackBar_Size_Back_Hat.Value;
            dltbinary = trackBar_RoundDilationBinary.Value;
            ersbinary = trackBar_Round_ErosionBinary.Value;
            opbinary = trackBar_SizeOpeningBinary.Value;
            clbinary = trackBar_SizeClosingBinary.Value;
            ThresholdBinaryDlt = trackBar_ThresholdBinary_Dilation.Value;
            ThresholdBinaryErs = trackBar_ThresholdBinary_Erosion.Value;
            ThresholdBinaryOp = trackBar_ThresholdBinary_Opening.Value;
            ThresholdBinaryCl = trackBar_ThresholdBinary_Closing.Value;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = trackBar_RoundDilation.Value.ToString();
            label2.Text = trackBar_RoundErosion.Value.ToString();
            label3.Text = trackBar_Size_Opening.Value.ToString();
            label4.Text = trackBar_Size_Closing.Value.ToString();
            label5.Text = trackBar_Size_Gra.Value.ToString();
            label6.Text = trackBar_Size_Top_Hat.Value.ToString();
            label7.Text = trackBar_Size_Back_Hat.Value.ToString();
            label8.Text = trackBar_RoundDilationBinary.Value.ToString();
            label9.Text = trackBar_ThresholdBinary_Dilation.Value.ToString();
            label10.Text = trackBar_ThresholdBinary_Erosion.Value.ToString();
            label11.Text = trackBar_Round_ErosionBinary.Value.ToString();
            label12.Text = trackBar_ThresholdBinary_Opening.Value.ToString();
            label13.Text = trackBar_SizeOpeningBinary.Value.ToString();
            label14.Text = trackBar_ThresholdBinary_Closing.Value.ToString();
            label15.Text = trackBar_SizeClosingBinary.Value.ToString();
        }


        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(bh, bh), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Blackhat, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void dilationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void erosionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(ThresholdBinaryOp), new Gray(255));

                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(opbinary, opbinary), new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = morphoImage.ToBitmap();
            }

        }

        private void closingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_Size_Closing_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar_Size_Closing.Value.ToString();
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(int.Parse(label4.Text), int.Parse(label4.Text)), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }
        }

        private void trackBar_RoundDilation_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar_RoundDilation.Value.ToString();
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                colorImage = inputImage.Dilate(int.Parse(label1.Text));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_RoundErosion_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar_RoundErosion.Value.ToString();
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                colorImage = inputImage.Erode(int.Parse(label2.Text));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_Size_Opening_Scroll(object sender, EventArgs e)
        {

            label3.Text = trackBar_Size_Opening.Value.ToString();
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(int.Parse(label3.Text), int.Parse(label3.Text)), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_Size_Gra_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar_Size_Gra.Value.ToString();
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(int.Parse(label5.Text), int.Parse(label5.Text)), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Gradient, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_Size_Top_Hat_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar_Size_Top_Hat.Value.ToString();
            
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(int.Parse(label6.Text), int.Parse(label6.Text)), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Tophat, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_Size_Back_Hat_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar_Size_Back_Hat.Value.ToString();

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(int.Parse(label7.Text), int.Parse(label7.Text)), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void trackBar_RoundDilationBinary_Scroll(object sender, EventArgs e)
        {
            label8.Text = trackBar_RoundDilationBinary.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width, inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label9.Text)), new Gray(255)).Dilate(int.Parse(label8.Text));
                pictureBoxOutput.Image = binaryImage.ToBitmap();
            }
        }

        private void trackBar_ThresholdBinary_Dilation_Scroll(object sender, EventArgs e)
        {

            label9.Text = trackBar_ThresholdBinary_Dilation.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width, inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label9.Text)), new Gray(255)).Dilate(int.Parse(label8.Text));
                pictureBoxOutput.Image = binaryImage.ToBitmap();
            }

        }

        private void trackBar_Round_Erosion_Scroll(object sender, EventArgs e)
        {
            label11.Text = trackBar_Round_ErosionBinary.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width, inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label9.Text)), new Gray(255)).Erode(int.Parse(label11.Text));
                pictureBoxOutput.Image = binaryImage.ToBitmap();
            }
        }


        private void trackBar_ThresholdBinary_Erosion_Scroll(object sender, EventArgs e)
        {

            label10.Text = trackBar_ThresholdBinary_Erosion.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = new Image<Gray, byte>(inputImage.Width, inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label10.Text)), new Gray(255)).Erode(int.Parse(label11.Text));
                pictureBoxOutput.Image = binaryImage.ToBitmap();
            }
        }

        private void trackBar_SizeOpeningBinary_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar_SizeOpeningBinary.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(int.Parse(label12.Text)), 
                    new Gray(255));
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(int.Parse(label13.Text), 
                    int.Parse(label13.Text)), 
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Open, 
                    kernel,
                    new Point(-1, -1), 1,
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBoxOutput.Image = morphoImage.ToBitmap();
            }
        }

        private void trackBar_ThresholdBinary_Opening_Scroll(object sender, EventArgs e)
        {
            label12.Text = trackBar_ThresholdBinary_Opening.Value.ToString();

            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(int.Parse(label12.Text)), 
                    new Gray(255));
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(int.Parse(label13.Text), 
                    int.Parse(label13.Text)), 
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Open,
                    kernel,
                    new Point(-1, -1), 1,
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBoxOutput.Image = morphoImage.ToBitmap();
            }
        }

        private void trackBar_SizeClosingBinary_Scroll(object sender, EventArgs e)
        {
            label15.Text = trackBar_SizeClosingBinary.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label14.Text)), 
                    new Gray(255));
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(int.Parse(label15.Text), 
                    int.Parse(label15.Text)), 
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Close,
                    kernel,
                    new Point(-1, -1), 1,
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBoxOutput.Image = morphoImage.ToBitmap();
            }
        }

        private void trackBar_ThresholdBinary_Closing_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar_ThresholdBinary_Closing.Value.ToString();
            if (inputImage != null)
            {
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(int.Parse(label14.Text)), 
                    new Gray(255));
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                    new Size(int.Parse(label15.Text), 
                    int.Parse(label15.Text)), 
                    new Point(-1, -1));
                morphoImage = binaryImage.MorphologyEx(MorphOp.Close,
                    kernel,
                    new Point(-1, -1), 1,
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBoxOutput.Image = morphoImage.ToBitmap();
            }
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(th, th), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Tophat, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(gra, gra), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Gradient, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(cl, cl), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }
        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(op, op), new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                colorImage = inputImage.Erode(ers);
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                colorImage = inputImage.Dilate(dlt);
                pictureBoxOutput.Image = colorImage.ToBitmap();
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                inputImage = new Image<Bgr, byte>(opf.FileName);
                pictureBoxInput.Image = inputImage.ToBitmap();
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
                pictureBoxOutput.Image.Save(saveImage.FileName);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
