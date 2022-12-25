using BUS;
using DAL;
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
    public partial class frmSoLuong : Form
    {
        protected DataGridView MyDgv;
        BUS_BanHang BUS_BH = new BUS_BanHang();
        public frmSoLuong(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmSoLuong_Load(object sender, EventArgs e)
        {
            if (frmBanHang.isSave == true)
            {
                nmAmount.Value = 1;
            }
            else
            {
                nmAmount.Value = frmBanHang.so_luong;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nmAmount.Value == 0)
            {
                MessageBox.Show("Số lượng không được bằng 0", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (frmBanHang.isSave == true)
            {
                string s = "INSERT INTO hoa_don(ma_tai_khoan,ma_ban,ma_thuc_uong,don_gia,so_luong,thanh_tien,ngay_hoa_don) ";
                s = s + "VALUES ( '" + frmDangNhap.user + "','" + frmBanHang.ma_ban + "',N'" + frmBanHang.ma_mon_an + "'," + frmBanHang.don_gia + "," + nmAmount.Value + "" + "," + frmBanHang.don_gia * nmAmount.Value + "" + ",GETDATE()" + ")";
                DBConnect.Instance.ExecuteNonQuery(s);
                MyDgv.DataSource = BUS_BH.DanhSachGoiMon(frmBanHang.ma_ban);
            }
            else if (frmBanHang.isSave == false)
            {
                string s = "UPDATE hoa_don SET so_luong = " + nmAmount.Value + "" + ",thanh_tien = " + frmBanHang.don_gia * nmAmount.Value + " WHERE ma_hoa_don = " + frmBanHang.id + "";
                DBConnect.Instance.ExecuteNonQuery(s);
                MyDgv.DataSource = BUS_BH.DanhSachGoiMon(frmBanHang.ma_ban);
            }
            this.Close();
        }
    }
}
