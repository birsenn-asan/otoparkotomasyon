using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace otopark_otomasyon
{
    public partial class Frm2 : Form
    {
        public Frm2()
        {
            InitializeComponent();
        }
       
        DateTime deger;
        OleDbConnection con;
        OleDbDataAdapter adap;
        OleDbCommand cmd;
        DataSet dset;

        void griddoldur()
    {
        con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otopark.accdb");
        adap = new OleDbDataAdapter("select * from otomasyon",con);
        dset = new DataSet();
        con.Open();
        adap.Fill(dset,"otomasyon");
        dataGridView1.DataSource = dset.Tables["otomasyon"];
        con.Close();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.RowHeadersVisible = false;
        }
        
        
        
        private void Frm2_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void btnekle_Click(object sender, EventArgs e)//araç giriş bilgileri ekleme
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

         
        }

       


        

        private void textBox1_TextChanged(object sender, EventArgs e)

        {
           

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otopark.accdb");
            con.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM otomasyon WHERE plaka LIKE'%" + textBox1.Text + "%'", con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            button1.Enabled = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DateTime zaman = DateTime.Now;
         int tutar = deger.Hour-zaman.Hour;
         tutar = Math.Abs(tutar);
         int fiyat = tutar*5;

         cmd = new OleDbCommand();
         con.Open();
         cmd.Connection = con;
        
         cmd.CommandText = "UPDATE otomasyon SET ucret='" + fiyat.ToString() + "',cikis_saati='" + zaman.ToString() +"' WHERE plaka='"+ textBox1.Text + "'";
         //textBoxa girilecek karakter sayısını 10 ile sınırladık

         cmd.ExecuteNonQuery();
         cmd.Dispose();
         con.Close();
         griddoldur();
           
           MessageBox.Show(tutar.ToString()+" saat kalmişdir","Bilgilendirme");
           label8.Text = fiyat.ToString()+"TL tutmuşdur "+tutar.ToString()+" saat kalmıştır";


        } 

        

       

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
           bsaat.Text = zaman.ToShortTimeString();
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into otomasyon (adi_soyadi,plaka,telno,giris_saati,cikis_saati) values ('" + adtxt.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + bsaat.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            deger =DateTime.Parse((dataGridView1.CurrentRow.Cells["giris_saati"].Value).ToString());
           textBox1.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

      
        }

       





}

 