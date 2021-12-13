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
      
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtTen.Text.ToString();
                if(name.Length == 0)
                {
                    MessageBox.Show("Ten khong duoc de trong !");
                    return;
                }


                DateTime dateOfBirth = new DateTime();
                if(dtpBirth.SelectedDate == null)
                {
                    MessageBox.Show("Ngay sinh khong duoc de trong !");
                    return;
                }else if(DateTime.Now.Year - dtpBirth.SelectedDate.Value.Year < 18 || 
                    DateTime.Now.Year - dtpBirth.SelectedDate.Value.Year > 60)
                {
                    MessageBox.Show("Tuoi chi trong khoang tu 18 - 60 ");
                    return;
                }
                else
                {
                    dateOfBirth = dtpBirth.SelectedDate.Value;
                }


                double money = 0;
                if(txtTien.Text.ToString().Length == 0)
                {
                    MessageBox.Show("So tien ban hang khong duoc trong");
                    return;
                }
                else
                {
                    double b;
                    if(!double.TryParse(txtTien.Text.ToString(),out b))
                    {
                        MessageBox.Show("So tien ban hang phai la kieu so thuc !");
                        return;
                    }else if (double.Parse(txtTien.Text.ToString()) < 0)
                    {
                        MessageBox.Show("So tien ban hang phai lon hon 0");
                        return;
                    }
                    else
                    {
                        money = double.Parse(txtTien.Text.ToString());
                    }
                }

                ComboBoxItem item = (ComboBoxItem)cboLoai.SelectedItem;
                string loaiNV = item.Content.ToString();

                double commission = 0;
                if(money >=1000 && money <= 5000)
                {
                    commission = money * 0.1;
                }else if(money > 5000)
                {
                    commission = money * 0.2;
                }

                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = $"{name} - {dateOfBirth.ToString("MM/dd/yyyy")} - " +
                    $"{loaiNV} - Tien ban hang: {money} - Hoa hong: {commission}";
                lstThongTin.Items.Add(lbItem);
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
 

            MessageBoxResult result = MessageBox.Show("Do you really want to delete all \"information\"?", "Yasuo :)", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    
                    lstThongTin.Items.Clear();
                    txtTen.Text = "";
                    txtTien.Text = "";
                    dtpBirth.SelectedDate = DateTime.Now;
                    cboLoai.SelectedIndex = -1;
                    MessageBox.Show("Information has been deleted!", "Yasuo :)");
                    txtTen.Focus();             
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, Bye!", "Yasuo :)");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "Yasuo :)");
                    break;
               
            }
        }
      
        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem lb = (ListBoxItem)lstThongTin.SelectedItem;
            if(lb == null)
            {
                MessageBox.Show("Vui long chon 1 NV trong list box");
                return;
            }
            string value = lb.Content.ToString();

            Window2 win2 = new Window2();
            win2.Tag = value;
            win2.Show();


        }

    }
}
