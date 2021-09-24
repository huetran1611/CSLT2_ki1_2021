using System;

namespace PhanSo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Tạo lớp phân số
            // in ra kết quả chuyển đổi từ phân số ra số thực

            try
            {
                PhanSo ps1 = new PhanSo(10, 0);
                Console.WriteLine("So thuc tuong ung voi phan so: {0}", ps1.ConvertToDouble());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
