using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zhorin_ColorConverter
{
    public partial class Form1 : Form
    {

        ColorConvert cc = new ColorConvert();
        Stack<int> CommandStack = new Stack<int>();
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files|*.jpeg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                cc.rgbImage = new Bitmap(imagePath);
                this.pictureBox1.Image = cc.rgbImage;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void HHalf(int value) {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            width = (int)(width * 0.5);
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpH = cc.hsvImage[i, j].h + value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)(tmpH);
                }
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        void H(int value)
        {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpH = cc.hsvImage[i, j].h + value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)(tmpH);
                }
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        void VHalf(int value)
        {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            width = (int)(width * 0.5);
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpV = cc.hsvImage[i, j].v + value;
                    if (tmpV < 0)
                        cc.hsvImage[i, j].v = (byte)(tmpV + 100);
                    else if (tmpV >= 100)
                        cc.hsvImage[i, j].v = (byte)(tmpV - 100);
                    else
                        cc.hsvImage[i, j].v = (byte)(tmpV);
                }

            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        void V(int value)
        {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpV = cc.hsvImage[i, j].v + value;
                    if (tmpV < 0)
                        cc.hsvImage[i, j].v = (byte)(tmpV + 100);
                    else if (tmpV >= 100)
                        cc.hsvImage[i, j].v = (byte)(tmpV - 100);
                    else
                        cc.hsvImage[i, j].v = (byte)(tmpV);
                }

            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        void SHalf(int value)
        {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            width = (int)(width * 0.5);
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpS = cc.hsvImage[i, j].s + value;
                    if (tmpS < 0)
                        cc.hsvImage[i, j].s = (byte)(tmpS + 100);
                    else if (tmpS >= 100)
                        cc.hsvImage[i, j].s = (byte)(tmpS - 100);
                    else
                        cc.hsvImage[i, j].s = (byte)(tmpS);
                }
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        void S(int value)
        {
            cc.ConvertRGBimagetoHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    int tmpS = cc.hsvImage[i, j].s + value;
                    if (tmpS < 0)
                        cc.hsvImage[i, j].s = (byte)(tmpS + 100);
                    else if (tmpS >= 100)
                        cc.hsvImage[i, j].s = (byte)(tmpS - 100);
                    else
                        cc.hsvImage[i, j].s = (byte)(tmpS);
                }
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked == true)
            {
                HHalf(trackBar1.Value);
                CommandStack.Push(trackBar1.Value);
                CommandStack.Push(1);
            }
            else
            {
                H(trackBar1.Value);
                CommandStack.Push(trackBar1.Value);
                CommandStack.Push(2);
            }
            trackBar1.Value = 0;
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked == true)
            {
                SHalf(trackBar2.Value);
                CommandStack.Push(trackBar2.Value);
                CommandStack.Push(3);
            }
            else
            {
                S(trackBar2.Value);
                CommandStack.Push(trackBar2.Value);
                CommandStack.Push(4);
            }
            trackBar2.Value = 0;
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked == true)
            {
                VHalf(trackBar3.Value);
                CommandStack.Push(trackBar3.Value);
                CommandStack.Push(5);
            }
            else
            {
                V(trackBar3.Value);
                CommandStack.Push(trackBar3.Value);
                CommandStack.Push(6);
            }
            trackBar3.Value = 0;
            this.Cursor = Cursors.Default;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap saveImage = (Bitmap)pictureBox1.Image;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "bmp";
            dialog.Filter = "Image files (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                saveImage.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int temp = CommandStack.Pop();
                int temp1 = CommandStack.Pop();
                if(temp == 1)
                    HHalf(-temp1);
                if(temp == 2)
                    H(-temp1);
                if(temp == 3)
                    SHalf(-temp1);
                if(temp == 4)
                    S(-temp1);
                if(temp == 5)
                    VHalf(-temp1);
                if(temp == 6)
                    V(-temp1);
                pictureBox1.Image = cc.rgbImage;
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                MessageBox.Show("Стек пуст.");
            }
        }
        


    }
    public struct HSVcolor
    {
        public ushort h;//hue 0-359
        public byte s; //saturation 0-100
        public byte v; //value 0-100

        public HSVcolor(ushort _h, byte _s, byte _v)
        {
            h = _h;
            s = _s;
            v = _v;
        }
    }

    public class ColorConvert
    {
        public Bitmap rgbImage; //двумурный типа Color 
        public HSVcolor[,] hsvImage;
        byte clamp(byte value, byte min, byte max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
        ushort clamp(ushort value, ushort min, ushort max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        public HSVcolor RGBtoHSV(Color source)
        {
            float eps = 0.00001f;
            ushort hue = 0;
            byte saturation = 0, value = 0;
            float R_ = source.R/255f;
            float G_ = source.G/255f;
            float B_ = source.B/255f;
            float Cmax = Math.Max(R_, Math.Max(G_, B_));
            float Cmin = Math.Min(R_, Math.Min(G_, B_));
            float delta = Cmax - Cmin;

            value = (byte) (100*Cmax);

            if (Cmax < eps)
            {
                saturation = 0;
            }
            else
            {
                saturation = (byte) (100*delta/Cmax);
            }
            if (delta < eps)
                hue = 0;
            else if (Cmax == R_)
                hue = (ushort) (60f*(((G_ - B_)/delta)%6f));
            else if(Cmax==G_)
                hue = (ushort) (60f*(((B_ - R_)/delta)+2f));
            else if(Cmax == B_)
                hue = (ushort) (60f*(((R_ - G_)/delta)+4f));
            return new HSVcolor(clamp(hue,0,359),saturation,value);
        }

        public Color HSVtoRGB(HSVcolor source)
        {
            float R_ = 0f, G_=0f, B_= 0f;
            float C = source.s*source.v/100f/100f;
            float X = C*(1 - Math.Abs((source.h/60f)%2f - 1));
            float m = source.v/100f - C;

            if (source.h < 60)
            {
                R_ = C;
                G_ = X;
                B_ = 0f;
            }
            else if (source.h < 120)
            {
                R_ = X;
                G_ = C;
                B_ = 0f;
            }
            else if (source.h < 180)
            {
                R_ = 0f;
                G_ = C;
                B_ = X;
            }
            else if (source.h < 240)
            {
                R_ = 0f;
                G_ = X;
                B_ = C;
            }
            else if (source.h < 300)
            {
                R_ = X;
                G_ = 0f;
                B_ = C;
            }
            else if (source.h < 360)
            {
                R_ = C;
                G_ = 0f;
                B_ = X;
            }
            byte R = (byte) (255f*(R_ + m));
            byte G = (byte) (255f*(G_ + m));
            byte B = (byte) (255f*(B_ + m));

            return Color.FromArgb(clamp(R, 0, 255), clamp(G, 0, 255), clamp(B, 0, 255));
        }

        public void ConvertRGBimagetoHSV()
        {
            int wight = rgbImage.Width;
            int height = rgbImage.Height;
            hsvImage = new HSVcolor[wight,height];
            for(int i = 0; i<wight; ++i)
                for (int j = 0; j < height; ++j)
                {
                    hsvImage[i, j] = RGBtoHSV(rgbImage.GetPixel(i, j));
                }
        }
          public void ConvertHSVimagetoRGB()
        {
            int wight = hsvImage.GetLength(0);
            int height = hsvImage.GetLength(1);
            rgbImage = new Bitmap(wight,height);
            for(int i = 0; i<wight; ++i)
                for (int j = 0; j < height; ++j)
                {
                    rgbImage.SetPixel(i,j,HSVtoRGB(hsvImage[i,j]));
                }
        }
    }



}
