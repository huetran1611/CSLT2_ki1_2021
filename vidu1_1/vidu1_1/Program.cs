using System;

namespace vidu1_1
{
    class Program
    {
        static void swap(ref int a, ref int b)
        {
            int tem = b;
            b = a;
            a = tem;

        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ////chuong trinh dau tien
            ////nhap vao ten cua ban, in ra loi chao "xin chao + ten_vua_duoc_nhap"
            //Console.WriteLine("Xin chao ten ban la gi?");
            //string ten = Console.ReadLine();
            ////Console.WriteLine("xin chao " + ten);
            //Console.WriteLine("Ban song o dau?");
            //string vitri = Console.ReadLine();
            //Console.WriteLine("xin chao ban {0}, den tu {1}", ten, vitri);

            //Console.WriteLine("den tu {1} chung ta gap go voi ban {0}", ten, vitri);

            //int a = 10;
            //int b = 20;
            //swap(ref a, ref b);
            //Console.WriteLine("gia tri cua a: {0}, b: {1}", a, b);

            // Nhập 2 số nguyên từ bàn phím vào và hiển thị thông báo in ra số lớn hơn:
            //Console.WriteLine("hay nhap so thu nhat:");
            //int a = Convert.ToInt32( Console.ReadLine());
            //Console.WriteLine("hay nhap vao so thu 2");
            //int b = Convert.ToInt32(Console.ReadLine());
            //if (a > b)
            //{
            //    Console.WriteLine("so thu nhat lon hon");
            //}
            //else
            //    Console.WriteLine("so thu hai lon hon");
            //Console.ReadLine(

            // Go tu vao ban phim 1 so nguyen n, hay in ra n la so chan hay so le

            ///1. nhap 10 so nguyen tu ban phim vao:
            ///2. in ra nguyen duong dau tien trong 10 so do
            ///3. Voi tat ca nhung so chan, hay tang gia tri cua so do len 2 lan
            int[] a = new int[10];
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine("hay nhap vao 1 so nguyen: ");
                a[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }
            //2. 
            for(i =0; i<10; i++)
            {
                if (a[i] > 0)
                {
                    Console.WriteLine("so nguyen duong dau tien la: " + a[i]);
                    break;
                }
            }
            //3.
            for (i =0; i<10; i++)
            {
                if (a[i] % 2 == 0)
                {
                    a[i] = a[i] * 2;
                }
                else
                    continue;
            }
            Console.WriteLine("thong tin cua mang sau khi xu ly la");
            for(i =0; i<10; i++)
            {
                Console.Write(a[i] + "; ");
            }
            Console.WriteLine("su dung foreach");

            foreach(int x in a)
            {
                Console.Write(a[i] + "; ");
            }

        }
    }

}
