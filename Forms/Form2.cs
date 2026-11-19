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
                n = Convert.ToInt32(textBox1.Text);

                if (n <= 0)
                {
                    MessageBox.Show("The number of elements must be greater than 0");
                    return;
                }

                Arrays a = new Arrays(n);

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ran.Next(-100, 100);
                    dataGridView1.Rows.Add(a[i].ToString());
                }

                if (a.error)
                    MessageBox.Show("Data processing error");

                label2.Text = "Minimum array element: " + a.Min.ToString();
            }
            catch
            {
                MessageBox.Show("Data entry error");
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
