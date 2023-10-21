using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Project_quan_li_ban_hang
{
    public partial class frmChiTietDonHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        int slSpTt = 0;
        string maSp = "";
        string maKH = "";
        int soLuongSpGioHang = 0;    
        public frmChiTietDonHang(string maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
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
            panel_new_GioHang.Controls.Add(childForm);
            panel_new_GioHang.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void FormKhachHangDaDangNhap_Load(object sender, EventArgs e)
        {
            grpCtdh.Visible = false;
            LoadDssp();
        }

        private void LoadDssp()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            string cmd = "\r\nselect * from SANPHAM";
            adapter = new SqlDataAdapter(cmd, sqlCon);
            DataTable tblSp = new DataTable();
            adapter.Fill(tblSp);
            lsvDssp.Items.Clear();
            foreach (DataRow dr in tblSp.Rows)
            {
                string maSp = dr["MaSp"].ToString();
                string tenSp = dr["TenSp"].ToString();
                string soLuong = dr["SoLuong"].ToString();
                string donGiaBan = dr["DonGiaBan"].ToString();
                string ghiChu = dr["GhiChu"].ToString();
                ListViewItem item = new ListViewItem(maSp);
                item.SubItems.Add(tenSp);
                item.SubItems.Add(soLuong);
                item.SubItems.Add(donGiaBan);
                item.SubItems.Add(ghiChu);
                lsvDssp.Items.Add(item);
            }
        }

        private void lsvDssp_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpCtdh.Visible = true;           
            if (lsvDssp.SelectedItems.Count == 0) { maSp = ""; return; }
            ListViewItem items = lsvDssp.SelectedItems[0];
            string foundMsp = items.SubItems[0].Text.Trim().ToString();
            maSp = foundMsp;
            string tenSp = items.SubItems[1].Text.Trim().ToString();
            string soLuong = items.SubItems[2].Text.Trim().ToString();
            string pathString = "";
            slSpTt = int.Parse(soLuong);
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                // Mã sản phẩm bạn muốn truy vấn
                string sqlQuery = "SELECT HinhAnh FROM SANPHAM WHERE MaSp = @MaSp";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@MaSp", SqlDbType.VarChar).Value = foundMsp;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pathString = reader["HinhAnh"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Hình ảnh đang gặp vấn đề", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                slSpTt = int.Parse(soLuong);
                if (File.Exists(pathString)) // Kiểm tra xem tệp hình ảnh có tồn tại hay không
                {
                    try
                    {
                        Image image = Image.FromFile(pathString); // Tạo đối tượng hình ảnh từ đường dẫn

                        pic_Ctdh.Image = image; // Gán hình ảnh cho PictureBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tệp hình ảnh không tồn tại.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
                int soLuongMua = int.Parse(lblSoLuong.Text);
                if (soLuongMua < slSpTt)
                {
                    soLuongMua++;
                    lblSoLuong.Text = soLuongMua.ToString();
                }
                else
                {
                    MessageBox.Show("Hiện tại sản phẩm của chúng tôi không đủ để đáp ứng nhu cầu của bạn");
                }
        }

        private void btnGiamU_Click(object sender, EventArgs e)
        {
            int giam = int.Parse(lblSoLuong.Text);
            giam--;
            if (giam >= 0)
            {
                lblSoLuong.Text = giam.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn số lượng sản phẩm bạn muốn mua");
            }
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if (maKH.Length == 0)
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản để có thể thêm sản phẩm vào giỏ hàng");
                lblSoLuong.Text = "1";
                return;
            }
            if (maSp.Length == 0) { lblSoLuong.Text = "1"; return; }
            soLuongSpGioHang = int.Parse(lblSoLuong.Text);
            lblSoLuong.Text = "1";
            OpenChildForm(new frmGioHang(maSp, soLuongSpGioHang));
        }
        private  int GetUpdatedHoaDon(HoaDon hoaDon)
        {
            int newMaHoaDon = 0;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string insertQuery = "INSERT INTO HoaDon (MaKh, NgayTaoHoaDon, TongTien) OUTPUT INSERTED.MaHd VALUES (@MaKh, @NgayTaoHoaDon, @TongTien);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaKh", hoaDon.MaKh);
                    cmd.Parameters.AddWithValue("@NgayTaoHoaDon", hoaDon.NgayTaoHoaDon);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                    // Execute the INSERT query and retrieve the new identity value (MaHoaDon)
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        newMaHoaDon = Convert.ToInt32(result);
                    }
                }
            }

            return newMaHoaDon;
        }
        private bool InsertHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            bool insertedSuccessfully = false;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string insertQuery = "INSERT INTO HoaDonChiTiet (MaHoaDon, MaSp, SoLuong, ThanhTien) VALUES (@MaHoaDon, @MaSp, @SoLuong, @ThanhTien)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", hoaDonChiTiet.MaHoaDon);
                    cmd.Parameters.AddWithValue("@MaSp", hoaDonChiTiet.MaSp);
                    cmd.Parameters.AddWithValue("@SoLuong", hoaDonChiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", hoaDonChiTiet.ThanhTien);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertedSuccessfully = true;
                    }
                }
            }

            return insertedSuccessfully;
        }
        private bool UpdateSoLuongInSanPham(string maSanPham, int newSoLuong)
        {

            bool updatedSuccessfully = false;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Retrieve the current SoLuong from the database
                string selectQuery = "SELECT SoLuong FROM SANPHAM WHERE MaSp = @MaSp";
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, connection))
                {
                    selectCmd.Parameters.AddWithValue("@MaSp", maSanPham);

                    int currentSoLuong = Convert.ToInt32(selectCmd.ExecuteScalar());

                    // Calculate the new SoLuong as the difference
                    int updatedSoLuong = currentSoLuong - newSoLuong;

                    // Update the SoLuong in the database
                    string updateQuery = "UPDATE SANPHAM SET SoLuong = @UpdatedSoLuong WHERE MaSp = @MaSp";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaSp", maSanPham);
                        cmd.Parameters.AddWithValue("@UpdatedSoLuong", updatedSoLuong);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            updatedSuccessfully = true;
                        }
                    }
                }
            }

            return updatedSuccessfully;
        }
        private bool DeleteItemFromGioHang()
        {
            bool deletedSuccessfully = false;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM GioHang";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        deletedSuccessfully = true;
                    }
                }
            }

            return deletedSuccessfully;
        }
    
    private void btnDatHang_Click(object sender, EventArgs e)
        {
            if(maKH.Length == 0)
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản để có thể thêm sản phẩm vào giỏ hàng");
                return;
            }
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaKh = maKH;
            hoaDon.NgayTaoHoaDon = DateTime.Now;
            hoaDon.TongTien = 0;
            int updatedHoaDon = GetUpdatedHoaDon(hoaDon);
            double tongHoaDon = 0;
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Câu lệnh SQL để truy vấn dữ liệu từ bảng GioHang
                string query = "SELECT * FROM GioHang";

                // Tạo một SqlDataAdapter để lấy dữ liệu từ câu lệnh SQL
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Tạo một DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ bảng vào biến DataTable
                adapter.Fill(dataTable);

                // Sau khi đã lấy dữ liệu vào biến dataTable
                bool check = false;
                foreach (DataRow row in dataTable.Rows)
                {
                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet
                    {
                        MaHoaDon = updatedHoaDon,
                        MaSp = row["MaSp"].ToString(),
                        SoLuong = int.Parse(row["SoLuong"].ToString()),
                        ThanhTien = double.Parse(row["ThanhTien"].ToString())
                    };
                    tongHoaDon += hoaDonChiTiet.ThanhTien;
                   check = InsertHoaDonChiTiet(hoaDonChiTiet);
                    if (check)
                    {
                        check = UpdateSoLuongInSanPham(row["MaSp"].ToString(), int.Parse(row["SoLuong"].ToString()));
                        if(check)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Cap nhat so luong san pham that bai");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Chen du lieu vao bang hoa don chi tiet that bai");
                    }
                }

                check = UpdateHoaDon(updatedHoaDon, tongHoaDon);
                if (check)
                {

                }
                else
                {
                    MessageBox.Show("Lỗi tạo hoá đơn");
                }
                check = DeleteItemFromGioHang();
                if(check)
                {
                    MessageBox.Show("Hoa don da duoc tao thanh cong");
                    LoadDssp();
                    grpCtdh.Visible = false; 
                    OpenChildForm(new frmGioHang(maSp,0));

                }
                else
                {
                    MessageBox.Show("Xoa du lieu gio hang that bai");
                }
            }
        }
        private bool UpdateHoaDon(int maHdToCapNhat, double newTongTien)
        {
            bool updatedSuccessfully = false;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string updateQuery = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHd = @MaHd";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaHd", maHdToCapNhat);
                    cmd.Parameters.AddWithValue("@TongTien", newTongTien);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        updatedSuccessfully = true;
                    }
                }
            }

            return updatedSuccessfully;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (maKH.Length == 0)
            {
                MessageBox.Show("Giỏ hàng hiện tại chưa có sản phẩm");
                lblSoLuong.Text = "1";
                return;
            }
            bool check = DeleteItemFromGioHang();
            if (check)
            {
                OpenChildForm(new frmGioHang(maKH,0));
                MessageBox.Show("Đơn hàng đã huỷ thành công");
            }
            else
            {
                MessageBox.Show("Huỷ thất bại");
            }
            lblSoLuong.Text = "1";
        }

        private void btn_ThemGioHang(object sender, MouseEventArgs e)
        {
            btnThemGioHang.BackColor = Color.Transparent;

        }

    
    }
}
