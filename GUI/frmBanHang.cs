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
    public partial class frmBanHang : Form
    {
        public static string ma_ban = "";
        DataTable dt = new DataTable();
        DAL_BanHang DAL_BH = new DAL_BanHang();
        BUS_BanHang BUS_BH = new BUS_BanHang();
        public static bool isSave = true;
        public static int id;
        public static string ma_mon_an = "";
        public static decimal don_gia;
        public static decimal so_luong;
        public static decimal tong_tien;
        public static string ngay_hd;
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            ma_ban = "";
            rdTatCa.Checked = true;
            DanhSachThucUong();
            DanhSachGoiMon(ma_ban);
            LoadComboboxTimKiem();
            txtUser.Text = frmDangNhap.user;
        }
        public void DanhSachGoiMon(string sma_ban)
        {
            grdOrder.AllowUserToAddRows = false;
            grdOrder.DataSource = BUS_BH.DanhSachGoiMon(sma_ban);
            grdOrder.Columns[0].HeaderText = "Id";
            grdOrder.Columns[1].HeaderText = "Bàn";
            grdOrder.Columns[2].HeaderText = "Món ăn";
            grdOrder.Columns[3].HeaderText = "Đơn giá";
            grdOrder.Columns[4].HeaderText = "Số lượng";
            grdOrder.Columns[5].HeaderText = "Tổng tiền";
        }
        private void LoadComboboxTimKiem()
        {
            DataTable dataTable = new DataTable();
            cboSearch.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("ma_thuc_uong", "Mã thức uống");
            dataTable.Rows.Add("ten_thuc_uong", "Tên thức uống");
            dataTable.Rows.Add("ma_loai", "Mã loại");
            dataTable.Rows.Add("don_gia", "Đơn giá");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
            cboSearch.SelectedIndex = 1;
        }
        private void DanhSachThucUong()
        {
            grdFood.AllowUserToAddRows = false;
            grdFood.DataSource = BUS_BH.DanhSachThucUong();
            grdFood.Columns[0].HeaderText = "Mã thức uống";
            grdFood.Columns[1].HeaderText = "Tên thức uống";
            grdFood.Columns[2].HeaderText = "Loại thức uống";
            grdFood.Columns[3].HeaderText = "Đơn giá";
            
        }
        private void DanhSachBan()
        {
            lvBan.Items.Clear();
            dt = DAL_BH.DanhSachBanTrong();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["ten_ban"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dt.Rows[i][0].ToString());
                item.ImageIndex = 0;
                item.SubItems.Add(subItem);
                lvBan.Items.Add(item);
            }
            dt = DAL_BH.DanhSachBanCoNguoi();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["ten_ban"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dt.Rows[i][0].ToString());
                item.ImageIndex = 1;
                item.SubItems.Add(subItem);
                lvBan.Items.Add(item);
            }
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            lvBan.Items.Clear();
            DanhSachBan();
        }

        private void rdTrong_CheckedChanged(object sender, EventArgs e)
        {
            lvBan.Items.Clear();
            dt = DAL_BH.DanhSachBanTrong();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["ten_ban"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dt.Rows[i][0].ToString());
                item.ImageIndex = 0;
                item.SubItems.Add(subItem);
                lvBan.Items.Add(item);
            }
        }

        private void rdCoNguoi_CheckedChanged(object sender, EventArgs e)
        {
            lvBan.Items.Clear();
            dt = DAL_BH.DanhSachBanCoNguoi();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["ten_ban"].ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, dt.Rows[i][0].ToString());
                item.ImageIndex = 1;
                item.SubItems.Add(subItem);
                lvBan.Items.Add(item);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_BH.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdFood.DataSource = dt;
        }

        private void lvBan_Click(object sender, EventArgs e)
        {
            string _ma_ban = lvBan.SelectedItems[0].SubItems[0].Text;
            lblten_ban.Text = _ma_ban;
            ma_ban = lvBan.SelectedItems[0].SubItems[1].Text;
            DanhSachGoiMon(ma_ban);
            TongTienHoaDon();
        }
        public void TongTienHoaDon()
        {
            if (grdOrder.Rows.Count == 0)
            {
                txttong_tien.Text = "0";
                return;
            }
            int tien = grdOrder.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdOrder.Rows[i].Cells["thanh_tien"].Value.ToString());
            }
            txttong_tien.Text = thanhtien.ToString("#,###");
            if (txttong_tien.Text == " VND")
            {
                txttong_tien.Text = "0 VND";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblten_ban.Text == "")
            {
                MessageBox.Show("Chưa chọn bàn để gọi món", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow row = this.grdFood.Rows[grdFood.CurrentCell.RowIndex];
            isSave = true;
            frmSoLuong frm = new frmSoLuong(this.grdOrder);
            ma_mon_an = row.Cells[0].Value.ToString();
            don_gia = decimal.Parse(row.Cells[3].Value.ToString() + "");
            ngay_hd = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            frm.Text = "Thêm số lượng";
            frm.ShowDialog();
            rdTatCa.Checked = true;
            DanhSachBan();
            TongTienHoaDon();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdOrder.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.grdOrder.Rows[grdOrder.CurrentCell.RowIndex];
            isSave = false;
            frmSoLuong frm = new frmSoLuong(this.grdOrder);
            id = int.Parse(row.Cells[0].Value.ToString() + "");
            so_luong = decimal.Parse(row.Cells[4].Value.ToString() + "");
            don_gia = decimal.Parse(row.Cells[3].Value.ToString() + "");
            frm.Text = "Sửa số lượng";
            frm.ShowDialog();
            rdTatCa.Checked = true;
            DanhSachBan();
            TongTienHoaDon();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdOrder.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                id = int.Parse(grdOrder.Rows[grdOrder.CurrentCell.RowIndex].Cells[0].Value.ToString() + "");
                string s = "DELETE hoa_don WHERE ma_hoa_don = " + frmBanHang.id + "";
                DBConnect.Instance.ExecuteNonQuery(s);
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSachGoiMon(ma_ban);
                rdTatCa.Checked = true;
                DanhSachBan();
                TongTienHoaDon();
            }
            else
                return;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (grdOrder.Rows.Count == 0)
            {
                return;
            }
            try
            {
                DialogResult ok = new DialogResult();
                ok = MessageBox.Show("Bạn có muốn tính tiền " + lblten_ban.Text + " Không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    MessageBox.Show("TỔNG SỐ TIỀN THANH TOÁN CỦA " + " [ " + lblten_ban.Text + " ] " + " LÀ " + txttong_tien.Text, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TongTienHoaDon();
                    string s = "INSERT INTO luu_hoa_don SELECT ngay_hoa_don,ma_ban,ma_thuc_uong,don_gia,so_luong,thanh_tien,ma_tai_khoan FROM hoa_don WHERE ma_ban = '" + ma_ban + "'; DELETE hoa_don WHERE ma_ban = '" + ma_ban + "'";
                    DBConnect.Instance.ExecuteNonQuery(s);
                    rdTatCa.Checked = true;
                    DanhSachBan();
                    DanhSachGoiMon(ma_ban);
                    TongTienHoaDon();
                }
                else
                {
                    return;
                }
            }
            catch { MessageBox.Show("Bạn chưa chọn bàn thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void lvBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
