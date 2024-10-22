using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    public partial class Dashboard : Form
    {
        private Timer timer;
        
        private Dictionary<Panel, List<Panel>> panelGroups = new Dictionary<Panel, List<Panel>>();
        private Dictionary<Panel, Timer> animationTimers = new Dictionary<Panel, Timer>();
        private int panelSize;

        public Dashboard()
        {
            InitializeComponent();
            panelSize = pl_con_p.Width;

            // Timer 설정
            timer = new Timer();
            timer.Interval = 1000; // 1초마다 신호 체크
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            pl_con_p.Resize += new EventHandler(Panel_Resize);
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            panelSize = pl_con_p.Width; // 패널 크기 업데이트
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //if (animationTimers.Values.Any(timer => timer.Enabled)) return; // 애니메이션 중이면 새로운 패널 생성하지 않음

            using (MySqlConnection connection = new MySqlConnection("Server=localhost; Database=mes; Uid=root; Pwd=1234;"))
            {
                connection.Open();
                string query = "SELECT * FROM plc LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int[] xValues = new int[32]; // X00부터 X1F까지
                            int x5c;
                            int x5d;
                            for (int i = 0; i < xValues.Length; i++)
                            {
                                //xValues[i] = Convert.ToInt32(reader[$"x{i:X2}"]);
                                //System.InvalidCastException: '개체를 DBNull에서 다른 형식으로 캐스팅할 수 없습니다

                                if (reader.IsDBNull(reader.GetOrdinal($"x{i:X2}")))
                                {
                                    xValues[i] = 0; // 기본값 설정
                                }
                                else
                                {
                                    xValues[i] = Convert.ToInt32(reader[$"x{i:X2}"]);
                                }
                            }

                            int[] yValues = new int[16]; // Y30부터 Y3F까지
                            for (int i = 0; i < yValues.Length; i++)
                            {
                                if (reader.IsDBNull(reader.GetOrdinal($"y{(0x30 + i):X2}")))
                                {
                                    yValues[i] = 0; // 기본값 설정
                                }
                                else
                                {
                                    yValues[i] = Convert.ToInt32(reader[$"y{(0x30 + i):X2}"]); // 여기가 y 컬럼 이름 참조하는 부분
                                }
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("x5c")))
                            {
                                x5c = 0;
                            }
                            else
                            {
                                x5c = Convert.ToInt32(reader["x5c"]);
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("x5d")))
                            {
                                x5d = 0;
                            }
                            else
                            {
                                x5d = Convert.ToInt32(reader["x5d"]);
                            }
                          
                            //컨베이어1(핸드폰 시작부)
                            if (xValues[0] == 1)
                            {
                                CreateNewPanel(0x00, GetImageBasedOnXValue(0x00), GetParentPanelBasedOnXValue(0x00), "top");
                            }

                            // 첫 번째 패널이 최하단에 도달했을 때만 패널을 삭제
                            if (xValues[1] == 1 && panelGroups.ContainsKey(pl_con_p) && panelGroups[pl_con_p].Count > 0 && panelGroups[pl_con_p].First().Bottom + panelGroups[pl_con_p].First().Margin.Bottom >= GetParentPanelBasedOnXValue(0x01).Height)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x01), "top");
                            }

                            //컨베이어4(핸드폰 중간)
                            if (xValues[1] == 1)
                            {
                                CreateNewPanelForX01(0x01, GetImageBasedOnXValue(0x01), pl_con_press);
                            }

                            // 첫 번째 패널이 좌측에 도달했을 때만 패널을 삭제
                            if (xValues[9] == 1 && panelGroups.ContainsKey(pl_con_press) && panelGroups[pl_con_press].Count > 0 && panelGroups[pl_con_press].First().Left + panelGroups[pl_con_press].First().Margin.Left >= GetParentPanelBasedOnXValue(0x09).Width)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x09), "left");
                            }


                            //컨베이어5(핸드폰 적재부)
                            if (xValues[9] == 1)
                            {
                                CreateNewPanelForX09(0x09, GetImageBasedOnXValue(0x09), pl_con_photo);
                            }

                            // 첫 번째 패널이 최상단에 도달했을 때만 패널을 삭제
                            if (xValues[10] == 1 && panelGroups.ContainsKey(pl_con_photo) && panelGroups[pl_con_photo].Count > 0 && panelGroups[pl_con_photo].First().Top + panelGroups[pl_con_photo].First().Margin.Top >= GetParentPanelBasedOnXValue(0x0A).Height)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x0A), "bottom");
                            }
                            /*
                            if (xValues[10] == 1 && panelGroups[pl_con_photo].Count > 0 && panelGroups[pl_con_photo].First().Top + panelGroups[pl_con_photo].First().Margin.Top >= GetParentPanelBasedOnXValue(0x0A).Height)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x0A), "bottom");
                            }
                            */
                            //컨베이어2 배터리
                            if (xValues[2] == 1)
                            {
                                CreateNewPanel(0x02, GetImageBasedOnXValue(0x02), GetParentPanelBasedOnXValue(0x02), "top");
                            }

                            // 첫 번째 패널이 최하단에 도달했을 때만 패널을 삭제
                            if (xValues[3] == 1 && panelGroups.ContainsKey(pl_con_b) && panelGroups[pl_con_b].Count > 0 && panelGroups[pl_con_b].First().Bottom + panelGroups[pl_con_b].First().Margin.Bottom >= GetParentPanelBasedOnXValue(0x03).Height)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x03), "top");
                            }

                            //컨베이어3 케이스
                            if (xValues[5] == 1)
                            {
                                CreateNewPanel(0x05, GetImageBasedOnXValue(0x05), GetParentPanelBasedOnXValue(0x05), "top");
                            }

                            // 첫 번째 패널이 최하단에 도달했을 때만 패널을 삭제
                            if (xValues[6] == 1 && panelGroups.ContainsKey(pl_con_c) && panelGroups[pl_con_c].Count > 0 && panelGroups[pl_con_c].First().Bottom + panelGroups[pl_con_c].First().Margin.Bottom >= GetParentPanelBasedOnXValue(0x06).Height)
                            {
                                DeleteOldestPanel(GetParentPanelBasedOnXValue(0x06), "top");
                            }

                        }
                    }
                }
            }
        }

        // x01이 시작 위치와 삭제위치가 동시라서 함수를 따로 만듬.
        private void CreateNewPanelForX01(int xValue, Image backgroundImage, Panel parentPanel)
        {
            if (!panelGroups.ContainsKey(parentPanel))
            {
                panelGroups[parentPanel] = new List<Panel>();
            }

            // 최대 패널 개수 제한을 8로 설정
            if (panelGroups[parentPanel].Count >= 8) return;

            Point location = new Point(parentPanel.Width - panelSize, 0); // right 위치에서 시작

            Panel newPanel = new Panel
            {
                Size = new Size(panelSize, panelSize),
                Location = location,
                BackgroundImage = backgroundImage,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            parentPanel.Controls.Add(newPanel);
            panelGroups[parentPanel].Add(newPanel);
            AnimatePanel(newPanel, parentPanel, "right");
        }

        // x09이 시작 위치와 삭제위치가 동시라서 함수를 따로 만듬.
        private void CreateNewPanelForX09(int xValue, Image backgroundImage, Panel parentPanel)
        {
            if (!panelGroups.ContainsKey(parentPanel))
            {
                panelGroups[parentPanel] = new List<Panel>();
            }

            // 최대 패널 개수 제한을 5로 설정
            if (panelGroups[parentPanel].Count >= 5) return;

            Point location = new Point(0, parentPanel.Height); // bottom 위치에서 시작

            Panel newPanel = new Panel
            {
                Size = new Size(panelSize, panelSize),
                Location = location,
                BackgroundImage = backgroundImage,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            parentPanel.Controls.Add(newPanel);
            panelGroups[parentPanel].Add(newPanel);
            AnimatePanel(newPanel, parentPanel, "bottom");
        }

        private void CreateNewPanel(int xValue, Image backgroundImage, Panel parentPanel, string startPosition)
        {
            if (xValue == 0x03 || xValue == 0x04 || xValue == 0x06 || xValue == 0x07 || xValue == 0x08 || xValue == 0x0A)
            {
                // 대기 로직 추가
                return;
            }

            if (!panelGroups.ContainsKey(parentPanel))
            {
                panelGroups[parentPanel] = new List<Panel>();
            }

            // 최대 패널 개수 제한
            if ((xValue == 0x01 && panelGroups[parentPanel].Count >= 8) || (xValue != 0x01 && panelGroups[parentPanel].Count >= 5)) return;

            Point location = GetLocationBasedOnXValue(xValue, parentPanel);

            Panel newPanel = new Panel
            {
                Size = new Size(panelSize, panelSize),
                Location = location, // 매개변수에 따라 위치 설정
                BackgroundImage = backgroundImage,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            parentPanel.Controls.Add(newPanel);
            panelGroups[parentPanel].Add(newPanel);
            AnimatePanel(newPanel, parentPanel, startPosition);
        }

        private Point GetLocationBasedOnXValue(int xValue, Panel parentPanel)
        {

            switch (xValue)
            {
                case 0x00:
                    return new Point(0, 0); // 부모 패널의 top 위치에서 시작
                case 0x01:
                    return new Point(0, 0); // 부모 패널의 top 위치기준 삭제
                case 0x02:
                    return new Point(0, 0); // 부모 패널의 top 위치에서 시작
                case 0x03:
                    return new Point(0, 0); // 부모 패널의 top 위치에서 삭제
                case 0x05:
                    return new Point(0, 0); // 부모 패널의 top 위치에서 시작
                case 0x06:
                    return new Point(0, 0); // 부모 패널의 top 위치에서 삭제
                case 0x09:
                    return new Point(0, parentPanel.Height); // 부모 패널의 bottom 위치에서 시작
                default:
                    return new Point(0, 0); // 기본 위치
            }
        }

        private Panel GetParentPanelBasedOnXValue(int xValue)
        {
            // xValue에 따라 부모 패널을 결정하는 로직
            switch (xValue)
            {
                case 0x00:
                    return pl_con_p;
                case 0x01:
                    return pl_con_p;
                case 0x02:
                    return pl_con_b;
                case 0x03:
                    return pl_con_b;
                case 0x04:
                    return pl_con_press;
                case 0x05:
                    return pl_con_c;
                case 0x06:
                    return pl_con_c;
                case 0x07:
                    return pl_con_press;
                case 0x08:
                    return pl_con_press;
                case 0x09:
                    return pl_con_photo;
                case 0x0A:
                    return pl_con_photo;
                default:
                    return smallDefaultPanel;

            }
        }

        private Image GetImageBasedOnXValue(int xValue)
        {
            // xValue에 따라 이미지를 결정하는 로직
            switch (xValue)
            {
                case 0x00:
                    return Properties.Resources.p_up;
                case 0x01:
                    return Properties.Resources.p_up;
                case 0x02:
                    return Properties.Resources.b_up;
                case 0x03:
                    return Properties.Resources.b_up;
                case 0x04:
                    return Properties.Resources.p_up;
                case 0x05:
                    return Properties.Resources.c_up;
                case 0x06:
                    return Properties.Resources.c_up;
                case 0x07:
                    return Properties.Resources.p_up;
                case 0x08:
                    return Properties.Resources.p_up;
                case 0x09:
                    return Properties.Resources.p_down;
                case 0x0A:
                    return Properties.Resources.p_up;
                default:
                    return Properties.Resources.p_up;
            }
        }

        private void AnimatePanel(Panel panel, Panel parentPanel, string startPosition)
        {
            bool animationComplete = false;
            if (animationTimers.ContainsKey(panel))
            {
                return; // 이미 타이머가 있으면 새로 생성하지 않음
            }
            Timer animationTimer = new Timer
            {
                Interval = 10 // 애니메이션 속도 조절
            };
            animationTimers[panel] = animationTimer;

            animationTimer.Tick += (s, e) =>
            {
                switch (startPosition)
                {
                    case "top":
                        int targetBottomPosition = parentPanel.Height - panelSize * (panelGroups[parentPanel].IndexOf(panel));
                        if (panel.Bottom >= targetBottomPosition)
                        {
                            animationComplete = true;
                        }
                        else
                        {
                            panel.Top += 1;
                        }
                        break;

                    case "bottom":
                        int targetTopPosition = parentPanel.Height - panelSize * (panelGroups[parentPanel].IndexOf(panel));
                        if (panel.Top <= targetTopPosition)
                        {
                            animationComplete = true;
                        }
                        else
                        {
                            panel.Top -= 1;
                        }
                        break;

                    case "right":
                        int targetLeftPosition = panelSize * panelGroups[parentPanel].IndexOf(panel);
                        if (panel.Left <= targetLeftPosition)
                        {
                            animationComplete = true;
                        }
                        else
                        {
                            panel.Left -= 1;
                        }
                        break;

                    default:
                        animationComplete = true;
                        break;

                }
                if (animationComplete)
                {
                    animationTimer.Stop();
                    animationTimers.Remove(panel); // 애니메이션 완료 후 타이머 제거
                }

            };
            animationTimer.Start();
        }

        private void DeleteOldestPanel(Panel parentPanel, string startPosition)
        {
            Panel oldestPanel = null;
            if (panelGroups.ContainsKey(parentPanel))
            {
                oldestPanel = panelGroups[parentPanel].FirstOrDefault();
            }

            if (oldestPanel != null)
            {
                parentPanel.Controls.Remove(oldestPanel);
                panelGroups[parentPanel].Remove(oldestPanel);

                // 남은 패널들을 아래로 이동
                foreach (var panel in panelGroups[parentPanel])
                {
                    AnimatePanel(panel, parentPanel, startPosition);
                }
            }
        }
    }
}

        /*
        private void DeleteOldestPanel()
        {
            Panel oldestPanel = panels.FirstOrDefault(); // 가장 먼저 추가된 패널을 찾음
            if (oldestPanel != null)
            {
                pl_con_p.Controls.Remove(oldestPanel);
                panels.Remove(oldestPanel);

                // 남은 패널들을 아래로 이동
                foreach (var panel in panels)
                {
                    AnimatePanelDown(panel);
                }
            }
        }

        private void AnimatePanelDown(Panel panel)
        {
            Timer animationTimer = new Timer
            {
                Interval = 10 // 애니메이션 속도 조절
            };
            animationTimer.Tick += (s, e) =>
            {
                // 패널이 지정된 목표 위치에 도달했는지 확인
                int targetPosition = pl_con_p.Height - panelSize * (panels.IndexOf(panel));
                if (panel.Bottom >= targetPosition)
                {
                    animationTimer.Stop();
                }
                else
                {
                    panel.Top += 1; // 패널이 아래로 이동
                }
            };
            animationTimer.Start();
        }

        private void CreateNewPanel()
        {
            // 최대 패널 개수 제한
            if (panels.Count >= 5) return;

            Panel newPanel = new Panel
            {
                Size = new Size(panelSize, panelSize),
                Location = new Point(0, 0), // 최상단에서 시작
                BackgroundImage = Properties.Resources.p_up,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            pl_con_p.Controls.Add(newPanel);
            panels.Add(newPanel);
            AnimatePanelDown(newPanel);
        }
    }
}
*/
/*
private void CreateNewPanel()
{
    if (panels.Count >= 5) return;

    Panel newPanel = new Panel
    {
        Size = new Size(panelSize, panelSize),
        //Location = new Point(0, pl_con_p.Height - panelSize), // 가장 아래에 위치
        //Location = new Point(0, -panelSize), // 최상단에서 시작
        Location = new Point(0, 0), // 최상단에 위치
        BackgroundImage = Properties.Resources.p_up,
        BackgroundImageLayout = ImageLayout.Stretch
    };

    pl_con_p.Controls.Add(newPanel);
    panels.Add(newPanel);
    AnimatePanelDown(newPanel, panels.Count - 1);
}

//private void AnimatePanel(Panel panel)
private void AnimatePanelDown(Panel panel, int position)
{
    Timer animationTimer = new Timer
    {
        Interval = 5 // 애니메이션 속도 조절
    };
    animationTimer.Tick += (s, e) =>
    {
        //if (panel.Top <= 0) // 매널이 화면 최상단에 도달했는지 확인하는 조건
        //if (panel.Bottom >= pl_con_p.Height - panelSize * (panels.Count - 1))

        //int index = panels.IndexOf(panel);
        //int targetPosition = pl_con_p.Height - panelSize * (index);
        int targetPosition = pl_con_p.Height - panelSize * (position);

        if (panel.Bottom >= targetPosition)
        {
            animationTimer.Stop();
        }
        else
        {
            panel.Top += 1; // 패널이 아래로 이동
            // panel.Top -= 1; // 패널이 위로 이동
        }
    };
    animationTimer.Start();
}

private void DeleteOldestPanel()
{
    Panel oldestPanel = panels.FirstOrDefault();
    if (oldestPanel != null)
    {
        pl_con_p.Controls.Remove(oldestPanel);
        panels.Remove(oldestPanel);

        // 남은 패널들을 아래로 이동
        //foreach (var panel in panels)
        //{
        //    panel.Top += panelSize;
        //}

        for (int i = 0; i < panels.Count; i++)
        {
            AnimatePanelDown(panels[i], i);
        }
    }
}
}*/

