using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public enum Giai
    {
        GiaiBa,
        GiaiNhi,
        GiaiNhat,
        GiaiDacBiet,
        KhongGiai
    }
    static class GiaiThuong
    {

        private static string[] tenGiai = {"giải ba", "giải nhì", "giải nhất", "giải đặc biệt"};
        private static long[] tienThuong = {100000, 500000, 1000000, 10000000 };
        
        public static long TienThuong(int viTri)
        {
            return tienThuong[viTri];
        }
        public static void ResetTienThuong()
        {
            tienThuong[(int)Giai.GiaiDacBiet] = 10000000;
        }
        public static void inc()
        {
            tienThuong[(int) Giai.GiaiDacBiet] += 100000;
        }
        public static string FormatPrice(long tienThuong)
        {
            return String.Format("{0:N0}đ", tienThuong);
        }
        public static string GetTenGiai(Giai giai)
        {
            return tenGiai[(int)giai];
        }
        public static long GetTienThuongGiai(Giai giai)
        {
            return tienThuong[(int)giai];
        }
    }
}
