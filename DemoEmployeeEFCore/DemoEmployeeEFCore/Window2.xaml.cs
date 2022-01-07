using DemoEmployeeEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoEmployeeEFCore
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        QLNhanVienContext db = new QLNhanVienContext();
        public Window2()
        {
            InitializeComponent();
            HienThiDuLieu();
        }

        private void HienThiDuLieu()
        {
            //try van
            var query = from PhongBan in db.PhongBans
                        join NhanVien in db.NhanViens on PhongBan.MaPhong equals NhanVien.MaPhong
                        select new
                        {
                            MaPhong = PhongBan.MaPhong,
                            TenPhong = PhongBan.TenPhong,
                            SoNhanVien = PhongBan.NhanViens.Count,
                            TongLuong = PhongBan.NhanViens.Sum(NhanVien=>NhanVien.Luong)
                        } 
                        ;

        

            //Hien thi len Datagrid
            danhsach.ItemsSource = query.ToList();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
