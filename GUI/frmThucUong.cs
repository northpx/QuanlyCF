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
    public partial class frmThucUong : Form
    {
        public static string ma_mon_an = "";
        public static string ten_mon_an = "";
        public static string loai_mon_an = "";
        public static decimal don_gia;
        public static decimal so_luong;
        public static string ghi_chu = "";
        public static bool isSave = true;
        BUS_ThucUong BUS_F = new BUS_ThucUong();
        DTO_ThucUong DTO_F = new DTO_ThucUong();
        public frmThucUong()
        {
            InitializeComponent();
        }

        private void frmThucUong_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_F.DanhSachThucUong();
            grdMain.Columns[0].HeaderText = "Mã thức uống";
            grdMain.Columns[1].HeaderText = "Tên thức uống";
            grdMain.Columns[2].HeaderText = "Loại thức uống";
            grdMain.Columns[3].HeaderText = "Đơn giá";
            grdMain.Columns[4].HeaderText = "Số lượng tồn kho";
            grdMain.Columns[5].HeaderText = "Ghi chú";
            grdMain.Columns[0].Width = 100;
            grdMain.Columns[1].Width = 120;
            grdMain.Columns[2].Width = 120;
            grdMain.Columns[3].Width = 120;
            grdMain.Columns[4].Width = 120;
            grdMain.Columns[5].Width = 150;
        }

        private void LoadComboboxTimKiem()
        {
            DataTable dataTable = new DataTable();
            cboSearch.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("ma_thuc_uong", "Mã thức uống");
            dataTable.Rows.Add("ten_thuc_uong", "Tên thức uống");
            dataTable.Rows.Add("loai_thuc_uong", "Loại thức uống");
            dataTable.Rows.Add("don_gia", "Đơn giá");
            dataTable.Rows.Add("so_luong", "Số lượng tồn kho");
            dataTable.Rows.Add("ghi_chu", "Ghi chú");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmThucUong_ThongTin frm = new frmThucUong_ThongTin(this.grdMain);
            frm.Text = "Thêm thức uống";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmThucUong_ThongTin frm = new frmThucUong_ThongTin(this.grdMain);
            ma_mon_an = row.Cells[0].Value.ToString();
            ten_mon_an = row.Cells[1].Value.ToString();
            loai_mon_an = row.Cells[2].Value.ToString();
            don_gia = decimal.Parse(row.Cells[3].Value.ToString() + "");
            so_luong = decimal.Parse(row.Cells[4].Value.ToString() + "");
            ghi_chu = row.Cells[5].Value.ToString();
            frm.Text = "Sửa thức uống";
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
                    DTO_F.MaMon = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString(); ;
                    BUS_F.XoaThucUong(DTO_F);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    grdMain.DataSource = BUS_F.DanhSachThucUong();
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
            grdMain.DataSource = BUS_F.DanhSachThucUong();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_F.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }
    }
}
