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
using DemoEmployeeEFCore.Models;
using Microsoft.Data.SqlClient;

namespace DemoEmployeeEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HienThiDuLieu();
        }

        //Tao the hien lop Context
        QLNhanVienContext db = new QLNhanVienContext();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }

        public void clearData()
        {
            MaNV.Clear();
            HoTen.Clear();
            Luong.Clear();
            Thuong.Clear();
            
            MaNV.Focus();
        }

        private void HienThiDuLieu()
        {
            //Truy van du lieu su dung LINQ
            var query = from NhanVien in db.NhanViens
                        where NhanVien.Luong > 5000
                        orderby NhanVien.Luong ascending 
                        select new
                        {
                            MaNV = NhanVien.MaNv,
                            MaPhong = NhanVien.MaPhong,
                            HoTen = NhanVien.HoTen,
                            Luong = String.Format("{0:n0}", NhanVien.Luong),
                            Thuong = String.Format("{0:n0}", NhanVien.Thuong) ,
                            Tong = String.Format("{0:n0}", NhanVien.Luong + NhanVien.Thuong) 
                        };
            //Hien thi len datagrid
            danhsach.ItemsSource = query.ToList();

            var query_combo = from a in db.PhongBans
                              select a;
            MaPhong.ItemsSource = query_combo.ToList();

        }

        //Hien thi len textbox
       
       
        //Them moi record
        private void them_click(object sender, RoutedEventArgs e)
        {

            try
            {
                NhanVien nv = new NhanVien();
                PhongBan pb = new PhongBan();

                //Validate code
                if(MaNV.Text == string.Empty)
                {
                    MessageBox.Show("Employee code is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    nv.MaNv = MaNV.Text;
                }

                //Validate name
                if (HoTen.Text == string.Empty)
                {
                    MessageBox.Show("Employee name is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    nv.HoTen = HoTen.Text;
                }

                //Validate salary
                int b;
                if (Luong.Text == string.Empty)
                {
                    MessageBox.Show("Salary field is empty !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!int.TryParse(Luong.Text.ToString(), out b))
                {
                    MessageBox.Show("Salary is an integer type !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (int.Parse(Luong.Text) < 3000 || int.Parse(Luong.Text) > 9000)
                {
                    MessageBox.Show("Salary is in 3000 - 9000 !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    nv.Luong = Convert.ToInt32(Luong.Text);
                }

                //Validate Bonus
                if (Thuong.Text == string.Empty)
                {
                    MessageBox.Show("Bonus field is empty !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!int.TryParse(Thuong.Text.ToString(), out b))
                {
                    MessageBox.Show("Bonus is an integer type !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (int.Parse(Thuong.Text) < 100 || int.Parse(Thuong.Text) > 900)
                {
                    MessageBox.Show("Bonus is in 100 - 900 !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    nv.Thuong = Convert.ToInt32(Thuong.Text);
                }

                pb = (PhongBan)MaPhong.SelectedItem;
                nv.MaPhong = pb.MaPhong;

                //Validate Department code
                //if (MaPhong.Text == string.Empty)
                //{
                //    MessageBox.Show("Department code is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                //else
                //{
                //    nv.MaPhong = MaPhong.Text;
                //}

                ////Validate department code
                //var check_department = (from dp in db.PhongBans
                //                        where dp.MaPhong == MaPhong.Text
                //                        select dp).SingleOrDefault();

                //if(check_department != null)
                //{
                    if (!db.NhanViens.Contains(nv))
                    {
                        //Add success
                        db.NhanViens.Add(nv);
                        db.SaveChanges();
                        HienThiDuLieu();

                        //Notification
                        MessageBox.Show("Successfully created", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                        clearData();

                    }
                    else
                    {
                        MessageBox.Show("Employee " + MaNV.Text + "  is existed ! \n\n\t Please try again !", "Insert failed",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Department " + MaPhong.Text + "  is not existed ! \n\n\t Please try again !", "Insert failed",
                //            MessageBoxButton.OK, MessageBoxImage.Error);
                //}
       
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

        private void sua_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sua_nv = (from sua in db.NhanViens
                              where sua.MaNv == MaNV.Text
                              select sua).SingleOrDefault();

                if (MaNV.Text == string.Empty)
                {
                    MessageBox.Show("Employee code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if(sua_nv != null)
                    {
                        //Update Employee
                        if (HoTen.Text == string.Empty)
                        {
                            MessageBox.Show("Employee name is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            sua_nv.HoTen = HoTen.Text;
                        }

                        PhongBan phongban_new = (PhongBan)MaPhong.SelectedItem;
                        sua_nv.MaPhong = phongban_new.MaPhong;




                        //Update Salary
                        int b;
                        if (Luong.Text == string.Empty)
                        {
                            MessageBox.Show("Salary field is empty !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (!int.TryParse(Luong.Text.ToString(), out b))
                        {
                            MessageBox.Show("Salary is an integer type !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (int.Parse(Luong.Text) < 3000 || int.Parse(Luong.Text) > 9000)
                        {
                            MessageBox.Show("Salary is in 3000 - 9000 !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            sua_nv.Luong = Convert.ToInt32(Luong.Text);
                        }

                        //Update Bonus
                        if (Thuong.Text == string.Empty)
                        {
                            MessageBox.Show("Bonus field is empty !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (!int.TryParse(Thuong.Text.ToString(), out b))
                        {
                            MessageBox.Show("Bonus is an integer type !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (int.Parse(Thuong.Text) < 100 || int.Parse(Thuong.Text) > 900)
                        {
                            MessageBox.Show("Bonus is in 100 - 900 !", "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            sua_nv.Thuong = Convert.ToInt32(Thuong.Text);
                        }

                        //Update success
                        db.SaveChanges();
                        HienThiDuLieu();

                        //Notification
                        MessageBox.Show("Employee " + MaNV.Text + "  has been updated !", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                        clearData();
                    }
                    else
                    {
                        MessageBox.Show("Employee " + MaNV.Text + "  is not existed ! \n\n\t Please try again !", "Update failed",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch
            {

            }
        }

        private void xoa_click(object sender, RoutedEventArgs e)
        {

            try
            {
                var xoa_nv = (from xoa in db.NhanViens
                              where xoa.MaNv == MaNV.Text
                              select xoa).SingleOrDefault();

                if (MaNV.Text == string.Empty)
                {
                    MessageBox.Show("Employee code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {

                    MessageBoxResult result = MessageBox.Show("Do you really want to delete this record ?", "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            if (xoa_nv != null)
                            {
                                //Delete success
                                db.NhanViens.Remove(xoa_nv);
                                db.SaveChanges();
                                HienThiDuLieu();

                                //Notification
                                MessageBox.Show("Employee " + MaNV.Text + "  has been deleted !", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                                clearData();
                            }
                            else
                            {
                                MessageBox.Show("Employee " + MaNV.Text + "  is not existed ! \n\n\t Please try again !", "Insert failed",
                                           MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Deny delete !", "Not deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case MessageBoxResult.Cancel:
                            MessageBox.Show("So wasted of time !!", "Cancel");
                            break;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                HienThiDuLieu();
            }
        }

       
        private void tim_click(object sender, RoutedEventArgs e)
        {
            //Dieu huong den Window 2
            Window2 win2 = new Window2();
            win2.Show();
        }

        private void danhsach_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            hien_thi();
        }

        private bool hien_thi()
        {
            if (danhsach.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn hàng trong DataGrid", "Thông báo");
                return false;
            }
            var a = danhsach.SelectedCells[1];
            var content = (a.Column.GetCellContent(a.Item) as TextBlock).Text;
            var nhanvien_sua = (from f in db.NhanViens
                                where f.MaNv == content
                                select f).SingleOrDefault();
            MaNV.Text = nhanvien_sua.MaNv;
            HoTen.Text = nhanvien_sua.HoTen;
            Luong.Text = nhanvien_sua.Luong.ToString();
            Thuong.Text = nhanvien_sua.Thuong.ToString();
            int i = 0;
            for (; i < MaPhong.Items.Count; i++)
            {
                PhongBan phongban_new = (PhongBan)MaPhong.Items[i];
                if (phongban_new.MaPhong == nhanvien_sua.MaPhong)
                {
                    break;
                }
            }
            MaPhong.SelectedIndex = i;
            return true;
        }
    }


}
