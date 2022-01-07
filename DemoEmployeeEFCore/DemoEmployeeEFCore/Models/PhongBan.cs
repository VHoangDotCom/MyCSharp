using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEmployeeEFCore.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaPhong { get; set; }
        public string TenPhong { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
