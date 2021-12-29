using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class NhanVien
    {
        public string hoten { get; set; }
        public string ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public int songaylam { get; set; }
        public int luong { get; set; }
        public NhanVien(string hoten, string ngaysinh, string gioitinh,int songaylam,int luong)
        {
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.songaylam = songaylam;
            this.luong = luong;
        }
    }
}
