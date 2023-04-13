using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    class VeBaSo : XoSo
    {
        private static readonly string url = @"..\..\Data\VeBaSo.txt";
        public static List<VeBaSo> historyVeBaSo;

        public VeBaSo()
        {
            num = new int[3];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = random.Next(1, 50);
            }
        }
        public VeBaSo(string date, int so1, int so2, int so3)
        {
            this.date = date;
            num = new int[3];
            num[0] = so1;
            num[1] = so2;
            num[2] = so3;
        }
        public override bool ComparePlayerNum(PlayerNum playerNum)
        {
            for (int i = num.Length - 1, j = playerNum.Lenght() - 1; i >= 0; i--)
            {
                int soTrung = 0;
                if (num[i] == playerNum.Num(j))
                {
                    soTrung++;
                    j--;
                    if (soTrung == num.Length)
                        return true;
                }  
            }
            return false;
        }
        public void AppendFile()
        {
            if (this != null)
            {
                if (File.Exists(VeBaSo.url))
                {
                    File.AppendAllText(url, this.ToFileString());
                }
                else
                {
                    MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                    File.Create(VeBaSo.url);
                }
            }
        }
        public static void ReadFile()
        {
            if (File.Exists(VeBaSo.url))
            {
                historyVeBaSo = new List<VeBaSo>();
                try
                {
                    string[] lines = File.ReadAllLines(VeBaSo.url);
                    foreach (string line in lines)
                    {
                        string[] strNum = line.Split(',');
                        int[] num = new int[3];
                        for (int i = 0; i < 3; i++)
                        {
                            num[i] = Convert.ToInt16(strNum[i+1].Trim());
                        }
                        historyVeBaSo.Add(new VeBaSo(strNum[0] ,num[0], num[1], num[2]));
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
                File.Create(VeBaSo.url);
            }
        }

        private string ToFileString()
        {
            date = DateTime.Today.ToString().Split(' ')[0];
            return String.Format("{0},{1},{2},{3}\n",date, num[0], num[1], num[2]);
        }
    }
}
