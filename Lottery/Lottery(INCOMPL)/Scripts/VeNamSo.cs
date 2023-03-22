using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    class VeNamSo : VeBonSo
    {
        private static readonly string url = @"..\..\Data\VeNamSo.txt";
        public static List<VeNamSo> historyVeNamSo;


        public VeNamSo()
        {
            so1 = random.Next(1, 50);
            so2 = random.Next(1, 50);
            so3 = random.Next(1, 50);
            so4 = random.Next(1, 50);
            so5 = random.Next(1, 50);
        }
        public VeNamSo(string date, int so1, int so2, int so3, int so4, int so5)
        {
            this.date = date;
            this.so1 = so1;
            this.so2 = so2;
            this.so3 = so3;
            this.so4 = so4;
            this.so5 = so5;
        }
        public new bool ComparePlayerNum(PlayerNum playerNum)
        {
            if (playerNum.So6 == this.so5)
            {
                if (playerNum.So5 == this.so4)
                {
                    if (playerNum.So4 == this.so3)
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
            else
                return false;
        }
        public new void AppendFile()
        {
            if (this != null)
            {
                if (File.Exists(VeNamSo.url))
                {
                    File.AppendAllText(VeNamSo.url, this.ToFileString());
                }
                else
                {
                    MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                    File.Create(VeNamSo.url);
                }
            }
        }
        public new static void ReadFile()
        {
            if (File.Exists(VeNamSo.url))
            {
                historyVeNamSo = new List<VeNamSo>();
                try
                {
                    string[] lines = File.ReadAllLines(VeNamSo.url);
                    foreach (string line in lines)
                    {
                        string[] strNum = line.Split(',');
                        int[] num = new int[5];
                        for (int i = 0; i < 5; i++)
                        {
                            num[i] = Convert.ToInt16(strNum[i+1].Trim());
                        }
                        historyVeNamSo.Add(new VeNamSo(strNum[0], num[0], num[1], num[2], num[3], num[4]));
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
                File.Create(VeNamSo.url);
            }
        }
        private string ToFileString()
        {
            date = DateTime.Today.ToString().Split(' ')[0];
            return String.Format("{0},{1},{2},{3},{4},{5},\n",date, so1, so2, so3, so4, so5);
        }
    }
}
