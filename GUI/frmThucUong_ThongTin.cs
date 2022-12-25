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
    public partial class frmThucUong_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_ThucUong BUS_F = new BUS_ThucUong();
        DTO_ThucUong DTO_F = new DTO_ThucUong();
        public frmThucUong_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmThucUong_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmThucUong.isSave == true)
            {
                DanhSachLoaiThucUong();
            }
            else
            {
                DanhSachLoaiThucUong();
                txtCode.Text = frmThucUong.ma_mon_an;
                txtName.Text = frmThucUong.ten_mon_an;
                cboTypeFood.SelectedValue = frmThucUong.loai_mon_an;
                nmPrice.Value = frmThucUong.don_gia;
                nmAmount.Value = frmThucUong.so_luong;
                txtNote.Text = frmThucUong.ghi_chu;
            }
        }
        private int KiemTraThucUongTonTai(string ma_thuc_uong)
        {
            BUS_ThucUong Food = new BUS_ThucUong();
            if (Food.KiemTraThucUongTonTai(ma_thuc_uong) == 1)
                return 0;
            return 1;
        }
        private void DanhSachLoaiThucUong()
        {
            DataTable dt = BUS_F.DanhSachLoaiThucUong();
            cboTypeFood.DataSource = dt;
            cboTypeFood.DisplayMember = "ten_loai";
            cboTypeFood.ValueMember = "ma_loai";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã món ăn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên món ăn không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (frmThucUong.isSave == true)
            {
                if (KiemTraThucUongTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Món ăn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_F.MaMon = txtCode.Text;
                DTO_F.TenMon = txtName.Text;
                DTO_F.MaLoai = cboTypeFood.SelectedValue.ToString();
                DTO_F.DonGia = nmPrice.Value;
                DTO_F.SoLuong = nmAmount.Value;
                DTO_F.GhiChu = txtNote.Text;
                BUS_F.ThemThucUong(DTO_F);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_F.DanhSachThucUong();
                this.Close();
            }
            else if (frmThucUong.isSave == false)
            {
                if (KiemTraThucUongTonTai(txtCode.Text) == 1 && txtCode.Text != frmThucUong.ma_mon_an)
                {
                    MessageBox.Show("Tạo thất bại, Món ăn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_F.MaMon_Sua = frmThucUong.ma_mon_an;
                DTO_F.MaMon = txtCode.Text;
                DTO_F.TenMon = txtName.Text;
                DTO_F.MaLoai = cboTypeFood.SelectedValue.ToString();
                DTO_F.DonGia = nmPrice.Value;
                DTO_F.SoLuong = nmAmount.Value;
                DTO_F.GhiChu = txtNote.Text;

                BUS_F.SuaThucUong(DTO_F);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_F.DanhSachThucUong();
                this.Close();
            }
        }
    }
}
