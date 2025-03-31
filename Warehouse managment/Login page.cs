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
// username 33 and  password CK
namespace Warehouse_managment
{
    public partial class Login_page : Form
    {
        string a, b;
        SqlConnection cn;
        SqlCommand cmd;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\Final Year Projects\Warehouse managment\Warehouse managment\Products.mdf;Integrated Security=True;Connect Timeout=30";

        public Login_page()
        {
            InitializeComponent();
            cn = new SqlConnection(cnstr);

        }

        private void Login_page_Load(object sender, EventArgs e)
        {
            
                textBox1.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cn.Open();
            string str1 = "select * from Manager";

            SqlCommand cmd = new SqlCommand(str1, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 a = dr[2].ToString();
                 b = dr[3].ToString();

            }
            cn.Close();
             
            string c = Convert.ToString(textBox1.Text);
             string d = Convert.ToString(textBox2.Text);

             if (textBox1.Text == "" || textBox2.Text == "")
             {


                 MessageBox.Show("please enter the username and password..");

             }

             else
             {
                if (c == a && d == b)
                 {
                    this.Hide();
                    Home_page obj = new Home_page();

                    obj.Show();
                    MessageBox.Show("Welocme home page...");
                }
                else if(c == "AdminChaitu" && d == "Master")
                {

                }
                else
                {
                    label1.Text = " invalid username or password";
                }
             }
            
           
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

            if (textBox2.PasswordChar == '\0')
            {
                button4.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox2.PasswordChar == '\0')
            {
                button4.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox2.PasswordChar == '*')
            {
                button3.BringToFront();
                textBox2.PasswordChar = '\0';

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "";

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }       
}
    