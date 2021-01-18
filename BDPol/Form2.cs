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
        public String conStr = "Data Source=LAPTOP-EMN5G8DL\\BD;Initial Catalog=PoliclinikaDB;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
            GetUs();
        }

        //Первая таблица Участка
        //Добавление
        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("INSERT INTO Policlinika.Plot (PlotName) VALUES ('{0}')", Plot.Text), connection);
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
            GetUs();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Plot.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        // Метод для отображения данных в таблицы
        private void GetUs()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                da = new SqlDataAdapter("SELECT * FROM Policlinika.Plot", connection);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                //comboBox1.DataSource = ds.Tables[0];
                //comboBox1.DisplayMember = "Plot";
                //comboBox1.ValueMember = "ID";
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

        //Удаление
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Policlinika.Plot WHERE PlotID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GetUs();
        }

        //Изменение
        private void button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("UPDATE Policlinika.Plot SET PlotName='{0}' WHERE PlotID={1}", Plot.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GetUs();
        }


        //Вторая таблица Пациенты
        private void button6_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("INSERT INTO Policlinika.Patient (PatientSurname, PatientName, PatientPatronymic, Phone) VALUES ('{0}', '{1}', '{2}', '{3}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text), connection);
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
            GetPat();
        }
        //Метод 
        private void GetPat()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                da = new SqlDataAdapter("SELECT * FROM Policlinika.Patient", connection);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                //comboBox1.DataSource = ds.Tables[0];
                //comboBox1.DisplayMember = "Plot";
                //comboBox1.ValueMember = "ID";
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
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
