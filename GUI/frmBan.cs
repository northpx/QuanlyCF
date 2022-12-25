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
    public partial class frmBan : Form
    {
        public static string ma_ban = "";
        public static string ten_ban = "";
        public static string khu_vuc = "";
        public static decimal so_luong;
        public static string ghi_chu = "";
        public static bool isSave = true;
        BUS_Ban BUS_T = new BUS_Ban();
        DTO_Ban DTO_T = new DTO_Ban();
        public frmBan()
        {
            InitializeComponent();
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_T.DanhSachBan();
            grdMain.Columns[0].HeaderText = "Mã bàn";
            grdMain.Columns[1].HeaderText = "Tên bàn";
            grdMain.Columns[2].HeaderText = "Khu vực";
            grdMain.Columns[3].HeaderText = "Số lượng người/bàn";
            grdMain.Columns[4].HeaderText = "Ghi chú";
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
            dataTable.Rows.Add("ma_ban", "Mã bàn");
            dataTable.Rows.Add("ten_ban", "Tên bàn");
            dataTable.Rows.Add("khu_vuc", "Khu vực");
            dataTable.Rows.Add("so_luong", "Số lượng người/bàn");
            dataTable.Rows.Add("ghi_chu", "Ghi chú");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmBan_ThongTin frm = new frmBan_ThongTin(this.grdMain);
            frm.Text = "Thêm bàn";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmBan_ThongTin frm = new frmBan_ThongTin(this.grdMain);
            ma_ban = row.Cells[0].Value.ToString();
            ten_ban = row.Cells[1].Value.ToString();
            khu_vuc = row.Cells[2].Value.ToString();
            so_luong = decimal.Parse(row.Cells[3].Value.ToString() + "");
            ghi_chu = row.Cells[4].Value.ToString();
            frm.Text = "Sửa bàn";
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
                    DTO_T.MaBan = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
                    BUS_T.XoaBan(DTO_T);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    grdMain.DataSource = BUS_T.DanhSachBan();
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
            grdMain.DataSource = BUS_T.DanhSachBan();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_T.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }
    }
}
