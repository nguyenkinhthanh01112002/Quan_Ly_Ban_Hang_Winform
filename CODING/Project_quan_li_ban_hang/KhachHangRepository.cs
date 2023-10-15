using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_quan_li_ban_hang
{
    internal class KhachHangRepository
    {
        private string connectionString; // Chuỗi kết nối đến cơ sở dữ liệu

        public KhachHangRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<KhachHang> GetCustomers()
        {
            List<KhachHang> customers = new List<KhachHang>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "select * from KhachHang"; // Thay thế bằng truy vấn SQL thực tế

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHang khachHang = new KhachHang
                            {
                                sDT = reader.GetString(0),
                                tenKH = reader.GetString(1),
                                diaChi = reader.GetString(2),
                               phai = reader.GetString(3),

                                vaiTro = reader.GetString(4),
                                maNV = reader.GetString(5),
                              

                                // Gán các thuộc tính khác tương ứng với cột trong bảng NHANVIEN
                            };
                            customers.Add(khachHang);
                        }

                    }
                }
            }

            return customers;
        }
    }
}
