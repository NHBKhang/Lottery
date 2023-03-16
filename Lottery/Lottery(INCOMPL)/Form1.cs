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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2= new Form2();
            f2.FormClosed += (s, args) => this.Close();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text += GiaiThuong.FormatPrice(GiaiThuong.TienThuong(0));
            label4.Text += GiaiThuong.FormatPrice(GiaiThuong.TienThuong(1));
            label5.Text += GiaiThuong.FormatPrice(GiaiThuong.TienThuong(2));
            label6.Text += GiaiThuong.FormatPrice(GiaiThuong.TienThuong(3));
        }
    }
}
