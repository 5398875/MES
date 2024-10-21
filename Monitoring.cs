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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MES
{
    public partial class Monitoring : Form
    {

        // 패널과 버튼 초기 크기와 위치 저장
        private Size panelOriginalSize;
        private Dictionary<Button, Rectangle> buttonOriginalPositions = new Dictionary<Button, Rectangle>();
        private Dictionary<System.Windows.Forms.GroupBox, Rectangle> groupBoxOriginalPositions = new Dictionary<System.Windows.Forms.GroupBox, Rectangle>();

        public Monitoring()
        {
            InitializeComponent();

            // 원본 크기와 위치 저장
            panelOriginalSize = panel_background.Size;

            SaveButtonOriginalPositions();
            SaveGroupBoxOriginalPositions();

            this.Resize += new EventHandler(MainForm_Resize);
            AdjustControlSizes();
        }

        private void SaveButtonOriginalPositions()
        {
            SaveControlOriginalPosition(X0);
            SaveControlOriginalPosition(X1);
            SaveControlOriginalPosition(X2);
            SaveControlOriginalPosition(X3);
            SaveControlOriginalPosition(X4);
            SaveControlOriginalPosition(X5);
            SaveControlOriginalPosition(X6);
            SaveControlOriginalPosition(X7);
            SaveControlOriginalPosition(X8);
            SaveControlOriginalPosition(X9);
            SaveControlOriginalPosition(X10);
            SaveControlOriginalPosition(X11);
            SaveControlOriginalPosition(X12);
            SaveControlOriginalPosition(X13);
            SaveControlOriginalPosition(X14);
            SaveControlOriginalPosition(X15);
            SaveControlOriginalPosition(X17);
            SaveControlOriginalPosition(X21);
            SaveControlOriginalPosition(X22);
            SaveControlOriginalPosition(X23);
            SaveControlOriginalPosition(X24);
            SaveControlOriginalPosition(X25);
            SaveControlOriginalPosition(X26);
            SaveControlOriginalPosition(X33);
            SaveControlOriginalPosition(X34);
            SaveControlOriginalPosition(X35);
            SaveControlOriginalPosition(X36);
            SaveControlOriginalPosition(X37);
            SaveControlOriginalPosition(X38);
            SaveControlOriginalPosition(X39);
            SaveControlOriginalPosition(X40);
            SaveControlOriginalPosition(X41);
            SaveControlOriginalPosition(X42);
            SaveControlOriginalPosition(X43);
            SaveControlOriginalPosition(X44);
            SaveControlOriginalPosition(X45);
        }

        private void SaveControlOriginalPosition(Button btn)
        {
            buttonOriginalPositions[btn] = new Rectangle(btn.Location, btn.Size);
        }

        private void SaveGroupBoxOriginalPositions()
        {
            SaveControlOriginalPositionGroupBox(groupBox1);
            SaveControlOriginalPositionGroupBox(groupBox2);
            SaveControlOriginalPositionGroupBox(groupBox3);
            SaveControlOriginalPositionGroupBox(groupBox4);
            SaveControlOriginalPositionGroupBox(groupBox5);
            SaveControlOriginalPositionGroupBox(groupBox7);
            SaveControlOriginalPositionGroupBox(groupBox8);
        }

        private void SaveControlOriginalPositionGroupBox(System.Windows.Forms.GroupBox gbx)
        {
            groupBoxOriginalPositions[gbx] = new Rectangle(gbx.Location, gbx.Size);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustControlSizes();
        }

        private void AdjustControlSizes()
        {
            float widthRatio = (float)panel_background.Width / panelOriginalSize.Width;
            float heightRatio = (float)panel_background.Height / panelOriginalSize.Height;

            foreach (var entry in buttonOriginalPositions)
            {
                Button btn = entry.Key;
                Rectangle original = entry.Value;

                btn.Width = (int)(original.Width * widthRatio);
                btn.Height = (int)(original.Height * heightRatio);
                btn.Left = (int)(original.Left * widthRatio);
                btn.Top = (int)(original.Top * heightRatio);
            }

            foreach (var entry in groupBoxOriginalPositions)
            {
                System.Windows.Forms.GroupBox gbx = entry.Key;
                Rectangle original = entry.Value;

                gbx.Width = (int)(original.Width * widthRatio);
                gbx.Height = (int)(original.Height * heightRatio);
                gbx.Left = (int)(original.Left * widthRatio);
                gbx.Top = (int)(original.Top * heightRatio);
            }
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
                                for (int i = 0; i < 11; i ++)
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
                                            button.BackColor = Color.FromArgb(255, 192, 192);
                                        }
                                    }
                                }
                                for (int i = 11; i < 27; i++)
                                {
                                    Button button = (Button)Controls.Find("X" + i, true).FirstOrDefault();
                                    if (button != null)
                                    {
                                        if (reader.GetBoolean(i + 1))
                                        {
                                            button.BackColor = Color.Blue;
                                        }
                                        else
                                        {
                                            button.BackColor = Color.FromArgb(192, 255, 192);
                                        }
                                    }
                                }
                                for (int i = 33; i < 46; i++)
                                {
                                    Button button = (Button)Controls.Find("X" + i, true).FirstOrDefault();
                                    if (button != null)
                                    {
                                        if (reader.GetBoolean(i + 1))
                                        {
                                            button.BackColor = Color.Green;
                                        }
                                        else
                                        {
                                            button.BackColor = Color.FromArgb(192, 192, 255);
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
