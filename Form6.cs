using System;
using System.IO;
using System.Text;
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
    public partial class Form6 : Form
    {
        public Form6()
        {

            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ResmiKaydet()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            saveFileDialog1.Title = "Resmi Kaydet";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") 
            {
               
                FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                DosyaAkisi.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {

            }else if (comboBox1.SelectedIndex == 1)
            {
                Form4 form4 = (Form4)Application.OpenForms["Form4"];
                PictureBox pb = form4.pictureBox2;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg";
                sfd.Title = "Kayıt";
                sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pb.Image.Save(sfd.FileName);
                }

            }
            if (comboBox1.SelectedIndex == 2)
            {
                Form4 form4 = (Form4)Application.OpenForms["Form4"];
                PictureBox pb = form4.pictureBox2;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "bmp dosyası(*.bmp)|*.bmp";
                sfd.Title = "Kayıt";
                sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pb.Image.Save(sfd.FileName);
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                Form4 form4 = (Form4)Application.OpenForms["Form4"];
                PictureBox pb = form4.pictureBox2;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "tif dosyası(*.tif)|*.tif";
                sfd.Title = "Kayıt";
                sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pb.Image.Save(sfd.FileName);
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                Form4 form4 = (Form4)Application.OpenForms["Form4"];
                PictureBox pb = form4.pictureBox2;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "png dosyası(*.png)|*.png";
                sfd.Title = "Kayıt";
                sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pb.Image.Save(sfd.FileName);
                }
            }
        }
    }
}
