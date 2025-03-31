using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_managment
{
    public partial class products : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chait\OneDrive\Documents\product.mdf;Integrated Security=True;Connect Timeout=30";
        public products()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "insert into product values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("submited");

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            cn.Open();
           string sql = "update product SET Id ='" + textBox1.Text + "', Name='"+comboBox1.SelectedItem.ToString()+"' ,Cost='" + textBox2.Text + "'where Stock='" + textBox3.Text + "'";
                cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            cn.Close();

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "delete from product where  Id ='" + textBox1.Text + "'";
            cmd = new SqlCommand(sql,cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            cn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


