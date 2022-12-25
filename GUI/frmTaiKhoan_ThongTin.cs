using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTaiKhoan_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_TaiKhoan BUS_U = new BUS_TaiKhoan();
        DTO_TaiKhoan DTO_U = new DTO_TaiKhoan();
        public frmTaiKhoan_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmTaiKhoan_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmTaiKhoan.isSave == true)
            {
                DanhSachQuyen();
            }
            else
            {
                DanhSachQuyen();
                txtCode.Text = frmTaiKhoan.ma_user;
                txtName.Text = frmTaiKhoan.ten_user;
                cboRoles.SelectedValue = frmTaiKhoan.quyen_user;
                txtPass.Text = frmTaiKhoan.mat_khau;
                txtRePass.Text = frmTaiKhoan.mat_khau;
                txtNote.Text = frmTaiKhoan.ghi_chu;
            }
        }
        private void DanhSachQuyen()
        {
            DataTable dt = BUS_U.DanhSachQuyen();
            cboRoles.DataSource = dt;
            cboRoles.DisplayMember = "ten_quyen";
            cboRoles.ValueMember = "ma_quyen";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã tài khoản không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên tài khoản không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return;
            }
            if ((txtPass.Text != txtRePass.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRePass.Focus();
                return;
            }

            if (frmTaiKhoan.isSave == true)
            {
                if (KiemTraTaiKhoanTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_U.TaiKhoan = txtCode.Text;
                DTO_U.TenTaiKhoan = txtName.Text;
                DTO_U.Quyen = cboRoles.SelectedValue.ToString();

                string pass = txtPass.Text;
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
                byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hashPass = "";
                foreach (byte item in hashData)
                {
                    hashPass += item;
                }

                DTO_U.MatKhau = hashPass;
                DTO_U.GhiChu = txtNote.Text;
                BUS_U.ThemTaiKhoan(DTO_U);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_U.DanhSachTaiKhoan();
                this.Close();
            }
            else if (frmTaiKhoan.isSave == false)
            {
                if (KiemTraTaiKhoanTonTai(txtCode.Text) == 1 && txtCode.Text != frmTaiKhoan.ma_user)
                {
                    MessageBox.Show("Tạo thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_U.TaiKhoanSua = frmTaiKhoan.ma_user;
                DTO_U.TaiKhoan = txtCode.Text;
                DTO_U.TenTaiKhoan = txtName.Text;
                DTO_U.Quyen = cboRoles.SelectedValue.ToString();

                string pass = txtPass.Text;
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
                byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hashPass = "";
                foreach (byte item in hashData)
                {
                    hashPass += item;
                }

                DTO_U.MatKhau = hashPass;
                DTO_U.GhiChu = txtNote.Text;

                BUS_U.SuaTaiKhoan(DTO_U);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_U.DanhSachTaiKhoan();
                this.Close();
            }
        }
        private int KiemTraTaiKhoanTonTai(string ma_tai_khoan)
        {
            BUS_TaiKhoan User = new BUS_TaiKhoan();
            if (User.KiemTraTaiKhoanTonTai(ma_tai_khoan) == 1)
                return 0;
            return 1;
        }
    }
}
