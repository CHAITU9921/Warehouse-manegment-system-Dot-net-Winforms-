using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;    // every connection time add this namespace 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
// Anything  her problem  so contact me (chaitanya kadam) 9921681787



namespace Warehouse_managment
{
    public partial class Customers_page : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        // connectin string  path to server explorer  and then mdf file properties 
        string cnstr =  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";
        public Customers_page()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }
        public void show()
        {

            // product show datagradeview  new create show fucntion 
            cn.Open();
            string sql = "select * from Customer";
            cmd = new SqlCommand(sql, cn);
            DataTable dt = new DataTable();
            adap = new SqlDataAdapter(sql, cn);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        public void error()  //check textbox empty or not   and then show validations 
        {
           

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
          
            
            if (textBox1.Text == "")
            {
                errorProvider2.SetError(textBox1, "plezzz enter the Customer ID");
            }
          
            if (textBox2.Text == "")
            {
                errorProvider3.SetError(textBox2, "plezzz enter the Name");
            }
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "plezzz enter the Email ID");
            }
            if (textBox4.Text == "")
            {
                errorProvider4.SetError(textBox4, "plezzz enter the Mobile No");
            }
            if (textBox5.Text == "")
            {
                errorProvider5.SetError(textBox5, "plezzz enter the Contact NO");
            }
            if (textBox6.Text == "")
            {
                errorProvider6.SetError(textBox6, "plezzz enter the Address");
            }
            
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            
            error();  // validatins  for the textbox  empty or not 
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                try
                {
                    //  Add customer  insert
                    cn.Open();
                    string sql = " insert into Customer values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "') ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("added succesfully...");
                    show();  // show all data in datagraid view  after insert 

                    //convert textbox value and Id  increment 

                    int a = Convert.ToInt32(textBox1.Text);
                    a++;
                    string ck = a.ToString();
                    textBox1.Text = ck;
                    
                    // clear textbox and  error providers 
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    errorProvider5.Clear();
                    errorProvider6.Clear();

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            error();  // validatins  for the textbox  empty or not 

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                try
                {
                    // update Customer
                    cn.Open();
                    string sql = " update  Customer SET  Name='" + textBox2.Text + "',Email='" + textBox3.Text + "',Mobile='" + textBox4.Text + "',Contact='" + textBox5.Text + "',Address='" + textBox6.Text + "' where   Id='" + textBox1.Text + "' ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("updated succesfully ..."); 
                    show();    // show all data in datagraid view  after  Update


                    // clear textbox and error providers 
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    errorProvider5.Clear();
                    errorProvider6.Clear();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            // Customer delete
            errorProvider2.Clear();
            // validations for textbox empty or not 
            if (textBox1.Text == "")
            {
                errorProvider2.SetError(textBox1, "plezzz enter the Customer ID");
            }
            else
            {
                // message box show and then opetions for yes or not  
                DialogResult result = MessageBox.Show("do yo want delete this ! ", "Alart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)          // message box result yes then delete the record 
                {
                    try
                    {
                        // Customer   delete
                        cn.Open();
                        string sql = " delete from Customer where Id='" + textBox1.Text + "' ";
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show(" deleted Succesfully  !");
                        show();    // show all data in datagraid view  after delete 
                        
                        // clear textbox or error provieders
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        errorProvider2.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void Customers_page_Load(object sender, EventArgs e)
        {
              textBox1.Enabled = false;
              show(); // page open time show all data in data graidview 

            // auto generated id
            cn.Open();
            string str1 = "select max(id) from Customer;";
            SqlCommand cmd = new SqlCommand(str1, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")  // no record found in table so value is 1 
                {
                    textBox1.Text = "1";
                }
                else
                {
                    // record is availabel so store in variable  and then incriment for 1 valuen and then show in textbox 
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
            }
            cn.Close();
        }
 
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }
 
        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // datagrade view select the row after fill data textbox show
            // datagrade row double click then record fill in textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Id"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                textBox4.Text = row.Cells["Mobile"].Value.ToString();
                textBox5.Text = row.Cells["contact"].Value.ToString();
                textBox6.Text = row.Cells["Address"].Value.ToString();

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;  // only numeric key press  and length 10 only  specal for mobile number 
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;   // only numeric key press  and length 10 only  specal for mobile number
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;    // only numeric key press  
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            //export to excel in datagradeview   all copy for google code  
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
            if(e.KeyCode == Keys.Enter) // after " ENTER " key press so focus on next textbox
            {
                textBox2.Focus();       
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // after " ENTER " key press so focus on next textbox
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // after " ENTER " key press so focus on next textbox
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    // after " ENTER " key press so focus on next textbox
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    // after " ENTER " key press so focus on next textbox
            {
                 button_WOC1.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
 
        }
        private void textBox3_Validating(object sender, CancelEventArgs e)

        {


            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (textBox3.Text.Length > 0 && textBox3.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(textBox3.Text.Trim()))
                {
                    MessageBox.Show("check email id");
                    textBox3.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // search textbox  using like and % operater  show data in graidview  
            try
            {
                cn.Open();
                string sql = " select * from  Customer where  Name like'" + textBox7.Text + "%'";
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

        private void button_WOC7_Click(object sender, EventArgs e)
        {
            show();   //show all the data or refresh button use 
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //  validatino for email textbos 
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(Regex.IsMatch(textBox3.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.textBox3, "please Enter valid email");
                return;
            }
        }
    }
}
