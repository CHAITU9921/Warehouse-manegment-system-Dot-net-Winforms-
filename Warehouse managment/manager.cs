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
// Anything  her problem  so contact me (chaitanya kadam) 9921681787

namespace Warehouse_managment
{
    public partial class manager : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\Final Year Projects\Warehouse managment\Warehouse managment\Products.mdf;Integrated Security=True;Connect Timeout=30";
        public manager()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }

        private void manager_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {

             errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, "Please enter the Name");

            if (textBox2.Text == "")
                errorProvider2.SetError(textBox2, "Please enter the Contact");

            if (textBox3.Text == "")
                errorProvider3.SetError(textBox3, "Please enter the Id");

            if (textBox4.Text == "")
                errorProvider4.SetError(textBox4, "Please enter the Password ");

            if(textBox1.Text !=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                try
                {

                    cn.Open();
                    string sql = " update  Manager SET Contact_No='" + textBox2.Text + "',Id='" + textBox3.Text + "',Password='" + textBox4.Text + "' where  Name='" + textBox1.Text + "' ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("updated succesfully.....");
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
