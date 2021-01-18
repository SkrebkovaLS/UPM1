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

namespace BDPol
{
    public partial class Form2 : Form
    {
        public String conStr = @"Data Source=LAPTOP-EMN5G8DL\BD;Initial Catalog=PoliclinikaDB;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("INSERT INTO Plot (FirstName) VALUES ('{0}')", textBox1.Text), connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Persons WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("UPDATE Persons SET FirstName='{1}' WHERE ID={2}", textBox1.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("INSERT INTO Patient (PatientSurname, PatientName, PatientOtch, Phone) VALUES ('{0}', '{1}' '{2}', '{3}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text), connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
