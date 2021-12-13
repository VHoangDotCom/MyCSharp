using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCustomer
{
    class Program
    {
        public List<KhachHang> ListKH = null;
        public List<KhachHangThanThiet> ListKHTT = null;
        // Bo private di
        public Program()
        {
            ListKH = new List<KhachHang>();
            ListKHTT = new List<KhachHangThanThiet>();
        }
        public static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Menu();
        }
        public void Menu()
        {
            KhachHang kh = new KhachHang();
            KhachHangThanThiet khtt = new KhachHangThanThiet();
            int key;
            while (true)
            {
                Console.WriteLine("\n\n\n\t\t QUAN LY KHACH HANG \n");
                Console.WriteLine("\t\t=========== MENU =============");
                Console.WriteLine("\t\t 1. Nhap thong tin");
                Console.WriteLine("\t\t 2. Hien thi danh sach");
                Console.WriteLine("\t\t 3. Sap xep danh sach");
                Console.WriteLine("\t\t 4. Thoat");
                try
                {
                    Console.Write("\n\t#Nhap lua chon : ");
                    key = Convert.ToInt32(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n\t\t\t 1. Khach Hang");
                            Console.WriteLine("\n\t\t\t 2. Khach Hang Than Thiet");
                            Console.Write("#Nhap lua chon : ");
                            int chon = Convert.ToInt32(Console.ReadLine());
                            if (chon == 1)
                            {
                                
                                Console.Write("Nhap ho ten khach hang : ");
                                string name = Console.ReadLine();
                                KhachHang khachHang = FindByName(name);
                                if(khachHang != null)
                                {
                                   
                                    goto case 1;

                                }
                                else
                                {
                                    kh._hoTen = name;
                                    Console.Write("Nhap gioi tinh ( true-nam / false-nu )  : ");

                                    if (Console.ReadLine() == "true")
                                    {
                                        kh._gioiTinh = true;
                                    }
                                    else if (Console.ReadLine() == "false")
                                    {
                                        kh._gioiTinh = false;
                                    }

                                    Console.Write("Nhap So luong mua : ");
                                    kh._slMua = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Nhap don gia : ");
                                    kh._donGia = Convert.ToDouble(Console.ReadLine());
                                    ListKH.Add(kh);
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\tThem moi khach hang thanh cong !");
                                }
                               
                            }
                            else if (chon == 2)
                            {
                                //Them khtt
                                Console.Write("Nhap ho ten khach hang than thiet : ");
                                khtt._hoTen = Console.ReadLine();
                                Console.Write("Nhap gioi tinh ( true-nam / false-nu ) : ");

                                if (Console.ReadLine() == "true")
                                {
                                    khtt._gioiTinh = true;
                                }
                                else if (Console.ReadLine() == "false")
                                {
                                    khtt._gioiTinh = false;
                                }
                                Console.Write("Nhap So luong mua : ");
                                khtt._slMua = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Nhap don gia : ");
                                khtt._donGia = Convert.ToDouble(Console.ReadLine());
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
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t Gia tri nhap vao khong hop le !");
                    Console.WriteLine("\t\t\t=> " + ex.Message);
                }
            }
        }

        //Ham tim kiem theo ten
        public KhachHang FindByName(string name)
        {
            KhachHang searchName = null;
            if(ListKH != null && ListKH.Count > 0)
            {
                foreach(KhachHang kh in ListKH)
                {
                    if (kh._hoTen == name)
                    {
                        searchName = kh;
                    }
                }
            }
            return searchName;
        }

        //Hien thi danh sach KH
        public void ShowKH(List<KhachHang> listKH)
        {

            Console.WriteLine("\n\t\t\t\tDanh sach khach hang : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKH != null && listKH.Count > 0)
            {
                foreach (KhachHang khachh in listKH)
                {
                   
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachh._hoTen, khachh._gioiTinh, khachh._slMua, khachh._donGia, khachh.tongTien(), "Khong");
                }
            }
        }

        //Hien thi ds KHTT
        public void ShowKHTT(List<KhachHangThanThiet> listKHTT)
        {

            Console.WriteLine("\n\n\t\t\t\tDanh sach khach hang than thiet : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKHTT != null && listKHTT.Count > 0)
            {
                foreach (KhachHangThanThiet khachhtt in listKHTT)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachhtt._hoTen, khachhtt._gioiTinh, khachhtt._slMua, khachhtt._donGia, khachhtt.tongTien(), khachhtt.QuaTang());
                }
            }
        }

        //DSKH da sap xep
        public void ShowKHSorted(List<KhachHang> listKH)
        {

            Console.WriteLine("\n\n\t\t\t\tDanh sach khach hang da sap xep : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKH != null && listKH.Count > 0)
            {
                foreach (KhachHang khachh in listKH)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachh._hoTen, khachh._gioiTinh, khachh._slMua, khachh._donGia, khachh.tongTien(),"Khong");
                }
                listKH.Sort();
            }
        }

        //DSKHTT da sap xep
        public void ShowKHTTSorted(List<KhachHangThanThiet> listKHTT)
        {

            Console.WriteLine("\n\n\t\t\t\tDanh sach khach hang than thiet da sap xep : ");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
                "Ho ten", "Gioi tinh", "SL mua", "Don gia", "Tong tien", "Qua tang");
            if (listKHTT != null && listKHTT.Count > 0)
            {

                foreach (KhachHangThanThiet khachhtt in listKHTT)
                {
                    Console.WriteLine("{0,-20} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,-15} ",
               khachhtt._hoTen, khachhtt._gioiTinh, khachhtt._slMua, khachhtt._donGia, khachhtt.tongTien(), khachhtt.QuaTang());
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
