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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_quan_li_ban_hang
{
    public partial class frmKhachHang : Form
    {
        string strCon = @"Data Source=NGUYENKINHTHANH\SQLEXPRESS;Initial Catalog=PROJECT_QUAN_LI_BAN_HANG;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        List<KhachHang> listKh = null;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            Get_MaNv();
            KhachHangRepository khachHangRepository = new KhachHangRepository(strCon);
            listKh = khachHangRepository.GetCustomers();
            Load_Dskh();
        }
        string maNV = "";
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
        private void Load_Dskh()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            string cmd = "\r\nselect * from KhachHang";
            adapter = new SqlDataAdapter(cmd, sqlCon);
            DataTable tblKh = new DataTable();
            adapter.Fill(tblKh);
            lsvDskh.Items.Clear();
            foreach (DataRow dr in tblKh.Rows)
            {
                string soDT = dr["Sdt"].ToString();
                string tenKh = dr["TenKhach"].ToString();
                string diaChi = dr["DiaChi"].ToString();
                string phai = dr["Phai"].ToString();
                string maNV = dr["MaNV"].ToString();
             
                ListViewItem item = new ListViewItem(soDT);
                item.SubItems.Add(tenKh);
                item.SubItems.Add(diaChi);
                item.SubItems.Add(phai);
                item.SubItems.Add(maNV);
               
                lsvDskh.Items.Add(item);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            New_KhachKhang();
        }
        private void New_KhachKhang()
        {
            txtSdt.Text = "";
            txtDiaChi.Text = "";
            txtTenKh.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
        }
        KiemTraNgoaiLe kt = new KiemTraNgoaiLe();
        
   
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
           
            
            string number = txtSdt.Text.Trim();
            bool check = kt.IsNumberPhonelValid(number);
            if (check)
            {
                KhachHang kh = listKh.FirstOrDefault(o=>o.sDT == number);
                if (kh != null)
                {
                    errorProvider1.SetError(txtSdt,"Số điện thoại bạn vừa nhập đã thực sự tồn tại");
                }
                else
                {
                    check = kt.IsNameValid(txtTenKh.Text.Trim().ToString());
                    if(check)
                    {
                        check = kt.IsAddressValid(txtDiaChi.Text.Trim().ToString());
                        if (check)
                        {
                            if (radNam.Checked == false && radNu.Checked == false)
                            {
                                errorProvider1.SetError(lblErrorPhai, "Bạn chưa chọn mục giới tính");
                            }
                            else
                            {
                                string gioiTinh = "";
                                if (radNam.Checked)
                                {
                                    gioiTinh = "Nam";
                                }
                                else
                                {
                                    gioiTinh = "Nữ";
                                }                        
                                using (SqlConnection connection = new SqlConnection(strCon))
                                {
                                    connection.Open();

                                    // Tạo một đối tượng SqlDataAdapter để thêm dữ liệu vào bảng Employees
                                    adapter = new SqlDataAdapter();

                                    // Tạo truy vấn SQL INSERT
                                    string sqlInsert = "INSERT INTO KhachHang "+
                                                       "VALUES (@SoDt, @TenKh, @DiaChi, @Phai, @RoleId,@MaNV)";                                                    
                                    // Tạo một đối tượng SqlCommand
                                    SqlCommand cmd = new SqlCommand(sqlInsert, connection);
                                    // Thay thế các tham số trong truy vấn với giá trị cụ thể
                                    cmd.Parameters.AddWithValue("@SoDt", txtSdt.Text.Trim().ToString());
                                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim().ToString());
                                    cmd.Parameters.AddWithValue("@RoleId", "khang"); // Thay thế bằng vai trò thực tế
                                    cmd.Parameters.AddWithValue("@Phai", gioiTinh); // Thay thế bằng tình trạng thực tế
                                    cmd.Parameters.AddWithValue("@TenKh", txtTenKh.Text.Trim().ToString());
                                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                                  
                                    // Thay thế bằng giá trị băm thực tế

                                    // Gán đối tượng SqlCommand cho SqlDataAdapter
                                    adapter.InsertCommand = cmd;

                                    // Thực hiện truy vấn INSERT và kiểm tra số dòng ảnh hưởng
                                    int kq = adapter.InsertCommand.ExecuteNonQuery();

                                    if (kq > 0)
                                    {
                                        MessageBox.Show("Bạn đã thêm khách hàng thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Load_Dskh();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Thêm khách hàng không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtDiaChi, "Địa chỉ bạn vừa nhập không hợp lệ");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtTenKh, "Tên bạn vừa nhập không hợp lệ");
                    }
                }
            }
            else
            {
                errorProvider1.SetError(txtSdt, "Số điện thoại bắt buộc có 10 chữ số");
            }
        }
        string firstNumber = "";
        private void lsvDskh_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (lsvDskh.SelectedItems.Count == 0) return;
            ListViewItem item = lsvDskh.SelectedItems[0];
            firstNumber = txtSdt.Text = item.SubItems[0].Text.Trim().ToString();
            txtDiaChi.Text = item.SubItems[2].Text.Trim().ToString();
            txtTenKh.Text = item.SubItems[1].Text.Trim().ToString();
            string gioiTinh = item.SubItems[3].Text.Trim();
            if (gioiTinh.Equals("Nam"))
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo truy vấn SQL SELECT
                string sqlSelect = "SELECT * FROM KhachHang WHERE Sdt = @soDT";
                
                // Tạo một đối tượng SqlCommand
                using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, connection))
                {
                    // Thay thế các tham số trong truy vấn với giá trị cụ thể
                    cmdSelect.Parameters.AddWithValue("@soDT", firstNumber);
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
                        bool check = kt.IsNumberPhonelValid(txtSdt.Text.Trim().ToString());
                        if (check)
                        {
                            if (txtSdt.Text.Trim().ToString().Equals(firstNumber))
                            {
                                check = true;
                                
                            }
                            else
                            {
                                KhachHang khachHang = listKh.FirstOrDefault(kh => kh.sDT == txtSdt.Text.Trim().ToString());
                                if (khachHang != null)
                                {
                                    errorProvider1.SetError(txtSdt, "Số điện thoại bạn vừa nhập đã thực sự tồn tại");
                                    check = false;
                                }
                                else
                                {
                                    check = true;
                                }
                            }
                            if (check)
                            {
                                check = kt.IsNameValid(txtTenKh.Text.Trim().ToString());
                                if (check)
                                {
                                    check = kt.IsAddressValid(txtDiaChi.Text.Trim().ToString());
                                    if (check)
                                    {
                                        string phai = radNam.Checked ? "Nam" : "Nữ";

                                        dataTable.Rows[0]["Sdt"] = txtSdt.Text.Trim().ToString();
                                        dataTable.Rows[0]["TenKhach"] = txtTenKh.Text.Trim().ToString();
                                        dataTable.Rows[0]["DiaChi"] = txtDiaChi.Text.Trim().ToString();
                                        dataTable.Rows[0]["Phai"] = phai;
                                        dataTable.Rows[0]["MaNV"] = maNV;
                                        int kq = adapter.Update(dataTable);
                                        if (kq > 0)
                                        {
                                            MessageBox.Show("Dữ liệu đã được cập nhật thành cônng", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Load_Dskh();                                         
                                        }
                                        else
                                        {
                                            MessageBox.Show("Dữ liệu đã cập nhật thất bại", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(txtDiaChi, "Địa chỉ bạn vừa nhập không hợp lệ");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txtTenKh, "Tên bạn vừa nhập vào không hợp lệ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng kiểm tra lại mục nhập liệu của bạn","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);  
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtSdt, "Số điện thoại bắt buộc có 10 chữ số");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSdt.Text.Length != 10) 
            {
                return;
            }


            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo câu truy vấn SQL DELETE dựa trên MaNV
                string sqlDelete = "DELETE FROM KhachHang WHERE Sdt = @soDT";

                // Tạo đối tượng SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Định nghĩa câu lệnh DELETE
                adapter.DeleteCommand = new SqlCommand(sqlDelete, connection);

                // Định nghĩa tham số
                adapter.DeleteCommand.Parameters.Add("@soDT", SqlDbType.VarChar,10).Value = txtSdt.Text.Trim().ToString(); // Thay thế "NV123" bằng MaNV cần xóa

                // Thực hiện câu lệnh DELETE
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được xoá thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Load_Dskh();
                        New_KhachKhang();

                    }
                    else
                    {
                        MessageBox.Show("Xoá dữ liệu không thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
        private void Load_FoundKh(string tenKh)
        {
            // Thay thế bằng chuỗi kết nối thực tế của bạn
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                // Tạo câu truy vấn SQL SELECT dựa trên tên nhân viên
                string sqlSelect = "SELECT * FROM KhachHang WHERE TenKhach LIKE @TenKh";

                // Tạo đối tượng SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);

                // Định nghĩa tham số
                adapter.SelectCommand.Parameters.AddWithValue("@TenKh", "%" + tenKh + "%"); // Tìm tất cả nhân viên có tên chứa chuỗi tìm kiếm

                // Tạo DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                adapter.Fill(dataTable);

                // Hiển thị kết quả tìm kiếm trong giao diện người dùng (ví dụ: trong một DataGridView)
                lsvDskh.Items.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string soDT = dr["Sdt"].ToString();
                    string tenKH = dr["TenKhach"].ToString();
                    string diaChi = dr["DiaChi"].ToString();
                    string phai = dr["Phai"].ToString();
                    string maNV = dr["MaNV"].ToString();
                    
                    ListViewItem item = new ListViewItem(soDT);
                    item.SubItems.Add(tenKH);
                    item.SubItems.Add(diaChi);
                    item.SubItems.Add(phai);
                    item.SubItems.Add((maNV));
                    
                    lsvDskh.Items.Add(item);
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKh = txtTkkh.Text.Trim().ToString();
            if (tenKh.Length == 0)
            {
                return;
            }
            Load_FoundKh(tenKh);
        }
    }
}

