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
    public partial class frmThongTinTKCN : Form
    {
        public frmThongTinTKCN()
        {
            InitializeComponent();
        }

        private void frmThongTinTKCN_Load(object sender, EventArgs e)
        {
            txtUser.Text = frmDangNhap.user;
            txtNameUser.Text = frmDangNhap.nameuser;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassold.Text == "")
            {
                MessageBox.Show("Mật khẩu cũ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassold.Focus();
                return;
            }
            if (txtPassNew.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassNew.Focus();
                return;
            }
            if ((txtPassNew.Text != txtRePass.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRePass.Focus();
                return;
            }
            if (txtPassold.Text != frmDangNhap.pass)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassold.Focus();
                return;
            }
            string s = string.Format(@"UPDATE tai_khoan set mat_khau = '" + txtPassNew.Text + "' where ma_tai_khoan = '" + txtUser.Text + "'");
            DBConnect.Instance.ExecuteNonQuery(s);
            MessageBox.Show("Đổi mật khẩu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }
    }
}
