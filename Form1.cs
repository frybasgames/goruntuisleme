using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.tif;*.png*.bmp;| Tüm Dosyalar |*.*";
            if (dosya.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            
            pictureBox1.ImageLocation = dosya.FileName;
            PictureBox pb = pictureBox1;



    }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2;
            f2= new Form2();
            f2.Show();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

   
}
