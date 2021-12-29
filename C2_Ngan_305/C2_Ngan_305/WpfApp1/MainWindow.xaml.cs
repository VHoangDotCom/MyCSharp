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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<NhanVien> ds = new List<NhanVien>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nhap_click(object sender, RoutedEventArgs e)
        {
            int check = 1;
            if (hoten.Text == "")
            {
                MessageBox.Show("Chưa nhập họ tên, vui lòng nhập lại", "Thông báo");
                check = 0;
            }
            if (ngaysinh.Text == "")
            {
                MessageBox.Show("Chưa nhập ngày sinh, vui lòng nhập lại", "Thông báo");
                check = 0;
            }
            else
            {
                if (DateTime.Now.Year - DateTime.Parse(ngaysinh.Text).Year < 18)
                {
                    MessageBox.Show("Tuổi nhân viên >=18, vui lòng nhập lại", "Thông báo");
                    check = 0;
                }
            }
            if (gioitinh_nam.IsChecked == false && gioitinh_nu.IsChecked == false)
            {
                MessageBox.Show("Chưa nhập giới tính, vui lòng nhập lại", "Thông báo");
                check = 0;
            }
            
            if (songay.Text == "")
            {
                MessageBox.Show("Chưa nhập số ngày làm việc, vui lòng nhập lại", "Thông báo");
                check = 0;
            }
            else
            {
                if (int.Parse(songay.Text) < 0 || int.Parse(songay.Text) > 30)
                {
                    MessageBox.Show("Số này làm việc >=0 và <=30, vui lòng nhập lại", "Thông báo");
                    check = 0;
                }
            }
            if (check == 1)
            {
                int songaylam = int.Parse(songay.Text);
                int luong = 0;
                if (songaylam <= 10)
                {
                    luong = songaylam * 200000;
                }
                else
                {
                    luong = 2000000 + (songaylam - 10) * 400000;
                }
                string gioitinh = null;
                if (gioitinh_nam.IsChecked == true)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                NhanVien a = new NhanVien(hoten.Text, ngaysinh.Text, gioitinh, songaylam, luong);
                ds.Add(a);
                danhsach.ItemsSource = ds.ToList();
            }
        }

        private void xoa_click(object sender, RoutedEventArgs e)
        {
            hoten.Text = null;
            hoten.Focus();
            ngaysinh.Text = DateTime.Now.ToString();
            gioitinh_nam.IsChecked = true;
            songay.Text = null;
        }

        private void window2_click(object sender, RoutedEventArgs e)
        {
            Window2 my = new Window2();
            my.Tag = ds;
            my.Show();
        }
    }
}
