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
    public partial class View : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";

        public View()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }
        public void show()
        {
            // show the product data in datagraid view 
            try
            {
                cn.Open();
                string sql = " select * from  Products ";
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
        private void View_Load(object sender, EventArgs e)
        {
            panel2.Enabled= false;
            show();
            // product table data  ,  add to combobox  in product name 
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {


            // Product Search after select the product name 
            errorProvider1.Clear();
            if (comboBox1.Text =="")
            {

                errorProvider1.SetError(comboBox1, "please select the Product name  !");
            }
            else
            {
                try
                {
                    cn.Open();
                    string sql = " select * from  Products where Product_Name like'" + comboBox1.SelectedItem.ToString() + "%'";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                    cn.Close();
                    errorProvider1.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                panel2.Enabled = false;
            }
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
       
         
        private void button_WOC5_Click(object sender, EventArgs e)
        {
            // update Product details 

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
           
            if (textBox2.Text == "")
                errorProvider1.SetError(textBox2, "Product name is missing  !");
               
            
            if (textBox3.Text == "")
                errorProvider2.SetError(textBox3, "Stock is missing  !");


            if (textBox4.Text =="")
            errorProvider3.SetError(textBox4, "Amount is missing ! ");


            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {

                try
                {
                    cn.Open();
                    string sql = " update  Products SET   Stock='" + textBox3.Text + "',Amount='" + textBox4.Text + "' where   Product_Name='" + textBox2.Text + "' ";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated succesfully ...");
                    cn.Close();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    panel2.Enabled = false;
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // after update textboxes are clear 
               

                
               
            }
        }   

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            if (e.RowIndex >= 0)
            {
                panel2.Enabled = true;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                
                textBox2.Text = row.Cells["Product_Name"].Value.ToString();
                textBox3.Text = row.Cells["Stock"].Value.ToString();
                textBox4.Text = row.Cells["Amount"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
