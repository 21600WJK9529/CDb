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
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM csharpmysql.test_table where id=@id";
            command.Parameters.AddWithValue("@id", textBox3.Text);
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            connection.Close();
            
        }
        //Redo to avoid injection
        private void button2_Click(object sender, EventArgs e)
        {
            //create
            var connection = new MySqlConnection(
               "server=localhost;user id=root;password=;database=csharpmysql;");
            connection.Open();
            //MessageBox.Show("Connection Open  !");
            String sql = "SELECT * FROM csharpmysql.test_table WHERE name=@name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", Name.Text);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) //John Smith
            {
                if (reader[1].ToString() == Name.Text)
                {
                    MessageBox.Show("name exists");
                }
                
            }
            else
            {
                reader.Close();
                MySqlCommand insert = connection.CreateCommand();
                insert.CommandText = "INSERT INTO csharpmysql.test_table(name,age) VALUES(@name, @age)";
                insert.Parameters.AddWithValue("@name", Name.Text);
                insert.Parameters.AddWithValue("@age", textBox2.Text);
                insert.ExecuteNonQuery();
                MessageBox.Show("Created");
                reader.Close();
            }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //read
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var connection = new MySqlConnection(
               "server=localhost;user id=root;password=;database=csharpmysql;");
            connection.Open();
            //MessageBox.Show("Connection Open  !");
            String sql = "SELECT * FROM csharpmysql.test_table WHERE Id=@id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", textBox3.Text);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }
            connection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
