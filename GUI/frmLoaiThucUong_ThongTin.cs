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
    public partial class frmLoaiThucUong_ThongTin : Form
    {
        protected DataGridView MyDgv;
        BUS_LoaiThucUong BUS_TF = new BUS_LoaiThucUong();
        DTO_LoaiThucUong DTO_TF = new DTO_LoaiThucUong();
        public frmLoaiThucUong_ThongTin(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Mã loại không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên loại không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (frmLoaiThucUong.isSave == true)
            {
                if (KiemTraLoaiThucUongTonTai(txtCode.Text) == 1)
                {
                    MessageBox.Show("Tạo thất bại, Loại món ăn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_TF.MaLoai = txtCode.Text;
                DTO_TF.TenLoai = txtName.Text;
                DTO_TF.GhiChu = txtNote.Text;
                BUS_TF.ThemLoai(DTO_TF);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_TF.DanhSachLoaiThucUong();
                this.Close();
            }
            else if (frmLoaiThucUong.isSave == false)
            {
                if (KiemTraLoaiThucUongTonTai(txtCode.Text) == 1 && txtCode.Text != frmLoaiThucUong.ma_loai)
                {
                    MessageBox.Show("Tạo thất bại, Loại món ăn này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DTO_TF.MaLoai_Sua = frmLoaiThucUong.ma_loai;
                DTO_TF.MaLoai = txtCode.Text;
                DTO_TF.TenLoai = txtName.Text;
                DTO_TF.GhiChu = txtNote.Text;

                BUS_TF.SuaLoai(DTO_TF);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MyDgv.DataSource = BUS_TF.DanhSachLoaiThucUong();
                this.Close();
            }
        }
        private int KiemTraLoaiThucUongTonTai(string ma_loai)
        {
            BUS_LoaiThucUong TypeFood = new BUS_LoaiThucUong();
            if (TypeFood.KiemTraLoaiThucUongTonTai(ma_loai) == 1)
                return 0;
            return 1;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiThucUong_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmLoaiThucUong.isSave == false)
            {
                txtCode.Text = frmLoaiThucUong.ma_loai;
                txtName.Text = frmLoaiThucUong.ten_loai;
                txtNote.Text = frmLoaiThucUong.ghi_chu;
            }
        }
    }
}
