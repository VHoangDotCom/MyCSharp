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

namespace De3
{
  
    public partial class MainWindow : Window
    {
        public double tienHoaHong;
        public string name;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btnThem_Click(object sender, RoutedEventArgs e)
        {
            double tienBH = 0;
            int k = 0;
            try
            {
                k = 0;
                tienBH = double.Parse(txtTien.Text);
                if (txtTien.Text != "" && Convert.ToDouble(txtTien.Text) > 0)
                {

                    if (k == 0)
                    {
                        if (tienBH > 0)
                        {
                            if (tienBH < 1000)
                            {
                                tienHoaHong = 0;
                            }
                            else if (tienBH >= 1000 && tienBH <= 5000)
                            {
                                tienHoaHong = tienBH * 0.1;
                            }
                            else
                            {
                                tienHoaHong = tienBH * 0.2;
                            }
                        }
                        lstThongTin.Items.Add(txtTen.Text + " - " + dtpBirth.Text + " - " + cboLoai.Text
                            + " - Tien ban hang: " + txtTien.Text + " - Hoa hong : " + tienHoaHong);

                    }
                }
            }
            catch (Exception h)
            {
                MessageBox.Show("So tien ban hang khong hop le !");
                k = 1;
            }
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            txtTen.Clear();
            txtTien.Clear();
            cboLoai.Text = "";
            dtpBirth.Text = "";
            lstThongTin.Items.Clear();
        }
      
        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 myWindow = new Window2();
            myWindow.Tag = txtTen.Text;
            myWindow.Tag = txtTien.Text;
            myWindow.Tag = dtpBirth.Text;
            myWindow.Tag = cboLoai.Text;
            myWindow.Show();
        }
    }
}
