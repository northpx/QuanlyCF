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
    public partial class frmLichSuHD : Form
    {
        BUS_Ban BUS_T = new BUS_Ban();
        BUS_BanHang BUS_O = new BUS_BanHang();
        public frmLichSuHD()
        {
            InitializeComponent();
        }

        private void frmLichSuHD_Load(object sender, EventArgs e)
        {
            DanhSachBan();
        }
        private void DanhSachBan()
        {
            DataTable dt = BUS_T.DanhSachBan();
            cboTable.DataSource = dt;
            cboTable.DisplayMember = "ten_ban";
            cboTable.ValueMember = "ma_ban";
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_O.DanhSachHoaDon(dtFrom1.Value, dtFrom2.Value, cboTable.SelectedValue.ToString());
            grdMain.Columns[0].HeaderText = "Ngày";
            grdMain.Columns[1].HeaderText = "Bàn";
            grdMain.Columns[2].HeaderText = "Món ăn";
            grdMain.Columns[3].HeaderText = "Đơn giá";
            grdMain.Columns[4].HeaderText = "Số lượng";
            grdMain.Columns[5].HeaderText = "Thành tiền";
            grdMain.Columns[0].Width = 120;
            grdMain.Columns[1].Width = 100;
            grdMain.Columns[2].Width = 100;
            grdMain.Columns[3].Width = 100;
            grdMain.Columns[4].Width = 100;
            grdMain.Columns[5].Width = 100;
        }
    }
}
