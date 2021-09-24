using System;
using System.Collections.Generic;
using System.Text;

namespace Chuong3Part3Bt1
{
    class DanhSachSV
    {
        private int n;
        private SinhVien[] DS;

        public DanhSachSV(int soLuong)
        {
            n = soLuong;
        }

        public void nhap()
        {
            Console.WriteLine("Hay nhap vao so phan tu cua mang");
            n = Convert.ToInt32(Console.ReadLine());
            DS = new SinhVien[n];
            for (int i =0; i<n; i++)
            {
                Console.WriteLine("Hay nhap thong tin cho sv thu {0}", i+1);
                DS[i] = new SinhVien();
                DS[i] = nhapSV(); // sử dụng hàm nhập sv để thay cho đoạn lệnh phía dưới
                //try
                //{
                //    Console.Write("Ten Sinh Vien: ");
                //    DS[i].hoTen = Console.ReadLine();
                //    Console.Write("Ma sinh vien: ");
                //    DS[i].maSV = Console.ReadLine();
                //    Console.Write("Diem Lap trinh cua sv la: ");
                //    DS[i].diemLT = Convert.ToSingle(Console.ReadLine());
                //    Console.Write("Diem CSDL: ");
                //    DS[i].diemCSDL = Convert.ToSingle(Console.ReadLine());
                //    Console.Write("Diem Web: ");
                //    DS[i].diemWeb = Convert.ToSingle(Console.ReadLine());
                //    Console.WriteLine("Diem tring binh cua sinh vien {0} la {1}", i, DS[i].diemTB);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("chuong trinh bi dung vi " + e.ToString());
                //}
            
            }
        }

        private SinhVien nhapSV()
        {
            SinhVien kq = new SinhVien();
            try
            {
                Console.Write("Ten Sinh Vien: ");
                kq.hoTen = Console.ReadLine();
                Console.Write("Ma sinh vien: ");
                kq.maSV = Console.ReadLine();
                Console.Write("Diem Lap trinh cua sv la: ");
                float diem;
                while (!Single.TryParse (Console.ReadLine(), out diem) || diem <=0 || diem>=10  ){
                    Console.Write("hay nhap Diem Lap trinh cua sv la: ");
                }
                kq.diemLT = diem;
                 
                Console.Write("Diem CSDL: ");
                while (!Single.TryParse(Console.ReadLine(), out diem) || diem <= 0 || diem >= 10)
                {
                    Console.Write("hay nhap lai diem CSDL cua sinh vien la: ");
                }
                kq.diemCSDL = diem;
                
                Console.Write("Diem Web: ");
                while (!Single.TryParse(Console.ReadLine(), out diem) || diem <= 0 || diem >= 10)
                {
                    Console.Write("hay nhap lai diem Web cua sinh vien la: ");
                }
                kq.diemWeb = diem;

                Console.WriteLine("Diem tring binh cua sinh vien  la {0}", kq.diemTB);
            }
            catch (Exception e)
            {
                Console.WriteLine("can phai nhap lai tt cho sv nay  " + e.ToString());
                kq = nhapSV();

            }
            return kq;
            
        }

        public int [] KetQuaSV()
        {
            int[] kq = new int[2];
            kq[0] = 0; // so luong sv lam khoa luan
            kq[1] = 0; // so luong sinh vien lam chuyen de
            for (int i =0; i<n; i++)
            {
                if (DS[i].diemTB >=8 && DS[i].diemLT >=5 && DS[i].diemCSDL >=5 && DS[i].diemWeb >= 5)
                {
                    kq[0] = kq[0] + 1;
                }
                else
                {
                    kq[1] = kq[1]+1;
                }
            }
            return kq;
        }

    }
}
