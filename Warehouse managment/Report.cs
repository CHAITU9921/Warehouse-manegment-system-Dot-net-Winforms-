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
using Microsoft.Reporting.WinForms;

// Anything  her problem  so contact me (chaitanya kadam) 9921681787

namespace Warehouse_managment
{
    public partial class Report : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=B:\FINAL YEAR PROJECTS\WAREHOUSE MANAGMENT\DATABASE FILE\PRODUCTS.MDF;Integrated Security=True;Connect Timeout=30";

        public Report()
        {
            cn = new SqlConnection(cnstr);
            InitializeComponent();
        }   
        private void Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            try
            {
                cn.Open();
                string sql = "select * from transection_details_in  where date between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' ";
                cmd = new SqlCommand(sql, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                string sql1 = "select * from transection_details_out  where date between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' ";
                cmd = new SqlCommand(sql1, cn);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("transection_details_in", dt);
                ReportDataSource source1 = new ReportDataSource("transection_details_out", dt1);
                reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
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
        private void label2_Click(object sender, EventArgs e)
        {

        }
       private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click_1(object sender, EventArgs e)
        {

        }  
    }
}
