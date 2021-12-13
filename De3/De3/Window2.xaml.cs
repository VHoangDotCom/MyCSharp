using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace De3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
     
        public Window2()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         

            try
            {
                var data = Tag.ToString().Split("-");
                txtTen.Text = data[0];
                dtpBirth.SelectedDate = DateTime.Parse(data[1]);
                foreach (ComboBoxItem cbItem in cboLoai.Items)
                {
                    if(cbItem.Content.ToString().Equals(data[2].Trim()))
                    {
                        cbItem.IsSelected = true;
                    }
                }
                var money = data[3].Split(":");
                txtTien.Text = money[1].Trim();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
