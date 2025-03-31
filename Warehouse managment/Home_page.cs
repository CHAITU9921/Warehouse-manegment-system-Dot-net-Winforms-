using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Anything  her problem  so contact me (chaitanya kadam) 9921681787

namespace Warehouse_managment
{
    public partial class Home_page : Form
    {
        
        public Home_page()
        {
           
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }
        private void product_Load(object sender, EventArgs e)
        {  
        }
        private void pRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product obj = new product();
            obj.Show();

        }

        private void cUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers_page obj2=new Customers_page();
            obj2.Show();
            
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplirs obj3=new Supplirs();
            obj3.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
 

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View obj5=new View();
            obj5.Show();
            
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report obj6=new Report();
            obj6.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            manager obj=new manager();  
            obj.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("do yo want logout  ! ", "Alart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Login_page login_Page = new Login_page();
                this.Enabled = false;
                login_Page.Show();
            }
        }

        private void transactionINOROUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaction obj=new transaction();
            obj.Show();
        }

        private void transactionInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invoice obj = new invoice();
            obj.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("do yo want logout  ! ", "Alart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            { 
                Login_page login_Page = new Login_page();
                this.Enabled = false;
                login_Page.Show();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //invoice obj = new invoice("");
            //obj.Show();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report obj6 = new Report();
            obj6.Show();
        }
    }
}