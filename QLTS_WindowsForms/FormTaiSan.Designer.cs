﻿namespace QLTS_WindowsForms
{
    partial class FormTaiSan
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonTatCa = new System.Windows.Forms.RadioButton();
            this.radioButtonTaiSanKhongGioiHan = new System.Windows.Forms.RadioButton();
            this.radioButtonTaiSanCoGioiHan = new System.Windows.Forms.RadioButton();
            this.radioButtonTaiSanCoTheThemVaoPhong = new System.Windows.Forms.RadioButton();
            this.checkBoxTaiSanKhongGioiHan = new System.Windows.Forms.CheckBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENTAISAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAISANKHONGGIOIHAN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NGAYMUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENLOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYTAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYSUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TENTAISAN,
            this.TAISANKHONGGIOIHAN,
            this.NGAYMUA,
            this.TENLOAI,
            this.MOTA,
            this.NGAYTAO,
            this.NGAYSUA});
            this.dataGridView.Location = new System.Drawing.Point(12, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(677, 514);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách tài sản";
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(699, 35);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 23);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Tag = "0";
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Enabled = false;
            this.buttonXoa.Location = new System.Drawing.Point(780, 35);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(75, 23);
            this.buttonXoa.TabIndex = 1;
            this.buttonXoa.Tag = "1";
            this.buttonXoa.Text = "Xoá";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Enabled = false;
            this.buttonSua.Location = new System.Drawing.Point(861, 35);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(75, 23);
            this.buttonSua.TabIndex = 2;
            this.buttonSua.Tag = "2";
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.checkBoxTaiSanKhongGioiHan);
            this.panel.Controls.Add(this.comboBox);
            this.panel.Controls.Add(this.dateTimePicker);
            this.panel.Controls.Add(this.buttonOK);
            this.panel.Controls.Add(this.buttonHuyBo);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.textBoxTen);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.textBoxMoTa);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.textBoxMa);
            this.panel.Controls.Add(this.label2);
            this.panel.Location = new System.Drawing.Point(699, 64);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 257);
            this.panel.TabIndex = 3;
            this.panel.Visible = false;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(81, 127);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(217, 21);
            this.comboBox.TabIndex = 15;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(81, 101);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(142, 224);
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
            this.buttonHuyBo.Location = new System.Drawing.Point(223, 224);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 8;
            this.buttonHuyBo.Tag = "25";
            this.buttonHuyBo.Text = "Huỷ bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày mua";
            // 
            // textBoxTen
            // 
            this.textBoxTen.Location = new System.Drawing.Point(81, 53);
            this.textBoxTen.Name = "textBoxTen";
            this.textBoxTen.Size = new System.Drawing.Size(217, 20);
            this.textBoxTen.TabIndex = 4;
            this.textBoxTen.Tag = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên tài sản";
            // 
            // textBoxMoTa
            // 
            this.textBoxMoTa.Location = new System.Drawing.Point(81, 154);
            this.textBoxMoTa.Multiline = true;
            this.textBoxMoTa.Name = "textBoxMoTa";
            this.textBoxMoTa.Size = new System.Drawing.Size(217, 64);
            this.textBoxMoTa.TabIndex = 3;
            this.textBoxMoTa.Tag = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mô tả";
            // 
            // textBoxMa
            // 
            this.textBoxMa.Location = new System.Drawing.Point(81, 24);
            this.textBoxMa.Name = "textBoxMa";
            this.textBoxMa.Size = new System.Drawing.Size(217, 20);
            this.textBoxMa.TabIndex = 3;
            this.textBoxMa.Tag = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã tài sản";
            // 
            // radioButtonTatCa
            // 
            this.radioButtonTatCa.AutoSize = true;
            this.radioButtonTatCa.Checked = true;
            this.radioButtonTatCa.Location = new System.Drawing.Point(111, 17);
            this.radioButtonTatCa.Name = "radioButtonTatCa";
            this.radioButtonTatCa.Size = new System.Drawing.Size(56, 17);
            this.radioButtonTatCa.TabIndex = 4;
            this.radioButtonTatCa.TabStop = true;
            this.radioButtonTatCa.Text = "Tất cả";
            this.radioButtonTatCa.UseVisualStyleBackColor = true;
            this.radioButtonTatCa.CheckedChanged += new System.EventHandler(this.radioButtonTatCa_CheckedChanged);
            // 
            // radioButtonTaiSanKhongGioiHan
            // 
            this.radioButtonTaiSanKhongGioiHan.AutoSize = true;
            this.radioButtonTaiSanKhongGioiHan.Location = new System.Drawing.Point(173, 17);
            this.radioButtonTaiSanKhongGioiHan.Name = "radioButtonTaiSanKhongGioiHan";
            this.radioButtonTaiSanKhongGioiHan.Size = new System.Drawing.Size(133, 17);
            this.radioButtonTaiSanKhongGioiHan.TabIndex = 4;
            this.radioButtonTaiSanKhongGioiHan.Text = "Tài sản không giới hạn";
            this.radioButtonTaiSanKhongGioiHan.UseVisualStyleBackColor = true;
            this.radioButtonTaiSanKhongGioiHan.CheckedChanged += new System.EventHandler(this.radioButtonTaiSanKhongGioiHan_CheckedChanged);
            // 
            // radioButtonTaiSanCoGioiHan
            // 
            this.radioButtonTaiSanCoGioiHan.AutoSize = true;
            this.radioButtonTaiSanCoGioiHan.Location = new System.Drawing.Point(312, 17);
            this.radioButtonTaiSanCoGioiHan.Name = "radioButtonTaiSanCoGioiHan";
            this.radioButtonTaiSanCoGioiHan.Size = new System.Drawing.Size(115, 17);
            this.radioButtonTaiSanCoGioiHan.TabIndex = 4;
            this.radioButtonTaiSanCoGioiHan.Text = "Tài sản có giới hạn";
            this.radioButtonTaiSanCoGioiHan.UseVisualStyleBackColor = true;
            this.radioButtonTaiSanCoGioiHan.CheckedChanged += new System.EventHandler(this.radioButtonTaiSanCoGioiHan_CheckedChanged);
            // 
            // radioButtonTaiSanCoTheThemVaoPhong
            // 
            this.radioButtonTaiSanCoTheThemVaoPhong.AutoSize = true;
            this.radioButtonTaiSanCoTheThemVaoPhong.Location = new System.Drawing.Point(433, 17);
            this.radioButtonTaiSanCoTheThemVaoPhong.Name = "radioButtonTaiSanCoTheThemVaoPhong";
            this.radioButtonTaiSanCoTheThemVaoPhong.Size = new System.Drawing.Size(173, 17);
            this.radioButtonTaiSanCoTheThemVaoPhong.TabIndex = 4;
            this.radioButtonTaiSanCoTheThemVaoPhong.Text = "Tài sản có thể thêm vào phòng";
            this.radioButtonTaiSanCoTheThemVaoPhong.UseVisualStyleBackColor = true;
            this.radioButtonTaiSanCoTheThemVaoPhong.CheckedChanged += new System.EventHandler(this.radioButtonTaiSanCoTheThemVaoPhong_CheckedChanged);
            // 
            // checkBoxTaiSanKhongGioiHan
            // 
            this.checkBoxTaiSanKhongGioiHan.AutoSize = true;
            this.checkBoxTaiSanKhongGioiHan.Location = new System.Drawing.Point(81, 79);
            this.checkBoxTaiSanKhongGioiHan.Name = "checkBoxTaiSanKhongGioiHan";
            this.checkBoxTaiSanKhongGioiHan.Size = new System.Drawing.Size(134, 17);
            this.checkBoxTaiSanKhongGioiHan.TabIndex = 16;
            this.checkBoxTaiSanKhongGioiHan.Text = "Tài sản không giới hạn";
            this.checkBoxTaiSanKhongGioiHan.UseVisualStyleBackColor = true;
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
            // TENTAISAN
            // 
            this.TENTAISAN.DataPropertyName = "TENTAISAN";
            this.TENTAISAN.HeaderText = "Tên tài sản";
            this.TENTAISAN.Name = "TENTAISAN";
            this.TENTAISAN.ReadOnly = true;
            // 
            // TAISANKHONGGIOIHAN
            // 
            this.TAISANKHONGGIOIHAN.DataPropertyName = "TAISANKHONGGIOIHAN";
            this.TAISANKHONGGIOIHAN.HeaderText = "Không giới hạn";
            this.TAISANKHONGGIOIHAN.Name = "TAISANKHONGGIOIHAN";
            this.TAISANKHONGGIOIHAN.ReadOnly = true;
            this.TAISANKHONGGIOIHAN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TAISANKHONGGIOIHAN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NGAYMUA
            // 
            this.NGAYMUA.DataPropertyName = "NGAYMUA";
            this.NGAYMUA.HeaderText = "Ngày mua";
            this.NGAYMUA.Name = "NGAYMUA";
            this.NGAYMUA.ReadOnly = true;
            // 
            // TENLOAI
            // 
            this.TENLOAI.DataPropertyName = "TENLOAI";
            this.TENLOAI.HeaderText = "Loại";
            this.TENLOAI.Name = "TENLOAI";
            this.TENLOAI.ReadOnly = true;
            // 
            // MOTA
            // 
            this.MOTA.DataPropertyName = "MOTA";
            this.MOTA.HeaderText = "Mô tả";
            this.MOTA.Name = "MOTA";
            this.MOTA.ReadOnly = true;
            // 
            // NGAYTAO
            // 
            this.NGAYTAO.DataPropertyName = "NGAYTAO";
            this.NGAYTAO.HeaderText = "Ngày tạo";
            this.NGAYTAO.Name = "NGAYTAO";
            this.NGAYTAO.ReadOnly = true;
            // 
            // NGAYSUA
            // 
            this.NGAYSUA.DataPropertyName = "NGAYSUA";
            this.NGAYSUA.HeaderText = "Ngày sửa";
            this.NGAYSUA.Name = "NGAYSUA";
            this.NGAYSUA.ReadOnly = true;
            // 
            // FormTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.radioButtonTaiSanCoTheThemVaoPhong);
            this.Controls.Add(this.radioButtonTaiSanCoGioiHan);
            this.Controls.Add(this.radioButtonTaiSanKhongGioiHan);
            this.Controls.Add(this.radioButtonTatCa);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormTaiSan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài sản";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox textBoxMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonTatCa;
        private System.Windows.Forms.RadioButton radioButtonTaiSanKhongGioiHan;
        private System.Windows.Forms.RadioButton radioButtonTaiSanCoGioiHan;
        private System.Windows.Forms.RadioButton radioButtonTaiSanCoTheThemVaoPhong;
        private System.Windows.Forms.CheckBox checkBoxTaiSanKhongGioiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENTAISAN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TAISANKHONGGIOIHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYMUA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENLOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYTAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYSUA;
    }
}