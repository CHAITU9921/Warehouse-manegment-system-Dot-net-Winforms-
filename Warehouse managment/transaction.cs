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
// Anything  her problem  so contact me (Name : chaitanya kadam) 9921681787

namespace Warehouse_managment
{
    public partial class transaction : Form
    {
        
        SqlConnection cn;
        SqlCommand cmd;
        string cnstr =  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";
        public transaction()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }
        private void transaction_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            try
            {
                comboBox1.Items.Clear();
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Product_Name from Products";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Product_Name"].ToString());
                }
                cn.Close();
            }
            catch 
            {
               
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
        }
        private void button_WOC5_Click(object sender, EventArgs e)
        {
            try
            {
                 
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();

                if (textBox1.Text == ""|| textBox6.Text == ""|| textBox7.Text == ""|| textBox8.Text == ""|| textBox9.Text == ""  ||listView1.Items.Count==0)
                {
                    if (textBox1.Text == "")
                        errorProvider1.SetError(textBox1, "enter the invoice id ");

                    if (textBox6.Text == "")
                        errorProvider3.SetError(textBox6, "enter this ");

                    if (textBox7.Text == "")
                        errorProvider4.SetError(textBox7, "enter this ");

                    if (textBox8.Text == "")
                        errorProvider5.SetError(textBox8, "enter this");

                    if (textBox9.Text == "")
                        errorProvider5.SetError(textBox9, "enter this");
                    if (listView1.Items.Count == 0)
                        errorProvider2.SetError(listView1, "add the Items ");
                }
                else
                {

                    if (listView1.Items.Count > 0)
                    {

                        if (radioButton4.Checked == true)
                        {
                            //transectin out details save to database 

                            SqlCommand cmd = cn.CreateCommand();
                            cn.Open();

                            cmd.CommandText = "Insert into transectino_total_in values ('" + textBox1.Text + "','" + textBox5.Text + "' ,'" + textBox6.Text + "' , '" + textBox7.Text + "' ,'" + textBox8.Text + "' ,'" + textBox9.Text + "')";
                            cmd.ExecuteNonQuery();

                            foreach (ListViewItem ListItem in listView1.Items)
                            {

                                cmd.CommandText = "Insert into transection_details_in values('" + textBox1.Text + "', '" + ListItem.SubItems[0].Text + "', '" + ListItem.SubItems[1].Text + "', '" + ListItem.SubItems[2].Text + "', '" + ListItem.SubItems[3].Text + "', '" + ListItem.SubItems[4].Text + "', '" + ListItem.SubItems[5].Text + "')";

                                cmd.ExecuteNonQuery();

                            }
                            cn.Close();
                            MessageBox.Show(" added succesfully...! ");


                        }
                        if (radioButton1.Checked == true)
                        {
                            // transection in details listview to datatabel 

                            SqlCommand cmd = cn.CreateCommand();
                            cn.Open();

                            cmd.CommandText = "Insert into transectino_total_out values ('" + textBox1.Text + "','" + textBox5.Text + "' ,'" + textBox6.Text + "' , '" + textBox7.Text + "' ,'" + textBox8.Text + "' ,'" + textBox9.Text + "')";
                            cmd.ExecuteNonQuery();

                            foreach (ListViewItem ListItem in listView1.Items)
                            {

                                cmd.CommandText = "Insert into transection_details_out values('" + textBox1.Text + "','" + ListItem.SubItems[0].Text + "', '" + ListItem.SubItems[1].Text + "', '" + ListItem.SubItems[2].Text + "', '" + ListItem.SubItems[3].Text + "', '" + ListItem.SubItems[4].Text + "', '" + ListItem.SubItems[5].Text + "')";

                                cmd.ExecuteNonQuery();

                            }
                            cn.Close();
                            MessageBox.Show(" added succesfully...! ");

                        }

                    }


                    // message show  transection Id  after succesfully 
                  string a = textBox1.Text;
                  MessageBox.Show("YOUR TRANSECTION IS SUCCESFULLY.....! \n INVICE-ID :" + a);


                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    errorProvider5.Clear();

                }
            }
            catch  
            {
               
            }

            // pass the value in textbox in invoice page 

            invoice invoice = new invoice(textBox1.Text);
            invoice.Show();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text)).ToString();
            }
            catch 
            {
              
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label5_Click_1(object sender, EventArgs e)
        {
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = textBox7.Text = (Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox6.Text)).ToString();
            }
            catch
            {

            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



 
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            if (comboBox1.Text =="" ||textBox2.Text == "" || textBox3.Text == "" )
            {
                if(textBox2.Text == "")
                errorProvider1.SetError(textBox2, "enter the  Amount");

                if (textBox3.Text == "")
                    errorProvider2.SetError(textBox3, "Enter the  Unit");


                if (comboBox1.SelectedItem == null)
                    errorProvider3.SetError(comboBox1, " Select The Product ");

                if (comboBox2.SelectedItem == null)
                    errorProvider4.SetError(comboBox1, "Select The name ");

            }
            else
            {
                try
                {
                    // stack in not availabel 
                    cn.Open();
                    string str = "select  Stock from Products where Product_Name='" + comboBox1.SelectedItem.ToString() + "'  ";

                    SqlCommand cmd = new SqlCommand(str, cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        string val = dr[0].ToString();
                        cn.Close();

                        if (Convert.ToInt32(val) > Convert.ToInt32(this.textBox3.Text))     // stack in not availabel
                        {



                            

                            try
                            {
                                cn.Open();
                                string str1 = "select  Stock from Products where Product_Name='" + comboBox1.SelectedItem.ToString() + "'  ";

                                SqlCommand cmd1 = new SqlCommand(str1, cn);
                                SqlDataReader dr1 = cmd1.ExecuteReader();

                                if (dr1.Read())
                                {

                                    string val1 = dr1[0].ToString();
                                    cn.Close();
                                    if (radioButton1.Checked == true)
                                    {


                                        // add data in listbox
                                        string[] arr = new string[6];
                                        arr[0] = comboBox2.SelectedItem.ToString();
                                        arr[1] = comboBox1.SelectedItem.ToString();
                                        arr[2] = textBox2.Text;
                                        arr[3] = textBox3.Text;
                                        arr[4] = textBox4.Text;
                                        arr[5] = dateTimePicker1.Value.ToString();

                                        ListViewItem item = new ListViewItem(arr);
                                        listView1.Items.Add(item);

                                        //total amount

                                        textBox9.Text = textBox7.Text = textBox5.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox4.Text)).ToString();

                                        textBox4.Clear();


                                        // after transection product stack  updated  
                                        int a = Convert.ToInt32(val1) - Convert.ToInt32(this.textBox3.Text);
                                        textBox4.Text = a.ToString();
                                        cn.Open();
                                        string sql = " update  Products SET   Stock='" + textBox4.Text + "' where   Product_Name='" + comboBox1.SelectedItem.ToString() + "' ";
                                        cmd = new SqlCommand(sql, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }

                                    if (radioButton4.Checked == true)
                                    {



                                        // add data in listbox
                                        string[] arr = new string[6];
                                        arr[0] = comboBox2.SelectedItem.ToString();
                                        arr[1] = comboBox1.SelectedItem.ToString();
                                        arr[2] = textBox2.Text;
                                        arr[3] = textBox3.Text;
                                        arr[4] = textBox4.Text;
                                        arr[5] = dateTimePicker1.Value.ToString();

                                        ListViewItem item = new ListViewItem(arr);
                                        listView1.Items.Add(item);

                                        //total amount

                                        textBox9.Text = textBox7.Text = textBox5.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox4.Text)).ToString();

                                        textBox4.Clear();


                                        // after transection product stack  updated  
                                        int a = Convert.ToInt32(val1) + Convert.ToInt32(this.textBox3.Text);
                                        textBox4.Text = a.ToString();
                                        cn.Open();
                                        string sql = " update  Products SET   Stock='" + textBox4.Text + "' where   Product_Name='" + comboBox1.SelectedItem.ToString() + "' ";
                                        cmd = new SqlCommand(sql, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                }
                            }
                            catch
                            {

                            }


                            comboBox2.Enabled = false;
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();

                            errorProvider1.Clear();
                            errorProvider2.Clear();
                            errorProvider3.Clear();
                            errorProvider4.Clear();

                        }
                        else
                        {
                            MessageBox.Show("please select the product amount less than : " + val);
                        } 
                    }
                }
                catch
                {

                }
            }
            cn.Close();
        }

      
      
        private void button_WOC3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("please Select the Listbox Item.....!");

            }
            else
            {
                 
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                            textBox9.Text = textBox7.Text = textBox5.Text = (Convert.ToInt32(textBox5.Text) - Convert.ToInt32(listView1.Items[i].SubItems[4].Text)).ToString();
                            listView1.Items[i].Remove();
                        MessageBox.Show(" Removed ......!");
                    }
                }
            }
            
        }
     
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
           
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.Text = " ";
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.Enabled = true;
             
            panel4.Enabled = true;

            radioButton1.ForeColor = Color.Red;
            radioButton4.ForeColor = Color.Green;
            

            if (radioButton4.Checked==true)
            {
                comboBox2.Items.Clear();
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Name from Supplier";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["Name"].ToString());
                }
                cn.Close();
            }
          
             
            textBox5.Text = "0";
            textBox7.Text = "0";
            textBox9.Text = "0";

            try
            {
                cn.Open();
                string str1 = "select max(InvoiceId) from transectino_total_in";

                SqlCommand cmd = new SqlCommand(str1, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        textBox1.Text = "1";
                    }
                    else
                    {
                        int a;
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        textBox1.Text = a.ToString();
                    }
                }
                cn.Close();
            }
            catch 
            {
               
            }

        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox2.Text = " ";
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
             
            comboBox2.Enabled = true;
             panel4.Enabled = true;
            radioButton1.ForeColor = Color.Green;
            radioButton4.ForeColor = Color.Red;
            
            //add cutomer name in in combobox 
            if ( radioButton1.Checked==true)
            {
                comboBox2.Items.Clear();
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Name from Customer";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["Name"].ToString());
                }
                cn.Close();
            }
             
            textBox5.Text = "0";
            textBox7.Text = "0";
            textBox9.Text = "0";

            // anuto generated invoice id 
            textBox1.Enabled = false;

            try
            {
                cn.Open();
                string str1 = "select max(InvoiceId) from transectino_total_out";

                SqlCommand cmd = new SqlCommand(str1, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        textBox1.Text = "1";
                    }
                    else
                    {
                        int a;
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        textBox1.Text = a.ToString();
                    }
                }
                cn.Close();
            }
            catch 
            {
              
            }
        }

     
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text =(Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox8.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Products where Product_Name='"+comboBox1.SelectedItem.ToString()+"' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text= dr["Amount"].ToString();
                }
                cn.Close();
            }
            catch  
            {
               
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
 
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
 
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
                textBox9.Text = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox8.Text)).ToString();

            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 textBox9.Text = textBox7.Text = (Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox6.Text)).ToString();

            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = textBox7.Text = (Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox6.Text)).ToString();
            }
            catch 
            {
               
            }
        }
    }
}
