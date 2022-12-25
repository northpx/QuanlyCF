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
    public partial class frmDangNhap : Form
    {
        BUS_TaiKhoan LG_BUS = new BUS_TaiKhoan();
        public static string user = "";
        public static string nameuser = "";
        public static string pass = "";
        public static string roless = "";

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            LabelWidth(lblBelow, 450);
            LabelWidth(lblcbo, 243);
            DanhSachQuyen();
        }
        private void DanhSachQuyen()
        {
            DataTable dt = LG_BUS.DanhSachQuyen();
            cboRoles.DataSource = dt;
            cboRoles.DisplayMember = "ten_quyen";
            cboRoles.ValueMember = "ma_quyen";
            cboRoles.SelectedIndex = 1;
        }
        public static void LabelWidth(Label label, int width)
        {
            label.AutoSize = false;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Width = width;
            label.Height = 1;
        }
        public static void LabelHeight(Label label, int size)
        {
            label.AutoSize = false;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Width = 1;
            label.Height = size;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";
            foreach (byte item in hashData)
            {
                hashPass += item;
            }

            if (username == "" || password == "")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return;
            }
            
            if (LG_BUS.DangNhapHeThong(username, hashPass, cboRoles.SelectedValue.ToString()) == null || LG_BUS.DangNhapHeThong(username, hashPass, cboRoles.SelectedValue.ToString()).Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_TaiKhoan.ma_tai_khoan = LG_BUS.DangNhapHeThong(username, hashPass, cboRoles.SelectedValue.ToString()).Rows[0]["ma_tai_khoan"] + "";
            DTO_TaiKhoan.mat_khau = LG_BUS.DangNhapHeThong(username, hashPass, cboRoles.SelectedValue.ToString()).Rows[0]["mat_khau"] + "";
            DTO_TaiKhoan.ma_quyen = LG_BUS.DangNhapHeThong(username, hashPass, cboRoles.SelectedValue.ToString()).Rows[0]["ma_quyen"] + "";

            
            if (string.IsNullOrEmpty(DTO_TaiKhoan.mat_khau))
            {
                MessageBox.Show("Thông tin đăng nhập sai", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();

            frmMain f = new frmMain();
            user = username;
            pass = hashPass;
            roless = cboRoles.SelectedValue.ToString();
            f.ShowDialog();
            this.Show();
        }
    }
}
