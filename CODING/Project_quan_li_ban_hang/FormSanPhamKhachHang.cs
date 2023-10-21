using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_quan_li_ban_hang
{
    public partial class frmSanPhamKhachHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        bool checkDn = false;
        string maKH = "";
        public frmSanPhamKhachHang(string maKhachHang)
        {
            InitializeComponent();
            this.maKH = maKhachHang;
        }
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void Add_Logout_Button()
        {
            Button logout_button = new Button();
            logout_button.Text = "Thoát"; // Đặt văn bản của nút là "Thoát"
            logout_button.Location = new Point(730,20);
            logout_button.Width = 100;
            logout_button.Height = 30;
            logout_button.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            logout_button.ForeColor = Color.Black;

            // Thiết lập nền trong suốt
            logout_button.FlatStyle = FlatStyle.Flat;
            logout_button.FlatAppearance.BorderSize = 0;
            logout_button.BackColor = Color.Transparent;

            // Tạo góc bo tròn cho nút
           
            logout_button.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, logout_button.Width, logout_button.Height, 10, 10));
            // Thêm sự kiện Click cho nút "Thoát"
            logout_button.Click += (sender, e) =>
            {
                // Đóng form con hiện tại khi nút "Thoát" được nhấp
                this.Hide();
                frmMenu frmMenu = new frmMenu();
                frmMenu.Show();
            };

            panel_heading.Controls.Add(logout_button);
        }
        private void frmSanPhamKhachHang_Load(object sender, EventArgs e)
        {
            if (maKH.Length != 0)
            {
                btnSigin.Visible = false;
                btnSigup.Visible = false;
                btnBack.Visible = false;
               Add_Logout_Button();
            }
            else
            {
                btnSigup.Visible = true;
                btnSigin.Visible = true;
                btnBack.Visible = true;  
            }
            OpenChildForm(new frmChiTietDonHang(maKH));
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPhamTimKiem(txtTkspkh.Text.Trim().ToString(),maKH));
            txtTksp.ResetText();
        }

        private void btnSigin_Click(object sender, EventArgs e)
        {
            frmDangNhapKhachHang dangNhap = new frmDangNhapKhachHang();
            this.Hide();
            dangNhap.Show();
        }

        private void btnSigup_Click(object sender, EventArgs e)
        {
            frmDangKy dangKy = new frmDangKy();
            this.Hide();
            dangKy.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }
    }
}
