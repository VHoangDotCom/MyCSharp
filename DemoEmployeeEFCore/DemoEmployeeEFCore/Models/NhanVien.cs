using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEmployeeEFCore.Models
{
    public partial class NhanVien
    {
        public string MaNv { get; set; }
        public string HoTen { get; set; }
        public int Luong { get; set; }
        public int Thuong { get; set; }
        public string MaPhong { get; set; }

        public virtual PhongBan MaPhongNavigation { get; set; }
    }
}
