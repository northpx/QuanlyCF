
namespace GUI
{
    partial class frmLichSuHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLichSuHD));
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.dtFrom2 = new System.Windows.Forms.DateTimePicker();
            this.dtFrom1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTable
            // 
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(459, 8);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(163, 21);
            this.cboTable.TabIndex = 100;
            // 
            // dtFrom2
            // 
            this.dtFrom2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom2.Location = new System.Drawing.Point(272, 8);
            this.dtFrom2.Name = "dtFrom2";
            this.dtFrom2.Size = new System.Drawing.Size(119, 20);
            this.dtFrom2.TabIndex = 98;
            // 
            // dtFrom1
            // 
            this.dtFrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom1.Location = new System.Drawing.Point(79, 8);
            this.dtFrom1.Name = "dtFrom1";
            this.dtFrom1.Size = new System.Drawing.Size(119, 20);
            this.dtFrom1.TabIndex = 97;
            this.dtFrom1.Value = new System.DateTime(2021, 4, 10, 18, 21, 41, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Từ ngày";
            // 
            // grdMain
            // 
            this.grdMain.BackgroundColor = System.Drawing.Color.White;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Location = new System.Drawing.Point(2, 38);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowHeadersWidth = 51;
            this.grdMain.Size = new System.Drawing.Size(683, 405);
            this.grdMain.TabIndex = 94;
            // 
            // btnRefesh
            // 
            this.btnRefesh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.ForeColor = System.Drawing.Color.Black;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefesh.Location = new System.Drawing.Point(628, 5);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(57, 28);
            this.btnRefesh.TabIndex = 207;
            this.btnRefesh.Tag = "L116";
            this.btnRefesh.Text = "Lọc";
            this.btnRefesh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefesh.UseVisualStyleBackColor = false;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 208;
            this.label2.Text = "Bàn";
            // 
            // frmLichSuHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.dtFrom2);
            this.Controls.Add(this.dtFrom1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdMain);
            this.Name = "frmLichSuHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử hóa đơn";
            this.Load += new System.EventHandler(this.frmLichSuHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.DateTimePicker dtFrom2;
        private System.Windows.Forms.DateTimePicker dtFrom1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdMain;
        internal System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Label label2;
    }
}