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

namespace DemGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string gioiTinh, honNhan, soThich="";
            if (radNam.IsChecked == true)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";

            honNhan = radChuaKetHon.IsChecked == true ? "Chưa kết hôn" : "Đã kết hôn";

            if (chkBongDa.IsChecked == true)
                soThich = "Bóng đá";
            if (chkBoi.IsChecked == true)
                soThich += "; Bơi lội";
            if (chkAmNhac.IsChecked == true)
                soThich += "; Âm nhạc";
            if (chkLeoNui.IsChecked == true)
                soThich += "; Leo núi";

            if (soThich.Substring(0,1)==";")
            {
                soThich = soThich.Substring(2, soThich.Length - 2);
            }

            lstPerson.Items.Clear();
            lstPerson.Items.Add("Họ tên: " + txtHoTen.Text);
            lstPerson.Items.Add("Giới tính: " + gioiTinh);
            lstPerson.Items.Add("Tình trạng hôn nhân: " + honNhan);
            lstPerson.Items.Add("Sở thích: " + soThich);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //string chuoiGoc = "Hà nội - Việt nam";
            //int soKyTu = chuoiGoc.Length;
            //string chuoiCon = chuoiGoc.Substring(1,soKyTu-2);
            //MessageBox.Show(chuoiCon);
        }
    }
}
