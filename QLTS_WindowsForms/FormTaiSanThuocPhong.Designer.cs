namespace QLTS_WindowsForms
{
    partial class FormTaiSanThuocPhong
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonChuyenTaiSan = new System.Windows.Forms.Button();
            this.listBoxPhong = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENCOSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonChuyenTinhTrang = new System.Windows.Forms.Button();
            this.buttonThanhLy = new System.Windows.Forms.Button();
            this.buttonThemTaiSan = new System.Windows.Forms.Button();
            this.buttonLoaiBoTaiSan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SUBID,
            this.TENCOSO,
            this.DIACHI,
            this.NGAY,
            this.MOTA});
            this.dataGridView.Location = new System.Drawing.Point(238, 64);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(758, 485);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonLoaiBoTaiSan);
            this.panel.Controls.Add(this.buttonThemTaiSan);
            this.panel.Controls.Add(this.buttonThanhLy);
            this.panel.Controls.Add(this.buttonChuyenTinhTrang);
            this.panel.Controls.Add(this.buttonChuyenTaiSan);
            this.panel.Location = new System.Drawing.Point(12, 7);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(984, 35);
            this.panel.TabIndex = 3;
            // 
            // buttonChuyenTaiSan
            // 
            this.buttonChuyenTaiSan.Location = new System.Drawing.Point(4, 5);
            this.buttonChuyenTaiSan.Name = "buttonChuyenTaiSan";
            this.buttonChuyenTaiSan.Size = new System.Drawing.Size(91, 23);
            this.buttonChuyenTaiSan.TabIndex = 3;
            this.buttonChuyenTaiSan.Text = "Chuyển tài sản";
            this.buttonChuyenTaiSan.UseVisualStyleBackColor = true;
            // 
            // listBoxPhong
            // 
            this.listBoxPhong.FormattingEnabled = true;
            this.listBoxPhong.Location = new System.Drawing.Point(12, 64);
            this.listBoxPhong.Name = "listBoxPhong";
            this.listBoxPhong.Size = new System.Drawing.Size(220, 485);
            this.listBoxPhong.TabIndex = 4;
            this.listBoxPhong.Click += new System.EventHandler(this.listBoxPhong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách phòng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Danh sách tài sản";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // SUBID
            // 
            this.SUBID.DataPropertyName = "SUBID";
            this.SUBID.HeaderText = "Mã tài sản";
            this.SUBID.Name = "SUBID";
            this.SUBID.ReadOnly = true;
            // 
            // TENCOSO
            // 
            this.TENCOSO.DataPropertyName = "TENCOSO";
            this.TENCOSO.HeaderText = "Tên tài sản";
            this.TENCOSO.Name = "TENCOSO";
            this.TENCOSO.ReadOnly = true;
            // 
            // DIACHI
            // 
            this.DIACHI.DataPropertyName = "DIACHI";
            this.DIACHI.HeaderText = "Số lượng";
            this.DIACHI.Name = "DIACHI";
            this.DIACHI.ReadOnly = true;
            // 
            // NGAY
            // 
            this.NGAY.HeaderText = "Ngày nhập";
            this.NGAY.Name = "NGAY";
            this.NGAY.ReadOnly = true;
            // 
            // MOTA
            // 
            this.MOTA.DataPropertyName = "MOTA";
            this.MOTA.HeaderText = "Mô tả";
            this.MOTA.Name = "MOTA";
            this.MOTA.ReadOnly = true;
            // 
            // buttonChuyenTinhTrang
            // 
            this.buttonChuyenTinhTrang.Location = new System.Drawing.Point(101, 5);
            this.buttonChuyenTinhTrang.Name = "buttonChuyenTinhTrang";
            this.buttonChuyenTinhTrang.Size = new System.Drawing.Size(115, 23);
            this.buttonChuyenTinhTrang.TabIndex = 3;
            this.buttonChuyenTinhTrang.Text = "Chuyển tình trạng";
            this.buttonChuyenTinhTrang.UseVisualStyleBackColor = true;
            // 
            // buttonThanhLy
            // 
            this.buttonThanhLy.Location = new System.Drawing.Point(222, 5);
            this.buttonThanhLy.Name = "buttonThanhLy";
            this.buttonThanhLy.Size = new System.Drawing.Size(81, 23);
            this.buttonThanhLy.TabIndex = 3;
            this.buttonThanhLy.Text = "Thanh lý";
            this.buttonThanhLy.UseVisualStyleBackColor = true;
            // 
            // buttonThemTaiSan
            // 
            this.buttonThemTaiSan.Location = new System.Drawing.Point(309, 5);
            this.buttonThemTaiSan.Name = "buttonThemTaiSan";
            this.buttonThemTaiSan.Size = new System.Drawing.Size(81, 23);
            this.buttonThemTaiSan.TabIndex = 3;
            this.buttonThemTaiSan.Text = "Thêm tài sản";
            this.buttonThemTaiSan.UseVisualStyleBackColor = true;
            this.buttonThemTaiSan.Click += new System.EventHandler(this.buttonThemTaiSan_Click);
            // 
            // buttonLoaiBoTaiSan
            // 
            this.buttonLoaiBoTaiSan.Location = new System.Drawing.Point(396, 5);
            this.buttonLoaiBoTaiSan.Name = "buttonLoaiBoTaiSan";
            this.buttonLoaiBoTaiSan.Size = new System.Drawing.Size(93, 23);
            this.buttonLoaiBoTaiSan.TabIndex = 3;
            this.buttonLoaiBoTaiSan.Text = "Loại bỏ tài sản";
            this.buttonLoaiBoTaiSan.UseVisualStyleBackColor = true;
            // 
            // FormTaiSanThuocPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPhong);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FormTaiSanThuocPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài sản thuộc phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonChuyenTaiSan;
        private System.Windows.Forms.ListBox listBoxPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENCOSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
        private System.Windows.Forms.Button buttonThanhLy;
        private System.Windows.Forms.Button buttonChuyenTinhTrang;
        private System.Windows.Forms.Button buttonThemTaiSan;
        private System.Windows.Forms.Button buttonLoaiBoTaiSan;
    }
}