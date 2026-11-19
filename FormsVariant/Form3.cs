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

            // Fixed matrix dimensions
            textBox1.Text = "5";
            textBox2.Text = "5";

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
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
                int minValue = Convert.ToInt32(textBox3.Text);
                int maxValue = Convert.ToInt32(textBox4.Text);

                // Validate input values
                if (minValue < -100 || maxValue > 100 ||
                    minValue > maxValue)
                {
                    throw new ArgumentException(
                        "Enter a valid range from -100 to 100.");
                }

                // Create two-dimensional array
                TwoArray a = new TwoArray(5, 5);

                Random ran = new Random();

                // Clear DataGridView
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Create columns
                for (int j = 0; j < 5; j++)
                {
                    DataGridViewTextBoxColumn column =
                        new DataGridViewTextBoxColumn();

                    column.HeaderText = "Column " + (j + 1);
                    dataGridView1.Columns.Add(column);
                }

                // Fill array and DataGridView
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows.Add();

                    for (int j = 0; j < 5; j++)
                    {
                        a[i, j] = ran.Next(minValue, maxValue + 1);

                        dataGridView1.Rows[i].Cells[j].Value =
                            a[i, j].ToString();

                        // Highlight negative elements below secondary diagonal
                        if (i + j > 4 && a[i, j] < 0)
                        {
                            dataGridView1.Rows[i].Cells[j]
                                .Style.BackColor = Color.Yellow;
                        }
                    }
                }

                // Check array errors
                if (a.error)
                    throw new Exception("Array processing error.");

                // Count negative elements below secondary diagonal
                int count = a.CountNegative;

                // Display result
                label5.Text =
                    "Negative elements below secondary diagonal: " +
                    count.ToString();
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