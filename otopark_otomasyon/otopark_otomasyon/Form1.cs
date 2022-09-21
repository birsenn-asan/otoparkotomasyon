using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace otopark_otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Frm2 frm2 = new Frm2();
        private void button1_Click(object sender, EventArgs e)
        {

           giristxt1.Text = "admin";
           giristxt2.Text = "123456";

            if (giristxt1.Text=="admin" && giristxt2.Text=="123456")
            {
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yapdınız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PowerBy Birsen AŞAN","Bilgilendirme Mesajıdır",MessageBoxButtons.OK);
        }
    }
}
