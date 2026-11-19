using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Form №1
        {

        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e) // Form №2
        {
            new Form2().Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e) // Form №3
        {
            new Form3().Show();
        }

        private void formsToolStripMenuItem_Click(object sender, EventArgs e) // MenuStrip (Forms)
        {

        }
    }
}
