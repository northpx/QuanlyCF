using BUS;
using DTO;
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
    public partial class frmBan_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_Ban BUS_T = new BUS_Ban();
        DTO_Ban DTO_T = new DTO_Ban();
        public frmBan_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmBan_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmBan.isSave == true)
            {
                DanhSachKhuVuc();
            }
            else
            {
                DanhSachKhuVuc();
                txtCode.Text = frmBan.ma_ban;
                txtName.Text = frmBan.ten_ban;
                cboArea.SelectedValue = frmBan.khu_vuc;
                nmAmount.Value = frmBan.so_luong;
                txtNote.Text = frmBan.ghi_chu;
            }
        }
        private void DanhSachKhuVuc()
        {
            DataTable dt = BUS_T.DanhSachKhuVuc();
            cboArea.DataSource = dt;
            cboArea.DisplayMember = "ten_khu_vuc";
            cboArea.ValueMember = "ma_khu_vuc";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã bàn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên bàn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (frmBan.isSave == true)
            {
                if (KiemTraBanTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Bàn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_T.MaBan = txtCode.Text;
                DTO_T.TenBan = txtName.Text;
                DTO_T.KhuVuc = cboArea.SelectedValue.ToString();
                DTO_T.SoLuong = nmAmount.Value;
                DTO_T.GhIChu = txtNote.Text;
                BUS_T.ThemBan(DTO_T);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_T.DanhSachBan();
                this.Close();
            }
            else if (frmBan.isSave == false)
            {
                if (KiemTraBanTonTai(txtCode.Text) == 1 && txtCode.Text != frmBan.ma_ban)
                {
                    MessageBox.Show("Tạo thất bại, Bàn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_T.MaBan_Sua = frmBan.ma_ban;
                DTO_T.MaBan = txtCode.Text;
                DTO_T.TenBan = txtName.Text;
                DTO_T.KhuVuc = cboArea.SelectedValue.ToString();
                DTO_T.SoLuong = nmAmount.Value;
                DTO_T.GhIChu = txtNote.Text;

                BUS_T.SuaBan(DTO_T);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_T.DanhSachBan();
                this.Close();
            }
        }
        private int KiemTraBanTonTai(string ma_ban)
        {
            BUS_Ban Table = new BUS_Ban();
            if (Table.KiemTraBanTonTai(ma_ban) == 1)
                return 0;
            return 1;
        }
    }
}
