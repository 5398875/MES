using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace MES
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            panel_button.Resize += new EventHandler(Panel1_Resize);

            // 초기 크기 설정
            AdjustButtonSizes();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Employee_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "select * from employee order by employee_id asc;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            /*while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["employee_id"], reader["position"], reader["employee_name"], reader["level"], reader["phonenumber"], reader["email"], reader["address"], reader["lastloginemployeecol"]);
                            }
                            */
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Panel1_Resize(object sender, EventArgs e)
        {
            AdjustButtonSizes();
        }

        private void AdjustButtonSizes()
        {

            int panelCount = 4; // panel1~panel4의 개수
            int totalWidth = panel_button.Width - panel_gap1.Width - panel_gap2.Width - panel_gap3.Width;
            int panelWidth = totalWidth / panelCount;

            bt_search_outer.Width = panelWidth;
            bt_add_outer.Width = panelWidth;
            bt_modify_outer.Width = panelWidth;
            bt_delete_outer.Width = panelWidth;

            // 필요하다면 패널들의 위치를 조정합니다.
            bt_search_outer.Left = 0;
            bt_add_outer.Left = panel_gap1.Right;
            bt_modify_outer.Left = panel_gap2.Right;
            bt_delete_outer.Left = panel_gap3.Right;

            bt_search.Height = bt_search_outer.Height - 8;
            bt_search.Width = bt_search_outer.Width - 8;
            bt_add.Height = bt_search_outer.Height - 8;
            bt_add.Width = bt_search_outer.Width - 8;
            bt_modify.Height = bt_search_outer.Height - 8;
            bt_modify.Width = bt_search_outer.Width - 8;
            bt_delete.Height = bt_search_outer.Height - 8;
            bt_delete.Width = bt_search_outer.Width - 8;

            // 버튼 위치 조정
            bt_search.Location = new Point(
                bt_search_outer.Width / 2 - bt_search.Width / 2,
                bt_search_outer.Height / 2 - bt_search.Height / 2 + 4
            );

            bt_add.Location = new Point(
                bt_add_outer.Width / 2 - bt_add.Width / 2,
                bt_add_outer.Height / 2 - bt_add.Height / 2 + 4
            );

            bt_modify.Location = new Point(
                bt_modify_outer.Width / 2 - bt_modify.Width / 2,
                bt_modify_outer.Height / 2 - bt_modify.Height / 2 + 4
            );

            bt_delete.Location = new Point(
                bt_delete_outer.Width / 2 - bt_delete.Width / 2,
                bt_delete_outer.Height / 2 - bt_delete.Height / 2 + 4
            );

            bt_search.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_search.Width, bt_search_outer.Height + 22, 40, 40));
            bt_search_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_search_outer.Width, bt_search_outer.Height + 22, 45, 45));
            bt_add.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add.Width, bt_add.Height + 22, 40, 40));
            bt_add_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_add_outer.Width, bt_add_outer.Height + 22, 45, 45));
            bt_modify.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_modify.Width, bt_modify.Height + 22, 40, 40));
            bt_modify_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_modify_outer.Width, bt_modify_outer.Height + 22, 45, 45));
            bt_delete.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_delete.Width, bt_delete.Height + 22, 40, 40));
            bt_delete_outer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, bt_delete_outer.Width, bt_delete_outer.Height + 22, 45, 45));
        }


        /*
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panel1.BackColor);
        }
        */
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }
            return null;
        }

        private void bt_attach_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 선택된 파일 경로 가져오기
                    string filePath = openFileDialog.FileName;

                    // PictureBox에 이미지 로드
                    pictureBox1.Image = Image.FromFile(filePath);

                    // 필요시, 이미지 경로를 저장할 수 있습니다.
                    // textBox_ImagePath.Text = filePath;
                }
            }
        }

        private void bt_search_Click_1(object sender, EventArgs e)
        {
            // 선택된 행 또는 체크된 행을 찾습니다.
            DataGridViewRow selectedRow = null;
            int checkedRowCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                {
                    selectedRow = row;
                    checkedRowCount++;
                }
            }

            // 체크박스가 2개 이상 선택된 경우 메시지 표시
            if (checkedRowCount > 1)
            {
                MessageBox.Show("한 개의 행만 선택해주세요.");
                return;
            }

            // 체크박스가 선택되지 않은 경우, 셀 선택 확인
            if (selectedRow == null)
            {
                if (dataGridView1.SelectedRows.Count > 1)
                {
                    MessageBox.Show("한 개의 행만 선택해주세요.");
                    return;
                }
                else if (dataGridView1.SelectedRows.Count == 1)
                {
                    selectedRow = dataGridView1.SelectedRows[0];
                }
                else
                {
                    MessageBox.Show("선택된 행이 없습니다.");
                    return;
                }
            }

            // employee_id를 가져옵니다.
            int employeeId = Convert.ToInt32(selectedRow.Cells["employee_id"].Value);

            // MySQL 데이터베이스에서 데이터를 검색합니다.
            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();
                string query = $"SELECT * FROM employee WHERE employee_id = {employeeId}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_position.Text = reader["position"].ToString();
                            tb_username.Text = reader["employee_name"].ToString();
                            tb_level.Text = reader["level"].ToString();
                            tb_userid.Text = reader["id"].ToString();
                            tb_password.Text = reader["pw"].ToString();
                            tb_phonenumber.Text = reader["phonenumber"].ToString();
                            tb_email.Text = reader["email"].ToString();
                            tb_address.Text = reader["address"].ToString();


                            if (!Convert.IsDBNull(reader["image"]))
                            {
                                byte[] imageData = (byte[])reader["image"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                // 이미지를 찾을 수 없는 경우 기본 이미지 설정
                                pictureBox1.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("데이터를 찾을 수 없습니다.");
                        }
                    }
                }
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            string position = tb_position.Text;
            string employeeName = tb_username.Text;
            string level = tb_level.Text;
            string userId = tb_userid.Text;
            string password = tb_password.Text;
            string phoneNumber = tb_phonenumber.Text;
            string email = tb_email.Text;
            string address = tb_address.Text;

            // 이미지 데이터 변수 선언
            byte[] imageData = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        Bitmap bmp = new Bitmap(pictureBox1.Image);
                        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75L);
                        ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                        EncoderParameters encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = qualityParam;
                        bmp.Save(ms, jpegCodec, encoderParams);
                        imageData = ms.ToArray();
                    }
                    catch (ExternalException ex)
                    {
                        MessageBox.Show("이미지를 저장하는 중 오류가 발생했습니다: " + ex.Message);
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
            }

            int newEmployeeId = 0;

            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();

                // 현재 최대 employee_id 가져오기
                string getMaxIdQuery = "SELECT MAX(employee_id) FROM employee";
                using (MySqlCommand getMaxIdCommand = new MySqlCommand(getMaxIdQuery, connection))
                {
                    object result = getMaxIdCommand.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        newEmployeeId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newEmployeeId = 1; // 데이터가 없는 경우 초기값 설정
                    }
                }

                // 새로운 행 추가
                string insertQuery = "INSERT INTO employee (employee_id, position, employee_name, level, id, pw, phonenumber, email, address,image) VALUES (@employee_id, @position, @employee_name, @level, @id, @pw, @phonenumber, @email, @address, @image)";
                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@employee_id", newEmployeeId);
                    insertCommand.Parameters.AddWithValue("@position", position);
                    insertCommand.Parameters.AddWithValue("@employee_name", employeeName);
                    insertCommand.Parameters.AddWithValue("@level", level);
                    insertCommand.Parameters.AddWithValue("@id", userId);
                    insertCommand.Parameters.AddWithValue("@pw", password);
                    insertCommand.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    insertCommand.Parameters.AddWithValue("@email", email);
                    insertCommand.Parameters.AddWithValue("@address", address);

                    // 이미지 데이터 추가 (null 체크)
                    if (imageData != null)
                    {
                        insertCommand.Parameters.AddWithValue("@image", imageData);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@image", DBNull.Value);
                    }

                    insertCommand.ExecuteNonQuery();
                }
            }

            MessageBox.Show("새로운 행이 추가되었습니다.");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "select * from employee order by employee_id asc;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            /*while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["employee_id"], reader["position"], reader["employee_name"], reader["level"], reader["phonenumber"], reader["email"], reader["address"], reader["lastloginemployeecol"]);
                            }
                            */
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            // 선택된 행 또는 체크된 행을 찾습니다.
            DataGridViewRow selectedRow = null;
            int checkedRowCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                {
                    selectedRow = row;
                    checkedRowCount++;
                }
            }

            // 체크박스가 2개 이상 선택된 경우 메시지 표시
            if (checkedRowCount > 1)
            {
                MessageBox.Show("한 개의 행만 선택해주세요.");
                return;
            }

            // 체크박스가 선택되지 않은 경우, 셀 선택 확인
            if (selectedRow == null)
            {
                if (dataGridView1.SelectedRows.Count > 1)
                {
                    MessageBox.Show("한 개의 행만 선택해주세요.");
                    return;
                }
                else if (dataGridView1.SelectedRows.Count == 1)
                {
                    selectedRow = dataGridView1.SelectedRows[0];
                }
                else
                {
                    MessageBox.Show("선택된 행이 없습니다.");
                    return;
                }
            }

            // employee_id를 가져옵니다.
            int employeeId = Convert.ToInt32(selectedRow.Cells["employee_id"].Value);

            // 수정할 값을 가져옵니다.
            string position = tb_position.Text;
            string employeeName = tb_username.Text;
            string level = tb_level.Text;
            string userId = tb_userid.Text;
            string password = tb_password.Text;
            string phoneNumber = tb_phonenumber.Text;
            string email = tb_email.Text;
            string address = tb_address.Text;

            byte[] imageData = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        Bitmap bmp = new Bitmap(pictureBox1.Image);
                        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75L);
                        ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                        EncoderParameters encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = qualityParam;
                        bmp.Save(ms, jpegCodec, encoderParams);
                        imageData = ms.ToArray();
                    }
                    catch (ExternalException ex)
                    {
                        MessageBox.Show("이미지를 저장하는 중 오류가 발생했습니다: " + ex.Message);
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
            }

            // MySQL 데이터베이스에서 데이터를 수정합니다.
            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();
                string updateQuery = "UPDATE employee SET position = @position, employee_name = @employee_name, level = @level, id = @id, pw = @pw, phonenumber = @phonenumber, email = @email, address = @address, image = @image WHERE employee_id = @employee_id";

                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    updateCommand.Parameters.AddWithValue("@position", position);
                    updateCommand.Parameters.AddWithValue("@employee_name", employeeName);
                    updateCommand.Parameters.AddWithValue("@level", level);
                    updateCommand.Parameters.AddWithValue("@id", userId);
                    updateCommand.Parameters.AddWithValue("@pw", password);
                    updateCommand.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    updateCommand.Parameters.AddWithValue("@email", email);
                    updateCommand.Parameters.AddWithValue("@address", address);

                    if (imageData != null)
                    {
                        updateCommand.Parameters.AddWithValue("@image", imageData);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@image", DBNull.Value);
                    }

                    updateCommand.ExecuteNonQuery();
                }
            }

            MessageBox.Show("선택된 행의 정보가 수정되었습니다.");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "select * from employee order by employee_id asc;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            /*while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["employee_id"], reader["position"], reader["employee_name"], reader["level"], reader["phonenumber"], reader["email"], reader["address"], reader["lastloginemployeecol"]);
                            }
                            */
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            List<int> employeeIds = new List<int>();

            // 체크된 행을 찾습니다.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                {
                    employeeIds.Add(Convert.ToInt32(row.Cells["employee_id"].Value));
                }
            }

            // 체크박스가 선택되지 않은 경우, 선택된 행 확인
            if (employeeIds.Count == 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    employeeIds.Add(Convert.ToInt32(selectedRow.Cells["employee_id"].Value));
                }
            }

            // 선택된 행이 없는 경우 메시지 표시
            if (employeeIds.Count == 0)
            {
                MessageBox.Show("삭제할 행을 선택해주세요.");
                return;
            }

            // 데이터베이스에서 삭제
            using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;

                    foreach (int id in employeeIds)
                    {
                        command.CommandText = $"DELETE FROM employee WHERE employee_id = {id}";
                        command.ExecuteNonQuery();
                    }
                }
            }

            // 삭제된 행을 DataGridView에서 제거
            foreach (int id in employeeIds)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["employee_id"].Value) == id)
                    {
                        dataGridView1.Rows.Remove(row);
                        break;
                    }
                }
            }

            MessageBox.Show("선택된 행이 삭제되었습니다.");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(User_info.User_connection))
                {
                    connection.Open();
                    string query = "select * from employee order by employee_id asc;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            /*while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["employee_id"], reader["position"], reader["employee_name"], reader["level"], reader["phonenumber"], reader["email"], reader["address"], reader["lastloginemployeecol"]);
                            }
                            */
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
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
