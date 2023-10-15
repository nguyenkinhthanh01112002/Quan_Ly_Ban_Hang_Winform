using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_quan_li_ban_hang
{
    internal class NhanVienRepository
    {
        private string connectionString; // Chuỗi kết nối đến cơ sở dữ liệu

        public NhanVienRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<NhanVien> GetEmployees()
        {
            List<NhanVien> employees = new List<NhanVien>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "select * from Employees"; // Thay thế bằng truy vấn SQL thực tế

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVien nhanVien = new NhanVien
                            {
                                id = reader.GetInt32(0),
                                maNV = reader.GetString(1),
                                email = reader.GetString(2),
                                diaChi = reader.GetString(3),
                               
                                roleId = reader.GetString(4),
                                tinhTrang = reader.GetByte(5),
                                passWordHash = reader.GetString(6),
                                hoTen = reader.GetString(7)

                                // Gán các thuộc tính khác tương ứng với cột trong bảng NHANVIEN
                            };
                            employees.Add(nhanVien);
                        }
                     
                    }
                }
            }

            return employees;
        }
    }
}
