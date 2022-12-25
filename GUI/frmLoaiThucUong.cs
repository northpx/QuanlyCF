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
    public partial class frmLoaiThucUong : Form
    {
        public static bool isSave = true;
        BUS_LoaiThucUong BUS_TF = new BUS_LoaiThucUong();
        DTO_LoaiThucUong DTO_TF = new DTO_LoaiThucUong();
        public static string ma_loai = "";
        public static string ten_loai = "";
        public static string ghi_chu = "";
        public frmLoaiThucUong()
        {
            InitializeComponent();
        }

        private void frmLoaiThucUong_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_TF.DanhSachLoaiThucUong();
            grdMain.Columns[0].HeaderText = "Mã loại";
            grdMain.Columns[1].HeaderText = "Tên loại";
            grdMain.Columns[2].HeaderText = "Ghi chú";
            grdMain.Columns[0].Width = 100;
            grdMain.Columns[1].Width = 120;
            grdMain.Columns[2].Width = 120;
        }
        private void LoadComboboxTimKiem()
        {
            DataTable dataTable = new DataTable();
            cboSearch.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("ma_loai", "Mã loại");
            dataTable.Rows.Add("ten_loai", "Tên loại");
            dataTable.Rows.Add("ghi_chu", "Ghi chú");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmLoaiThucUong_ThongTin frm = new frmLoaiThucUong_ThongTin(this.grdMain);
            frm.Text = "Thêm loại";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmLoaiThucUong_ThongTin frm = new frmLoaiThucUong_ThongTin(this.grdMain);
            ma_loai = row.Cells[0].Value.ToString();
            ten_loai = row.Cells[1].Value.ToString();
            ghi_chu = row.Cells[2].Value.ToString();
            frm.Text = "Sửa loại";
            frm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count == 1)
            {
                return;
            }
            try
            {
                DialogResult dr = MessageBox.Show("Có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DTO_TF.MaLoai = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
                    BUS_TF.XoaLoai(DTO_TF);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    grdMain.DataSource = BUS_TF.DanhSachLoaiThucUong();
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
            grdMain.DataSource = BUS_TF.DanhSachLoaiThucUong();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_TF.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
