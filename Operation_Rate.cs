using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace MES
{
    public partial class Operation_Rate : Form
    {
        public Operation_Rate()
        {
            InitializeComponent();
        }

        private void Operation_Rate_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "SELECT hour(event_time) as hour, count(Y30) as time, SUM(Y30) AS Y30, SUM(Y31) AS Y31, SUM(Y32) AS Y32, SUM(Y33) AS Y33, SUM(Y34) AS Y34, SUM(Y35) AS Y35, SUM(Y36) AS Y36, SUM(Y37) AS Y37, SUM(Y38) AS Y38, SUM(Y39) AS Y39, SUM(Y3A) AS Y40, SUM(Y3B) AS Y41, SUM(Y3C) AS Y42, SUM(Y3D) AS Y43, SUM(Y3E) AS Y44, SUM(Y3F) AS Y45 FROM plc WHERE DATE(event_time) = '2024-10-18' group by hour(event_time);";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 30; i < 46; i++)
                                {
                                    Chart chart = (Chart)Controls.Find("Y"+i, true).FirstOrDefault();
                                    
                                    if (chart != null)
                                    {
                                        chart.Series["percent"].Points.AddXY(reader[0], reader.GetInt32(i - 28) * 100 / reader.GetInt32(1));
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
