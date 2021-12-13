using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCustomer
{
    public class KhachHang
    {
        private string hoTen;
        public string _hoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        private bool gioiTinh;
        public bool _gioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        private int slMua;
        public int _slMua
        {
            get { return slMua; }
            set { slMua = value; }
        }

        private double donGia;
        public double _donGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public KhachHang()
        {

        }

        public KhachHang(string ten, bool gt, int sl, double gia)
        {
            this.hoTen = ten;
            this.gioiTinh = gt;
            this.slMua = sl;
            this.donGia = gia;
        }

        public double tongTien()
        {
            if(slMua < 100)
            {
                return slMua * donGia;
            }
            else
            {
                return 0.9 * slMua * donGia;
            }
        }
    }
}
