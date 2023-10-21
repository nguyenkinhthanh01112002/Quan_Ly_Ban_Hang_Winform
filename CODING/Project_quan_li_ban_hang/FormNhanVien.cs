using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_quan_li_ban_hang
{

    public partial class frmNhanVien : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        List<NhanVien> listNv = null;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            NhanVienRepository nhanVienRepository = new NhanVienRepository(strCon);
            listNv = nhanVienRepository.GetEmployees();
            Load_Dssv();
        }
        private void Load_Dssv()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            string cmd = "select * from Employees";
            adapter = new SqlDataAdapter(cmd, sqlCon);
            DataTable tblNv = new DataTable();
            adapter.Fill(tblNv);
            lsvDssv.Items.Clear();
            foreach (DataRow dr in tblNv.Rows)
            {
                string maNV = dr["MaNV"].ToString();
                string tenNV = dr["HoTen"].ToString();
                string diaChi = dr["DiaChi"].ToString();
                string vaiTro = dr["RoleId"].ToString();
                string tinhTrang = dr["TinhTrang"].ToString();
                string email = dr["Email"].ToString();
                ListViewItem item = new ListViewItem(maNV);
                item.SubItems.Add(tenNV);
                item.SubItems.Add(diaChi);
                item.SubItems.Add(vaiTro);
                item.SubItems.Add((tinhTrang));
                item.SubItems.Add(email);
                lsvDssv.Items.Add(item);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtEmail.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            radHd.Checked = false;
            radNhd.Checked = false;
            radQt.Checked = false;
            radNv.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
            bool check = true;
            string email = txtEmail.Text;
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChi.Text;
            if (email.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtEmail, "Email không được bỏ trống");
            }
            else
            {

                check = kt.IsValidEmail(email);
                if (check)
                {
                    NhanVien existingEmployee = listNv.FirstOrDefault(nv => string.Equals(nv.email, email, StringComparison.OrdinalIgnoreCase));

                    if (existingEmployee != null)
                    {
                        errorProvider1.SetError(txtEmail, "Email bạn nhập đã thực sự tồn tại");
                        check = false;
                    }
                    else
                    {
                        check = kt.IsNameValid(tenNV);
                        if (check)
                        {
                            check = kt.IsAddressValid(diaChi);
                            if (check)
                            {
                                if (radHd.Checked == false && radNhd.Checked == false)
                                {
                                    errorProvider1.SetError(radHd, "Tình trạng nhân viên không được bỏ trống");
                                }
                                else
                                {
                                    byte tinhTrang = radHd.Checked ? (byte)1 : (byte)0;
                                    if (radQt.Checked == false && radNv.Checked == false)
                                    {
                                        errorProvider1.SetError(radNv, "Vai trò nhân viên không được bỏ trống");
                                    }
                                    else
                                    {
                                        string vaiTro = string.Empty;
                                        if (radNv.Checked)
                                        {
                                            vaiTro = "nvien";
                                        }
                                        else
                                        {
                                            vaiTro = "admin";
                                        }
                                        using (SqlConnection connection = new SqlConnection(strCon))
                                        {
                                            connection.Open();

                                            // Tạo một đối tượng SqlDataAdapter để thêm dữ liệu vào bảng Employees
                                            adapter = new SqlDataAdapter();

                                            // Tạo truy vấn SQL INSERT
                                            string sqlInsert = "INSERT INTO Employees (Email, DiaChi, RoleId, TinhTrang, PasswordHash,HoTen) " +
                                                               "VALUES (@Email, @DiaChi, @RoleId, @TinhTrang, @PasswordHash,@HoTen)";

                                            // Tạo một đối tượng SqlCommand
                                            SqlCommand cmd = new SqlCommand(sqlInsert, connection);
                                            string password = GenerateRandomPassword(5);
                                            string inputPasswordHash = ComputeSha256Hash(password);


                                            // Thay thế các tham số trong truy vấn với giá trị cụ thể
                                            cmd.Parameters.AddWithValue("@Email", email);
                                            cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                                            cmd.Parameters.AddWithValue("@RoleId", vaiTro); // Thay thế bằng vai trò thực tế
                                            cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang); // Thay thế bằng tình trạng thực tế
                                            cmd.Parameters.AddWithValue("@PasswordHash", inputPasswordHash);
                                            cmd.Parameters.AddWithValue("@HoTen", txtTenNV.Text.Trim());// Thay thế bằng giá trị băm thực tế

                                            // Gán đối tượng SqlCommand cho SqlDataAdapter
                                            adapter.InsertCommand = cmd;

                                            // Thực hiện truy vấn INSERT và kiểm tra số dòng ảnh hưởng
                                            int kq = adapter.InsertCommand.ExecuteNonQuery();

                                            if (kq > 0)
                                            {
                                                MessageBox.Show("Bạn đã thêm nhân viên thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Load_Dssv();
                                                SendPasswordEmail(email, password);
                                                MessageBox.Show("Mật khẩu mới đẫ được gửi tới email: " + email);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Têm nhân viên không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được bỏ trống");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtTenNV, "Tên bạn vừa nhập không hợp lệ");
                        }
                    }

                }
                else
                {
                    errorProvider1.SetError(txtEmail, "Địa chỉ email bạn vừa nhập không hợp lệ");
                }

            }



        }
        // kiểm tra ngoại lệ tên
        public bool IsNameValid(string name)
        {
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    return false; // Tên chứa ít nhất một số
                }
            }
            return true; // Tên không chứa số
        }

        static string GenerateRandomPassword(int length)
        {
            // Chuỗi ký tự chứa các chữ số từ 0 đến 9
            string digits = "0123456789";
            Random random = new Random();
            char[] passwordChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                // Chọn ngẫu nhiên một ký tự từ chuỗi digits và thêm vào mật khẩu
                int index = random.Next(0, digits.Length);
                passwordChars[i] = digits[index];
            }

            // Chuyển mảng ký tự thành chuỗi và trả về
            return new string(passwordChars);
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        static void SendPasswordEmail(string toEmail, string password)
        {
            try
            {
                string fromMail = "nguyenkinhthanh11@gmail.com";
                string fromPassword = "rrsj izbc pxnl vuuk";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Test Subject";
                message.To.Add(new MailAddress(toEmail));
                message.Body = "Mật khẩu mới của bạn là: " + password;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
                MessageBox.Show("Vui lòng kiểm tra email của bạn để xem mật khẩu", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string maNV = "";
        private void lsvDssv_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (lsvDssv.SelectedItems.Count == 0) { return; }
            ListViewItem row = lsvDssv.SelectedItems[0];
            maNV = row.SubItems[0].Text.Trim().ToString();
            txtTenNV.Text = row.SubItems[1].Text;
            txtEmail.Text = row.SubItems[5].Text;
            txtDiaChi.Text = row.SubItems[2].Text;
            string vaiTro = row.SubItems[3].Text.Trim().ToString();
            if (vaiTro.Equals("admin"))
            {
                radQt.Checked = true;
            }
            else
            {
                radNv.Checked = true;
            }
            byte tinhTrang = byte.Parse(row.SubItems[4].Text);
            if (tinhTrang == 1)
            {
                radHd.Checked = true;
            }
            else
            {
                radHd.Checked = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
            if (maNV.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin bạn muốn cập nhật", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo truy vấn SQL SELECT
                string sqlSelect = "SELECT * FROM Employees WHERE MaNV = @MaNV";

                // Tạo một đối tượng SqlCommand
                using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, connection))
                {
                    // Thay thế các tham số trong truy vấn với giá trị cụ thể
                    cmdSelect.Parameters.AddWithValue("@MaNV", maNV); 
                    // Tạo một đối tượng SqlDataAdapter và DataTable
                    adapter = new SqlDataAdapter(cmdSelect);
                    DataTable dataTable = new DataTable();

                    // Tạo một đối tượng SqlCommandBuilder để tạo các lệnh tự động
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Kiểm tra xem có dòng dữ liệu nào được tìm thấy
                    if (dataTable.Rows.Count > 0)
                    {
                        // Thay đổi giá trị của PasswordHash trong DataTable
                        bool check = kt.IsValidEmail(txtEmail.Text);
                        if (check)
                        {
                            if (dataTable.Rows[0]["Email"].ToString() == txtEmail.Text.Trim().ToString())

                            {
                              
                                dataTable.Rows[0]["Email"] = txtEmail.Text.Trim().ToString();
                            }
                            else
                            {
                                NhanVien existingEmployee = listNv.FirstOrDefault(nv => string.Equals(nv.email, txtEmail.Text.Trim().ToString(), StringComparison.OrdinalIgnoreCase));

                                if (existingEmployee != null)
                                {
                                    check = false;
                                    errorProvider1.SetError(txtEmail, "Email bạn nhập đã thực sự tồn tại");
                                   
                                }
                                else
                                {
                                    dataTable.Rows[0]["Email"] = txtEmail.Text;
                                }
                            }
                            
                            if (check)
                            {
                                check = kt.IsNameValid(txtTenNV.Text);
                                if(check)
                                {
                                    dataTable.Rows[0]["HoTen"] = txtTenNV.Text.Trim().ToString();
                                    check = kt.IsAddressValid(txtDiaChi.Text.ToString());
                                    if (check)
                                    {
                                        dataTable.Rows[0]["DiaChi"] = txtDiaChi.Text.Trim().ToString() ;
                                        if (radQt.Checked)
                                        {
                                            dataTable.Rows[0]["RoleId"] = "admin";
                                        }
                                        else
                                        {
                                            dataTable.Rows[0]["RoleId"] = "nvien";
                                        }
                                        if (radHd.Checked)
                                        {
                                            dataTable.Rows[0]["TinhTrang"] = 1;
                                        }
                                        else
                                        {
                                            dataTable.Rows[0]["TinhTang"] = 0;

                                        }
                                 
                                    }
                                    else
                                    {
                                        check = false;
                                        errorProvider1.SetError(txtDiaChi, "Địa chỉ bạn vừa nhập không hợp lệ");
                                    }
                                }
                                else
                                {
                                    check = false;
                                    errorProvider1.SetError(txtTenNV, "Họ tên bạn vừa nhập không hợp lệ");
                                }
                                if (check)
                                {
                                    int kq = adapter.Update(dataTable);
                                    if(kq > 0)
                                    {
                                        MessageBox.Show("Dữ liệu đã được cập nhật thành cônng","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                        Load_Dssv();

                                    }
                                    else {
                                        MessageBox.Show("Dữ liệu đã cập nhật thất bại", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                                    }
                                }
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtEmail, "Địa chỉ email bạn vừa nhập không hợp lệ");

                        }

                        // Cập nhật dữ liệu trong cơ sở dữ liệu bằng cách gọi Update trên SqlDataAdapter
                     
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(maNV.Length == 0)
            {
                return;
            }
          

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo câu truy vấn SQL DELETE dựa trên MaNV
                string sqlDelete = "DELETE FROM Employees WHERE MaNV = @MaNV";

                // Tạo đối tượng SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Định nghĩa câu lệnh DELETE
                adapter.DeleteCommand = new SqlCommand(sqlDelete, connection);

                // Định nghĩa tham số
                adapter.DeleteCommand.Parameters.Add("@MaNV", SqlDbType.VarChar, 22).Value = maNV; // Thay thế "NV123" bằng MaNV cần xóa

                // Thực hiện câu lệnh DELETE
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được xoá thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Load_Dssv();
                    }
                    else
                    {
                        MessageBox.Show("Xoá dữ liệu không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
               

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Mời bạn tiếp tục sử dụng dịch vụ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Load_FoundNv(string tenNv)
        {
           // Thay thế bằng chuỗi kết nối thực tế của bạn
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo câu truy vấn SQL SELECT dựa trên tên nhân viên
                string sqlSelect = "SELECT * FROM Employees WHERE HoTen LIKE @TenNV";

                // Tạo đối tượng SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);

                // Định nghĩa tham số
                adapter.SelectCommand.Parameters.AddWithValue("@TenNV", "%" + tenNv + "%"); // Tìm tất cả nhân viên có tên chứa chuỗi tìm kiếm

                // Tạo DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                adapter.Fill(dataTable);

                // Hiển thị kết quả tìm kiếm trong giao diện người dùng (ví dụ: trong một DataGridView)
                lsvDssv.Items.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string maNV = dr["MaNV"].ToString();
                    string tenNV = dr["HoTen"].ToString();
                    string diaChi = dr["DiaChi"].ToString();
                    string vaiTro = dr["RoleId"].ToString();
                    string tinhTrang = dr["TinhTrang"].ToString();
                    string email = dr["Email"].ToString();
                    ListViewItem item = new ListViewItem(maNV);
                    item.SubItems.Add(tenNV);
                    item.SubItems.Add(diaChi);
                    item.SubItems.Add(vaiTro);
                    item.SubItems.Add((tinhTrang));
                    item.SubItems.Add(email);
                    lsvDssv.Items.Add(item);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenNv = txtTknv.Text.Trim().ToString();
            if(tenNv.Length == 0)
            {
                return;
            }
            Load_FoundNv(txtTknv.Text);
        }
    }
}
