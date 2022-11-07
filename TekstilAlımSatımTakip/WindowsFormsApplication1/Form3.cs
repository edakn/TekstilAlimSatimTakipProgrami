using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form1 frm1;
        public Form3()
        {
            InitializeComponent();
        }
       

        private void Form3_Load(object sender, EventArgs e)
        {
            frm1.listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double top, kdv, metre, fiyat, toplam_tutar;
            top = double.Parse(textBox2.Text);
            kdv = double.Parse(textBox5.Text);
            metre = double.Parse(textBox3.Text);
            fiyat=double.Parse(textBox4.Text);
            toplam_tutar = ((metre * fiyat) * top) + ((metre * fiyat) * top)*(kdv / 100);
            textBox6.Text = toplam_tutar.ToString();

            frm1.bag.Open();
            frm1.kmt.Connection = frm1.bag;
            frm1.kmt.CommandText = "INSERT INTO mal_kayıt(kumaş_turu,top_say,metre,fiyat,kdv,sonuc) VALUES ('" +comboBox1.Text + "','" + textBox2.Text + "','" +textBox3.Text + "','" +  textBox4.Text + "','" +textBox5.Text + "','" + textBox6.Text + "') ";
            frm1.kmt.ExecuteNonQuery();
            frm1.kmt.Dispose();
            frm1.bag.Close();
            frm1.dtst.Clear();
            frm1.listele();
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * From mal_kayıt", frm1.bag);
                if (textBox1.Text == "")
                {
                    frm1.kmt.Connection = frm1.bag;
                    frm1.kmt.CommandText = "Select * from mal_kayıt";
                    adtr.SelectCommand = frm1.kmt;
                    adtr.Fill(frm1.dtst, "mal_kayıt");
                }
                if (Convert.ToBoolean(frm1.bag.State) == false)
                {
                    frm1.bag.Open();
                }
                adtr.SelectCommand.CommandText = " Select * From mal_kayıt" +
                     " where(kumas_turu like '%" + textBox1.Text + "%' )";
                frm1.dtst.Tables["mal_kayıt"].Clear();
                adtr.Fill(frm1.dtst, "mal_kayıt");
                frm1.bag.Close();
                
            
        }

    }
}
