using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_quan_li_ban_hang
{
    public partial class frmDangKy : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public frmDangKy()
        {
            InitializeComponent();
        }
        KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           errorProvider1.Clear();
           bool check = kt.IsValidEmail(txtEmail.Text.Trim().ToString());
            if (check)
            {
              check =  Check_Unique_Email(txtEmail.Text);
                if (check == false)
                {
                    check = kt.IsNameValid(txtTdn.Text.Trim().ToString());
                    if (check)
                    {
                        check = kt.IsValidPassword(txtMk.Text.Trim().ToString());
                        if (check)
                        {
                            if(txtMk.Text == txtXnmk.Text)
                            {
                                using (SqlConnection connection = new SqlConnection(strCon))
                                {
                                    connection.Open();

                                    // Câu lệnh SQL để chèn dữ liệu vào bảng KhachHangOnline
                                    string insertQuery = "INSERT INTO KhachHangOnline (TenKhachHang, Email, PasswordHash, RoleID) " +
                                                         "VALUES (@TenKhachHang, @Email, @PasswordHash, @RoleID)";

                                    // Tạo và thực thi SqlCommand
                                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@TenKhachHang", txtTdn.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@PasswordHash", ComputeSha256Hash(txtMk.Text.Trim().ToString()));
                                        cmd.Parameters.AddWithValue("@RoleID", "khang"); // Thay ROLE1 bằng giá trị RoleID thích hợp

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Bạn đã đăng ký thành công","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                            frmSanPhamKhachHang sanPKh = new frmSanPhamKhachHang("");
                                            this.Hide();
                                            sanPKh.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Đăng ký không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng kiểm tra lại mật khẩu của bạn", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtMk, "Mật khẩu bắt buộc phải có 5 kí tự");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtTdn,"Tên bạn vừa nhập không hợp lệ");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtEmail, "Email bạn vừa nhập đã được sử dụng");
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, "Email bạn vừa nhập không hợp lệ");
            }
        }
        private bool Check_Unique_Email(string inPutEmail)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Câu lệnh SQL để truy vấn dữ liệu từ bảng GioHang
                string query = "SELECT * FROM KhachHangOnLine";

                // Tạo một SqlDataAdapter để lấy dữ liệu từ câu lệnh SQL
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Tạo một DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ bảng vào biến DataTable
                adapter.Fill(dataTable);
             
                // Sau khi đã lấy dữ liệu vào biến dataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    string email = Convert.ToString(row["Email"]);

                    if (email.Trim().ToLower().Equals(inPutEmail.Trim().ToString()))
                    {
                        // Nếu tìm thấy giá trị trùng, đặt biến timThay thành true và thoát khỏi vòng lặp.
                        return true;
                    }
                }
                return false;               
            }

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
        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắc muốn thoát không","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmSanPhamKhachHang sanPhamKhachHang = new frmSanPhamKhachHang("");
                this.Hide();
                sanPhamKhachHang.Show();
            }
            else
            {
                txtEmail.Text = "";
                txtTdn.Text = "";
                txtMk.Text = "";
                txtXnmk.Text = "";
                MessageBox.Show("Bạn có thể tiếp tục hoàn thiện phần đăng ký");
            }
        }
    }
}
