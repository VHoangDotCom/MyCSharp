using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCustomer
{
    public class KhachHangThanThiet: KhachHang
    {
        public KhachHangThanThiet()
        {

        }
        public KhachHangThanThiet(string hoTen,bool gioiTinh, int slMua,double donGia)
        {
            this._hoTen = hoTen;
            this._gioiTinh = gioiTinh;
            this._slMua = slMua;
            this._donGia = donGia;
        }
        public string QuaTang()
        {
            if(tongTien() <= 1000)
            {
                return "Coupon 200";
            }
            else
            {
                return "Coupon 500";
            }
        }
    }
}
