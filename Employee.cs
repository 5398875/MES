using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace MES
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        

        private void Employee_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            try
            {
                using (MySqlConnection connection = new MySqlConnection("Server=localhost; Database=team2; Uid=root; Pwd=1234;"))
                {
                    connection.Open();
                    string query = "select * from employee order by employee_id asc;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["employee_id"], reader["position"], reader["employee_name"], reader["level"], reader["phonenumber"], reader["email"], reader["address"], reader["lastloginemployeecol"]);
                            }
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
