using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class VeBaSo : XoSo
    {
        protected string date;
        private string url;

        public VeBaSo()
        {
            so1 = so2 = so3 = 0;
        }
        public VeBaSo(int so1, int so2, int so3)
        {
            this.so1 = so1;
            this.so2 = so2;
            this.so3 = so3;
        }

    }
}
