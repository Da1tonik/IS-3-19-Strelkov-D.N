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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection conn = Baza.baza();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string commandStr = "SELECT idStud AS 'ID', fioStud AS 'ФИО', datetimeStud AS 'Дата рождения' FROM t_PraktStud";
                MyDA.SelectCommand = new MySqlCommand(commandStr, Baza.baza());
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
            }
            catch
            {
                MessageBox.Show("Исправьте ошибку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
            private void button1_Click(object sender, EventArgs e)
            {
                if (textBox1.TextLength != 0)
                {
                    string commandStr2 = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES (@fio,@date)";
                    using (MySqlCommand command = new MySqlCommand(commandStr2, Baza.baza()))
                    {
                        command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateTimePicker1.Value;
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    table.Clear();
                    string commandStr = "SELECT idStud AS 'ID', fioStud AS 'ФИО', datetimeStud AS 'Дата рождения' FROM t_PraktStud";
                    MyDA.SelectCommand = new MySqlCommand(commandStr, Baza.baza());
                    MyDA.Fill(table);
                    bSource.DataSource = table;
                    dataGridView1.DataSource = bSource;
                }
                else
                {
                    MessageBox.Show("Заполните данные");
                }
            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    dataGridView1.CurrentRow.Selected = true;
                }
                catch
                { }
            }
        
}   }
