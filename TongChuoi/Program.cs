using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongChuoi
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("\n\tNhap so nguyen duong n : ");
                 n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("\n\tn ko hop le !\n");
                }
            } while (n <= 0);
            Console.Write("\n\t\tGia tri bieu thuc 1 = " + Tong1(n));
            Console.Write("\n\t\tGia tri bieu thuc 2 = " + Tong2(n));
            Console.ReadLine();

        }

        public static int Tong1(int n)
        {
            int S=0;
            for(int i = 1; i <= n; i++)
            {
                S += i;
            }
            return S;
        }

        public static double Tong2(int n)
        {
            double S = 0 ;
              /*      int i=1;
                   while( i <= n){
                        S = S + 1.0 / i;
                        i++;
                    } */
              for(int i = 1; i <= n; i++)
            {
                S = S + 1.0 / i;
            }
            return S;
        }

    }
}
