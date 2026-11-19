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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // Maximum value: (TextBox)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e) // Number of workshops:
        {

        }

        private void label2_Click(object sender, EventArgs e) // Number of plots:
        {

        }

        private void label3_Click(object sender, EventArgs e) // Minimum value:
        {

        }

        private void label4_Click(object sender, EventArgs e) // Maximum value:
        {

        }

        private void label5_Click(object sender, EventArgs e) // Workshop with minimal resources:
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Number of workshops: (TextBox)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Number of plots: (TextBox)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // Minimum value: (TextBox)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Calculate
        {
            try
            {
                // Read input values
                int n = Convert.ToInt32(textBox1.Text);
                int m = Convert.ToInt32(textBox2.Text);
                int minValue = Convert.ToInt32(textBox3.Text);
                int maxValue = Convert.ToInt32(textBox4.Text);

                // Validate input values
                if (n <= 0 || m <= 0)
                    throw new ArgumentException(
                        "The number of workshops and plots must be greater than zero.");

                if (minValue < 0 || maxValue > 1000 || minValue > maxValue)
                    throw new ArgumentException(
                        "Enter a valid range from 0 to 1000.");

                // Create two-dimensional array
                TwoArray a = new TwoArray(n, m, minValue, maxValue);

                Random ran = new Random();

                // Clear DataGridView
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Create workshop column
                DataGridViewTextBoxColumn column =
                    new DataGridViewTextBoxColumn();

                column.HeaderText = "Workshop";
                column.Width = 80;

                dataGridView1.Columns.Add(column);

                // Dynamically create plot columns
                for (int j = 0; j < m; j++)
                {
                    column = new DataGridViewTextBoxColumn();
                    column.HeaderText = "Plot " + (j + 1);
                    column.Width = 80;

                    dataGridView1.Columns.Add(column);
                }

                // Fill array and DataGridView
                for (int i = 0; i < a.Lengthi; i++)
                {
                    dataGridView1.Rows.Add();

                    // Workshop number
                    dataGridView1.Rows[i].Cells[0].Value =
                        (i + 1).ToString();

                    // Generate random values for each plot
                    for (int j = 0; j < a.Lengthj; j++)
                    {
                        a[i, j] = ran.Next(minValue, maxValue + 1);

                        dataGridView1.Rows[i].Cells[j + 1].Value =
                            a[i, j].ToString();
                    }
                }

                // Check array errors
                if (a.error)
                    throw new Exception("Array processing error.");

                // Find workshop with minimum resources
                int[] massiv = a.Min;

                int workshop = massiv[0];

                // Display result
                label5.Text =
                    "Workshop with minimal resources: " +
                    (workshop + 1).ToString();

                // Highlight the corresponding row
                dataGridView1.Rows[workshop]
                    .DefaultCellStyle.BackColor = Color.Yellow;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter integer values.",
                    "Input error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "The entered number is too large.",
                    "Input error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
