
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
    public partial class Form1 : Form
    {
       
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;
        public Form1()
        {
            InitializeComponent();
            
            frm3 = new Form3();
            frm4 = new Form4();
            frm5 = new Form5();
            frm6 = new Form6();
           
            frm3.frm1 = this;
            frm4.frm1 = this;
            frm5.frm1 = this;
            frm6.frm1 = this;
            
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        public void listele()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From mal_kayıt", bag);
            adtr.Fill(dtst, "mal_kayıt");
            frm3.dataGridView1.DataSource = dtst.Tables["mal_kayıt"];
            adtr.Dispose();
            bag.Close();
        }
        
        public void listele2()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From gelirler", bag);
            adtr.Fill(dtst, "gelirler");
            frm4.dataGridView1.DataSource = dtst.Tables["gelirler"];
            adtr.Dispose();
            bag.Close();
        }
        public void listele3()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From giderler", bag);
            adtr.Fill(dtst, "giderler");
            frm5.dataGridView1.DataSource = dtst.Tables["giderler"];
            adtr.Dispose();
            bag.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text =label2.Text.Substring (1) + label2.Text.Substring(0, 1);

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm6.Show();
            this.Hide();
        }
    }
}
