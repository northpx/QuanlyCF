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
    public partial class frmTaiKhoan : Form
    {
        public static bool isSave = true;
        BUS_TaiKhoan BUS_U = new BUS_TaiKhoan();
        DTO_TaiKhoan DTO_U = new DTO_TaiKhoan();

        public static string ma_user = "";
        public static string ten_user = "";
        public static string quyen_user = "";
        public static string mat_khau = "";
        public static string ghi_chu = "";
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboboxTimKiem();
            grdMain.AllowUserToAddRows = false;
            grdMain.DataSource = BUS_U.DanhSachTaiKhoan();
            grdMain.Columns[0].HeaderText = "Mã tài khoản";
            grdMain.Columns[1].HeaderText = "Tên tài khoản";
            grdMain.Columns[2].HeaderText = "Quyền";
            grdMain.Columns[3].HeaderText = "Ghi chú";
            grdMain.Columns[0].Width = 100;
            grdMain.Columns[1].Width = 120;
            grdMain.Columns[2].Width = 120;
            grdMain.Columns[3].Width = 150;
        }
        private void LoadComboboxTimKiem()
        {
            DataTable dataTable = new DataTable();
            cboSearch.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("ma_tai_khoan", "Mã tài khoản");
            dataTable.Rows.Add("ten_tai_khoan", "Tên tài khoản");
            dataTable.Rows.Add("ma_quyen", "Quyền");
            dataTable.Rows.Add("ghi_chu", "Ghi chú");
            cboSearch.DataSource = dataTable;
            cboSearch.DisplayMember = "ten";
            cboSearch.ValueMember = "ma";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            frmTaiKhoan_ThongTin frm = new frmTaiKhoan_ThongTin(this.grdMain);
            frm.Text = "Thêm tài khoản";
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdMain.Rows[grdMain.CurrentCell.RowIndex];
            isSave = false;
            frmTaiKhoan_ThongTin frm = new frmTaiKhoan_ThongTin(this.grdMain);
            ma_user = row.Cells[0].Value.ToString();
            ten_user = row.Cells[1].Value.ToString();
            quyen_user = row.Cells[2].Value.ToString();
            ghi_chu = row.Cells[3].Value.ToString();
            DataTable dt = BUS_U.DanhSachMatKhau(ma_user);
            mat_khau = dt.Rows[0]["mat_khau"].ToString();
            frm.Text = "Sửa tài khoản";
            frm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DTO_U.TaiKhoan = grdMain.Rows[grdMain.CurrentCell.RowIndex].Cells[0].Value.ToString();
                BUS_U.XoaTaiKhoan(DTO_U);
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                grdMain.DataSource = BUS_U.DanhSachTaiKhoan();
            }
            else
                return;
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
            grdMain.DataSource = BUS_U.DanhSachTaiKhoan();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_U.LoadDanhSachTimKiem(cboSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            grdMain.DataSource = dt;
        }
    }
}
