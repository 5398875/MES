using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //sql 연동을 위함

namespace MES
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse); //모서리 다듬는 함수

        private void Form1_Load(object sender, EventArgs e)
        {
            button_Login_Inner.Height = button_Login_Outer.Height - 8;
            button_Login_Inner.Width = button_Login_Outer.Width - 4;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15)); //창의 모서리 다듬기
            button_Login_Inner.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-50, 0, button_Login_Inner.Width, button_Login_Inner.Height, 40, 40));
            button_Login_Outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-50, 0, button_Login_Outer.Width, button_Login_Outer.Height, 45, 45));
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        bool bMouseDown;
        Point pLocation;

        private void tableLayoutPanel_Top_MouseDown(object sender, MouseEventArgs e) //마우스버튼이 눌리면
        {
            if (e.Button == MouseButtons.Left) //좌클릭이 눌리면
            {
                bMouseDown = true; //마우스 눌림 true
                pLocation = e.Location; //그 위치를 저장
            }
        }

        private void tableLayoutPanel_Top_MouseUP(object sender, MouseEventArgs e) //마우스버튼이 떨어지면
        {
            bMouseDown = false; //마우스 눌림 false
        }

        private void tableLayoutPanel_Top_MouseMove(object sender, MouseEventArgs e) //마우스가 움직이면
        {
            if (bMouseDown) //마우스가 눌려있을때
            {
                this.Location = new Point((this.Location.X - pLocation.X) + e.X, (this.Location.Y - pLocation.Y) + e.Y);
                this.Update(); //창의 위치를 (초기 창위치와 초기 마우스 위치의 차이)+마우스의 현재위치로 마우스를 따라 창이 움직이도록 한다
            }
        }

        private void textBox_ID_Enter(object sender, EventArgs e)
        {
            if(textBox_ID.Text == "Username")
            {
                textBox_ID.ForeColor = Color.White;
                textBox_ID.Text = string.Empty;
            }
        }

        private void textBox_ID_Leave(object sender, EventArgs e)
        {
            if (textBox_ID.Text == string.Empty)
            {
                textBox_ID.ForeColor = Color.FromArgb(170, 171, 176);
                textBox_ID.Text = "Username";
            }
        }

        private void textBox_PW_Enter(object sender, EventArgs e)
        {
            if (textBox_PW.Text == "Password")
            {
                textBox_PW.ForeColor = Color.White;
                textBox_PW.Text = string.Empty;
                textBox_PW.PasswordChar = '●';
            }
        }

        private void textBox_PW_Leave(object sender, EventArgs e)
        {
            if (textBox_PW.Text == string.Empty)
            {
                textBox_PW.ForeColor = Color.FromArgb(170, 171, 176);
                textBox_PW.Text = "Password";
                textBox_PW.PasswordChar = '\0';
            }
        }

        private void button_Login_Inner_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server = localhost;Database=team2;Uid=root;Pwd=1234;");
            connection.Open();

            string login_query = "SELECT * FROM employee WHERE id = \'" + textBox_ID.Text + "\' ";

            MySqlCommand login_command = new MySqlCommand(login_query, connection);
            MySqlDataReader user_account = login_command.ExecuteReader();

            while(user_account.Read())
            {

                if(textBox_ID.Text == (string)user_account["id"] && textBox_PW.Text == (string)(user_account["pw"]))
                {
                    User_info.User_name = (string)user_account["employee_name"];
                    User_info.User_position = (string)user_account["position"];
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("로그인 실패");
                }
            }

            connection.Close();
        }
    }
}
