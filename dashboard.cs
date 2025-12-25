using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group3_Test2
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            server form2 = new server();
            form2.Show();
            
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
