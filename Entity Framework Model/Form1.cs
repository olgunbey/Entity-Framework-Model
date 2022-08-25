using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            
                dataGridView1.DataSource = dbSinavOgrenciEntities.TBLOGRENCI.ToList();
            var query = from items in dbSinavOgrenciEntities.TBLOGRENCI
                        select new { items.ID, items.AD, items.SOYAD };
            dataGridView1.DataSource = query.ToList();
            
         

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            var query = from items in dbSinavOgrenciEntities.TBLNOTLAR
                        select new { items.NOTID, items.OGR, items.DERS, items.SINAV1,items.SINAV2,items.SINAV3,items.DURUM,items.ORTALAMA };
            dataGridView1.DataSource = query.ToList();
            

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            dataGridView1.DataSource = dbSinavOgrenciEntities.DERSLER.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            TBLOGRENCI tBLOGRENCI = new TBLOGRENCI();
            tBLOGRENCI.AD = textBox2.Text;
            tBLOGRENCI.SOYAD = textBox3.Text;
            dbSinavOgrenciEntities.TBLOGRENCI.Add(tBLOGRENCI);
            dbSinavOgrenciEntities.SaveChanges();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            var x = dbSinavOgrenciEntities.TBLOGRENCI.Find(id);
            dbSinavOgrenciEntities.TBLOGRENCI.Remove(x);
            dbSinavOgrenciEntities.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            var x = dbSinavOgrenciEntities.TBLOGRENCI.Find(id);
            x.AD = textBox2.Text;
            x.SOYAD = textBox3.Text;
            dbSinavOgrenciEntities.SaveChanges();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
            //    textBox1.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
             //   textBox2.Text = dataGridView1.CurrentRow.Cells["AD"].Value.ToString();
             //   textBox3.Text = dataGridView1.CurrentRow.Cells["SOYAD"].Value.ToString(); 
            }
            catch (Exception)
            {

                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            dataGridView1.DataSource = dbSinavOgrenciEntities.NOTLARIM();
            List<Object> tBLNOTLARs = dbSinavOgrenciEntities.Database.SqlQuery<Object>(@"exec [DbSinavOgrenci]..NOTLARIM").ToList();
            dataGridView1.DataSource = tBLNOTLARs;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            dataGridView1.DataSource = dbSinavOgrenciEntities.TBLOGRENCI.Where(x => x.AD == textBox2.Text).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
            string aranan = textBox2.Text;
            var query = from x in dbSinavOgrenciEntities.TBLOGRENCI
                        where x.AD.Contains(aranan)
                        select x;
            dataGridView1.DataSource = query.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[3].Visible = false;
            DbSinavOgrenciEntities dbSinavOgrenciEntities = new DbSinavOgrenciEntities();
           
            if (radioButton1.Checked==true)
            { //a dan z sıralama
                List<TBLOGRENCI> list = dbSinavOgrenciEntities.TBLOGRENCI.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = list;
               
            }
            if(radioButton2.Checked==true)
            {// zden a sıralama
                List<TBLOGRENCI> List = dbSinavOgrenciEntities.TBLOGRENCI.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = List;
            }
            if(radioButton3.Checked==true)
            {// ilk 3 veri
                List<TBLOGRENCI> list2 = dbSinavOgrenciEntities.TBLOGRENCI.Take(3).ToList();
                dataGridView1.DataSource = list2;
            }
            if(radioButton4.Checked==true)
            {
                List<TBLOGRENCI> list3 = dbSinavOgrenciEntities.TBLOGRENCI.Where(p => p.AD.StartsWith("A")).ToList();
                dataGridView1.DataSource = list3;
            }
            if(radioButton5.Checked==true)
            {
                List<TBLOGRENCI> liste4 = dbSinavOgrenciEntities.TBLOGRENCI.Where(p => p.AD.EndsWith("A")).ToList();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
