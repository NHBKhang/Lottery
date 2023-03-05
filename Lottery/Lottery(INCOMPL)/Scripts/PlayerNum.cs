using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Lottery
{
    class PlayerNum : XoSo
    {
        private static readonly string url = @"..\..\Data\PlayerNum.txt";

        public PlayerNum()
        {
            so1 = so2 = so3 = so4 = so5 = so6 = 0;
        }
        public PlayerNum(int a, int b, int c, int d, int e, int f)
        {
            so1 = a;
            so2 = b;
            so3 = c;
            so4 = d;
            so5 = e;
            so6 = f;
        }
        public void AccessFile(bool isChangable)
        {
            if (File.Exists(url))
            {
                
            }
            else
            {
                MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                File.Create(url);
            }
        }
    }
}
