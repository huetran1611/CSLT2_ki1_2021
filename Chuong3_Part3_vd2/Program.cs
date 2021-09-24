using System;

namespace Chuong3_Part3_vd2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a, b;
            try
            {
                Console.WriteLine("hay nhap vao so a: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("hay nhap vao so b: ");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("thuong cua a/b la {0}", a / b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
