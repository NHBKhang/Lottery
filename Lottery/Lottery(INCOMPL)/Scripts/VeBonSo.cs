using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    class VeBonSo : VeBaSo
    {
        private static readonly string url = @"..\..\Data\VeBonSo.txt";
        public static List<VeBonSo> historyVeBonSo;


        public VeBonSo()
        {
            num = new int[4];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = random.Next(1, 50);
            }
        }
        public VeBonSo(string date, int so1, int so2, int so3, int so4)
        {
            this.date = date;
            num = new int[4];
            num[0] = so1;
            num[1] = so2;
            num[2] = so3;
            num[3] = so4;
        }
        public new void AppendFile()
        {
            if(this != null)
            {
                if (File.Exists(VeBonSo.url))
                {
                    File.AppendAllText(VeBonSo.url, this.ToFileString());
                }
                else
                {
                    MessageBox.Show("File not found. File have been created. Turn off and save again.", "Error");
                    File.Create(VeBonSo.url);
                }
            }
        }
        public new static void ReadFile()
        {
            if (File.Exists(VeBonSo.url))
            {
                historyVeBonSo = new List<VeBonSo>();
                try
                {
                    string[] lines = File.ReadAllLines(VeBonSo.url);
                    foreach (string line in lines)
                    {
                        string[] strNum = line.Split(',');
                        int[] num = new int[4];
                        for (int i = 0; i < 4; i++)
                        {
                            num[i] = Convert.ToInt16(strNum[i+1].Trim());
                        }
                        historyVeBonSo.Add(new VeBonSo(strNum[0], num[0], num[1], num[2], num[3]));
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
                File.Create(VeBonSo.url);
            }
        }
        private string ToFileString()
        {
            date = DateTime.Today.ToString().Split(' ')[0];
            return String.Format("{0},{1},{2},{3},{4},\n",date, num[0], num[1], num[2], num[3]);
        }
    }
}
