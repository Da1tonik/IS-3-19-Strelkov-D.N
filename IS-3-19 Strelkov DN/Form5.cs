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

        private void button1_Click(object sender, EventArgs e)
        {
            Baza baza = new Baza();           
                try
                {
                    Baza.baza().Open();
                    string commandStr = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES (@fio,@date)";                 
                    using (MySqlCommand command = new MySqlCommand(commandStr, Baza.baza()))
                    {
                        command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateTimePicker1.Text;
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                finally
                {
                    MessageBox.Show("Соединение закрыто.");
                    Baza.baza().Close();
                }
                       
        }
    }
}
