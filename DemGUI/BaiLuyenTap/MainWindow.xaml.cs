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

namespace BaiLuyenTap
{
   
    public partial class MainWindow : Window
    {
        double tienLuong;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btnThem_Click(object sender, RoutedEventArgs e)
        {
          

            int soNgay = 0, tuoi;
            string ngoaiNgu = "";
            //Tinh tien luong
            int k = 0;
            if (txtDay.Text != "" && Convert.ToInt32(txtDay.Text) >0)
            {
                try
                {
                    k = 0;
                    soNgay = int.Parse(txtDay.Text);
                 
                }
                catch (Exception error)
                {
                    MessageBox.Show("So ngay di lam ko hop le ");
                    k = 1;
                    
                }
                if (k == 0)
                {
                    if (soNgay > 0)
                    {
                        if (soNgay <= 20)
                        {
                            tienLuong = soNgay * 100000;
                        }
                        else
                        {
                            tienLuong = 2000000 + (soNgay - 20) * 200000;
                        }
                    }
                    if (chkAnh.IsChecked == true)
                        ngoaiNgu = "Tieng Anh";
                    if (chkPhap.IsChecked == true)
                        ngoaiNgu += "; Tieng Phap";
                    if (chkTrung.IsChecked == true)
                        ngoaiNgu += "; Tieng Trung";

                    lstThongTin.Items.Add(txtTen.Text + " - " + txtPB.Text + " - " + ngoaiNgu + " - "
                        + dtpBirth.Text + " - " + txtDay.Text + " - " + tienLuong.ToString());

                }
            }

        }

            private void btnXoa_Click(object sender, RoutedEventArgs e)
              {
            lstThongTin.Items.Clear();
                }
        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 myWindow = new Window2();
            myWindow.Tag = txtTen.Text;
            myWindow.Show();
        }

    }
}
