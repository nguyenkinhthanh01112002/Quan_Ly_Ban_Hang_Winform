using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_quan_li_ban_hang
{
    public partial class frmGioHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        string maHang = "";
        int soLuong = 0;
        private int GetRowCountInGioHang()
        {
            int rowCount = 0;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string countQuery = "SELECT COUNT(*) FROM GioHang";

                using (SqlCommand cmd = new SqlCommand(countQuery, connection))
                {
                    rowCount = (int)cmd.ExecuteScalar();
                }
            }

            return rowCount;
        }
        public frmGioHang(string maHang,int soLuongMua)
        {
            
            InitializeComponent();
            this.maHang = maHang;
            this.soLuong = soLuongMua;
            int kq = GetRowCountInGioHang();
            if(kq == 0)
            {
                lsv_GioHang.Items.Clear();
            }
        }

        private void frmGioHang_Load(object sender, EventArgs e)
        {
            if (this.soLuong == 0)
            {
                return;
            }
           
            if (Check_Unique_MaHang())
            {
                UpdateGioHangTable();
            }
            else
            {
                InsertGioHangTable();
            }
            
            Load_Dsgh();
        }
        private void Load_Dsgh()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            string cmd = "\r\nselect * from GioHang";
            adapter = new SqlDataAdapter(cmd, sqlCon);
            DataTable tblSp = new DataTable();
            adapter.Fill(tblSp);
            lsv_GioHang.Items.Clear();
            foreach (DataRow dr in tblSp.Rows)
            {
                string maSp = dr["MaSp"].ToString();
                string tenSp = dr["TenHang"].ToString();
                string soLuong = dr["SoLuong"].ToString();
                string donGiaBan = dr["DonGia"].ToString();
                string thanhTien = dr["ThanhTien"].ToString();
                ListViewItem item = new ListViewItem(maSp);
                item.SubItems.Add(tenSp);
                item.SubItems.Add(soLuong);
                item.SubItems.Add(donGiaBan);
                item.SubItems.Add(thanhTien);
                lsv_GioHang.Items.Add(item);
            }
        }
        private int GetUpdatedId()
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string query = "SELECT MAX(Id) AS LatestMaHoaDon FROM HoaDon";
                SqlCommand cmd = new SqlCommand(query, connection);

                // Execute the query and retrieve the result
                int latestMaHoaDon = (int)cmd.ExecuteScalar();
                return latestMaHoaDon;   
            }
        }
        private void InsertGioHangTable()
        {
            if (Check_Unique_MaHang()==false)
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                string cmd = "\r\nselect * from SANPHAM WHERE MaSp = @maSp";
                adapter = new SqlDataAdapter(cmd, sqlCon);
                adapter.SelectCommand.Parameters.AddWithValue("@maSp", maHang);
                DataTable tblSp = new DataTable();
                adapter.Fill(tblSp);

                foreach (DataRow dr in tblSp.Rows)
                {
                    string maSp = dr["MaSp"].ToString();
                    string tenSp = dr["TenSp"].ToString();                
                    string donGiaBan = dr["DonGiaBan"].ToString();                   
                    using (SqlConnection connection = new SqlConnection(strCon))
                    {
                        connection.Open();

                        // Dữ liệu cần chèn


                        // Câu lệnh SQL chèn dữ liệu vào bảng GioHang
                        string insertQuery = "INSERT INTO GioHang (MaSp, TenHang, SoLuong, DonGia, ThanhTien) VALUES (@MaHang, @TenHang, @SoLuong, @DonGia, @ThanhTien)";

                        // Tạo và thực thi SqlCommand
                        using (SqlCommand cmd_2 = new SqlCommand(insertQuery, connection))
                        {
                            cmd_2.Parameters.AddWithValue("@MaHang", maSp);
                            cmd_2.Parameters.AddWithValue("@TenHang", tenSp);
                            cmd_2.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd_2.Parameters.AddWithValue("@DonGia", double.Parse(donGiaBan));
                            cmd_2.Parameters.AddWithValue("@ThanhTien", double.Parse(donGiaBan) * soLuong);

                            int rowsAffected = cmd_2.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thanh cong");
                            }
                            else
                            {
                                MessageBox.Show("That bai");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn đã thêm sản phẩm vào giỏ hàng, bạn có thể cập nhật số lượng muốn mua");
            }
        }
        private void UpdateGioHangTable()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            string cmd = "\r\nselect * from SANPHAM WHERE MaSp = @maSp";
            adapter = new SqlDataAdapter(cmd, sqlCon);
            adapter.SelectCommand.Parameters.AddWithValue("@maSp", maHang);
            DataTable tblSp = new DataTable();
            adapter.Fill(tblSp);

            foreach (DataRow dr in tblSp.Rows)
            {
                string maSp = dr["MaSp"].ToString();
                string tenSp = dr["TenSp"].ToString();
                string donGiaBan = dr["DonGiaBan"].ToString();
                if (Check_Unique_MaHang())
                {
                    using (SqlConnection connection = new SqlConnection(strCon))
                    {
                        connection.Open();

                        // Create an UPDATE SQL query to update the record with MaHang
                        string updateQuery = "UPDATE GioHang SET SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien WHERE MaSp = @MaHang";

                        // Create and execute the SqlCommand
                        using (SqlCommand cmd_2 = new SqlCommand(updateQuery, connection))
                        {
                            cmd_2.Parameters.AddWithValue("@MaHang", maHang);
                            cmd_2.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd_2.Parameters.AddWithValue("@DonGia", double.Parse(donGiaBan));
                            cmd_2.Parameters.AddWithValue("@ThanhTien", double.Parse(donGiaBan) * soLuong);

                            int rowsAffected = cmd_2.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật thành công");
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm với MaHang này trong giỏ hàng.");
                }

            }
        }
        private bool Check_Unique_MaHang()
        {
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
                foreach (DataRow row in dataTable.Rows)
                {
                    string maHangTrongBang = Convert.ToString(row["MaSp"]);

                    if (maHangTrongBang.Equals(maHang))
                    {
                        // Nếu tìm thấy giá trị trùng, đặt biến timThay thành true và thoát khỏi vòng lặp.
                        return true;
               
                    }
                }
                return false;
                // Giờ bạn có thể sử dụng biến dataTable để làm việc với dữ liệu từ bảng GioHang
            }
        }
    }
}
