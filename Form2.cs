using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _161220058_Omer_Faruk_Ermis_Goruntu_Isleme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            
            
        }
        private Bitmap griYap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;

                    Color renk;

                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }
        public static Bitmap ResimBoyutlandir(Bitmap img, int istenenEn, int istenenBoy)
        {
            Size istenenimg = new Size(istenenBoy, istenenEn);
            int genislik = img.Width;
            int yukseklik = img.Height;

            float Oran = 0;
            float genislikOranı = 0;
            float yukseklikOranı = 0;

            genislikOranı = ((float)istenenimg.Width / (float)genislik);
            yukseklikOranı = ((float)istenenimg.Height / (float)yukseklik);

            if (yukseklikOranı < genislikOranı)
                Oran = yukseklikOranı;
            else
                Oran = genislikOranı;

            int yenigenislik = (int)(genislik * Oran);
            int yeniyukseklik = (int)(yukseklik * Oran);
            Bitmap b = new Bitmap(yenigenislik, yeniyukseklik);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, yenigenislik, yeniyukseklik);
            g.Dispose();
            return b;
        }        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                PictureBox pb = form1.pictureBox1;
                Bitmap temp = (Bitmap)(pb.Image);
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb
                (255, nRed, nGreen, nBlue));
                    }
                }
                pb.Image = (Bitmap)bmap.Clone();
            }
        }
        public Bitmap Kes(int left, int right, int top, int bottom)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            PictureBox pb = form1.pictureBox1;
            Bitmap GirisResmi1;
            GirisResmi1 = new Bitmap(pb.Image);
            Bitmap b = new Bitmap(right - left, bottom - top);
            for (int i = left; i < right; i++)
            {
                for (int j = top; j < bottom; j++)
                {
                    b.SetPixel(i - left, j - top, GirisResmi1.GetPixel(i, j));
                }
            }
            return b;
        }
        private Bitmap ResminHistograminiCiz(Bitmap bmp)
        {
            
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi;
            GirisResmi = bmp;
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            int i = 0; 
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; //Griton resimde üç kanal
                    
                    DiziPiksel.Add(OrtalamaRenk); 
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r < 255; r++) 
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++)
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            
            int RenkMaksPikselSayisi = 0;
            for (int k = 0; k <= 255; k++)
            {
                
                listBox1.Items.Add("Renk:" + k + "=" + DiziPikselSayilari[k]);
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();
            pictureBox2.Refresh();
            int GrafikYuksekligi = 400;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi, OlcekX = 1.6;
            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
               (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
            }
            return bmp;
            
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                PictureBox pb = form1.pictureBox1;
                Bitmap image = new Bitmap(pb.Image);
                Bitmap gri = griYap(image);
                pictureBox2.Image = gri;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                PictureBox pb = form1.pictureBox1;
                Resize(100,100);
                Bitmap image = new Bitmap(pb.Image);
                pictureBox2.Image = image;
                

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                PictureBox pb = form1.pictureBox1;
                Bitmap image = new Bitmap(pb.Image);
                Bitmap boyutlandir = ResimBoyutlandir(image,250,250);
                pictureBox2.Image = boyutlandir;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                Bitmap kes = Kes(0,50,0,50);
                pictureBox2.Image = kes;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                PictureBox pb = form1.pictureBox1;
                Bitmap image1 = new Bitmap(pb.Image);
                Bitmap histogram = ResminHistograminiCiz(image1);
                pictureBox2.Image = histogram;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
