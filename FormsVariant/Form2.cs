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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;

            dataGridView1.Rows.Clear();

            Random ran = new Random();

            try
            {
                Arrays a = new Arrays(16);

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ran.Next(-100, 101);
                    dataGridView1.Rows.Add(a[i].ToString());
                }

                label2.Text = "Sum of array elements: " + a.Sum.ToString();
            }
            catch
            {
                MessageBox.Show("Data processing error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
