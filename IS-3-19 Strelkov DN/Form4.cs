using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BazLiter;

namespace IS_3_19_Strelkov_DN
{
    public partial class Form4 : Form
    {
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baza baza = new Baza();
            try
            {
                Baza.baza().Open();
                string commandStr = "SELECT idStud AS 'ID', fioStud AS 'ФИО', drStud AS 'Дата рождения' FROM t_datetime";
                MyDA.SelectCommand = new MySqlCommand(commandStr, Baza.baza());
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            finally
            {
                MessageBox.Show("Подключение завершено.");
                Baza.baza().Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DateTime dr = new DateTime();
                dr = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                MessageBox.Show(DateTime.Today.Subtract(dr.Date).Days.ToString() + " дней с момента рождения.");
            }
            catch
            {
            }
        }
    }
}
