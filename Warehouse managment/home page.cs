using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_managment
{
    public partial class home_page : Form
    {
        public home_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Customer obj8 = new Add_Customer();
            obj8.Show();
        }

            private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction_In obj8 = new Transaction_In();
            obj8.Show();
        }

        private void home_page_Load(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            products obj1 = new products();
            obj1.Show();

        }

        private void suppliesrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Suppliers obj5 = new Add_Suppliers();
            obj5.Show();

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Suppliers ojb6= new View_Suppliers();
            ojb6.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View_Customer ojb7= new View_Customer();
            ojb7.Show();
        }

        private void outToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction_out obj9 = new Transaction_out();
            obj9.Show();
        }

        private void newTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void salesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Salea_Manager_Details obj11= new View_Salea_Manager_Details();
            obj11.Show();
        }

        private void stockeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stocke_View obj10 = new Stocke_View();
            obj10.Show();
        }

        private void addSalesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Sales obj15=new Add_Sales();
            obj15.Show();
        }

        private void warehouseManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Warehouse_Manager_Details obj12= new View_Warehouse_Manager_Details();
            obj12.Show();
        }

        private void viewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_1 obj13= new View_1();
            obj13.Show();
        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           View_Balance obj14= new View_Balance();
            obj14.Show();
        }
    }
}
 