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
    public partial class frmNhanVien_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_NhanVien BUS_S = new BUS_NhanVien();
        DTO_NhanVien DTO_S = new DTO_NhanVien();
        public frmNhanVien_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmNhanVien_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmNhanVien.isSave == true)
            {
                DanhSachGioiTinh();
            }
            else
            {
                DanhSachGioiTinh();
                txtCode.Text = frmNhanVien.ma_nv;
                txtName.Text = frmNhanVien.ten_nv;
                cboSex.SelectedValue = frmNhanVien.gioi_tinh;
                txtPhone.Text = frmNhanVien.dien_thoai;
                txtAddres.Text = frmNhanVien.dia_chi;
            }
        }
        private void DanhSachGioiTinh()
        {
            DataTable dt = BUS_S.DanhSachGioiTinh();
            cboSex.DataSource = dt;
            cboSex.DisplayMember = "ten_gioi_tinh";
            cboSex.ValueMember = "ma_gioi_tinh";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (frmNhanVien.isSave == true)
            {
                if (KiemTraNhanVienTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Nhân viên này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_S.MaNhanVien = txtCode.Text;
                DTO_S.TeNhanVien = txtName.Text;
                DTO_S.GioiTinh = cboSex.SelectedValue.ToString();
                DTO_S.DienThoai = txtPhone.Text;
                DTO_S.DiaChi = txtAddres.Text;
                BUS_S.ThemNhanVien(DTO_S);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_S.DanhSachNhanVien();
                this.Close();
            }
            else if (frmNhanVien.isSave == false)
            {
                if (KiemTraNhanVienTonTai(txtCode.Text) == 1 && txtCode.Text != frmNhanVien.ma_nv)
                {
                    MessageBox.Show("Tạo thất bại, Nhân viên này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_S.MaNhanVien_Sua = frmNhanVien.ma_nv;
                DTO_S.MaNhanVien = txtCode.Text;
                DTO_S.TeNhanVien = txtName.Text;
                DTO_S.GioiTinh = cboSex.SelectedValue.ToString();
                DTO_S.DienThoai = txtPhone.Text;
                DTO_S.DiaChi = txtAddres.Text;

                BUS_S.SuaNhanVien(DTO_S);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_S.DanhSachNhanVien();
                this.Close();
            }
        }
        private int KiemTraNhanVienTonTai(string ma_nhan_vien)
        {
            BUS_NhanVien User = new BUS_NhanVien();
            if (User.KiemTraNhanVienTonTai(ma_nhan_vien) == 1)
                return 0;
            return 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
