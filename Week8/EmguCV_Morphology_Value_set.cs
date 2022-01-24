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
    public partial class EmguCV_Morphology_Value_set : Form
    {
        public EmguCV_Morphology_Value_set()
        {
            InitializeComponent();
        }
        int dlt, ers, opn, cln, gra, th, bh, dltb, ersb, opnb, clnb, dlttb, erstb, opntb, clntb;
        Image<Bgr, byte> inputImage;
        Image<Bgr, byte> colorImage;
        Image<Gray, byte> binaryImage, morphoImage;

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                return;
            }
            pictureBox2.Image = inputImage.Dilate(dlt).ToBitmap();
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage == null)
                {
                    return;
                }
                pictureBox2.Image = inputImage.Dilate(int.Parse(textBox1.Text)).ToBitmap();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage == null)
                {
                    return;
                }
                pictureBox2.Image = inputImage.Erode(int.Parse(textBox2.Text)).ToBitmap();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox3.Text), int.Parse(textBox3.Text)),//pien
                        new Point(-1, -1));
                    colorImage = inputImage.MorphologyEx(MorphOp.Open,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = colorImage.ToBitmap();
                }
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox4.Text), int.Parse(textBox4.Text)),//pien
                        new Point(-1, -1));
                    colorImage = inputImage.MorphologyEx(MorphOp.Close,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = colorImage.ToBitmap();
                }
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox5.Text), int.Parse(textBox5.Text)),//pien
                        new Point(-1, -1));
                    colorImage = inputImage.MorphologyEx(MorphOp.Gradient,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = colorImage.ToBitmap();
                }
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox6.Text), int.Parse(textBox6.Text)),//pien
                        new Point(-1, -1));
                    colorImage = inputImage.MorphologyEx(MorphOp.Tophat,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = colorImage.ToBitmap();
                }
            }
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox7.Text), int.Parse(textBox7.Text)),//pien
                        new Point(-1, -1));
                    colorImage = inputImage.MorphologyEx(MorphOp.Blackhat,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = colorImage.ToBitmap();
                }
            }
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox16.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = new Image<Gray, byte>(inputImage.Width,
                        inputImage.Height);
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox16.Text)),
                        new Gray(255)).Dilate(int.Parse(textBox8.Text));//pien
                    pictureBox2.Image = binaryImage.ToBitmap();
                }
            }
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = new Image<Gray, byte>(inputImage.Width,
                        inputImage.Height);
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox14.Text)),
                        new Gray(255)).Erode(int.Parse(textBox9.Text));//pien
                    pictureBox2.Image = binaryImage.ToBitmap();
                }
            }
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox13.Text)),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox10.Text), int.Parse(textBox10.Text)), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Open,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox12.Text)),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox11.Text), int.Parse(textBox11.Text)), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Close,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void EmguCV_Morphology_Value_set_Load(object sender, EventArgs e)
        {
            dlt = int.Parse(textBox1.Text);
            ers = int.Parse(textBox2.Text);
            opn = int.Parse(textBox3.Text);
            cln = int.Parse(textBox4.Text);
            gra = int.Parse(textBox5.Text);
            th = int.Parse(textBox6.Text);
            bh = int.Parse(textBox7.Text);
            dltb = int.Parse(textBox8.Text);
            dlttb = int.Parse(textBox16.Text);
            erstb = int.Parse(textBox14.Text);
            opntb = int.Parse(textBox13.Text);
            clntb = int.Parse(textBox12.Text);
            ersb = int.Parse(textBox9.Text);
            opnb = int.Parse(textBox10.Text);
            clnb = int.Parse(textBox11.Text);

        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox12.Text)),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox11.Text), int.Parse(textBox11.Text)), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Close,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox13.Text)),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(int.Parse(textBox10.Text), int.Parse(textBox10.Text)), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Open,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void textBox16_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox16.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = new Image<Gray, byte>(inputImage.Width,
                        inputImage.Height);
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox16.Text)),
                        new Gray(255)).Dilate(int.Parse(textBox8.Text));//pien
                    pictureBox2.Image = binaryImage.ToBitmap();
                }
            }
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = new Image<Gray, byte>(inputImage.Width,
                        inputImage.Height);
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(int.Parse(textBox14.Text)),
                        new Gray(255)).Erode(int.Parse(textBox9.Text));//pien
                    pictureBox2.Image = binaryImage.ToBitmap();
                }
            }
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                return;
            }
            pictureBox2.Image = inputImage.Erode(ers).ToBitmap();
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new Size(opn, opn),//pien
                    new Point(-1, -1));
                colorImage = inputImage.MorphologyEx(MorphOp.Open,
                    kernel,
                    new Point(-1, -1), 1,
                    BorderType.Default,
                    new MCvScalar(1.0));
                pictureBox2.Image = colorImage.ToBitmap();
            }
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage != null)
            {
                colorImage = new Image<Bgr, byte>(inputImage.Width, inputImage.Height);
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new Size(cln, cln), //pien
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
                    new Size(gra, gra), //pien
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
                    new Size(th, th), //pien
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
                    new Size(bh, bh), //pien
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
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox16.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = new Image<Gray, byte>(inputImage.Width,
                        inputImage.Height);
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(dlttb),
                        new Gray(255)).Dilate(dltb);//pien
                    pictureBox2.Image = binaryImage.ToBitmap();
                }
            }
        }

        private void erosionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else 
            {
                if (inputImage != null)
                {
                binaryImage = new Image<Gray, byte>(inputImage.Width,
                    inputImage.Height);
                binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                    new Gray(erstb),
                    new Gray(255)).Erode(ersb);//pien
                pictureBox2.Image = binaryImage.ToBitmap();
                }
            }

        }

        private void openingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(opntb),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(opnb, opnb), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Open,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void closingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Not null");
                return;
            }
            else
            {
                if (inputImage != null)
                {
                    binaryImage = inputImage.Convert<Gray, byte>().ThresholdBinary(
                        new Gray(clntb),
                        new Gray(255));

                    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                        new Size(clnb, clnb), //pien
                        new Point(-1, -1));
                    morphoImage = binaryImage.MorphologyEx(MorphOp.Close,
                        kernel,
                        new Point(-1, -1), 1,
                        BorderType.Default,
                        new MCvScalar(1.0));
                    pictureBox2.Image = morphoImage.ToBitmap();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputImage = new Image<Bgr, byte>(openFile.FileName);
                pictureBox1.Image = inputImage.ToBitmap();
            }

        }
    }
}
