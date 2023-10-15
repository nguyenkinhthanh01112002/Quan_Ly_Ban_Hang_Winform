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
    public partial class FormChiTietDonHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        int slSpTt = 0;
        public FormChiTietDonHang()
        {
            InitializeComponent();
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
            if (lsvDssp.SelectedItems.Count == 0) { return; }
            ListViewItem items = lsvDssp.SelectedItems[0];
            string foundMsp = items.SubItems[0].Text.Trim().ToString();
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
            }
        }
    }
}
