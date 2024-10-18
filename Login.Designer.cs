namespace MES
{
    partial class Login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_full = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Top = new System.Windows.Forms.TableLayoutPanel();
            this.label_name = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Right = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.button_Login_Inner = new System.Windows.Forms.Button();
            this.button_Login_Outer = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Left = new System.Windows.Forms.TableLayoutPanel();
            this.label_Welcome = new System.Windows.Forms.Label();
            this.tableLayoutPanel_full.SuspendLayout();
            this.tableLayoutPanel_Top.SuspendLayout();
            this.tableLayoutPanel_main.SuspendLayout();
            this.tableLayoutPanel_Right.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_full
            // 
            this.tableLayoutPanel_full.ColumnCount = 1;
            this.tableLayoutPanel_full.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_full.Controls.Add(this.tableLayoutPanel_Top, 0, 0);
            this.tableLayoutPanel_full.Controls.Add(this.tableLayoutPanel_main, 0, 1);
            this.tableLayoutPanel_full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_full.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_full.Name = "tableLayoutPanel_full";
            this.tableLayoutPanel_full.RowCount = 2;
            this.tableLayoutPanel_full.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_full.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_full.Size = new System.Drawing.Size(707, 520);
            this.tableLayoutPanel_full.TabIndex = 0;
            // 
            // tableLayoutPanel_Top
            // 
            this.tableLayoutPanel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel_Top.ColumnCount = 3;
            this.tableLayoutPanel_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel_Top.Controls.Add(this.label_name, 0, 0);
            this.tableLayoutPanel_Top.Controls.Add(this.button_close, 2, 0);
            this.tableLayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Top.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Top.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Top.Name = "tableLayoutPanel_Top";
            this.tableLayoutPanel_Top.RowCount = 1;
            this.tableLayoutPanel_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Top.Size = new System.Drawing.Size(707, 30);
            this.tableLayoutPanel_Top.TabIndex = 0;
            this.tableLayoutPanel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_Top_MouseDown);
            this.tableLayoutPanel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_Top_MouseMove);
            this.tableLayoutPanel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_Top_MouseUP);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_name.ForeColor = System.Drawing.Color.White;
            this.label_name.Location = new System.Drawing.Point(3, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(60, 30);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "CN_Login";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_close
            // 
            this.button_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_close.ForeColor = System.Drawing.Color.White;
            this.button_close.Location = new System.Drawing.Point(668, 3);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(36, 24);
            this.button_close.TabIndex = 3;
            this.button_close.Text = "✕";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.ColumnCount = 2;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_Right, 1, 0);
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_Left, 0, 0);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel_main.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 1;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(707, 490);
            this.tableLayoutPanel_main.TabIndex = 1;
            // 
            // tableLayoutPanel_Right
            // 
            this.tableLayoutPanel_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(59)))));
            this.tableLayoutPanel_Right.ColumnCount = 1;
            this.tableLayoutPanel_Right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Right.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel_Right.Controls.Add(this.tableLayoutPanel1, 0, 7);
            this.tableLayoutPanel_Right.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel_Right.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel_Right.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Right.Location = new System.Drawing.Point(353, 0);
            this.tableLayoutPanel_Right.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Right.Name = "tableLayoutPanel_Right";
            this.tableLayoutPanel_Right.RowCount = 10;
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Right.Size = new System.Drawing.Size(354, 490);
            this.tableLayoutPanel_Right.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(3, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login to your account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel_login, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 340);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 50);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel_login
            // 
            this.panel_login.Controls.Add(this.button_Login_Inner);
            this.panel_login.Controls.Add(this.button_Login_Outer);
            this.panel_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_login.Location = new System.Drawing.Point(0, 0);
            this.panel_login.Margin = new System.Windows.Forms.Padding(0);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(200, 50);
            this.panel_login.TabIndex = 0;
            // 
            // button_Login_Inner
            // 
            this.button_Login_Inner.FlatAppearance.BorderSize = 0;
            this.button_Login_Inner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Login_Inner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button_Login_Inner.Location = new System.Drawing.Point(0, 4);
            this.button_Login_Inner.Margin = new System.Windows.Forms.Padding(0);
            this.button_Login_Inner.Name = "button_Login_Inner";
            this.button_Login_Inner.Size = new System.Drawing.Size(176, 40);
            this.button_Login_Inner.TabIndex = 0;
            this.button_Login_Inner.Text = "LOGIN";
            this.button_Login_Inner.UseVisualStyleBackColor = true;
            this.button_Login_Inner.Click += new System.EventHandler(this.button_Login_Inner_Click);
            // 
            // button_Login_Outer
            // 
            this.button_Login_Outer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button_Login_Outer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Login_Outer.FlatAppearance.BorderSize = 0;
            this.button_Login_Outer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Login_Outer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.button_Login_Outer.Location = new System.Drawing.Point(0, 0);
            this.button_Login_Outer.Margin = new System.Windows.Forms.Padding(0);
            this.button_Login_Outer.Name = "button_Login_Outer";
            this.button_Login_Outer.Size = new System.Drawing.Size(200, 50);
            this.button_Login_Outer.TabIndex = 1;
            this.button_Login_Outer.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(67)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_ID, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_PW, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 212);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(354, 100);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.label2.Location = new System.Drawing.Point(20, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 50);
            this.label2.TabIndex = 0;
            this.label2.Text = "👤";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.label3.Location = new System.Drawing.Point(20, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 50);
            this.label3.TabIndex = 1;
            this.label3.Text = "🔒";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(67)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ID.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.textBox_ID.Location = new System.Drawing.Point(60, 15);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(294, 22);
            this.textBox_ID.TabIndex = 2;
            this.textBox_ID.Text = "Username";
            this.textBox_ID.Enter += new System.EventHandler(this.textBox_ID_Enter);
            this.textBox_ID.Leave += new System.EventHandler(this.textBox_ID_Leave);
            // 
            // textBox_PW
            // 
            this.textBox_PW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(67)))));
            this.textBox_PW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_PW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_PW.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_PW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.textBox_PW.Location = new System.Drawing.Point(60, 65);
            this.textBox_PW.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(294, 22);
            this.textBox_PW.TabIndex = 3;
            this.textBox_PW.Text = "Password";
            this.textBox_PW.Enter += new System.EventHandler(this.textBox_PW_Enter);
            this.textBox_PW.Leave += new System.EventHandler(this.textBox_PW_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(81)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 8);
            this.label4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(81)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 312);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 8);
            this.label5.TabIndex = 6;
            // 
            // tableLayoutPanel_Left
            // 
            this.tableLayoutPanel_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.tableLayoutPanel_Left.ColumnCount = 1;
            this.tableLayoutPanel_Left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Left.Controls.Add(this.label_Welcome, 0, 1);
            this.tableLayoutPanel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Left.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Left.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Left.Name = "tableLayoutPanel_Left";
            this.tableLayoutPanel_Left.RowCount = 3;
            this.tableLayoutPanel_Left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel_Left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel_Left.Size = new System.Drawing.Size(353, 490);
            this.tableLayoutPanel_Left.TabIndex = 0;
            // 
            // label_Welcome
            // 
            this.label_Welcome.AutoSize = true;
            this.label_Welcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Welcome.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Welcome.ForeColor = System.Drawing.Color.White;
            this.label_Welcome.Location = new System.Drawing.Point(3, 146);
            this.label_Welcome.Name = "label_Welcome";
            this.label_Welcome.Size = new System.Drawing.Size(347, 100);
            this.label_Welcome.TabIndex = 0;
            this.label_Welcome.Text = "Welcome to the\r\nMES system";
            this.label_Welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 520);
            this.Controls.Add(this.tableLayoutPanel_full);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel_full.ResumeLayout(false);
            this.tableLayoutPanel_Top.ResumeLayout(false);
            this.tableLayoutPanel_Top.PerformLayout();
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_Right.ResumeLayout(false);
            this.tableLayoutPanel_Right.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_login.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel_Left.ResumeLayout(false);
            this.tableLayoutPanel_Left.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_full;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Top;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Right;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Left;
        private System.Windows.Forms.Label label_Welcome;
        private System.Windows.Forms.Button button_Login_Inner;
        private System.Windows.Forms.Button button_Login_Outer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

