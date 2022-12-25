using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDoanhThu : Form
    {
        BUS_BanHang BUS_BH = new BUS_BanHang();
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_BH.DoanhThu(dtFrom1.Value, dtFrom2.Value);
            grdMain.Columns[0].HeaderText = "Mã bàn";
            grdMain.Columns[1].HeaderText = "Tên bàn";
            grdMain.Columns[2].HeaderText = "Tổng tiền";
            grdMain.Columns[0].Width = 50;
            grdMain.Columns[1].Width = 100;
            grdMain.Columns[2].Width = 100;

            if (grdMain.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VND";
                lblTongTien.ForeColor = SystemColors.HotTrack;
                return;
            }
            int tien = grdMain.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdMain.Rows[i].Cells["Total"].Value.ToString());
            }
            lblTongTien.Text = thanhtien.ToString("#,###") + " VND";
            if (lblTongTien.Text == " VND")
            {
                lblTongTien.Text = "0 VND";
            }
        }
    }
}
