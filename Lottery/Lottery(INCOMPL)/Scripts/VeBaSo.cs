﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class VeBaSo : XoSo
    {
        private string url;


        public VeBaSo()
        {
            so1 = random.Next(1, 50);
            so2 = random.Next(1, 50);
            so3 = random.Next(1, 50);
        }
        public VeBaSo(int so1, int so2, int so3)
        {
            this.so1 = so1;
            this.so2 = so2;
            this.so3 = so3;
        }
        public bool ComparePlayerNum(PlayerNum playerNum)
        {
            if (playerNum.So6 == this.so3)
            {
                if (playerNum.So5 == this.so2)
                {
                    if (playerNum.So4 == this.so1)
                    {

                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
            
            return true;
        }

    }
}
