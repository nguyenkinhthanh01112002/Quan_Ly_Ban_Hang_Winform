﻿using System;
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
using System.Web.Configuration;
using System.Runtime.Remoting.Messaging;

namespace Project_quan_li_ban_hang
{
    public partial class frmXnmk : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public frmXnmk()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void btnSend_Click(object sender, EventArgs e)
        {
            txtShowInvEmail.Visible = false;
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            DataTable nhanvienTb = new DataTable();

            // Tạo truy vấn SQL để lấy dữ liệu từ bảng NHANVIEN
            string sqlQuery = "select * from Employees";

            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu và điền vào DataTable
            adapter = new SqlDataAdapter(sqlQuery, sqlCon);

            SqlCommandBuilder buider = new SqlCommandBuilder(adapter);
            adapter.Fill(nhanvienTb);


            string email = txtEmail.Text.Trim().ToString();
            KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
            bool check = kt.IsValidEmail(email);
            if (check)
            {
                foreach (DataRow row in nhanvienTb.Rows)
                {
                    string savedEmail = row["Email"].ToString().Trim();

                    // Bây giờ bạn có thể làm gì đó với giá trị email
                    if (email.ToLower().Equals(savedEmail.ToLower()))
                    {
                        string password = GenerateRandomPassword(5);
                        string inputPasswordHash = ComputeSha256Hash(password);
                        SendPasswordEmail(email, password);
                        row["PasswordHash"] = inputPasswordHash;
                        int kq = adapter.Update(nhanvienTb);
                        if (kq > 0)
                        {
                            MessageBox.Show("Mật khẩu mới đã được gủi tới địa chỉ email: " + email);
                            frmLogin login = new frmLogin();
                            this.Hide();
                            login.Show();
                        }

                    }
                }
              
            }
            else
            {
                txtShowInvEmail.Visible = true;
               
            }
        }
        // ham random mk
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
        // ma hoa
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
        // send email password
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
                message.Body = "Mật khẩu mới của bạn là: "+password;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
                MessageBox.Show("Vui lòng kiểm tra email của bạn để xem mật khẩu","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmXnmk_Load(object sender, EventArgs e)
        {
            txtShowInvEmail.Visible = false;
        }
    }
}
