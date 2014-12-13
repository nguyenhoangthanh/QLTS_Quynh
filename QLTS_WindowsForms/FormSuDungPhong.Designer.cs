namespace QLTS_WindowsForms
{
    partial class FormSuDungPhong
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
            this.NGAYTAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KHOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYMUON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TUGIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DENGIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONGSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGUOIMUON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENNGUOIMUON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGUOIDUYET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHICHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.dateTimePickerDenGio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTuGio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.textBoxSoLuongSinhVien = new System.Windows.Forms.TextBox();
            this.textBoxLyDoMuon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKhoa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDuyet = new System.Windows.Forms.Button();
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
            this.NGAYTAO,
            this.KHOA,
            this.NGAYMUON,
            this.TUGIO,
            this.DENGIO,
            this.SOLUONGSV,
            this.NGUOIMUON,
            this.TENNGUOIMUON,
            this.STATUS,
            this.NGUOIDUYET,
            this.GHICHU});
            this.dataGridView.Location = new System.Drawing.Point(12, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(677, 514);
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
            // NGAYTAO
            // 
            this.NGAYTAO.DataPropertyName = "NGAYTAO";
            this.NGAYTAO.HeaderText = "Ngày tạo";
            this.NGAYTAO.Name = "NGAYTAO";
            this.NGAYTAO.ReadOnly = true;
            // 
            // KHOA
            // 
            this.KHOA.DataPropertyName = "KHOA";
            this.KHOA.HeaderText = "Khoa/phòng mượn";
            this.KHOA.Name = "KHOA";
            this.KHOA.ReadOnly = true;
            // 
            // NGAYMUON
            // 
            this.NGAYMUON.DataPropertyName = "NGAYMUON";
            this.NGAYMUON.HeaderText = "Ngày mượn";
            this.NGAYMUON.Name = "NGAYMUON";
            this.NGAYMUON.ReadOnly = true;
            // 
            // TUGIO
            // 
            this.TUGIO.DataPropertyName = "TUGIO";
            this.TUGIO.HeaderText = "Từ giờ";
            this.TUGIO.Name = "TUGIO";
            this.TUGIO.ReadOnly = true;
            // 
            // DENGIO
            // 
            this.DENGIO.DataPropertyName = "DENGIO";
            this.DENGIO.HeaderText = "Đến giờ";
            this.DENGIO.Name = "DENGIO";
            this.DENGIO.ReadOnly = true;
            // 
            // SOLUONGSV
            // 
            this.SOLUONGSV.DataPropertyName = "SOLUONGSV";
            this.SOLUONGSV.HeaderText = "Số lượng sinh viên";
            this.SOLUONGSV.Name = "SOLUONGSV";
            this.SOLUONGSV.ReadOnly = true;
            // 
            // NGUOIMUON
            // 
            this.NGUOIMUON.DataPropertyName = "NGUOIMUON";
            this.NGUOIMUON.HeaderText = "Người mượn";
            this.NGUOIMUON.Name = "NGUOIMUON";
            this.NGUOIMUON.ReadOnly = true;
            this.NGUOIMUON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TENNGUOIMUON
            // 
            this.TENNGUOIMUON.DataPropertyName = "TENNGUOIMUON";
            this.TENNGUOIMUON.HeaderText = "Tên người mượn";
            this.TENNGUOIMUON.Name = "TENNGUOIMUON";
            this.TENNGUOIMUON.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "Tình trạng";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            // 
            // NGUOIDUYET
            // 
            this.NGUOIDUYET.DataPropertyName = "NGUOIDUYET";
            this.NGUOIDUYET.HeaderText = "Người duyệt";
            this.NGUOIDUYET.Name = "NGUOIDUYET";
            this.NGUOIDUYET.ReadOnly = true;
            // 
            // GHICHU
            // 
            this.GHICHU.DataPropertyName = "GHICHU";
            this.GHICHU.HeaderText = "Ghi chú";
            this.GHICHU.Name = "GHICHU";
            this.GHICHU.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách đăng ký sử dụng phòng";
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(698, 35);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(61, 23);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Tag = "0";
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Enabled = false;
            this.buttonXoa.Location = new System.Drawing.Point(765, 35);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(61, 23);
            this.buttonXoa.TabIndex = 1;
            this.buttonXoa.Tag = "1";
            this.buttonXoa.Text = "Xoá";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Enabled = false;
            this.buttonSua.Location = new System.Drawing.Point(832, 35);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(64, 23);
            this.buttonSua.TabIndex = 2;
            this.buttonSua.Tag = "2";
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.dateTimePickerDenGio);
            this.panel.Controls.Add(this.dateTimePickerTuGio);
            this.panel.Controls.Add(this.dateTimePickerNgayMuon);
            this.panel.Controls.Add(this.buttonOK);
            this.panel.Controls.Add(this.buttonHuyBo);
            this.panel.Controls.Add(this.textBoxSoLuongSinhVien);
            this.panel.Controls.Add(this.textBoxLyDoMuon);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.textBoxKhoa);
            this.panel.Controls.Add(this.label2);
            this.panel.Location = new System.Drawing.Point(698, 64);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 237);
            this.panel.TabIndex = 3;
            this.panel.Visible = false;
            // 
            // dateTimePickerDenGio
            // 
            this.dateTimePickerDenGio.CustomFormat = "H:mm";
            this.dateTimePickerDenGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDenGio.Location = new System.Drawing.Point(122, 79);
            this.dateTimePickerDenGio.Name = "dateTimePickerDenGio";
            this.dateTimePickerDenGio.ShowUpDown = true;
            this.dateTimePickerDenGio.Size = new System.Drawing.Size(176, 20);
            this.dateTimePickerDenGio.TabIndex = 9;
            // 
            // dateTimePickerTuGio
            // 
            this.dateTimePickerTuGio.CustomFormat = "H:mm";
            this.dateTimePickerTuGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuGio.Location = new System.Drawing.Point(122, 53);
            this.dateTimePickerTuGio.Name = "dateTimePickerTuGio";
            this.dateTimePickerTuGio.ShowUpDown = true;
            this.dateTimePickerTuGio.Size = new System.Drawing.Size(176, 20);
            this.dateTimePickerTuGio.TabIndex = 9;
            // 
            // dateTimePickerNgayMuon
            // 
            this.dateTimePickerNgayMuon.CustomFormat = "dd/M/yyyy";
            this.dateTimePickerNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayMuon.Location = new System.Drawing.Point(122, 27);
            this.dateTimePickerNgayMuon.Name = "dateTimePickerNgayMuon";
            this.dateTimePickerNgayMuon.Size = new System.Drawing.Size(176, 20);
            this.dateTimePickerNgayMuon.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(142, 202);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Tag = "20";
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonHuyBo
            // 
            this.buttonHuyBo.Location = new System.Drawing.Point(223, 202);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 8;
            this.buttonHuyBo.Tag = "25";
            this.buttonHuyBo.Text = "Huỷ bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            // 
            // textBoxSoLuongSinhVien
            // 
            this.textBoxSoLuongSinhVien.Location = new System.Drawing.Point(122, 105);
            this.textBoxSoLuongSinhVien.Name = "textBoxSoLuongSinhVien";
            this.textBoxSoLuongSinhVien.Size = new System.Drawing.Size(176, 20);
            this.textBoxSoLuongSinhVien.TabIndex = 6;
            this.textBoxSoLuongSinhVien.Tag = "15";
            // 
            // textBoxLyDoMuon
            // 
            this.textBoxLyDoMuon.Location = new System.Drawing.Point(122, 132);
            this.textBoxLyDoMuon.Multiline = true;
            this.textBoxLyDoMuon.Name = "textBoxLyDoMuon";
            this.textBoxLyDoMuon.Size = new System.Drawing.Size(176, 63);
            this.textBoxLyDoMuon.TabIndex = 6;
            this.textBoxLyDoMuon.Tag = "15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số lượng sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đến giờ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lý do mượn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Từ giờ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày mượn";
            // 
            // textBoxKhoa
            // 
            this.textBoxKhoa.Location = new System.Drawing.Point(122, 5);
            this.textBoxKhoa.Name = "textBoxKhoa";
            this.textBoxKhoa.Size = new System.Drawing.Size(176, 20);
            this.textBoxKhoa.TabIndex = 3;
            this.textBoxKhoa.Tag = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Khoa/ phòng mượn";
            // 
            // buttonDuyet
            // 
            this.buttonDuyet.Enabled = false;
            this.buttonDuyet.Location = new System.Drawing.Point(902, 35);
            this.buttonDuyet.Name = "buttonDuyet";
            this.buttonDuyet.Size = new System.Drawing.Size(57, 23);
            this.buttonDuyet.TabIndex = 4;
            this.buttonDuyet.Text = "Duyệt";
            this.buttonDuyet.UseVisualStyleBackColor = true;
            this.buttonDuyet.Click += new System.EventHandler(this.buttonDuyet_Click);
            // 
            // FormSuDungPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.buttonDuyet);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormSuDungPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đăng ký sử dụng phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox textBoxLyDoMuon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.Button buttonDuyet;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenGio;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuGio;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayMuon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSoLuongSinhVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYTAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KHOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYMUON;
        private System.Windows.Forms.DataGridViewTextBoxColumn TUGIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DENGIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONGSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGUOIMUON;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENNGUOIMUON;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGUOIDUYET;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHICHU;
    }
}