using System;
using System.Collections.Generic;
using System.Text;

namespace Chuong3_part2_vd1
{
    class Nguoi
    {
        //HoTen, NgaySinh, QueQuan
        protected string HoTen;
        protected string QueQuan;
        protected DateTime NgaySinh;

        // Thuc hien dong goi du lieu

        public string hoTen
        {
            get
            {
                return HoTen;
            }
            set
            {
                HoTen = value;
            }
        }
        // lam tuong tu voi cac thuoc tinh con lai
        public string queQuan
        {
            get { return QueQuan; }
            set { QueQuan = value; }
        }
        public DateTime ngaySinh
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }
        // xuat thong tin
        public virtual void Xuat() {
            Console.WriteLine("Thong tin cua sinh vien:");
            Console.WriteLine("Ho ten: {0}, Que quan: {1}, Ngay sinh: {2}/{3}/{4}, ", 
                               HoTen,  QueQuan, NgaySinh.Day,NgaySinh.Month, ngaySinh.Year );
        }

        public Nguoi() { }
        public Nguoi (string hoten, string quequan, DateTime ngaysinh)
        {
            this.HoTen = hoten;
            this.QueQuan = quequan;
            this.NgaySinh = ngaysinh;
        }


    }
}
