using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap
{
    class SanPham
    {
        public string MaSP { get; set; }
            public string TenSP { get; set; }
            public string MaLoai { get; set; }
            public double DonGia { get; set; }
            public double SoLuong { get; set; }
        public double Tong { get; set; }

        public SanPham(string masp,string tensp, string maloai, double dongia,double slc,double thanhTien)
        {
            this.MaLoai = maloai;
            this.MaSP = masp;
            this.DonGia = dongia;
            this.TenSP = tensp;
            this.SoLuong = slc;
            this.Tong = thanhTien;
        }

        public SanPham()
        {

        }
       
    }
}
