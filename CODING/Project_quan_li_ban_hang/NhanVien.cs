using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_quan_li_ban_hang
{
    internal class NhanVien
    {
        public int id { get; set; }
        public string maNV { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string roleId { get; set; }
        public int tinhTrang { get; set; }
        public string passWordHash { get; set; }
        public string hoTen { get; set; }

    }
}
