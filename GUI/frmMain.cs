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
    public partial class frmMain : Form
    {
        BUS_BanHang BUS_BH = new BUS_BanHang();
        public frmMain()
        {
            InitializeComponent();
            
        }

        
        public static void LabelHeight(Label label, int size)
        {
            label.AutoSize = false;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Width = 1;
            label.Height = size;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinTKCN frm = new frmThongTinTKCN();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            frmKhuVuc frm = new frmKhuVuc();
            frm.ShowDialog();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.ShowDialog();
        }

        private void btnLoaiThucUong_Click(object sender, EventArgs e)
        {
            frmLoaiThucUong frm = new frmLoaiThucUong();
            frm.ShowDialog();
        }

        private void btnThucUong_Click(object sender, EventArgs e)
        {
            frmThucUong frm = new frmThucUong();
            frm.ShowDialog();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.ShowDialog();
        }

        private void btnLSHoaDon_Click(object sender, EventArgs e)
        {
            frmLichSuHD frm = new frmLichSuHD();
            frm.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmDoanhThu frm = new frmDoanhThu();
            frm.ShowDialog();
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (frmDangNhap.roless == "NHANVIEN")
            {
                btnTaiKhoan.Enabled = false;
                btnNhanVien.Enabled = false;
                btnKhuVuc.Enabled = false;
                btnBan.Enabled = false;
                btnLoaiThucUong.Enabled = false;
                btnThucUong.Enabled = false;
                btnLSHoaDon.Enabled = false;
                btnDoanhThu.Enabled = false;
            }
        }
    }
}
