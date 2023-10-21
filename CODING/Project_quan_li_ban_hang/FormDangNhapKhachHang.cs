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
    public partial class frmDangNhapKhachHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        string maKH = "";
        public frmDangNhapKhachHang()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool check = Check_Tk(txtEmail.Text.Trim().ToString(), txtMatKhau.Text.Trim().ToString());
            if (check)
            {
                MessageBox.Show("Logined successfully");
                this.Hide();
                frmSanPhamKhachHang sanPhamKhachHang = new frmSanPhamKhachHang(maKH);
                sanPhamKhachHang.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại email hoặc mật khẩu đăng nhập của bạn");
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
        private bool Check_Tk(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Câu lệnh SQL để truy vấn dữ liệu từ bảng GioHang
                string query = "SELECT * FROM KhachHangOnline";

                // Tạo một SqlDataAdapter để lấy dữ liệu từ câu lệnh SQL
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Tạo một DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ bảng vào biến DataTable
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    maKH = Convert.ToString(row["ID"]);
                    string emailTable = Convert.ToString(row["Email"]);
                    string passWordTable = Convert.ToString(row["PasswordHash"]);
                    if (emailTable.ToLower().Equals(email.ToLower()) && passWordTable.ToLower().Equals(ComputeSha256Hash(password).ToLower()))
                    {
                        return true;
                    }

                }
                return false;
                // Giờ bạn có thể sử dụng biến dataTable để làm việc với dữ liệu từ bảng GioHang
            }
        }

        private void frmDangNhapKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void lblQuenMk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn cần nhập email để khôi phục lại mật khẩu", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmXnmkKh xnmk = new frmXnmkKh();
            this.Hide();
            xnmk.Show();
        }

       
    }
}
