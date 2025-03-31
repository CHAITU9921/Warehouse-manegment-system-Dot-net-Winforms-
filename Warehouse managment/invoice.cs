using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
// Anything  her problem  so contact me (chaitanya kadam) 9921681787

namespace Warehouse_managment
{
    public partial class invoice : Form
    {
     
       // public string id { get; set; }

        SqlConnection cn;
        SqlCommand cmd;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";

        public invoice()  // default constructor 
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
            
            
        }
        public invoice(string val) // parameterised constructor 
        {
            try
            {
                textBox2.Text = val.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void invoice_Load(object sender, EventArgs e)
        {
            
            
           
        }

       
        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            try
            {
                cn.Open();
                string sql = "select * from transection_details_out  where InvoiceId='" + textBox2.Text + "'  ";
                cmd = new SqlCommand(sql, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                string sql1 = "select * from transectino_total_out  where InvoiceId='" + textBox2.Text + "'  ";
                cmd = new SqlCommand(sql1, cn);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("transection_details_out", dt);
                ReportDataSource source1 = new ReportDataSource("transection_total_out", dt1);
                reportViewer1.LocalReport.ReportPath = "Report3.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.LocalReport.DataSources.Add(source1);
                reportViewer1.RefreshReport();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
