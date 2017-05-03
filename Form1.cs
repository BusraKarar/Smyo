using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int i = 0;
        int toplamkayıt = 0;
        
        public Form1()
        {
            InitializeComponent();
            yenile();
           

        }
        private void kayıtgoster()
        {

            textBox6.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
       
        
        
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\Users\wi7\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\WindowsFormsApplication2\Database11.accdb");
                OleDbCommand kaydet = new OleDbCommand(" insert into sınıf(Alan1,Alan2,Alan3) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                
                baglan.Close();
                MessageBox.Show("eklendi");
                yenile();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }
        public void yenile()
        {
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\Users\wi7\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\WindowsFormsApplication2\Database11.accdb");
            DataTable veritablosu = new DataTable();
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From sınıf", baglanti);
            adtr.Fill(veritablosu);
            dataGridView1.DataSource = veritablosu;
            baglanti.Close();
            toplamkayıt = dataGridView1.Rows.Count;
        }

        private void Güncel_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\Users\wi7\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\WindowsFormsApplication2\Database11.accdb");
                OleDbCommand guncel=new OleDbCommand("update sınıf set Alan1='"+textBox1.Text+"',Alan2='"+textBox2.Text+"',Alan3='"+textBox3.Text+"' where Alan3='"+textBox4.Text.ToString()+"'",baglan);
                baglan.Open();
                guncel.ExecuteNonQuery();
                
                MessageBox.Show("Kayıt Güncellendi");
                baglan.Close();
                yenile();
                
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\Users\wi7\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\WindowsFormsApplication2\Database11.accdb");
                OleDbCommand delete = new OleDbCommand("delete * from sınıf where Alan3='" + textBox5.Text.ToString() + "'", baglan);
                baglan.Open();
                delete.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Silindi");
                yenile();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            kayıtgoster();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i -= 1;
                kayıtgoster();
            }

            else MessageBox.Show("ilk kayıttasınız");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (i !=toplamkayıt-2)
            {
                i += 1;
                kayıtgoster();

            }
            else MessageBox.Show("Son kayıttasınız");
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = 0;
            kayıtgoster();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            i = toplamkayıt - 2;
            kayıtgoster();
        }


    }
}
