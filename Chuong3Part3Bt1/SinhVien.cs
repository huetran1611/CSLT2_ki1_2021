using System;
using System.Collections.Generic;
using System.Text;

namespace Chuong3Part3Bt1
{
    class SinhVien
    {
        private string HoTen, MaSV;
        private DateTime NgaySinh;
        private float DiemLT, DiemCSDL, DiemWeb, DiemTB;

        //Thực hiện đóng gói dữ liệu với get và set
        public string hoTen
        {
            get { return HoTen; }
            set { HoTen = value; }
        }

        public string maSV
        {
            get { return MaSV; }
            set { MaSV = value; }
        }
        public float diemTB
        {

            get { return DiemTB; }
        }
        
        public float diemLT
        {
            set
            {
                if (value <0 || value >= 10)
                {
                    Console.WriteLine("Diem nhap vao ko hop le");
                    return;
                }
                DiemLT = value;
                DiemTB = (DiemLT + DiemCSDL + DiemWeb) / 3;
            }
            get { return DiemLT; }
        }
        public float diemCSDL
        {
            set
            {
                DiemCSDL = value;
                DiemTB = (DiemLT + DiemCSDL + DiemWeb) / 3;
            }
            get { return DiemCSDL; }

        }
        public float diemWeb
        {
            set
            {
                DiemWeb = value;
                DiemTB = (DiemLT + DiemCSDL + DiemWeb) / 3;
            }
            get { return DiemWeb; }
        }
        // tuowng tu viet cho nhung thuoc tinh khac

        // Xay dung phuong thu khoi tao 0 tham so va nhieu thamso

        public SinhVien()
        {
            this.HoTen = "";
            this.MaSV = "";
            this.NgaySinh = new DateTime();
            this.DiemLT = this.DiemCSDL = this.DiemWeb = 0;
        }

        public SinhVien (string HoTen, string MaSV, DateTime NgaySinh, float DiemLT, float DiemCSDL, float DiemWeb)
        {
            this.HoTen = HoTen;
            this.MaSV = MaSV;
            this.NgaySinh = NgaySinh;
            this.DiemLT = DiemLT;
            this.DiemCSDL = DiemCSDL;
            this.DiemWeb = DiemWeb;
        }


        



    }
}
