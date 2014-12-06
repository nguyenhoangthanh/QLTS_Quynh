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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENCOSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonThanhLy = new System.Windows.Forms.Button();
            this.buttonChuyenTinhTrang = new System.Windows.Forms.Button();
            this.buttonChuyenTaiSan = new System.Windows.Forms.Button();
            this.listBoxPhong = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonXoa = new System.Windows.Forms.Button();
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
            // panel
            // 
            this.panel.Controls.Add(this.buttonXoa);
            this.panel.Controls.Add(this.buttonSua);
            this.panel.Controls.Add(this.buttonThem);
            this.panel.Controls.Add(this.buttonThanhLy);
            this.panel.Controls.Add(this.buttonChuyenTinhTrang);
            this.panel.Controls.Add(this.buttonChuyenTaiSan);
            this.panel.Location = new System.Drawing.Point(12, 7);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(984, 35);
            this.panel.TabIndex = 3;
            // 
            // buttonSua
            // 
            this.buttonSua.Location = new System.Drawing.Point(564, 5);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(93, 23);
            this.buttonSua.TabIndex = 3;
            this.buttonSua.Text = "Cập nhật tài sản";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(407, 5);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(151, 23);
            this.buttonThem.TabIndex = 3;
            this.buttonThem.Text = "Chuyển tài sản vào phòng";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonThanhLy
            // 
            this.buttonThanhLy.Location = new System.Drawing.Point(320, 5);
            this.buttonThanhLy.Name = "buttonThanhLy";
            this.buttonThanhLy.Size = new System.Drawing.Size(81, 23);
            this.buttonThanhLy.TabIndex = 3;
            this.buttonThanhLy.Text = "Thanh lý";
            this.buttonThanhLy.UseVisualStyleBackColor = true;
            // 
            // buttonChuyenTinhTrang
            // 
            this.buttonChuyenTinhTrang.Location = new System.Drawing.Point(179, 5);
            this.buttonChuyenTinhTrang.Name = "buttonChuyenTinhTrang";
            this.buttonChuyenTinhTrang.Size = new System.Drawing.Size(135, 23);
            this.buttonChuyenTinhTrang.TabIndex = 3;
            this.buttonChuyenTinhTrang.Text = "Chuyển tình trạng tài sản";
            this.buttonChuyenTinhTrang.UseVisualStyleBackColor = true;
            // 
            // buttonChuyenTaiSan
            // 
            this.buttonChuyenTaiSan.Location = new System.Drawing.Point(4, 5);
            this.buttonChuyenTaiSan.Name = "buttonChuyenTaiSan";
            this.buttonChuyenTaiSan.Size = new System.Drawing.Size(169, 23);
            this.buttonChuyenTaiSan.TabIndex = 3;
            this.buttonChuyenTaiSan.Text = "Chuyển tài sản giữa các phòng";
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
            // buttonXoa
            // 
            this.buttonXoa.Location = new System.Drawing.Point(663, 5);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(93, 23);
            this.buttonXoa.TabIndex = 3;
            this.buttonXoa.Text = "Loại bỏ tài sản";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
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
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
    }
}