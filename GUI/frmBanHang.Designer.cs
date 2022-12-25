
namespace GUI
{
    partial class frmBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.lvBan = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grdFood = new System.Windows.Forms.DataGridView();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.rdTrong = new System.Windows.Forms.RadioButton();
            this.rdCoNguoi = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblten_ban = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.txttong_tien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdOrder = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // lvBan
            // 
            this.lvBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvBan.BackColor = System.Drawing.Color.White;
            this.lvBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBan.HideSelection = false;
            this.lvBan.LargeImageList = this.imageList;
            this.lvBan.Location = new System.Drawing.Point(0, 44);
            this.lvBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvBan.Name = "lvBan";
            this.lvBan.Size = new System.Drawing.Size(415, 643);
            this.lvBan.TabIndex = 2;
            this.lvBan.UseCompatibleStateImageBehavior = false;
            this.lvBan.SelectedIndexChanged += new System.EventHandler(this.lvBan_SelectedIndexChanged);
            this.lvBan.Click += new System.EventHandler(this.lvBan_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ban_trong.png");
            this.imageList.Images.SetKeyName(1, "ban_co_nguoi.jpg");
            // 
            // grdFood
            // 
            this.grdFood.AllowUserToAddRows = false;
            this.grdFood.AllowUserToDeleteRows = false;
            this.grdFood.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdFood.BackgroundColor = System.Drawing.Color.White;
            this.grdFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFood.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grdFood.Location = new System.Drawing.Point(424, 44);
            this.grdFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdFood.Name = "grdFood";
            this.grdFood.ReadOnly = true;
            this.grdFood.RowHeadersWidth = 51;
            this.grdFood.Size = new System.Drawing.Size(657, 224);
            this.grdFood.TabIndex = 61;
            // 
            // rdTatCa
            // 
            this.rdTatCa.AutoSize = true;
            this.rdTatCa.Location = new System.Drawing.Point(275, 15);
            this.rdTatCa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(97, 21);
            this.rdTatCa.TabIndex = 195;
            this.rdTatCa.TabStop = true;
            this.rdTatCa.Text = "Tất cả bàn";
            this.rdTatCa.UseVisualStyleBackColor = true;
            this.rdTatCa.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // rdTrong
            // 
            this.rdTrong.AutoSize = true;
            this.rdTrong.Location = new System.Drawing.Point(139, 15);
            this.rdTrong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdTrong.Name = "rdTrong";
            this.rdTrong.Size = new System.Drawing.Size(91, 21);
            this.rdTrong.TabIndex = 193;
            this.rdTrong.TabStop = true;
            this.rdTrong.Text = "Bàn trống";
            this.rdTrong.UseVisualStyleBackColor = true;
            this.rdTrong.CheckedChanged += new System.EventHandler(this.rdTrong_CheckedChanged);
            // 
            // rdCoNguoi
            // 
            this.rdCoNguoi.AutoSize = true;
            this.rdCoNguoi.Location = new System.Drawing.Point(11, 15);
            this.rdCoNguoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdCoNguoi.Name = "rdCoNguoi";
            this.rdCoNguoi.Size = new System.Drawing.Size(85, 21);
            this.rdCoNguoi.TabIndex = 192;
            this.rdCoNguoi.TabStop = true;
            this.rdCoNguoi.Text = "Có người";
            this.rdCoNguoi.UseVisualStyleBackColor = true;
            this.rdCoNguoi.CheckedChanged += new System.EventHandler(this.rdCoNguoi_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Location = new System.Drawing.Point(635, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(369, 25);
            this.txtSearch.TabIndex = 222;
            // 
            // cboSearch
            // 
            this.cboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSearch.BackColor = System.Drawing.SystemColors.Control;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(424, 10);
            this.cboSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(201, 24);
            this.cboSearch.TabIndex = 221;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(1013, 9);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(68, 28);
            this.btnFind.TabIndex = 223;
            this.btnFind.Text = "Lọc";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.Black;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(1093, 234);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(137, 34);
            this.btnDel.TabIndex = 226;
            this.btnDel.Tag = "L116";
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(1093, 150);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 34);
            this.btnAdd.TabIndex = 224;
            this.btnAdd.Tag = "L116";
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(1093, 192);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 34);
            this.btnEdit.TabIndex = 225;
            this.btnEdit.Tag = "L117";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblten_ban
            // 
            this.lblten_ban.BackColor = System.Drawing.Color.Green;
            this.lblten_ban.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblten_ban.ForeColor = System.Drawing.Color.White;
            this.lblten_ban.Location = new System.Drawing.Point(1093, 9);
            this.lblten_ban.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblten_ban.Name = "lblten_ban";
            this.lblten_ban.Size = new System.Drawing.Size(137, 81);
            this.lblten_ban.TabIndex = 227;
            this.lblten_ban.UseVisualStyleBackColor = false;
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.BackColor = System.Drawing.SystemColors.Control;
            this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhTien.ForeColor = System.Drawing.Color.Black;
            this.btnTinhTien.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhTien.Image")));
            this.btnTinhTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhTien.Location = new System.Drawing.Point(1097, 655);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(143, 34);
            this.btnTinhTien.TabIndex = 228;
            this.btnTinhTien.Tag = "L116";
            this.btnTinhTien.Text = "Thanh toán";
            this.btnTinhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTinhTien.UseVisualStyleBackColor = false;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // txttong_tien
            // 
            this.txttong_tien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txttong_tien.BackColor = System.Drawing.Color.White;
            this.txttong_tien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttong_tien.Location = new System.Drawing.Point(1093, 121);
            this.txttong_tien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttong_tien.Multiline = true;
            this.txttong_tien.Name = "txttong_tien";
            this.txttong_tien.ReadOnly = true;
            this.txttong_tien.Size = new System.Drawing.Size(136, 25);
            this.txttong_tien.TabIndex = 229;
            this.txttong_tien.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1116, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 230;
            this.label1.Text = "Tổng tiền";
            // 
            // grdOrder
            // 
            this.grdOrder.AllowUserToAddRows = false;
            this.grdOrder.AllowUserToDeleteRows = false;
            this.grdOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdOrder.BackgroundColor = System.Drawing.Color.White;
            this.grdOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grdOrder.Location = new System.Drawing.Point(424, 276);
            this.grdOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ReadOnly = true;
            this.grdOrder.RowHeadersWidth = 51;
            this.grdOrder.Size = new System.Drawing.Size(815, 378);
            this.grdOrder.TabIndex = 231;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 662);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 233;
            this.label2.Text = "Ngày làm việc :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(571, 661);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 22);
            this.dateTimePicker1.TabIndex = 234;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(697, 662);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 18);
            this.label3.TabIndex = 235;
            this.label3.Text = "Nhân viên bán hàng :";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(897, 660);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(183, 22);
            this.txtUser.TabIndex = 236;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 690);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttong_tien);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.lblten_ban);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.rdTatCa);
            this.Controls.Add(this.rdTrong);
            this.Controls.Add(this.rdCoNguoi);
            this.Controls.Add(this.grdFood);
            this.Controls.Add(this.lvBan);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBan;
        private System.Windows.Forms.DataGridView grdFood;
        private System.Windows.Forms.RadioButton rdTatCa;
        private System.Windows.Forms.RadioButton rdTrong;
        private System.Windows.Forms.RadioButton rdCoNguoi;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Button btnFind;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button lblten_ban;
        internal System.Windows.Forms.Button btnTinhTien;
        internal System.Windows.Forms.TextBox txttong_tien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridView grdOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
    }
}