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
using System.Web.Hosting;
using System.Windows.Forms;

namespace Project_quan_li_ban_hang
{
    public partial class frmLogin : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            // Tạo một DataTable để lưu trữ dữ liệu từ bảng NHANVIEN
            DataTable nhanvienTb = new DataTable();

            // Tạo truy vấn SQL để lấy dữ liệu từ bảng NHANVIEN
            string sqlQuery = "select * from Employees";

            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu và điền vào DataTable
            adapter = new SqlDataAdapter(sqlQuery, sqlCon);
            adapter.Fill(nhanvienTb);
            string userInputPassword = txtMatKhau.Text.Trim().ToString();
            string inputPasswordHash = ComputeSha256Hash(userInputPassword);
            bool check = false;
            
            foreach (DataRow row in nhanvienTb.Rows)
            {
                string email = row["Email"].ToString().Trim();
                string savedPassword = row["PasswordHash"].ToString();
                // Bây giờ bạn có thể làm gì đó với giá trị email
                if (email.ToLower().Equals(txtEmail.Text.Trim().ToLower()))
                {
                    if(savedPassword == inputPasswordHash)
                    {
                        check = true;
                        break;
                    }                      
                }
            }
           if(check == true)
            {
                string email = txtEmail.Text.Trim().ToString();
                MessageBox.Show("Logined successfully","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                try
                {
                    // Tạo kết nối SQL
                    using (SqlConnection connection = new SqlConnection(strCon))
                    {
                        connection.Open();

                        // Tạo một đối tượng SqlDataAdapter để lấy dữ liệu từ bảng "Gmail_Nv"
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Gmail_Nv", connection);
                        
                        // Tạo một đối tượng DataTable để lưu trữ dữ liệu
                        DataTable dataTable = new DataTable();

                        // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                        adapter.Fill(dataTable);

                        // Thêm dữ liệu mới vào DataTable
                        DataRow newRow = dataTable.NewRow();
                        newRow["gmail"] = email;
                        dataTable.Rows.Add(newRow);
                        SqlCommandBuilder buider = new SqlCommandBuilder(adapter);
                        // Cập nhật dữ liệu trong cơ sở dữ liệu bằng cách sử dụng SqlDataAdapter
                        adapter.Update(dataTable);
                        frmSanPham frmSp = new frmSanPham();
                        frmSp.Show();
                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message,"Nofitication",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Email hoac mat khau dang nhap khong dung","Notification",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

      

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblQuenMk_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn cần nhập email để khôi phục lại mật khẩu", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
