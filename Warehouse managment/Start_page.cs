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
    public partial class Start_page : Form
    {
        public Start_page()
        {
            InitializeComponent();

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void Start_page_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            timer1.Start();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar1.Value = startpoint;
            label5.Text=progressBar1.Value.ToString()+" %";
            if (startpoint == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Login_page obj1 = new Login_page();
                this.Hide();
                obj1.Show();
                


            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
