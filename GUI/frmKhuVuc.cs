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
    public partial class frmKhuVuc : Form
    {
        public static bool isSave = true;
        BUS_KhuVuc BUS_A = new BUS_KhuVuc();
        DTO_KhuVuc DTO_A = new DTO_KhuVuc();
        public static string ma_kv = "";
        public static string ten_kv = "";
        public static string ghi_chu = "";
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_A.DanhSachKhuVuc();
            grdMain.Columns[0].HeaderText = "Mã khu vực";
            grdMain.Columns[1].HeaderText = "Tên khu vực";
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
            dataTable.Rows.Add("ma_khu_vuc", "Mã khu vực");
            dataTable.Rows.Add("ten_khu_vuc", "Tên khu vực");
            dataTable.Rows.Add("ghi_chu", "Ghi chú");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmKhuVuc_ThongTin frm = new frmKhuVuc_ThongTin(this.grdMain);
            frm.Text = "Thêm khu vực";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmKhuVuc_ThongTin frm = new frmKhuVuc_ThongTin(this.grdMain);
            ma_kv = row.Cells[0].Value.ToString();
            ten_kv = row.Cells[1].Value.ToString();
            ghi_chu = row.Cells[2].Value.ToString();
            frm.Text = "Sửa khu vực";
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
                    DTO_A.MaKhuVuc = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
                    BUS_A.XoaKhuVuc(DTO_A);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    grdMain.DataSource = BUS_A.DanhSachKhuVuc();
                }
                else
                    return;
            }
            catch
            {
                MessageBox.Show("Không xóa được, Dữ liệu đã phát sinh bên danh mục bàn", "Thông báo",
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
            grdMain.DataSource = BUS_A.DanhSachKhuVuc();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_A.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }
    }
}
