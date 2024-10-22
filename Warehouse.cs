using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MES
{
    public partial class Warehouse : Form
    {    
        private float basePanelWidth;
        private float baseFontSize;
        private float basePanelWidthRed;
        private float basePanelHeightRed;
        private float basePanelHeightBlue;
        private float baseLabelWidth;
        private float baseLabelHeight;

        public Warehouse()
        {
            InitializeComponent();

            basePanelWidth = panel_bottom.Width;
            baseFontSize = lb_red_f.Font.Size;
            basePanelWidthRed = pl_red_f.Width;
            basePanelHeightRed = pl_red_f.Height;
            basePanelHeightBlue = pl_blue_f.Height;
            baseLabelWidth = lb_red_f.Width;
            baseLabelHeight = pl_red_f.Height;

            panel_button.Resize += new EventHandler(Panel1_Resize); // 폼 사이즈 이벤트핸들러

            // 초기 크기 설정
            AdjustButtonSizes(); // 폼이 생성될 때 버튼 사이즈 리폼
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Panel1_Resize(object sender, EventArgs e) // 폼 사이즈 이벤트
        {
            AdjustButtonSizes();

            float scaleFactor = panel_bottom.Width / basePanelWidth; // 크기 변화 비율 계산
            float newFontSize = baseFontSize * scaleFactor; // 비례해서 새로운 폰트 크기 설정

            float newPanelWidth = basePanelWidthRed * scaleFactor;
            float newPanelHeightRed = basePanelHeightRed * scaleFactor;
            float newPanelHeightBlue = basePanelHeightBlue * scaleFactor;
            float newLabelWidth = baseLabelWidth * scaleFactor;
            float newLabelHeight = baseLabelHeight * scaleFactor;

            lb_red_f.Font = new Font(lb_red_f.Font.FontFamily, newFontSize, lb_red_f.Font.Style);
            lb_red_s.Font = new Font(lb_red_s.Font.FontFamily, newFontSize, lb_red_s.Font.Style);
            lb_blue_f.Font = new Font(lb_blue_f.Font.FontFamily, newFontSize, lb_blue_f.Font.Style);
            lb_blue_s.Font = new Font(lb_blue_s.Font.FontFamily, newFontSize, lb_blue_s.Font.Style);

            // 라벨 위치 조정 (중앙 정렬)
            lb_red_f.Location = new Point((int)((newPanelWidth - newLabelWidth) / 2), (int)((newPanelHeightRed - newLabelHeight) / 2));
            lb_red_s.Location = new Point((int)((newPanelWidth - newLabelWidth) / 2), (int)((newPanelHeightRed - newLabelHeight) / 2));
            lb_blue_f.Location = new Point((int)((newPanelWidth - newLabelWidth) / 2), (int)((newPanelHeightBlue - newLabelHeight) / 2));
            lb_blue_s.Location = new Point((int)((newPanelWidth - newLabelWidth) / 2), (int)((newPanelHeightBlue - newLabelHeight) / 2));
        }

        private void AdjustButtonSizes()
        {
            int panelCount = 4; // panel1~panel4의 개수
            int totalWidth = panel_button.Width - panel_gap1.Width - panel_gap2.Width - panel_gap3.Width;
            int panelWidth = totalWidth / panelCount;

            bt_empty_outer.Width = panelWidth;
            bt_add_red_outer.Width = panelWidth;
            bt_add_blue_outer.Width = panelWidth;

            // 필요하다면 패널들의 위치를 조정합니다.
            bt_empty_outer.Left = 0;
            bt_add_red_outer.Left = panel_gap1.Right;
            bt_add_blue_outer.Left = panel_gap2.Right;
        

            bt_empty.Height = bt_empty_outer.Height - 8;
            bt_empty.Width = bt_empty_outer.Width - 8;
            bt_add_red.Height = bt_empty_outer.Height - 8;
            bt_add_red.Width = bt_empty_outer.Width - 8;
            bt_add_blue.Height = bt_empty_outer.Height - 8;
            bt_add_blue.Width = bt_empty_outer.Width - 8;

            // 버튼 위치 조정
            bt_empty.Location = new Point(
                bt_empty_outer.Width / 2 - bt_empty.Width / 2,
                bt_empty_outer.Height / 2 - bt_empty.Height / 2 + 4
            );

            bt_add_red.Location = new Point(
                bt_add_red_outer.Width / 2 - bt_add_red.Width / 2,
                bt_add_red_outer.Height / 2 - bt_add_red.Height / 2 + 4
            );

            bt_add_blue.Location = new Point(
                bt_add_blue_outer.Width / 2 - bt_add_blue.Width / 2,
                bt_add_blue_outer.Height / 2 - bt_add_blue.Height / 2 + 4
            );

            bt_empty.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_empty.Width, bt_empty_outer.Height + 22, 40, 40));
            bt_empty_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_empty_outer.Width, bt_empty_outer.Height + 22, 45, 45));
            bt_add_red.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add_red.Width, bt_add_red.Height + 22, 40, 40));
            bt_add_red_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add_red_outer.Width, bt_add_red_outer.Height + 22, 45, 45));
            bt_add_blue.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add_blue.Width, bt_add_blue.Height + 22, 40, 40));
            bt_add_blue_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add_blue_outer.Width, bt_add_blue_outer.Height + 22, 45, 45));
        }

        private int red_num;
        private int blue_num;
        private void Warehouse_Load(object sender, EventArgs e)
        {
            ProcessWarehouseDataSearch();
        }

        private void ProcessWarehouseDataSearch()
        {
            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();
                string query = "SELECT * FROM mes.warehouse LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            red_num = Convert.ToInt32(reader["red"]);
                            blue_num = Convert.ToInt32(reader["blue"]);
                        }
                        else
                        {
                            MessageBox.Show("데이터를 찾을 수 없습니다.");
                        }
                    }
                }
            }
            // 패널 업데이트
            lb_red.Text = red_num.ToString();
            lb_blue.Text = blue_num.ToString();

            UpdateFlowLayoutPanels("red", red_num);
            UpdateFlowLayoutPanels("blue", blue_num);
        }

        private void ProcessWarehouseDataUpdate() // update, image, textBox
        {
            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();
                string updateQuery = "UPDATE mes.warehouse SET red = @red, blue = @blue limit 1";

                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@red", red_num);
                    updateCommand.Parameters.AddWithValue("@blue", blue_num);
                    updateCommand.ExecuteNonQuery();
                }
            }

            UpdateFlowLayoutPanels("red", red_num); //ui는 데이터베이스 업데이트 후 실행
            UpdateFlowLayoutPanels("blue", blue_num);
            lb_red.Text = red_num.ToString();
            lb_blue.Text = blue_num.ToString();
        }

        private void UpdateFlowLayoutPanels(string color, int count)
        {
            if (color == "red")
            {
                switch (red_num)
                {
                    case 1:
                        ph1_red.Visible = true;
                        ph2_red.Visible = false;
                        ph3_red.Visible = false;
                        ph4_red.Visible = false;
                        ph5_red.Visible = false;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 2:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = false;
                        ph4_red.Visible = false;
                        ph5_red.Visible = false;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 3:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = false;
                        ph5_red.Visible = false;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 4:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = true;
                        ph5_red.Visible = false;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 5:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = true;
                        ph5_red.Visible = true;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 6:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = true;
                        ph5_red.Visible = true;
                        ph6_red.Visible = true;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                    case 7:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = true;
                        ph5_red.Visible = true;
                        ph6_red.Visible = true;
                        ph7_red.Visible = true;
                        ph8_red.Visible = false;
                        break;
                    case 8:
                        ph1_red.Visible = true;
                        ph2_red.Visible = true;
                        ph3_red.Visible = true;
                        ph4_red.Visible = true;
                        ph5_red.Visible = true;
                        ph6_red.Visible = true;
                        ph7_red.Visible = true;
                        ph8_red.Visible = true;
                        break;
                    // 다른 경우들
                    default:
                        ph1_red.Visible = false;
                        ph2_red.Visible = false;
                        ph3_red.Visible = false;
                        ph4_red.Visible = false;
                        ph5_red.Visible = false;
                        ph6_red.Visible = false;
                        ph7_red.Visible = false;
                        ph8_red.Visible = false;
                        break;
                }
            }
            else
            {
                switch (blue_num)
                {
                    case 1:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = false;
                        ph3_blue.Visible = false;
                        ph4_blue.Visible = false;
                        ph5_blue.Visible = false;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 2:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = false;
                        ph4_blue.Visible = false;
                        ph5_blue.Visible = false;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 3:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = false;
                        ph5_blue.Visible = false;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 4:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = true;
                        ph5_blue.Visible = false;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 5:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = true;
                        ph5_blue.Visible = true;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 6:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = true;
                        ph5_blue.Visible = true;
                        ph6_blue.Visible = true;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                    case 7:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = true;
                        ph5_blue.Visible = true;
                        ph6_blue.Visible = true;
                        ph7_blue.Visible = true;
                        ph8_blue.Visible = false;
                        break;
                    case 8:
                        ph1_blue.Visible = true;
                        ph2_blue.Visible = true;
                        ph3_blue.Visible = true;
                        ph4_blue.Visible = true;
                        ph5_blue.Visible = true;
                        ph6_blue.Visible = true;
                        ph7_blue.Visible = true;
                        ph8_blue.Visible = true;
                        break;
                    // 다른 경우들
                    default:
                        ph1_blue.Visible = false;
                        ph2_blue.Visible = false;
                        ph3_blue.Visible = false;
                        ph4_blue.Visible = false;
                        ph5_blue.Visible = false;
                        ph6_blue.Visible = false;
                        ph7_blue.Visible = false;
                        ph8_blue.Visible = false;
                        break;
                }
            }
        }


        private void bt_empty_Click(object sender, EventArgs e)
        {
            red_num = 0;
            blue_num = 0;
            ProcessWarehouseDataUpdate();
        }

        private void bt_add_red_Click(object sender, EventArgs e)
        {
            int red_num_before = Convert.ToInt32(lb_red.Text);
            red_num = ++red_num_before;
            if(red_num>8)
            {
                red_num = 8;
                MessageBox.Show("RED 창고가 가득 찼습니다.");
            }
            blue_num = Convert.ToInt32(lb_blue.Text);
            ProcessWarehouseDataUpdate();
        }

        private void bt_add_blue_Click(object sender, EventArgs e)
        {
            int blue_num_before = Convert.ToInt32(lb_blue.Text);
            blue_num = ++blue_num_before;
            if (blue_num > 8)
            {
                blue_num = 8;
                MessageBox.Show("blue 창고가 가득 찼습니다.");
            }
            red_num = Convert.ToInt32(lb_red.Text);
            ProcessWarehouseDataUpdate();
        }
    }
}
