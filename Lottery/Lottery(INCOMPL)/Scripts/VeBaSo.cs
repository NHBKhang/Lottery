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
            so1 = random.Next(1, 50);
            so2 = random.Next(1, 50);
            so3 = random.Next(1, 50);
        }
        public VeBaSo(string date, int so1, int so2, int so3)
        {
            this.date = date;
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
            return String.Format("{0},{1},{2},{3}\n",date, so1, so2, so3);
        }
    }
}
