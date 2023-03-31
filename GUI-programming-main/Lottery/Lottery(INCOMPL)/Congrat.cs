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
    public partial class FCongrat : Form
    {
        public FCongrat()
        {
            InitializeComponent();
        }

        private void FCongrat_Load(object sender, EventArgs e)
        {
            lbGiai.Text += GiaiThuong.GetTenGiai(Form2.giai);
            lbMoney.Text = GiaiThuong.FormatPrice(GiaiThuong.GetTienThuongGiai(Form2.giai));
            GiaiThuong.ResetTienThuong();
        }
    }
}
