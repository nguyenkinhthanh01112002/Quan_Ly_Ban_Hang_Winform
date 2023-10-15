using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_quan_li_ban_hang
{
    internal class KiemTraNgoaiLe
    {
        public bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra định dạng email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Sử dụng Regex.IsMatch để kiểm tra chuỗi email có khớp với biểu thức chính quy hay không
            return Regex.IsMatch(email, pattern);
        }
        public bool IsNameValid(string name)
        {
            if(name.Length == 0)
            {
                return false;
            }
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    return false; // Tên chứa ít nhất một số
                }
            }
            return true; // Tên không chứa số
        }
        public  bool IsAddressValid(string address)
        {
            if(address.Length == 0) 
            {
                return false;
            }
            return true;
        }
        public bool IsNumberPhonelValid(string number)
        {
            string pattern = @"^0\d{9}$"; // Bắt đầu bằng 0 và sau đó là 9 chữ số

            if (Regex.IsMatch(number, pattern))
            {
                return true;
            }
           return false;
        }
        public bool IsNumberProductValid(string number)
        {
            int soLuong;
            if (int.TryParse(number, out soLuong))
            {
                if (soLuong >= 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
        public bool IsMoneyValid(string money) 
        {
            float soTien;
            if (float.TryParse(money, out soTien))
            {
                if (soTien >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
