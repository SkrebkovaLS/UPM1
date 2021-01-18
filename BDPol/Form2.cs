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
                cmd = new SqlCommand(String.Format("INSERT INTO Plot (FirstName) VALUES ('{0}', '{1}')", textBox1.Text), connection);
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
    }
}
