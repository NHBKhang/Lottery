using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class VeBonSo : VeBaSo
    {
        private string url;


        public VeBonSo()
        { 
            so1 = random.Next(1, 50);
            so2 = random.Next(1, 50);
            so3 = random.Next(1, 50);
            so4 = random.Next(1, 50);
        }
        public VeBonSo(int so1, int so2, int so3, int so4)
        {
            this.so1 = so1;
            this.so2 = so2;
            this.so3 = so3;
            this.so4 = so4;
        }
        public new bool ComparePlayerNum(PlayerNum playerNum)
        {
            if (playerNum.So6 == this.so4)
            {
                if (playerNum.So5 == this.so3)
                {
                    if (playerNum.So4 == this.so2)
                    {
                        if (playerNum.So4 == this.so1)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
