using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form1 frm1;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm1.bag.Open();
            frm1.kmt.Connection = frm1.bag;
            frm1.kmt.CommandText = "INSERT INTO gelirler(satılan_mal,fiyat) VALUES ('" + textBox1.Text+ "','" + textBox2.Text + "') ";
            frm1.kmt.ExecuteNonQuery();
            frm1.kmt.Dispose();
            frm1.bag.Close();
            frm1.dtst.Clear();
            frm1.listele2();
            MessageBox.Show("Kayıt İşlemi Tamamlandı");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            frm1.listele2();
        }
    }
}
