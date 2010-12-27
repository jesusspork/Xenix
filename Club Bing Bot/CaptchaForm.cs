using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Xenix
{
    public partial class CaptchaForm : Form
    {
        public CaptchaForm()
        {
            InitializeComponent();
        }

        private void CaptchaForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (Form1.Instance.StopPlaying) { this.Close(); }
            PictureBox[] pBox = { pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, 
                                    pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14};
            for (int i = 2; i < 14; i++)
            {
                pBox[i - 2].Image = resizeImage(Image.FromFile(i + "_Asirra.bmp"), new Size(125, 125));
            }
            pBox = null;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBox[] cBoxes = { checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8,
                                  checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14 };
            int BoxNum = Int32.Parse(((PictureBox)sender).Name.Split('x')[1]);
            CheckBox box = null;
            //box = cBoxes[BoxNum - 3];
            switch (BoxNum)
            {
                case 3:
                    box = cBoxes[0];
                    break;
                case 4:
                    box = cBoxes[1];
                    break;
                case 5:
                    box = cBoxes[2];
                    break;
                case 6:
                    box = cBoxes[3];
                    break;
                case 7:
                    box = cBoxes[4];
                    break;
                case 8:
                    box = cBoxes[5];
                    break;
                case 9:
                    box = cBoxes[6];
                    break;
                case 10:
                    box = cBoxes[7];
                    break;
                case 11:
                    box = cBoxes[8];
                    break;
                case 12:
                    box = cBoxes[9];
                    break;
                case 13:
                    box = cBoxes[10];
                    break;
                case 14:
                    box = cBoxes[11];
                    break;
            }
            Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").
                Document.GetElementById("asirra-container-" + (BoxNum - 3)).InvokeMember("click");
            if (!box.Checked)
            {

                Bitmap bmp = new Bitmap((Bitmap)((PictureBox)sender).Image, 125, 125);

                for (int i = 0; i < 25; i++)
                {
                    bmp.SetPixel(35 + i, 65 + i, Color.Red);
                    bmp.SetPixel(36 + i, 67 + i, Color.Red);
                }

                for (int ii = 0; ii < 70; ii++)
                {
                    bmp.SetPixel(60 + (ii / 2), 90 - (ii), Color.Red);
                    bmp.SetPixel(60 + (ii / 2), 91 - (ii), Color.Red);
                }

                ((PictureBox)sender).Image = bmp;
                box.Checked = true;
            }
            else
            {
                ((PictureBox)sender).Image = resizeImage(Image.FromFile(BoxNum - 1 + "_Asirra.bmp"), new Size(125, 125));
                box.Checked = false;
            }
        }

        private delegate void newCat();


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").
                        Document.GetElementById("ScoreButton").InvokeMember("click");
            }
            catch { MessageBox.Show("Unable to click Asirra scoring button"); }
            this.Visible = false;
            try
            {
                for (int i = 0; i < 15; i++)
                { System.IO.File.Delete(i + "_Asirra.bmp"); }
            }
            catch { }
            newCat newcatx = new newCat(Form1.Instance.newcaptchas);
            Form1.Instance.webBrowser1.Invoke(newcatx);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").
                        Document.GetElementById("NewChallengeButton").InvokeMember("click");
            }
            catch { MessageBox.Show("Unable to click Asirra new challenge button"); }
            this.Visible = false;
            newCat newcatx = new newCat(Form1.Instance.newcaptchas);
            Form1.Instance.webBrowser1.Invoke(newcatx);
            this.Close();
        }
    }
}
