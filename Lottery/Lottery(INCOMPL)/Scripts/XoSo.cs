using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public abstract class XoSo
    {
        protected int so1;
        protected int so2;
        protected int so3;
        protected int so4;
        protected int so5;
        protected int so6;
        protected Random random = new Random();
        protected string date;

        public int So1
        {
            get { return so1; }
        }
        public int So2
        {
            get { return so2; }
        }
        public int So3
        {
            get { return so3; }
        }
        public int So4
        {
            get { return so4; }
        }
        public int So5
        {
            get { return so5; }
        }
        public int So6
        {
            get { return so6; }
        }
        protected XoSo()
        {
            so1 = so2 = so3 = so4 = so5 = so6 = 0;
        }
    }
}
