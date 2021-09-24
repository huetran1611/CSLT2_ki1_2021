using System;

namespace Chuong3Part3Bt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DanhSachSV dsSinhVien = new DanhSachSV(0);
            dsSinhVien.nhap();
            int[] kq = dsSinhVien.KetQuaSV();
            Console.WriteLine("So luong sinh vien duoc lam khoa luan la: {0}, so luong duoc lam chuyen de {1} ", kq[0], kq[1]);
            Console.ReadLine();
        }
    }
}
