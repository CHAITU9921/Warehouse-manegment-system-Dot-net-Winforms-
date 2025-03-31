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
    public partial class View_Suppliers : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chait\OneDrive\Documents\product.mdf;Integrated Security=True;Connect Timeout=30";
        public View_Suppliers()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "update suppliers SET where Name='"+textBox1.Text+"'";
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            cn.Close();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select * from suppliers where Name='"+textBox1.Text+"'";
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adap = new SqlDataAdapter(sql, cn);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("searching");
            cn.Close();

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "delete from suppliers where Name='" + textBox1.Text + "'";
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            cn.Close();

        }
    }
}
