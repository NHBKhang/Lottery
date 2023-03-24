using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class FHistory : Form
    {
        private int lotPos;
        private int playPos;
        public FHistory()
        {
            InitializeComponent();
        }

        private void FHistory_Load(object sender, EventArgs e)
        {
            lotPos = playPos = 0;
            PlayerNum.ReadFile();
            ShowPLayerNum(playPos);

            VeBaSo.ReadFile();
            VeBonSo.ReadFile();
            VeNamSo.ReadFile();
            VeSauSo.ReadFile();
            ShowVeSo(lotPos);
        }
        private void ShowPLayerNum(int playerNumPos)
        {
            if (playerNumPos < PlayerNum.historyPlayerNums.Count && playerNumPos >= 0)
            {
                label1.Text = PlayerNum.historyPlayerNums[playerNumPos].So1.ToString();
                label2.Text = PlayerNum.historyPlayerNums[playerNumPos].So2.ToString();
                label3.Text = PlayerNum.historyPlayerNums[playerNumPos].So3.ToString();
                label4.Text = PlayerNum.historyPlayerNums[playerNumPos].So4.ToString();
                label5.Text = PlayerNum.historyPlayerNums[playerNumPos].So5.ToString();
                label6.Text = PlayerNum.historyPlayerNums[playerNumPos].So6.ToString();
            }
        }
        private void ShowVeSo(int lotteryPos)
        {
            ShowVeBaSo(lotteryPos);
            ShowVeBonSo(lotteryPos);
            ShowVeNamSo(lotteryPos);
            ShowVeSauSo(lotteryPos);

            if (lotteryPos < VeBaSo.historyVeBaSo.Count && lotteryPos >= 0)
                lbDate.Text = VeBaSo.historyVeBaSo[lotteryPos].Date;
            else if (lotteryPos == -1)
                lbDate.Text = string.Empty;
            
            
        }
        private void ShowVeBaSo(int lotteryPos)
        {
            if (lotteryPos < VeBaSo.historyVeBaSo.Count && lotteryPos >= 0)
            {
                lb11.Text = VeBaSo.historyVeBaSo[lotteryPos].So1.ToString();
                lb12.Text = VeBaSo.historyVeBaSo[lotteryPos].So2.ToString();
                lb13.Text = VeBaSo.historyVeBaSo[lotteryPos].So3.ToString();
            }
            else if (lotPos == -1)
                lb11.Text = lb12.Text = lb13.Text = string.Empty;
        }
        private void ShowVeBonSo(int lotteryPos)
        {
            if (lotteryPos < VeBonSo.historyVeBonSo.Count && lotteryPos >= 0)
            {
                lb21.Text = VeBonSo.historyVeBonSo[lotteryPos].So1.ToString();
                lb22.Text = VeBonSo.historyVeBonSo[lotteryPos].So2.ToString();
                lb23.Text = VeBonSo.historyVeBonSo[lotteryPos].So3.ToString();
                lb24.Text = VeBonSo.historyVeBonSo[lotteryPos].So4.ToString();
            }
            else if (lotPos == -1)
                lb21.Text = lb22.Text = lb23.Text = lb24.Text = string.Empty;
        }
        private void ShowVeNamSo(int lotteryPos)
        {
            if (lotteryPos < VeNamSo.historyVeNamSo.Count && lotteryPos >= 0)
            {
                lb31.Text = VeNamSo.historyVeNamSo[lotteryPos].So1.ToString();
                lb32.Text = VeNamSo.historyVeNamSo[lotteryPos].So2.ToString();
                lb33.Text = VeNamSo.historyVeNamSo[lotteryPos].So3.ToString();
                lb34.Text = VeNamSo.historyVeNamSo[lotteryPos].So4.ToString();
                lb35.Text = VeNamSo.historyVeNamSo[lotteryPos].So5.ToString();
            }
            else if (lotPos == -1)
                lb31.Text = lb32.Text = lb33.Text = lb34.Text = lb35.Text = string.Empty;
        }
        private void ShowVeSauSo(int lotteryPos)
        {
            if (lotteryPos < VeSauSo.historyVeSauSo.Count && lotteryPos >= 0)
            {
                lb41.Text = VeSauSo.historyVeSauSo[lotteryPos].So1.ToString();
                lb42.Text = VeSauSo.historyVeSauSo[lotteryPos].So2.ToString();
                lb43.Text = VeSauSo.historyVeSauSo[lotteryPos].So3.ToString();
                lb44.Text = VeSauSo.historyVeSauSo[lotteryPos].So4.ToString();
                lb45.Text = VeSauSo.historyVeSauSo[lotteryPos].So5.ToString();
                lb46.Text = VeSauSo.historyVeSauSo[lotteryPos].So6.ToString();
            }
            else if (lotPos == -1)
                lb41.Text = lb42.Text = lb43.Text = lb44.Text = lb45.Text = lb46.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lotPos++;
            ShowVeSo(lotPos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lotPos--;
            ShowVeSo(lotPos);
        }

        private void btPPrev_Click(object sender, EventArgs e)
        {
            playPos--;
            ShowPLayerNum(playPos);
        }

        private void btPNext_Click(object sender, EventArgs e)
        {
            playPos++;
            ShowPLayerNum(playPos);
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            lotPos = -1;
            DateTime date = dtDate.Value;
            for(int i = 0; i < VeBaSo.historyVeBaSo.Count; i++)
            {
                DateTime hisDate = DateTime.Parse(VeBaSo.historyVeBaSo[i].Date);
                if(date == hisDate)
                {
                    lotPos = i;
                }
            }
            ShowVeSo(lotPos);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
