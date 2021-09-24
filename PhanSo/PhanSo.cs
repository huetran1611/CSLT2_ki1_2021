using System;
using System.Collections.Generic;
using System.Text;

namespace PhanSo
{
    class PhanSo
    {
        private int mauSo;
        private int tuSo;

        public PhanSo(int tu, int mau)
        {
            mauSo = mau;
            tuSo = tu;
        }

        public double ConvertToDouble()
        {
            try
            {
                return tuSo / mauSo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
