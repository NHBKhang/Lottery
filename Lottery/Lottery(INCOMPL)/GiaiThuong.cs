using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class GiaiThuong
    {
        enum Giai
        {
            GiaiBa,
            GiaiNhi,
            GiaiNhat,
            GiaiDacBiet
        }
        private static long tienThuong = 10000000;
        public static long TienThuong
        {
            get { return tienThuong; }
            set { tienThuong = value; }
        }
        public GiaiThuong()
        {
            tienThuong = 10000000;
        }
        public static long inc()
        {
            return tienThuong + 100000;
        }
        public static string FormatPrice(long tienThuong)
        {
            return String.Format("{0:N0}đ", tienThuong);
        }
    }
}
