using System;

namespace Chuong3_part2_vd1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SinhVien sv1 = new SinhVien();
            sv1.hoTen = "nguyen hoai anh";
            sv1.ngaySinh = Convert.ToDateTime("13/04/2000");
            sv1.queQuan = "thai binh";
            sv1.maSV = "20012001A";

            sv1.Xuat();

            SinhVien sv2 = new SinhVien("nguyen minh anh", "Ha Nam", Convert.ToDateTime("10/10/2000"), "20002002A");
            sv2.Xuat();
            Console.ReadLine();

        }
    }
}
