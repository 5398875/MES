using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse); //모서리 다듬는 함수

        private void Main_Load(object sender, EventArgs e)
        {
            tableLayoutPanel_Full.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, tableLayoutPanel_Full.Width, tableLayoutPanel_Full.Height, 25, 25));
            make_Menu_Round(Dashboard);         make_Menu_Round(Monitoring_Test);   make_Menu_Round(Employee);      make_Menu_Round(Operation);
            make_SubMenu_Round(Operation_Rate); make_SubMenu_Round(Operation_Analyze);
            Dashboard.Checked = true;
            button_Menu_Click(Dashboard, EventArgs.Empty);
            label_User_Name.Text = User_info.User_name;
            label_User_Position.Text = User_info.User_position; 
        }

        private void make_Menu_Round(CheckBox checkbox)
        {
            checkbox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-50, 0, 200, 72, 72, 72));
        }

        private void make_SubMenu_Round(CheckBox checkbox)
        {
            checkbox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-50, 0, 200, 48, 48, 48));
        }

        bool Collapsed;
        CheckBox checkBox_Expand;
        FlowLayoutPanel flowLayoutPanel_Expand;

        private void timer_Expand_Menu_Tick(object sender, EventArgs e)
        {
            if (Collapsed)
            {
                flowLayoutPanel_Expand.Height += 10;
                if (flowLayoutPanel_Expand.Height >= flowLayoutPanel_Expand.MaximumSize.Height)
                {
                    flowLayoutPanel_Expand.Height = flowLayoutPanel_Expand.MaximumSize.Height;
                    timer_Expand_Menu.Stop();
                }
            }
            else
            {
                flowLayoutPanel_Expand.Height -= 10;
                if (flowLayoutPanel_Expand.Height <= flowLayoutPanel_Expand.MinimumSize.Height)
                {
                    flowLayoutPanel_Expand.Height = flowLayoutPanel_Expand.MinimumSize.Height;
                    timer_Expand_Menu.Stop();
                }
            }
        }

        private void button_Expand_Menu_Click(object sender, EventArgs e)
        {
            checkBox_Expand = sender as CheckBox;
            flowLayoutPanel_Expand = (FlowLayoutPanel)Controls.Find($"flowLayoutPanel_{checkBox_Expand.Name}_Container", true)[0];
            if (checkBox_Expand.Checked) { Collapsed = true; }
            else { Collapsed = false; }

            timer_Expand_Menu.Start();
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button_Menu_MouseEnter(object sender, EventArgs e)
        {
            CheckBox entered_Button = sender as CheckBox;
            if (entered_Button != null)
            {
                entered_Button.ForeColor = Color.FromArgb(235, 22, 22);
            }
        }

        private void button_Menu_MouseLeave(object sender, EventArgs e)
        {
            CheckBox leaved_Button = sender as CheckBox;
            if(leaved_Button != null)
            {
                leaved_Button.ForeColor = Color.FromArgb(108, 114, 147);
            }
        }

        CheckBox checkBox_Menu;
        Form form_ToShow;

        private void button_Menu_Click(object sender, EventArgs e)
        {
            if (panel_Main.Controls.Count > 0)
            {
                if (checkBox_Menu == sender as CheckBox)
                {
                    checkBox_Menu.Checked = true;
                    return;
                }
                else
                {
                    checkBox_Menu.Checked = false;
                    checkBox_Menu.ForeColor = Color.FromArgb(108, 114, 147);
                }
                
                var previous_Form = panel_Main.Controls[0] as Form;
                if (previous_Form != null)
                {
                    previous_Form.Close();
                    previous_Form.Dispose();
                }
            }

            checkBox_Menu = sender as CheckBox;
            switch (checkBox_Menu.Name)
            {
                case "Employee" : form_ToShow = new Employee(); break;
                case "Monitoring" : form_ToShow = new Monitoring(); break;
                case "Dashboard" : form_ToShow = new Dashboard(); break;
                case "Operation_Rate": form_ToShow = new Operation_Rate(); break;
                case "Operation_Analyze": form_ToShow = new Operation_Analyze(); break;
                case "Warehouse": form_ToShow = new Warehouse(); break;
            }
            
            checkBox_Menu.ForeColor = Color.FromArgb(235, 22, 22);
            form_ToShow.TopLevel = false;
            form_ToShow.Dock = DockStyle.Fill;
            panel_Main.Controls.Add(form_ToShow);
            form_ToShow.Show();
        }
    }
}
