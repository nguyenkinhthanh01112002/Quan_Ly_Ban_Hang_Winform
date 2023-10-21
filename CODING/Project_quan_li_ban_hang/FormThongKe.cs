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
    public partial class frmThongKe : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet dataSet = null;
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnTop3_Count_Product_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server

            grp_ThongKe.Text = "Top 3 sản phẩm có doanh số cao nhất";
            // Câu lệnh SQL
            string sqlQuery = "SELECT TOP 3 sp.MaSp, sp.TenSp, SUM(hdct.SoLuong) AS 'SO LUONG', SUM(hdct.ThanhTien) AS 'Tong Tien' " +
                              "FROM HOADONCHITIET hdct INNER JOIN SANPHAM sp ON hdct.MaSp = sp.MaSp " +
                              "GROUP BY sp.MaSp, sp.TenSp " +
                              "ORDER BY [SO LUONG] DESC";

            // Tạo đối tượng SqlConnection và SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Tạo DataSet để lưu dữ liệu
                dataSet = new DataSet();

                // Mở kết nối và điền dữ liệu vào DataSet
                connection.Open();
                dataAdapter.Fill(dataSet, "Result");

                // Lấy dữ liệu từ DataSet
                DataTable dataTable = dataSet.Tables["Result"];

                // Hiển thị dữ liệu
                lsv_Show.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    string maSp = row["MaSp"].ToString();
                    string tenSp = row["TenSp"].ToString();
                    string soLuong = row["SO LUONG"].ToString();
                    string tongTien = row["Tong Tien"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSp);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(tongTien);
                    lsv_Show.Items.Add(item);
                }
                // Đóng kết nối
                connection.Close();
            }
        }

        private void btnTop3_Max_Rev_Click(object sender, EventArgs e)
        {
            grp_ThongKe.Text = "Top 3 sản phẩm có doanh thu cao nhất";
            string sqlQuery = "SELECT TOP 3 sp.MaSp, sp.TenSp, SUM(hdct.SoLuong) AS 'SO LUONG', SUM(ThanhTien) AS 'Tong Tien' " +
                              "FROM HOADONCHITIET hdct INNER JOIN SANPHAM sp ON hdct.MaSp = sp.MaSp " +
                              "GROUP BY sp.MaSp, sp.TenSp " +
                              "ORDER BY [Tong Tien] DESC";

            // Tạo đối tượng SqlConnection và SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Tạo DataSet để lưu dữ liệu
                dataSet = new DataSet();

                // Mở kết nối và điền dữ liệu vào DataSet
                connection.Open();
                dataAdapter.Fill(dataSet, "Result");

                // Lấy dữ liệu từ DataSet
                DataTable dataTable = dataSet.Tables["Result"];

                // Hiển thị dữ liệu
                lsv_Show.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    string maSp = row["MaSp"].ToString();
                    string tenSp = row["TenSp"].ToString();
                    string soLuong = row["SO LUONG"].ToString();
                    string tongTien = row["Tong Tien"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSp);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(tongTien);
                    lsv_Show.Items.Add(item);
                }
                // Đóng kết nối
                connection.Close();
            }
        }

        private void btnTop3_Min_Count_Product_Click(object sender, EventArgs e)
        {
            grp_ThongKe.Text = "Top 3 sản phẩm có doanh số thấp nhất";
            string sqlQuery = "SELECT TOP 3 sp.MaSp, sp.TenSp, SUM(hdct.SoLuong) AS 'SO LUONG', SUM(ThanhTien) AS 'Tong Tien' " +
                              "FROM HOADONCHITIET hdct INNER JOIN SANPHAM sp ON hdct.MaSp = sp.MaSp " +
                              "GROUP BY sp.MaSp, sp.TenSp " +
                              "ORDER BY [SO LUONG] ASC";

            // Tạo đối tượng SqlConnection và SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Tạo DataSet để lưu dữ liệu
                dataSet = new DataSet();

                // Mở kết nối và điền dữ liệu vào DataSet
                connection.Open();
                dataAdapter.Fill(dataSet, "Result");

                // Lấy dữ liệu từ DataSet
                DataTable dataTable = dataSet.Tables["Result"];

                // Hiển thị dữ liệu
                lsv_Show.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    string maSp = row["MaSp"].ToString();
                    string tenSp = row["TenSp"].ToString();
                    string soLuong = row["SO LUONG"].ToString();
                    string tongTien = row["Tong Tien"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSp);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(tongTien);
                    lsv_Show.Items.Add(item);
                }
                // Đóng kết nối
                connection.Close();
            }
        }

        private void btnTop3_Min_Rev_Click(object sender, EventArgs e)
        {
            grp_ThongKe.Text = "Top 3 sản phẩm có doanh thu thấp nhất";
            string sqlQuery = "SELECT TOP 3 sp.MaSp, sp.TenSp, SUM(hdct.SoLuong) AS 'SO LUONG', SUM(ThanhTien) AS 'Tong Tien' " +
                              "FROM HOADONCHITIET hdct INNER JOIN SANPHAM sp ON hdct.MaSp = sp.MaSp " +
                              "GROUP BY sp.MaSp, sp.TenSp " +
                              "ORDER BY [Tong Tien] ASC";

            // Tạo đối tượng SqlConnection và SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Tạo DataSet để lưu dữ liệu
                dataSet = new DataSet();

                // Mở kết nối và điền dữ liệu vào DataSet
                connection.Open();
                dataAdapter.Fill(dataSet, "Result");

                // Lấy dữ liệu từ DataSet
                DataTable dataTable = dataSet.Tables["Result"];

                // Hiển thị dữ liệu
                lsv_Show.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    string maSp = row["MaSp"].ToString();
                    string tenSp = row["TenSp"].ToString();
                    string soLuong = row["SO LUONG"].ToString();
                    string tongTien = row["Tong Tien"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSp);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(tongTien);
                    lsv_Show.Items.Add(item);
                }
                // Đóng kết nối
                connection.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
