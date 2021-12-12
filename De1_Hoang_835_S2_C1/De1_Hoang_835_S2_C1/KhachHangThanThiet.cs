using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Hoang_835_S2_C1
{
    public class KhachHangThanThiet:KhachHang
    {
       public KhachHangThanThiet()
        {

        }
        public KhachHangThanThiet(string hoTen, string gioiTinh,int slMua, double dongia)
        {
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.slMua = slMua;
            this.donGia = donGia;
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
