using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace _161220058_Omer_Faruk_Ermis_Goruntu_Isleme
{
    
    public partial class Form4 : Form
    {
        public Form4()
        {
            
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                

            }else if(comboBox1.SelectedIndex == 1)
            {
                Form3 form3 = (Form3)Application.OpenForms["Form3"];
                PictureBox pb = form3.pictureBox1;
                Bitmap GirisResmi;
                GirisResmi = new Bitmap(pb.Image);
                pictureBox2.Image = Morfologi.Dilate(GirisResmi);
                
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Form3 form3 = (Form3)Application.OpenForms["Form3"];
                PictureBox pb = form3.pictureBox1;
                Bitmap GirisResmi;
                GirisResmi = new Bitmap(pb.Image);
                pictureBox2.Image = Morfologi.DilateAndErodeFilter(GirisResmi,250,0,true,true,true);

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Form3 form3 = (Form3)Application.OpenForms["Form3"];
                PictureBox pb = form3.pictureBox1;
                Bitmap GirisResmi;
                GirisResmi = new Bitmap(pb.Image);
                pictureBox2.Image = Morfologi.OpenMorphologyFilter(GirisResmi, 250, true, true, true);

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                Form3 form3 = (Form3)Application.OpenForms["Form3"];
                PictureBox pb = form3.pictureBox1;
                Bitmap GirisResmi;
                GirisResmi = new Bitmap(pb.Image);
                pictureBox2.Image = Morfologi.CloseMorphologyFilter(GirisResmi, 250, true, true, true);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

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
    }
    
}
