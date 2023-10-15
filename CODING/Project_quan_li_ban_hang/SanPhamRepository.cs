using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_quan_li_ban_hang
{
    internal class SanPhamRepository
    {
        private string connectionString; // Chuỗi kết nối đến cơ sở dữ liệu

        public SanPhamRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SanPham> GetProducts()
        {
            List<SanPham> products = new List<SanPham>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM SANPHAM";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham sanPham = new SanPham
                            {
                                MaSp = reader.GetString(0),
                                TenSp = reader.GetString(1),
                                SoLuong = reader.GetInt32(2),
                             // DonGiaNhap = (float)reader.GetDouble(3),
                             //  DonGiaBan = (float)reader.GetDouble(4),
                                DonGiaNhap = (float)reader.GetDouble(3),
                                DonGiaBan = (float)reader.GetDouble(4),

                                HinhAnh = reader.GetString(5),
                                GhiChu = reader.GetString(6),
                                MaNV = reader.GetString(7)
                            };
                            products.Add(sanPham);
                        }
                    }
                }
            }

            return products;
        }
    }
}
