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
    public partial class Form2 : Form
    {
        public bool isWinning;
        public static Giai giai;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbMoney.Text = "Tiền: " + GiaiThuong.FormatPrice(Program.currentMoney);
            lbDate.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.FormClosed += (s, args) => this.Close();
            f1.Show();        
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private PlayerNum GetPlayerNumber()
        {
            int[] cacSo = new int[6];
            try
            {
                cacSo[0] = Convert.ToInt16(textBox1.Text);
                cacSo[1] = Convert.ToInt16(textBox2.Text);
                cacSo[2] = Convert.ToInt16(textBox3.Text);
                cacSo[3] = Convert.ToInt16(textBox4.Text);
                cacSo[4] = Convert.ToInt16(textBox5.Text);
                cacSo[5] = Convert.ToInt16(textBox6.Text);
                foreach(int i in cacSo)
                {
                    if (i > 50)
                        throw new Exception("Input higher than 50");
                    if (i < 0)
                        throw new Exception("Input lower than 0");
                }
                return new PlayerNum(cacSo[0], cacSo[1], cacSo[2], cacSo[3], cacSo[4], cacSo[5]);
            } catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
                return null;
            }
        }

        private void btChot_Click(object sender, EventArgs e)
        {
            //lấy 6 số đã nhập
            PlayerNum playerNum = GetPlayerNumber();
            if (playerNum == null)
                return;

            VeBaSo ve3So = new VeBaSo();
            lb11.Text = ve3So.So1.ToString();
            lb12.Text = ve3So.So2.ToString();
            lb13.Text = ve3So.So3.ToString();

            VeBonSo ve4So = new VeBonSo();
            lb21.Text = ve4So.So1.ToString();
            lb22.Text = ve4So.So2.ToString();
            lb23.Text = ve4So.So3.ToString();
            lb24.Text = ve4So.So4.ToString();

            VeNamSo ve5So = new VeNamSo();
            lb31.Text = ve5So.So1.ToString();
            lb32.Text = ve5So.So2.ToString();
            lb33.Text = ve5So.So3.ToString();
            lb34.Text = ve5So.So4.ToString();
            lb35.Text = ve5So.So5.ToString();

            VeSauSo ve6So = new VeSauSo();
            lb41.Text = ve6So.So1.ToString();
            lb42.Text = ve6So.So2.ToString();
            lb43.Text = ve6So.So3.ToString();
            lb44.Text = ve6So.So4.ToString();
            lb45.Text = ve6So.So5.ToString();
            lb46.Text = ve6So.So6.ToString();

            isWinning = true;
            if (ve6So.ComparePlayerNum(playerNum))
            {
                giai = Giai.GiaiDacBiet;
            }
            else
            {
                if (ve5So.ComparePlayerNum(playerNum))
                {
                    giai = Giai.GiaiNhat;
                }
                else
                {
                    if (ve4So.ComparePlayerNum(playerNum))
                    {
                        giai = Giai.GiaiNhi;
                    }
                    else
                    {
                        if (ve3So.ComparePlayerNum(playerNum))
                        {
                            giai = Giai.GiaiBa;
                        }
                        else
                        {
                            giai = Giai.KhongGiai;
                            isWinning = false;
                        }
                        
                    }
                }
                
            }
            isWinning = true;
            giai = Giai.GiaiDacBiet;
            if (isWinning)
            {
                FCongrat fCongrat = new FCongrat();
                fCongrat.ShowDialog();
                Program.IncCurrentMoney(GiaiThuong.GetTienThuongGiai(giai));
                lbMoney.Text = "Tiền: " + GiaiThuong.FormatPrice(Program.currentMoney);
                GiaiThuong.ResetTienThuong();
            }

            //tăng giá giải thưởng
            GiaiThuong.inc();
        }

        private void btRandomTicket_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            textBox1.Text = random.Next(1, 50).ToString();
            textBox2.Text = random.Next(1, 50).ToString();
            textBox3.Text = random.Next(1, 50).ToString();
            textBox4.Text = random.Next(1, 50).ToString();
            textBox5.Text = random.Next(1, 50).ToString();
            textBox6.Text = random.Next(1, 50).ToString();
        }

        private void BtHistory_Click(object sender, EventArgs e)
        {
            FHistory fHistory = new FHistory();
            fHistory.Show();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            PlayerNum playerNum = GetPlayerNumber();
            if (playerNum == null)
                return;
            playerNum.AppendFile();
        }

        private void btSaveResult_Click(object sender, EventArgs e)
        {
            VeBaSo veBaSo = GetVeBaSo();
            VeBonSo veBonSo = GetVeBonSo();
            VeNamSo veNamSo = GetVeNamSo();
            VeSauSo veSauSo = GetVeSauSo();
            if (veBaSo != null && veBonSo != null && veNamSo != null && veSauSo != null)
            {
                veBaSo.AppendFile();
                veBonSo.AppendFile();
                veNamSo.AppendFile();
                veSauSo.AppendFile();
            }
        }
        private VeBaSo GetVeBaSo()
        {
            int[] cacSo = new int[3];
            try
            {
                cacSo[0] = Convert.ToInt16(lb11.Text);
                cacSo[1] = Convert.ToInt16(lb12.Text);
                cacSo[2] = Convert.ToInt16(lb13.Text);
                return new VeBaSo(lbDate.Text ,cacSo[0], cacSo[1], cacSo[2]);
            }
            catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
                return null;
            }
        }
        private VeBonSo GetVeBonSo()
        {
            int[] cacSo = new int[4];
            try
            {
                cacSo[0] = Convert.ToInt16(lb21.Text);
                cacSo[1] = Convert.ToInt16(lb22.Text);
                cacSo[2] = Convert.ToInt16(lb23.Text);
                cacSo[3] = Convert.ToInt16(lb24.Text);
                return new VeBonSo(lbDate.Text, cacSo[0], cacSo[1], cacSo[2], cacSo[3]);
            }
            catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
                return null;
            }
        }
        private VeNamSo GetVeNamSo()
        {
            int[] cacSo = new int[5];
            try
            {
                cacSo[0] = Convert.ToInt16(lb31.Text);
                cacSo[1] = Convert.ToInt16(lb32.Text);
                cacSo[2] = Convert.ToInt16(lb33.Text);
                cacSo[3] = Convert.ToInt16(lb34.Text);
                cacSo[4] = Convert.ToInt16(lb35.Text);
                return new VeNamSo(lbDate.Text, cacSo[0], cacSo[1], cacSo[2], cacSo[3], cacSo[4]);
            }
            catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
                return null;
            }
        }
        private VeSauSo GetVeSauSo()
        {
            int[] cacSo = new int[6];
            try
            {
                cacSo[0] = Convert.ToInt16(lb41.Text);
                cacSo[1] = Convert.ToInt16(lb42.Text);
                cacSo[2] = Convert.ToInt16(lb43.Text);
                cacSo[3] = Convert.ToInt16(lb44.Text);
                cacSo[4] = Convert.ToInt16(lb45.Text);
                cacSo[5] = Convert.ToInt16(lb46.Text);
                return new VeSauSo(lbDate.Text, cacSo[0], cacSo[1], cacSo[2],cacSo[3], cacSo[4], cacSo[5]);
            }
            catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
                return null;
            }
        }
    }
}
