using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public abstract class XoSo
    {
        protected int[] num;
        protected Random random = new Random();
        protected string date;

        public int Num(int index)
        {
            if (index < 0 || index >= num.Length)
            {
                return -1;
            }
            return num[index];
        }
        public string Date
        {
            get { return date; }
        }
        protected XoSo()
        {
            
        }
        public abstract bool ComparePlayerNum(PlayerNum playerNum);
    }
}
