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

namespace MES
{
    public partial class Monitoring : Form
    {
        public Monitoring()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "select * from plc order by event_time desc limit 1;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < 48; i ++)
                                {
                                    Button button = (Button)Controls.Find("X" + i, true).FirstOrDefault();
                                    if(button != null)
                                    {
                                        if (reader.GetBoolean(i+1))
                                        {
                                            button.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            button.BackColor = Color.White;
                                        }
                                    }
                                }
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
