using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Hoang_835_S2_C1
{
    public class Program
    {

        public List<KhachHang> ListKH = null;
        public List<KhachHangThanThiet> ListKHTT = null;

        public Program()
        {
            ListKH = new List<KhachHang>();
            ListKHTT = new List<KhachHangThanThiet>();
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }

        public  void Menu()
        {
            KhachHang kh = new KhachHang();
            KhachHangThanThiet khtt = new KhachHangThanThiet();
            int key;
            while (true)
            {
                Console.WriteLine("\n\t\t QUAN LY KHACH HANG \n");
                Console.WriteLine("\t\t=========== MENU =============");
                Console.WriteLine("\t\t\t 1. Nhap thong tin");
                Console.WriteLine("\t\t\t 2. Hien thi danh sach");
                Console.WriteLine("\t\t\t 3. Sap xep danh sach");
                Console.WriteLine("\t\t\t 4. Thoat");
                try
                {
                    Console.Write("\n\t#Nhap lua chon : ");
                    key = Convert.ToInt32(Console.ReadLine());

                    switch (key)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n\t\t\t 1. Khach Hang");
                            Console.WriteLine("\n\t\t\t 2. Khach Hang than thiet");
                            Console.Write("Nhap lua chon cua ban : ");
                            int chon = Convert.ToInt32(Console.ReadLine());
                            if (chon == 1)
                            {
                                //Them kh
                                Console.WriteLine("Nhap ho ten khach hang : ");
                                kh.hoTen = Console.ReadLine();
                                Console.WriteLine("Nhap gioi tinh : ");
                                kh.gioiTinh = Console.ReadLine();
                                Console.WriteLine("Nhap So luong mua : ");
                                kh.slMua =Convert.ToInt32( Console.ReadLine());
                                Console.WriteLine("Nhap don gia : ");
                                kh.donGia =Convert.ToDouble( Console.ReadLine());
                                ListKH.Add(kh);
                                Console.Clear();
                                Console.WriteLine("\n\n\t\tThem moi khach hang thanh cong !");
                            }
                            else if (chon == 2)
                            {
                                //Them khtt
                                Console.WriteLine("Nhap ho ten khach hang than thiet : ");
                                khtt.hoTen = Console.ReadLine();
                                Console.WriteLine("Nhap gioi tinh : ");
                                khtt.gioiTinh = Console.ReadLine();
                                Console.WriteLine("Nhap So luong mua : ");
                                khtt.slMua = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Nhap don gia : ");
                                khtt.donGia = Convert.ToDouble(Console.ReadLine());
                                ListKHTT.Add(khtt);
                                Console.Clear();
                                Console.WriteLine("\n\n\t\tThem moi khach hang than thiet thanh cong !");
                            }
                            else
                            {
                                Console.WriteLine("Lua chon khong hop le !");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            ShowKH(GetKhachHangs());

                            ShowKHTT(GetKhachHangThanThiets());


                            break;
                        case 3:
                            //Sap xep theo ten + so luog mua
                            Console.Clear();
                            ShowKHSorted(GetKhachHangs());

                            ShowKHTTSorted(GetKhachHangThanThiets());

                            break;
                        case 4:
                            Console.WriteLine("\n\n\t\t  Goodbye !! ");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\n\n\t\t\tChuc nang khogn hop le ! Moi nhap lai ! !\n\n");
                            break;

                    }
                }catch(Exception error)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t Gia tri nhap vao khong hop le !!");
                    Console.WriteLine("\t\t\t=> " + error.Message);

                }
            }
        }

        public void ShowKH(List<KhachHang> listKH)
        {
            
            Console.WriteLine("\n\t\tDanh sach khach hang : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien");
            if (listKH != null && listKH.Count > 0)
            {
                foreach (KhachHang khachh in listKH)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | ",
               khachh.hoTen, khachh.gioiTinh, khachh.slMua, khachh.donGia, khachh.tongTien());
                }
            }
        }

        public void ShowKHSorted(List<KhachHang> listKH)
        {

            Console.WriteLine("\n\t\tDanh sach khach hang : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien");
            if (listKH != null && listKH.Count > 0)
            {
                foreach (KhachHang khachh in listKH)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | ",
               khachh.hoTen, khachh.gioiTinh, khachh.slMua, khachh.donGia, khachh.tongTien());
                }
                listKH.Sort();
            }
        }

        public void ShowKHTT(List<KhachHangThanThiet> listKHTT)
        {
           
            Console.WriteLine("\n\t\tDanh sach khach hang than thiet : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKHTT != null && listKHTT.Count > 0)
            {
                foreach (KhachHangThanThiet khachhtt in listKHTT)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachhtt.hoTen, khachhtt.gioiTinh, khachhtt.slMua, khachhtt.donGia, khachhtt.tongTien(), khachhtt.QuaTang());
                }
            }
        }

        public void ShowKHTTSorted(List<KhachHangThanThiet> listKHTT)
        {

            Console.WriteLine("\n\t\tDanh sach khach hang than thiet : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKHTT != null && listKHTT.Count > 0)
            {
               
                foreach (KhachHangThanThiet khachhtt in listKHTT)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachhtt.hoTen, khachhtt.gioiTinh, khachhtt.slMua, khachhtt.donGia, khachhtt.tongTien(), khachhtt.QuaTang());
                }
                listKHTT.Sort();
            }
        }

        public List<KhachHang> GetKhachHangs()
        {
            return ListKH;
        }
       
        public List<KhachHangThanThiet> GetKhachHangThanThiets()
        {
            return ListKHTT;
        }

        static void PressAnyKey()
        {
            Console.WriteLine("\n\t\tNhan phim bat ki de tiep tuc...");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
