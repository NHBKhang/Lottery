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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();
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
            } catch (Exception ex)
            {
                string error = String.Format(" Error {0}", ex.Message);
                MessageBox.Show("Wrong input." + error, "Input error");
            }
            return new PlayerNum(cacSo[0], cacSo[1], cacSo[2], cacSo[3], cacSo[4], cacSo[5]);
        }

        private void btChot_Click(object sender, EventArgs e)
        {
            //tăng giá giải thưởng
            GiaiThuong.inc();

            //lấy 6 số đã nhập
            int[] soChon = new int[6];
            PlayerNum playerNum = GetPlayerNumber();

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
            playerNum.AccessFile(false);
        }
    }
}
