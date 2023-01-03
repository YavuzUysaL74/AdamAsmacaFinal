using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmacas2
{
    public partial class Form1 : Form
    {
        

        Random rnd = new Random();
        string[] kelimeler = new string[] {"YAVUZ", "UÇAK", "GEMİ", "MEKANİK", "ELEKTRONİK", "MERHABA", "KODLAMA", "İZMİR", "BOYOZ", "KARTAL", "BİLGİSAYAR", "KUŞ"};
        public string rastgeleKelime;
        public int rastgele;
        public string[] harf;
        public int imageNumber = 0;
        public int can;
        
        
       

        public Form1()
        {
            MessageBox.Show("Kazandı yazısının çıkması ve oyunun tamamlanması için kelimenin tam olarak girilmesi ve kelime tahmin butonuna bir defa basılması gerekmektedir!!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            rastgele = rnd.Next(0, kelimeler.Length);
            rastgeleKelime = kelimeler[rastgele];
            rastgeleKelime = rastgeleKelime.ToUpper();
            listBox1.Items.Add(rastgeleKelime);
            harf = new string[rastgeleKelime.Length];
            can = 6;
            label1.Text = " ";
            label2.Text = can.ToString();
            for (int i = 0; i < rastgeleKelime.Length; i++)
            {
                harf[i] = "_";
                label1.Text += harf[i] + " ";
            }
            button2.Enabled = true;
            button3.Enabled = true;
            imageNumber = 0;
            pictureBox1.Image = imageList1.Images[imageNumber];
            
        }
        public string girilenKelime; 
        private void button2_Click(object sender, EventArgs e)
        {
            
            string girilenKelime = textBox1.Text.ToUpper();

            if (girilenKelime == rastgeleKelime)
            {
                for (int j = 0; j < rastgeleKelime.Length; j++)
                {
                    harf[j] = girilenKelime[j].ToString();
                }
            }            
            else
            {
                can--;
                imageNumber++;
                pictureBox1.Image = imageList1.Images[imageNumber];
                
                if(can == 0)
                {
                    MessageBox.Show("Kaybettiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = "";
                    button2.Enabled = false;
                    button3.Enabled = false;
                    imageNumber = 0;
                }
            }            
            if (rastgeleKelime == girilenKelime)
            {
                MessageBox.Show("Kazandınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = "";
                button2.Enabled = false;
                button3.Enabled = false;
                imageNumber = 0;
            }
            label2.Text = can.ToString();
            label1.Text = " ";
            for (int j = 0; j < rastgeleKelime.Length; j++)
            {
                label1.Text += harf[j] + " ";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string girilenKelime = textBox1.Text.ToUpper();
            
            bool döngü = false;
            for (int i = 0; i < rastgeleKelime.Length; i++)
            {
                if (girilenKelime[0] == rastgeleKelime[i])
                {
                    harf[i] = girilenKelime[0].ToString();
                    döngü = true;
                    
                    
                }
                
            }
            if (döngü == false)
            {
                can--;
                imageNumber++;
                pictureBox1.Image = imageList1.Images[imageNumber];
                if (can == 0)
                {
                    MessageBox.Show("Kaybettiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = "";
                    imageNumber = 0;

                }
                
            }
            ;
            label2.Text = can.ToString();
            
            
            label1.Text = " ";
            for (int j = 0; j < rastgeleKelime.Length; j++)
            {
                label1.Text += harf[j] + " ";
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[imageNumber];
            button1.BackColor = Color.Yellow;
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = new DialogResult();
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz","Uyarı!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}