using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamGiac
{
    class Program
    {
        static void Main(string[] args)
        {
            float a, b, c;
            Console.WriteLine("Nhap do dai 3 canh cua tam giac :\n");
            do
            {
                Console.Write("a = ");
                 a = float.Parse(Console.ReadLine());
                Console.Write("b = ");
                b = float.Parse(Console.ReadLine());
                Console.Write("c = ");
                c = float.Parse(Console.ReadLine());

                if (a <= 0 || b <= 0 || c <= 0 || a + b < c || a + c < b || b + c < a)
                {
                    Console.WriteLine("\n\t\tDo dai khong hop le; Moi nhap lai ");
                }
            } while (a <= 0 || b <= 0 || c <= 0 || a + b < c || a + c < b || b + c < a);
            Console.WriteLine("Chu vi tam giac la : " + ChuVi(a, b, c));
            Console.WriteLine("Dien tich tam giac la : " + DienTich(a, b, c));
            Console.ReadLine();
        }

        static float ChuVi(float a, float b,float c)
        {
            return a + b + c;
        }

        static double DienTich(float a,float b,float c)
        {
            float semi = ChuVi(a, b, c) / 2;
            return Math.Sqrt(semi * (semi - a) * (semi - b) * (semi - c));

        }

    }
}
