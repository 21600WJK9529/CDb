using MySql.Data.MySqlClient;
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

namespace CDb
{
    public partial class DbConnect : Form
    {
       
        public DbConnect()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = new MySqlConnection(
               "server=localhost;user id=root;password=;database=csharpmysql;");
            connection.Open();
            //MessageBox.Show("Connection Open  !");
            String sql = "SELECT * FROM csharpmysql.test_table";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader[0].ToString()+" "+reader[1].ToString()+" "+reader[2].ToString());
            }
            connection.Close();
            
        }
        //Redo to avoid injection
        private void button2_Click(object sender, EventArgs e)
        {
            var connection = new MySqlConnection(
               "server=localhost;user id=root;password=;database=csharpmysql;");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO csharpmysql.test_table(name,age) VALUES(@name, @age)";
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@age", textBox2.Text);
            command.ExecuteNonQuery();
            connection.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //name

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //age

        }
    }
}
