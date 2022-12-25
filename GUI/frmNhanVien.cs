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
    public partial class frmNhanVien : Form
    {
        public static string ma_nv = "";
        public static string ten_nv = "";
        public static string gioi_tinh = "";
        public static string dien_thoai = "";
        public static string dia_chi = "";
        public static bool isSave = true;
        BUS_NhanVien BUS_NV = new BUS_NhanVien();
        DTO_NhanVien DTO_NV = new DTO_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_NV.DanhSachNhanVien();
            grdMain.Columns[0].HeaderText = "Mã nhân viên";
            grdMain.Columns[1].HeaderText = "Tên nhân viên";
            grdMain.Columns[3].HeaderText = "Điện thoại";
            grdMain.Columns[4].HeaderText = "Địa chỉ";
            grdMain.Columns[2].HeaderText = "Giới tính";
            grdMain.Columns[0].Width = 100;
            grdMain.Columns[1].Width = 120;
            grdMain.Columns[2].Width = 120;
            grdMain.Columns[3].Width = 120;
            grdMain.Columns[4].Width = 150;
        }
        private void LoadComboboxTimKiem()
        {
            DataTable dataTable = new DataTable();
            cboSearch.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("ma_nhan_vien", "Mã nhân viên ");
            dataTable.Rows.Add("ten_nhan_vien", "Tên nhân viên");
            dataTable.Rows.Add("ma_gioi_tinh", "Giới tính");
            dataTable.Rows.Add("dien_thoai", "Điện thoại");
            dataTable.Rows.Add("dia_chi", "Địa chỉ");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmNhanVien_ThongTin frm = new frmNhanVien_ThongTin(this.grdMain);
            frm.Text = "Thêm nhân viên";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmNhanVien_ThongTin frm = new frmNhanVien_ThongTin(this.grdMain);
            ma_nv = row.Cells[0].Value.ToString();
            ten_nv = row.Cells[1].Value.ToString();
            gioi_tinh = row.Cells[2].Value.ToString();
            dien_thoai = row.Cells[3].Value.ToString();
            dia_chi = row.Cells[4].Value.ToString();
            frm.Text = "Sửa nhân viên";
            frm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count == 0)
            {
                return;
            }
            try
            {
                DialogResult dr = MessageBox.Show("Có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DTO_NV.MaNhanVien = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    BUS_NV.XoaNhanVien(DTO_NV);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    grdMain.DataSource = BUS_NV.DanhSachNhanVien();
                }
                else
                    return;
            }
            catch
            {
                MessageBox.Show("Không xóa được, Dữ liệu đã phát sinh", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < grdMain.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = grdMain.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < grdMain.Rows.Count; i++)
            {
                for (int j = 0; j < grdMain.Columns.Count; j++)
                {
                    if (grdMain.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grdMain.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            grdMain.DataSource = BUS_NV.DanhSachNhanVien();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_NV.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }
    }
}
