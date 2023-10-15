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
using TheArtOfDevHtmlRenderer.Adapters;

namespace Project_quan_li_ban_hang
{
    public partial class frmSanPham : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        List<SanPham> listProducts = null;
        string maNV = "";
        KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
        string maSp = "";
        string folder = @"E:\ANH_DUANMAU";
        public frmSanPham()
        {
            InitializeComponent();
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            New_Data();
        }
        private void New_Data()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtSoLuong.Text = "";
            txtGhiChu.Text = "";
            pictureSp.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(pictureSp.Image != null)
            {
                string fname = txtMaHang.Text + ".jpg";
                
                string pathstring = System.IO.Path.Combine(folder, fname);
                SanPham sanPham = listProducts.FirstOrDefault(sp=>sp.MaSp==txtMaHang.Text.Trim());
                if (sanPham == null)
                {
                    bool check = kt.IsNameValid(txtTenHang.Text.Trim());
                    if (check)
                    {
                        check = kt.IsNumberProductValid(txtSoLuong.Text.Trim());
                        if (check)
                        {
                            check = kt.IsMoneyValid(txtDonGiaBan.Text);
                            if (check)
                            {
                                check = kt.IsMoneyValid(txtDonGiaNhap.Text);
                                if (check)
                                {
                                    check = kt.IsNameValid(txtTenHang.Text);
                                    if (check)
                                    {
                                        pictureSp.Image.Save(pathstring);
                                        using (SqlConnection connection = new SqlConnection(strCon))
                                        {
                                            connection.Open();

                                            // Tạo một đối tượng SqlCommand để chèn dữ liệu vào bảng SanPham
                                            using (SqlCommand cmd = new SqlCommand())
                                            {
                                                cmd.Connection = connection;
                                                cmd.CommandText = "INSERT INTO SanPham (MaSp,TenSp, SoLuong, DonGiaNhap,DonGiaBan,HinhAnh,GhiChu,MaNV) " +
                                                                 "VALUES (@MaSp,@TenSp, @SoLuong, @DonGiaNhap,@DonGiaBan, @HinhAnh,@GhiChu, @MaNV)";

                                                // Thay thế các tham số với giá trị thực tế
                                                cmd.Parameters.AddWithValue("@MaSp", txtMaHang.Text.Trim());
                                                cmd.Parameters.AddWithValue("@TenSp", txtTenHang.Text.Trim());
                                                cmd.Parameters.AddWithValue("@SoLuong",int.Parse( txtSoLuong.Text.Trim()));
                                                cmd.Parameters.AddWithValue("@DonGiaNhap", float.Parse(txtDonGiaNhap.Text));
                                                cmd.Parameters.AddWithValue("@DonGiaBan", float.Parse(txtDonGiaBan.Text));
                                                cmd.Parameters.AddWithValue("@HinhAnh", pathstring);
                                                cmd.Parameters.AddWithValue("@GhiChu",txtGhiChu.Text.Trim());
                                                cmd.Parameters.AddWithValue("@MaNV", maNV);
                                              

                                                // Thực hiện câu lệnh INSERT
                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                if (rowsAffected > 0)
                                                {
                                                    MessageBox.Show("Dữ liệu đã được chèn thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    Load_Dssp();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Dữ liệu đã được chèn thất bại", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(txtGhiChu, "Vui lòng kiểm tra lại mục ghi chú của bạn");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txtDonGiaNhap, "Đơn giá bạn vừa nhập không hợp lệ");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtDonGiaBan, "Đơn giá bạn vừa nhập không hợp lệ");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtSoLuong, "Số lượng >=0");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtTenHang,"vui lòng kiểm tra lại tên sản phẩm");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtMaHang, "Mã hàng bạn nhập đã thực sự tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ảnh sản phẩm","Notification",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void pictureSp_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                open.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;";
                open.FilterIndex = 1; // This sets the default filter to Image Files
                open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // You can change the initial directory as needed

                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                }
            }

        }

        private void Get_MaNv()
        {
            string gmail = "";

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

                    // Duyệt qua các dòng trong DataTable và lấy dữ liệu
                    foreach (DataRow row in dataTable.Rows)
                    {
                        gmail = row["gmail"].ToString();

                    }
                    // Chuỗi kết nối đến cơ sở dữ liệu SQL Server của bạn


                    try
                    {
                        // Tạo câu lệnh SQL SELECT với điều kiện WHERE và sử dụng tham số
                        string selectQuery = "SELECT * FROM Employees WHERE Email = @email";

                        // Tạo đối tượng SqlCommand để thực thi câu lệnh SELECT
                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            // Thêm tham số cho câu lệnh WHERE
                            command.Parameters.AddWithValue("@email", gmail);

                            // Tạo đối tượng SqlDataAdapter và DataTable để lưu trữ dữ liệu
                            adapter = new SqlDataAdapter(command);
                            DataTable dataTable_2 = new DataTable();

                            // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                            adapter.Fill(dataTable_2);

                            // Duyệt qua các dòng kết quả
                            foreach (DataRow row in dataTable_2.Rows)
                            {
                                maNV = row["MaNV"].ToString();
                            }

                        }
                        // Tạo câu lệnh SQL DELETE
                        string deleteQuery = "DELETE FROM Gmail_Nv";

                        // Tạo đối tượng SqlCommand để thực thi câu lệnh DELETE
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Thực thi câu lệnh DELETE
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Get_MaNv();
            SanPhamRepository sanPhamRepository = new SanPhamRepository(strCon);
            listProducts = sanPhamRepository.GetProducts();
           
            Load_Dssp();
        }
        private void Load_Dssp()
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
                string donGiaNhap = dr["DonGiaNhap"].ToString();
                string donGiaBan = dr["DonGiaBan"].ToString();
                string hinhAnh = dr["HinhAnh"].ToString() ;
                string ghiChu = dr["GhiChu"].ToString();
            

                ListViewItem item = new ListViewItem(maSp);
                item.SubItems.Add(tenSp);
                item.SubItems.Add(soLuong);
                item.SubItems.Add(donGiaNhap);
                item.SubItems.Add(donGiaBan);
                item.SubItems.Add(hinhAnh);
                item.SubItems.Add(ghiChu);
                lsvDssp.Items.Add(item);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(maSp.Length == 0) {
                MessageBox.Show("Vui lòng chọn thông tin bạn muốn cập nhật", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; }
            errorProvider1.Clear();
            KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
            
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo truy vấn SQL SELECT
                string sqlSelect = "SELECT * FROM SANPHAM WHERE MaSp = @MaSp";

                // Tạo một đối tượng SqlCommand
                using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, connection))
                {
                    // Thay thế các tham số trong truy vấn với giá trị cụ thể
                    cmdSelect.Parameters.AddWithValue("@MaSp", maSp);
                    // Tạo một đối tượng SqlDataAdapter và DataTable
                    adapter = new SqlDataAdapter(cmdSelect);
                    DataTable dataTable = new DataTable();

                    // Tạo một đối tượng SqlCommandBuilder để tạo các lệnh tự động
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Kiểm tra xem có dòng dữ liệu nào được tìm thấy
                    if (dataTable.Rows.Count > 0)
                    {
                        bool check = true;
                        if (txtMaHang.Text.Equals(maSp))
                        {
                            check = true;
                        }
                        else
                        {
                            SanPham sanPham = listProducts.FirstOrDefault(sp => sp.MaSp.ToLower() == txtMaHang.Text.Trim().ToString().ToLower());
                            if(sanPham == null)
                            {
                                check = true;
                            }
                            else
                            {
                                errorProvider1.SetError(txtMaHang, "Mã hàng bạn vừa nhập đã thực sự tồn tại");
                                check = false;
                            }
                        }
                        if(check)
                        {
                            check = kt.IsNameValid(txtTenHang.Text.Trim().ToString());
                            if(check)
                            {
                                dataTable.Rows[0]["TenSp"] = txtTenHang.Text.Trim().ToString();
                                check = kt.IsNumberProductValid(txtSoLuong.Text.Trim().ToString());
                                if (check)
                                {
                                    dataTable.Rows[0]["SoLuong"] = int.Parse(txtSoLuong.Text);
                                    check = kt.IsMoneyValid(txtDonGiaNhap.Text);
                                    if (check)
                                    {
                                        dataTable.Rows[0]["DonGiaNhap"] = double.Parse(txtDonGiaNhap.Text);
                                        check = kt.IsMoneyValid(txtDonGiaBan.Text);
                                        if (check)

                                        {
                                            dataTable.Rows[0]["DonGiaBan"] = double.Parse(txtDonGiaBan.Text);
                                            check = kt.IsNameValid(txtGhiChu.Text);
                                            if (check)
                                            {
                                                if (pictureSp.Image == null)
                                                {
                                                    MessageBox.Show("Ảnh không được bổ trống", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                }
                                                else
                                                {
                                                    string randomString = GenerateRandomString(5);
                                                    string fname = txtMaHang.Text +randomString+ ".jpg";
                                                  
                                                    string pathstring = System.IO.Path.Combine(folder, fname);
                                                    
                                                    
                                                    pictureSp.Image.Save(pathstring);
                                                    dataTable.Rows[0]["HinhAnh"] = pathstring;
                                                    int kq = adapter.Update(dataTable);
                                                    if(kq> 0)
                                                    {
                                                        MessageBox.Show("Dữ liệu đã được cập nhật thành công");
                                                        Load_Dssp();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Dữ liệu đã cập nhật thất bại");
                                                    }






                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(txtGhiChu, "Ghi chú bạn vừa nhập không hợp lệ");
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(txtDonGiaBan, "Đơn giá bán bạn vừa nhập không hợp lệ");
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(txtDonGiaNhap, "Số tiền bạn vừa nhập không hợp lệ");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txtSoLuong, "Số lượng bạn vừa nhập không hợp lệ");
                                }
                            }                              
                            else
                            {
                                errorProvider1.SetError(txtTenHang, "Tên sản phẩm bạn vừa nhập không hợp lệ");

                            }

                            // Cập nhật dữ liệu trong cơ sở dữ liệu bằng cách gọi Update trên SqlDataAdapter

                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu nhập vào không hợp lệ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Thay đổi giá trị của PasswordHash trong DataTable

                }
            }

        }

        private void lsvDssp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDssp.SelectedItems.Count == 0) return;
            ListViewItem item = lsvDssp.SelectedItems[0];
            string foundMsp = item.SubItems[0].Text.ToString();
            string soLuong = item.SubItems[2].Text.ToString();
            string tenSp = item.SubItems[1].Text.ToString();
            string donGiaNhap = item.SubItems[3].Text.ToString();
            string donGiaBan = item.SubItems[4].Text.ToString();
            string hinhAnh = item.SubItems[5].Text.ToString();
            string ghiChu = item.SubItems[6].Text.ToString();
            txtMaHang.Text = foundMsp;
            txtTenHang.Text = tenSp;
            txtSoLuong.Text = soLuong;
            txtDonGiaNhap.Text = donGiaNhap;
            txtDonGiaBan.Text = donGiaBan;
            maSp = foundMsp;
            txtGhiChu.Text = ghiChu;

            if (File.Exists(hinhAnh)) // Kiểm tra xem tệp hình ảnh có tồn tại hay không
            {
                try
                {
                    Image image = Image.FromFile(hinhAnh); // Tạo đối tượng hình ảnh từ đường dẫn

                    pictureSp.Image = image; // Gán hình ảnh cho PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message,"Notification",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tệp hình ảnh không tồn tại.","Notification",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomChars);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            if (txtMaHang.Text.ToLower().Equals(maSp.ToLower()))
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();

                    // Tạo câu truy vấn SQL DELETE dựa trên MaNV
                    string sqlDelete = "DELETE FROM SANPHAM WHERE MaSp = @maSp";

                    // Tạo đối tượng SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Định nghĩa câu lệnh DELETE
                    adapter.DeleteCommand = new SqlCommand(sqlDelete, connection);

                    // Định nghĩa tham số
                    adapter.DeleteCommand.Parameters.Add("@maSp", SqlDbType.VarChar, 20).Value = txtMaHang.Text.Trim().ToString(); // Thay thế "NV123" bằng MaNV cần xóa

                    // Thực hiện câu lệnh DELETE
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được xoá thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Load_Dssp();
                            New_Data();

                        }
                        else
                        {
                            MessageBox.Show("Xoá dữ liệu không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                return;
            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Mời bạn tiếp tục sử dụng dịch vụ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string maHang = dr["MaSp"].ToString();
                    string tenSP = dr["TenSp"].ToString();
                    string soLuong = dr["SoLuong"].ToString();
                    string donGiaNhap = dr["DonGiaNhap"].ToString();
                    string donGiaBan = dr["DonGiaBan"].ToString();
                    string hinhAnh = dr["HinhAnh"].ToString();
                    string ghiChu = dr["GhiChu"].ToString();
                    ListViewItem item = new ListViewItem(maSp);
                    item.SubItems.Add(tenSP);
                    item.SubItems.Add(soLuong);
                    item.SubItems.Add(donGiaNhap);
                    item.SubItems.Add(donGiaBan);
                    item.SubItems.Add(hinhAnh);
                    item.SubItems.Add(ghiChu);
                    lsvDssp.Items.Add(item);    
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSp = txtTksp.Text.Trim().ToString();
            if (tenSp.Length == 0)
            {
                return;
            }
            Load_FoundSp(tenSp);
        }
    }
}
