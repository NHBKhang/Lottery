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
        public static List<PlayerNum> historyPlayerNums;

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
        public void AppendFile()
        {
            if (File.Exists(url))
            {
                File.AppendAllText(url, this.ToFileString());
            }
            else
            {
                MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                File.Create(url);
            }

                
        }
        public static void ReadFile()
        {
            if (File.Exists(url))
            {
                historyPlayerNums = new List<PlayerNum>();
                try
                {
                    string[] lines = File.ReadAllLines(url);
                    foreach (string line in lines)
                    {
                        string[] strNum = line.Split(',');
                        int[] num = new int[6];
                        for (int i = 0; i < 6; i++)
                        {
                            num[i] = Convert.ToInt16(strNum[i].Trim());
                        }
                        historyPlayerNums.Add(new PlayerNum(num[0], num[1], num[2], num[3], num[4], num[5]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                File.Create(url);
            }
        }
        private string ToFileString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},\n",so1, so2, so3, so4, so5, so6);
        }

    }
}
