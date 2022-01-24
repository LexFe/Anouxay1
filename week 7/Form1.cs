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


namespace week_7
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imageInput;
        Image<Gray, byte> imgCanny;
        Image<Gray, float> imgSobel;
        Image<Gray, float> imgLaplacian;
        int t1, t2 , ks , kl;

        public Form1()
        {
            InitializeComponent();
            t1 = int.Parse(textBox1.Text);
            t2 = int.Parse(textBox2.Text);
            ks = int.Parse(textBox3.Text);
            kl = int.Parse(textBox4.Text);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                imageInput = new Image<Bgr, byte>(opf.FileName);
                imageBox1.Image = imageInput;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.DefaultExt = "*.jpg";
            saveImage.Filter = "Jpeg Files (*.jpg)|*.jpg|PNG files(*.png)|*.png BMP files(*.bmp)|*.bmp ";
            if (saveImage.ShowDialog()== DialogResult.OK)
            {
                imageInput.Save(saveImage.FileName);
                MessageBox.Show("Saving Complete");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            t2 = int.Parse(textBox2.Text);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(imageInput == null)
       {
                return;
            }
            Image<Gray, byte> imgGray = imageInput.Convert<Gray, byte>();
            imgSobel = new Image<Gray, float>(imageInput.Width, imageInput.Height, new Gray(0));
            imgSobel = imgGray.Sobel(1, 1, 3);
            imageBox2.Image = imgSobel;

        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageInput != null)
            {
                imgLaplacian = imageInput.Convert<Gray, float>().Laplace(3);
                imageBox2.Image = imgLaplacian;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ks = int.Parse(textBox3.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
            t1 = int.Parse(textBox1.Text);
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(imageInput == null)
            {
                return;
            }
            imgCanny = new Image<Gray, byte>(imageInput.Width, imageInput.Height, new Gray(0));
            imgCanny = imageInput.Canny(150, 20);
            imageBox2.Image = imgCanny;
        }
    }
}
