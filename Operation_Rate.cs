using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MES
{
    public partial class Operation_Rate : Form
    {
        public Operation_Rate()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse); //모서리 다듬는 함수

        private void Operation_Rate_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "SELECT hour(event_time) as hour, count(Y30) as time, SUM(Y30) AS Y30, SUM(Y31) AS Y31, SUM(Y32) AS Y32, SUM(Y33) AS Y33, SUM(Y34) AS Y34, SUM(Y35) AS Y35, SUM(Y37) + sum(y38) AS Y36, SUM(Y39) AS Y37, SUM(Y3A) AS Y38, SUM(Y3B) AS Y39, SUM(Y3C) AS Y40, SUM(X5C) + SUM(X5D) AS Y41 FROM plc where event_time >= now() - interval 5 hour group by hour(event_time);";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int count = reader.GetInt32(1);
                                int x = reader.GetInt32(0);
                                for (int i = 30; i < 42; i++)
                                {
                                    Chart chart = (Chart)Controls.Find("Y"+i, true).FirstOrDefault();
                                    if (chart != null)
                                    {
                                        chart.Series["percent"].Points.AddXY(x, reader.GetInt32(i - 28) * 100 / count);
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

        private void Operation_Rate_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel_Array.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, tableLayoutPanel_Array.Width, tableLayoutPanel_Array.Height, 30, 30));
            for (int i = 30; i < 42; i++)
            {
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)Controls.Find("tableLayoutPanel_Y" + i, true).FirstOrDefault();
                tableLayoutPanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, tableLayoutPanel.Width, tableLayoutPanel.Height, 30, 30));
            }
        }

        private void numericUpDown_Spinner_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();

                    string query;
                    if (radioButton_Hour.Checked)
                    {
                        query = $@"SELECT hour(event_time) as hour, count(Y30) as time, SUM(Y30) AS Y30, SUM(Y31) AS Y31, SUM(Y32) AS Y32, SUM(Y33) AS Y33, SUM(Y34) AS Y34, SUM(Y35) AS Y35, SUM(Y37) + sum(y38) AS Y36, SUM(Y39) AS Y37, SUM(Y3A) AS Y38, SUM(Y3B) AS Y39, SUM(Y3C) AS Y40, SUM(X5C) + SUM(X5D) AS Y41 FROM plc where event_time >= now() - interval {(int)numericUpDown_Spinner.Value} hour group by hour(event_time);";
                    }
                    else
                    {
                        query = $@"SELECT day(event_time) as day, count(Y30) as time, SUM(Y30) AS Y30, SUM(Y31) AS Y31, SUM(Y32) AS Y32, SUM(Y33) AS Y33, SUM(Y34) AS Y34, SUM(Y35) AS Y35, SUM(Y37) + sum(y38) AS Y36, SUM(Y39) AS Y37, SUM(Y3A) AS Y38, SUM(Y3B) AS Y39, SUM(Y3C) AS Y40, SUM(X5C) + SUM(X5D) AS Y41 FROM plc where event_time >= now() - interval {(int)numericUpDown_Spinner.Value} day group by day(event_time);";
                    }
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int count = reader.GetInt32(1);
                                int x = reader.GetInt32(0);
                                for (int i = 30; i < 42; i++)
                                {
                                    Chart chart = (Chart)Controls.Find("Y" + i, true).FirstOrDefault();
                                    if (chart != null)
                                    {
                                        chart.Series["percent"].Points.AddXY(x, reader.GetInt32(i - 28) * 100 / count);
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
