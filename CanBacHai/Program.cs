using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanBacHai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\tNhap do chinh xac epsilon (ep < 1) : ");
            double epsilon = Convert.ToDouble(Console.ReadLine());
            Console.Write("\n\tNhap so a(a>0) : ");
            int a = Convert.ToInt32(Console.ReadLine());
            double result = 1.0f;
            while(Math.Abs(result * result-a)/a >= epsilon)
            {
                result = (a / result - result) / 2 + result;
            }

            Console.Write("\n\tCan bac 2 cua {0} = {1} ", a, result);
            Console.ReadLine();
        }
    }
}
