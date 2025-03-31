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
using Excel = Microsoft.Office.Interop.Excel;
// Anything  her problem  so contact me (chaitanya kadam) 9921681787


namespace Warehouse_managment
{
    public partial class product : Form
    {
        int a;
        string b;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";
        public product()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }

       

        private void label5_Click(object sender, EventArgs e)
        { 

        }

        private void product_Load(object sender, EventArgs e)
        {
            textBox1.Enabled=false;
            show();

            // auto generated id
            cn.Open();
            string str1 = "select max(Product_Id) from Products";

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
       
        public void show()
        {
            // product show datagradeview  new create show fucntion 
            cn.Open();
            string sql = "select * from Products";
            cmd = new SqlCommand(sql, cn);
            DataTable dt = new DataTable();
            adap = new SqlDataAdapter(sql, cn);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        public void error()
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
          


            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "plezzz enter the Supplirs ID");
            }

            if (comboBox1.Text == "")
            {
                errorProvider2.SetError(comboBox1, "plezzz enter the Name");
            }
            if (textBox2.Text == "")
            {
                errorProvider3.SetError(textBox2, "plezzz enter the Email ID");
            }
            if (textBox3.Text == "")
            {
                errorProvider4.SetError(textBox3, "plezzz enter the Mobile No");
            }
            

        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {

            

            // product name availabel  so update product 
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("select the  product fist ! ");
                }
                else
                {
                    cn.Open();
                    string str1 = "select Product_Name,Product_Id  from Products where Product_Name='" + comboBox1.SelectedItem.ToString() + "' ";

                    SqlCommand cmd = new SqlCommand(str1, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string val = dr[0].ToString();

                        b = dr[1].ToString();
                        if (val == comboBox1.SelectedItem.ToString())
                        {
                            // a is  globel veriable
                            a = 1;
                        }
                        else
                        {
                            a = 0;
                        }
                    }
                    cn.Close();
                }
            }
            catch
            {

            }

            error();
            // add new  insert

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {

                try
                {
                    if(a==1)
                    {
                      //  textBox1.Text = ;
                        cn.Open();
                        string sql = " update  Products SET  Product_Id='" + textBox1.Text + "',Amount='" + textBox2.Text + "',Stock='" + textBox3.Text + "'  where Product_Name='" + comboBox1.SelectedItem.ToString() + "' ";
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("updated succesfully.....");
                    }

                    if (a == 0)
                    {           
                        //add new  insert
                        cn.Open();
                        string sql = " insert into Products values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "') ";
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        //cn.Close();
                        MessageBox.Show("added succesfully...");
              
                    
                    }



                    //convert textbox value and sr_no  increment 

                    int b = Convert.ToInt32(textBox1.Text);
                    b++;
                    string ck = b.ToString();
                    textBox1.Text = ck;
                  
                    show();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    comboBox1.Text = "";
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //product search in gridview

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            // product delete
            if (  textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "please enter the id");
            }
            else
            {
                DialogResult result = MessageBox.Show("do yo want delete this ! ", "Alart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Product   delete
                        cn.Open();
                        string sql = " delete from Products where Product_Id='" +  textBox1.Text + "' ";
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close(); 
                        MessageBox.Show(" deleted Succesfully  !");
                        show();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        errorProvider1.Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                 
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            show(); 
        }

        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Product_Id"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["Product_Name"].Value.ToString();
                textBox2.Text = row.Cells["Amount"].Value.ToString();
                textBox3.Text = row.Cells["Stock"].Value.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch=e.KeyChar;
            if(!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            // Product Search after select the product name 

            try
            {


                cn.Open();
                string sql = " select * from  Products where Product_Name like'" + textBox4.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                cn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void button_WOC2_Click_1(object sender, EventArgs e)
        {
            //export to excel in datagradeview 
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
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
               button_WOC1.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC4_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "please enter the product Name");
            }
            else
            {
                comboBox1.Items.Add(textBox5.Text);
                MessageBox.Show("Added succesfully");
                textBox5.Clear();
                errorProvider1.Clear();
            }
            
        }
    }
}