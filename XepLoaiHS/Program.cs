using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLoaiHS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t=== Nhap thong tin ===\n");
            Console.Write("\n\tNhap ho ten HS : ");
            string name = Console.ReadLine();
            Console.Write("\tNhap diem thi cuoi ki : ");
            float result = float.Parse(Console.ReadLine());

            Judgement(name, result);
            Console.ReadLine();
        }

        public static void Judgement(string name, float result)
        {
            name = name.ToUpper();
            Console.WriteLine("\n\n\t\t=== Ket qua ===\n");
            Console.Write(name + " - ");
            if (result >= 8)
            {
                Console.WriteLine("Gioi");
            }else if(result>=6.5 && result < 8)
            {
                Console.WriteLine("Kha");
            }
            else if (result >= 5 && result < 6.5)
            {
                Console.WriteLine("Trung binh");
            }
            else
            {
                Console.WriteLine("\tYeu");
            }

        }
    }
}
