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
            // var connection = new MySqlConnection(
            //      "server=localhost;user id=root;password=;database=csharpmysql;");
            //   connection.Open();
            //MessageBox.Show("Connection Open  !");
            //   MySqlCommand command = connection.CreateCommand();
            //   command.CommandText = "SELECT * FROM csharpmysql.test_table where id=@id";
            //   command.Parameters.AddWithValue("@id", textBox3.Text);
            //   command.ExecuteNonQuery();
            // MySqlDataReader reader = command.ExecuteReader();
            //MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            //connection.Close();
            using (MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=csharpmysql"))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM csharpmysql.test_table where id=@id";
                    command.Parameters.AddWithValue("@id", id.Text);
                    command.ExecuteNonQuery();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) //John Smith
                    {
                        if (reader[0].ToString() != id.Text)
                        {
                            MessageBox.Show("No data for id");
                            //reader.Close();
                        }
                        //reader.Close();

                    }
                    else
                    {                  //id                        name                            age
                        MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                    }
                    connection.Close();
                }
            }

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
            command.Parameters.AddWithValue("@name", fName.Text);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) //John Smith
            {
                if (reader[1].ToString() == fName.Text)
                {
                    MessageBox.Show("name exists");
                }

            }
            else
            {
                reader.Close();
                MySqlCommand insert = connection.CreateCommand();
                insert.CommandText = "INSERT INTO csharpmysql.test_table(name,age) VALUES(@name, @age)";
                insert.Parameters.AddWithValue("@name", fName.Text);
                insert.Parameters.AddWithValue("@age", age.Text);
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
            using (MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=csharpmysql"))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM csharpmysql.test_table where id=@id";
                    command.Parameters.AddWithValue("@id", id.Text);
                    command.ExecuteNonQuery();
                    MySqlDataReader reader = command.ExecuteReader();
                    Boolean read = reader.Read();
                    if (read.Equals(true))
                    {
                        if (reader[0].ToString() == id.Text)
                        {
                            MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                            //reader.Close();
                        }
                    }
                    //reader.Close();
                    else
                    {
                        MessageBox.Show("No data for id");
                    }
                    connection.Close();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}