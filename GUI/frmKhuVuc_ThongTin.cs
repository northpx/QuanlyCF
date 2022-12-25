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
    public partial class frmKhuVuc_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_KhuVuc BUS_A = new BUS_KhuVuc();
        DTO_KhuVuc DTO_A = new DTO_KhuVuc();
        public frmKhuVuc_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void frmKhuVuc_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmKhuVuc.isSave == false)
            {
                txtCode.Text = frmKhuVuc.ma_kv;
                txtName.Text = frmKhuVuc.ten_kv;
                txtNote.Text = frmKhuVuc.ghi_chu;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã khu vực không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên khu vực không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (frmKhuVuc.isSave == true)
            {
                if (KiemTraKhuVucTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Khu vực này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_A.MaKhuVuc = txtCode.Text;
                DTO_A.TenKhuVuc = txtName.Text;
                DTO_A.GhiChu = txtNote.Text;
                BUS_A.ThemKhuVuc(DTO_A);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_A.DanhSachKhuVuc();
                this.Close();
            }
            else if (frmKhuVuc.isSave == false)
            {
                if (KiemTraKhuVucTonTai(txtCode.Text) == 1 && txtCode.Text != frmKhuVuc.ma_kv)
                {
                    MessageBox.Show("Tạo thất bại, Khu vực này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_A.MaKhuVuc_Sua = frmKhuVuc.ma_kv;
                DTO_A.MaKhuVuc = txtCode.Text;
                DTO_A.TenKhuVuc = txtName.Text;
                DTO_A.GhiChu = txtNote.Text;

                BUS_A.SuKhuVuc(DTO_A);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_A.DanhSachKhuVuc();
                this.Close();
            }
        }
        private int KiemTraKhuVucTonTai(string ma_khu_vuc)
        {
            BUS_KhuVuc Area = new BUS_KhuVuc();
            if (Area.KiemTraKhuVucTonTai(ma_khu_vuc) == 1)
                return 0;
            return 1;
        }
    }
}
