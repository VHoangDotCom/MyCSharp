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


namespace EmployeeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Connect truc tiep Database
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ULU1CBF;Initial Catalog=QLNhanVien;Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        //Clear Data textbox
        public void clearData()
        {
            MaNV.Clear();
            HoTen.Clear();
            Luong.Clear();
            Thuong.Clear();
            MaPhong.Clear();
            MaNV.Focus();
        }

        //Show in List
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select MaNV, HoTen, FORMAT(Luong,'#,###,##0') as Luong, FORMAT(Thuong,'#,###,##0') as Thuong, MaPhong, FORMAT(Luong+Thuong,'#,###,##0') as Tong " +
                "from NhanVien " +
                "WHERE Luong > 5000 " +
                "ORDER BY  Luong ASC", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            danhsach.ItemsSource = dt.DefaultView;
            MaNV.Focus();
        }

        //Show in textbox
        private void danhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(danhsach.SelectedIndex.ToString() != null)
            {
                DataRowView drv = (DataRowView)danhsach.SelectedItem;
                if(drv != null)
                {
                    MaNV.Text = drv[0].ToString();
                    HoTen.Text = drv[1].ToString();
                    Luong.Text = drv[2].ToString();
                    Thuong.Text = drv[3].ToString();
                    MaPhong.Text = drv[4].ToString();
                }
            }
        }

        //Create Employee
        private void them_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Insert into Database
                SqlCommand cmd = new SqlCommand("INSERT INTO NhanVien VALUES (@MaNV, @HoTen, @Luong, @Thuong, @MaPhong)", con);
                cmd.CommandType = CommandType.Text;

                //Validate Employee Code
                if (MaNV.Text == string.Empty)
                {
                    MessageBox.Show("Employee code is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaNV", MaNV.Text);
                }

                //validate Name
                if (HoTen.Text == string.Empty)
                {
                    MessageBox.Show("Employee full name is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@HoTen", HoTen.Text);
                }

                //Validate Salary
                int b;
                if (Luong.Text == string.Empty)
                {
                    MessageBox.Show("Salary field is empty !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } else if (!int.TryParse(Luong.Text.ToString(), out b))
                {
                    MessageBox.Show("Salary is an integer type !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } else if (int.Parse(Luong.Text) <3000 || int.Parse(Luong.Text) > 9000)
                {
                    MessageBox.Show("Salary is in 3000 - 9000 !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Luong", Luong.Text);
                }

                //Validate Thuong
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
                    cmd.Parameters.AddWithValue("@Thuong", Thuong.Text);
                }

                //Validate Department code
                if (MaPhong.Text == string.Empty)
                {
                    MessageBox.Show("Department code is required !", "Insert failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaPhong", MaPhong.Text);
                }

                //Execute Query
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Show after insert
                LoadGrid();

                //Notification success
                MessageBox.Show("Successfully created", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        //Update Employee
        private void sua_click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update NhanVien set HoTen ='" + HoTen.Text + "'," +
                "Luong = '"+Luong.Text+"', Thuong = '"+Thuong.Text+"', MaPhong = '"+MaPhong.Text+"'" +
                "where MaNV = '"+MaNV.Text+"'",con);

            //Validate update
            try
            {
                int b;
                //Validate code
                if(MaNV.Text == string.Empty)
                {
                    MessageBox.Show("Employee code is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate name
                 if(HoTen.Text == string.Empty)
                {
                    MessageBox.Show("Employee name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate Salary
                 if(Luong.Text == string.Empty)
                {
                    MessageBox.Show("Salary is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record has been updated successfully !", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }catch(SqlException ex)
            { 
               MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
               
                LoadGrid();
            }

        }

        //Delete Employee
        private void xoa_click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from NhanVien" +
                " where MaNV = '" + MaNV.Text + "' ", con);
           
            try
            {
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
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL error !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
                LoadGrid();
            }
        
        }

        //Search Employee
        private void tim_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
