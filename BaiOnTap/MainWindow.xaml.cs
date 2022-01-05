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
using System.Data.SqlClient;
using System.Data;


namespace BaiOnTap
{
  
    public partial class MainWindow : Window
    {
        private static List<SanPham> sp = new List<SanPham>();
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        //Connect + truy van truc tiep ; ko su dung package
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ULU1CBF;Initial Catalog=QLBANHANG;Integrated Security=True");

        public void LoadGrid()
        {
          
            SqlCommand cmd = new SqlCommand("Select MaSP, TenSP, MaLoai, DonGia,SoLuong, DonGia*SoLuong as Tong from SanPham where DonGia > 100 " +
                "ORDER BY TenSP DESC", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();         
            danhsach.ItemsSource = dt.DefaultView;
            MaSP.Focus();

            danhsach.ItemsSource = sp.ToList();
        }
         
        //Them San Pham
       
        private void them_click(object sender, RoutedEventArgs e)
        {
            try
            {
             //Insert into Database
                SqlCommand cmd = new SqlCommand("INSERT INTO SanPham VALUES(@MaSP, @TenSP, @MaLoai, @SoLuong,@DonGia)", con);
                cmd.CommandType = CommandType.Text;

                //Validate Product code
                if (MaSP.Text == string.Empty)
                {
                    MessageBox.Show("Product code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaSP", MaSP.Text);
                }

                //Validate Product name
                if (TenSP.Text == string.Empty)
                {
                    MessageBox.Show("Product name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TenSP", TenSP.Text);
                }

                //Validate Product type code
                if (MaLoai.Text == string.Empty)
                {
                    MessageBox.Show("Product type code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaLoai", MaLoai.Text);
                }

                //Validate quantity
                int b;
                if (SoLuong.Text == string.Empty)
                {
                    MessageBox.Show("Quantity is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else if (!int.TryParse(SoLuong.Text.ToString(), out b))
                {
                    MessageBox.Show("Quantity is an integer type !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else if (int.Parse(SoLuong.Text) < 0)
                {
                    MessageBox.Show("Quantity is more than 0 !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong.Text);
                }

                //Validate Pice
                if (DonGia.Text == string.Empty)
                {
                    MessageBox.Show("Product price is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!int.TryParse(DonGia.Text.ToString(), out b))
                {
                    MessageBox.Show("Price is an integer type !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (int.Parse(DonGia.Text) < 0)
                {
                    MessageBox.Show("Price is more than 0 !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DonGia", DonGia.Text);
                }

                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Show
                LoadGrid();

                // Add in List Model
                /*  double Tong = 0;
               double gia = double.Parse(DonGia.Text);
               double sl = double.Parse(SoLuong.Text); 
                  Tong = gia*sl;
                  SanPham a = new SanPham(MaSP.Text,TenSP.Text,MaLoai.Text,gia,sl,Tong);
                  sp.Add(a); 
                  danhsach.ItemsSource = sp.ToList(); */

                MessageBox.Show("Successfully created", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message,"SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        //Update record
        private void sua_click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update SanPham set TenSP ='"+TenSP.Text+"'," +
                " DonGia = '"+DonGia.Text+"' , SoLuong = '"+SoLuong.Text+"' " +
                "where MaSP = '"+MaSP.Text+"'",con);

           
            try
            {
                int b;
                if (MaSP.Text == string.Empty)
                {
                    MessageBox.Show("Product code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (TenSP.Text == string.Empty)
                {
                    MessageBox.Show("Product name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (MaLoai.Text != string.Empty)
                {
                    MessageBox.Show("You are not allowed to change Product Type code" +
                        ". 'Loai san pham' must be null.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (DonGia.Text == string.Empty)
                {
                    MessageBox.Show("Product price is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!int.TryParse(DonGia.Text.ToString(), out b))
                {
                    MessageBox.Show("Price is an integer type !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (int.Parse(DonGia.Text) < 0)
                {
                    MessageBox.Show("Price is more than 0 !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (SoLuong.Text == string.Empty)
                {
                    MessageBox.Show("Product quantity is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!int.TryParse(SoLuong.Text.ToString(), out b))
                {
                    MessageBox.Show("Quantity is an integer type !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (int.Parse(SoLuong.Text) < 0)
                {
                    MessageBox.Show("Quantity is more than 0 !", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record has been updated successfully !", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();
            }
        }

        //Clear Data
        public void clearData()
        {
            
            MaSP.Clear();
            TenSP.Clear();
            DonGia.Clear();
            MaLoai.Clear();
            SoLuong.Clear();
            MaSP.Focus();
        }
        private void xoa_click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from SanPham where  MaSP = '" + MaSP.Text + "' ",con);
            try
            {
               

                  if (MaSP.Text == string.Empty)
                {
                    MessageBox.Show("Product code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Do you really want to delete this record ?", "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                            con.Close();
                            clearData();
                            LoadGrid();
                            con.Close();
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Deny delete !", "Not deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case MessageBoxResult.Cancel:
                            MessageBox.Show("Nevermind then...", "Cancel");
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
                con.Close();
            }
        }


        private void tim_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void danhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhsach.SelectedIndex.ToString() != null)
            {
                DataRowView drv = (DataRowView)danhsach.SelectedItem;
                if(drv != null)
                {
                    MaSP.Text = drv[0].ToString();
                    TenSP.Text = drv[1].ToString();
                    MaLoai.Text = drv[2].ToString();
                    SoLuong.Text = drv[3].ToString();
                    DonGia.Text = drv[4].ToString();
                    
                }
            }
        }
    }
}
