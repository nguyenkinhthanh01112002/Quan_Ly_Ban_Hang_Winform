using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public frmSanPhamKhachHang()
        {
            InitializeComponent();
        }

        private void frmSanPhamKhachHang_Load(object sender, EventArgs e)
        {
            grpCtdh.Visible = false;
            LoadDssp();
        }
        private void  LoadDssp()
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
        private void Load_FoundSp(string tenSp)
        {
            // Thay thế bằng chuỗi kết nối thực tế của bạn
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo câu truy vấn SQL SELECT dựa trên tên nhân viên
                string sqlSelect = "SELECT * FROM SANPHAM WHERE TenSp LIKE @TenSp";

                // Tạo đối tượng SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);

                // Định nghĩa tham số
                adapter.SelectCommand.Parameters.AddWithValue("@TenSp", "%" + tenSp + "%"); // Tìm tất cả nhân viên có tên chứa chuỗi tìm kiếm

                // Tạo DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                adapter.Fill(dataTable);

                // Hiển thị kết quả tìm kiếm trong giao diện người dùng (ví dụ: trong một DataGridView)
                lsvDssp.Items.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string maSp = dr["MaSp"].ToString();
                    string tenSP = dr["TenSp"].ToString();
                    string soLuong = dr["SoLuong"].ToString();              
                    string donGiaBan = dr["DonGiaBan"].ToString();              
                    string ghiChu = dr["GhiChu"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSP);
                    item.SubItems.Add(soLuong);                  
                    item.SubItems.Add(donGiaBan);              
                    item.SubItems.Add(ghiChu);
                    lsvDssp.Items.Add(item);
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSp = txtTkspkh.Text.Trim().ToString();
            if (tenSp.Length == 0)
            {
                lsvDssp.Items.Clear();
                return;
            }
            Load_FoundSp(tenSp);
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
        int slSpTt = 0;
        private void lsvDssp_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpCtdh.Visible = true;
            if(lsvDssp.SelectedItems.Count == 0) { return; }
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

        private void btnSigup_Click(object sender, EventArgs e)
        {

        }
    }
}
