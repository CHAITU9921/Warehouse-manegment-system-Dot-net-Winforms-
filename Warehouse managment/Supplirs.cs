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
using System.Text.RegularExpressions;



namespace Warehouse_managment
{
    public partial class Supplirs : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        string cnstr  = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";

        public Supplirs()
        {
            cn = new SqlConnection(cnstr);

            InitializeComponent();
        }


        public void show()
        {
            // product show datagradeview  new create show fucntion 
            cn.Open();
            string sql = "select * from Supplier";
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
            errorProvider5.Clear();
            errorProvider6.Clear();


            if (textBox1.Text == "")
            {
                errorProvider2.SetError(textBox1, "plezzz enter the Supplirs ID");
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
        private void SUPPLIERS_Load(object sender, EventArgs e)
        {
             textBox1.Enabled = false;
            show();

            // auto generated id
            cn.Open();
            string str1 = "select max(Id) from Supplier";

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            //  supplir submit 
            error();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                try
                {
                    // Supplirs  submit
                    cn.Open();
                    string sql = " insert into Supplier values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "') ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("added succesfully...");

                    //convert textbox value and sr_no  increment 

                    int a = Convert.ToInt32(textBox1.Text);
                    a++;
                    string r = a.ToString();
                    textBox1.Text = r;


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

                    show();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
           
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            // update supplier


            error();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                try
                {
                    cn.Open();
                    string sql = " update  Supplier SET Name='" + textBox2.Text + "',Email='" + textBox3.Text + "',Mobile='" + textBox4.Text + "',Contact='" + textBox5.Text + "',Address='" + textBox6.Text + "' where  Id='" + textBox1.Text + "' ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("updated succesfully.....");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textBox1.Clear();
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
                show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            // Supplier delete
            errorProvider2.Clear();
            if (textBox1.Text == "")
            {
                errorProvider2.SetError(textBox1, "plezzz enter the Customer ID");
            }
            else
            {
                DialogResult result = MessageBox.Show("do yo want delete this ! ", "Alart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Supplier   delete
                        cn.Open();
                        string sql = " delete from Supplier where Id='" + textBox1.Text + "' ";
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show(" deleted Succesfully  !");
                        show();
                        textBox1.Clear();
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

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                 
                    cn.Open();

                    string sql = " SELECT* FROM Supplier WHERE Name LIKE '" + textBox7.Text + "%' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                    cn.Close();
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC4_Click_1(object sender, EventArgs e)
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
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_WOC1.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox3.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(textBox3, "please provide valid email");
                return;
            }
        }
    }
}
