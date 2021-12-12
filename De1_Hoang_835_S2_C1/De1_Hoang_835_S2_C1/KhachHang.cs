using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Hoang_835_S2_C1
{
    public  class KhachHang
    {
       
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public int slMua { get; set; }
        public double donGia { get; set; }
        

        public KhachHang(string hoTen, string gioitinh, int slMua,double dongia)
            {
            this.hoTen = hoTen;
            this.gioiTinh = gioitinh;
            this.slMua = slMua;
            this.donGia = dongia;
            
            }
        public KhachHang()
        {

        }


        public  double tongTien()
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
