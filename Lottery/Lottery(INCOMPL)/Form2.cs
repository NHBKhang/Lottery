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
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void GetPlayerNumber()
        {


        }

        private void btChot_Click(object sender, EventArgs e)
        {

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
    }
}
