using System;
using System.Collections.Generic;
using System.Text;

namespace Chuong3_part2_vd1
{
    class SinhVien:Nguoi
    {
        private string MaSV;
        //Dong goi du lieu cho masv
        public string maSV
        {
            get { return MaSV; }
            set { MaSV = value; }
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("ma cua sinh vien la: {0}", MaSV);

        }

        public SinhVien(string hoten, string quequan, DateTime ngaysinh, string masv): base(hoten,quequan,ngaysinh)
        {            
            MaSV = masv;
        }
        public SinhVien() { }

    }
}
