namespace QLTS_WindowsForms
{
    partial class FormQuanLyTaiSanThuocPhong
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dateTimePickerNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTinhTrang = new System.Windows.Forms.ComboBox();
            this.comboBoxPhong = new System.Windows.Forms.ComboBox();
            this.comboBoxTaiSan = new System.Windows.Forms.ComboBox();
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxMoTa = new System.Windows.Forms.TextBox();
            this.textBoxSoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelThongBao = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelThongBao);
            this.groupBox.Controls.Add(this.dateTimePickerNgayNhap);
            this.groupBox.Controls.Add(this.comboBoxTinhTrang);
            this.groupBox.Controls.Add(this.comboBoxPhong);
            this.groupBox.Controls.Add(this.comboBoxTaiSan);
            this.groupBox.Controls.Add(this.buttonHuyBo);
            this.groupBox.Controls.Add(this.buttonOK);
            this.groupBox.Controls.Add(this.textBoxMoTa);
            this.groupBox.Controls.Add(this.textBoxSoLuong);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(283, 261);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "...";
            // 
            // dateTimePickerNgayNhap
            // 
            this.dateTimePickerNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgayNhap.Location = new System.Drawing.Point(94, 121);
            this.dateTimePickerNgayNhap.Name = "dateTimePickerNgayNhap";
            this.dateTimePickerNgayNhap.Size = new System.Drawing.Size(183, 20);
            this.dateTimePickerNgayNhap.TabIndex = 20;
            // 
            // comboBoxTinhTrang
            // 
            this.comboBoxTinhTrang.FormattingEnabled = true;
            this.comboBoxTinhTrang.Location = new System.Drawing.Point(94, 147);
            this.comboBoxTinhTrang.Name = "comboBoxTinhTrang";
            this.comboBoxTinhTrang.Size = new System.Drawing.Size(183, 21);
            this.comboBoxTinhTrang.TabIndex = 25;
            // 
            // comboBoxPhong
            // 
            this.comboBoxPhong.FormattingEnabled = true;
            this.comboBoxPhong.Location = new System.Drawing.Point(94, 41);
            this.comboBoxPhong.Name = "comboBoxPhong";
            this.comboBoxPhong.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPhong.TabIndex = 5;
            this.comboBoxPhong.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaiSan_SelectedIndexChanged);
            // 
            // comboBoxTaiSan
            // 
            this.comboBoxTaiSan.FormattingEnabled = true;
            this.comboBoxTaiSan.Location = new System.Drawing.Point(94, 68);
            this.comboBoxTaiSan.Name = "comboBoxTaiSan";
            this.comboBoxTaiSan.Size = new System.Drawing.Size(183, 21);
            this.comboBoxTaiSan.TabIndex = 10;
            this.comboBoxTaiSan.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaiSan_SelectedIndexChanged);
            // 
            // buttonHuyBo
            // 
            this.buttonHuyBo.Location = new System.Drawing.Point(202, 233);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 40;
            this.buttonHuyBo.Text = "Huỷ bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(121, 233);
            this.buttonOK.MaximumSize = new System.Drawing.Size(75, 23);
            this.buttonOK.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 35;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxMoTa
            // 
            this.textBoxMoTa.Location = new System.Drawing.Point(94, 173);
            this.textBoxMoTa.Multiline = true;
            this.textBoxMoTa.Name = "textBoxMoTa";
            this.textBoxMoTa.Size = new System.Drawing.Size(183, 54);
            this.textBoxMoTa.TabIndex = 30;
            // 
            // textBoxSoLuong
            // 
            this.textBoxSoLuong.Location = new System.Drawing.Point(94, 95);
            this.textBoxSoLuong.Name = "textBoxSoLuong";
            this.textBoxSoLuong.Size = new System.Drawing.Size(183, 20);
            this.textBoxSoLuong.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mô tả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tình trạng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài sản";
            // 
            // labelThongBao
            // 
            this.labelThongBao.AutoSize = true;
            this.labelThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelThongBao.ForeColor = System.Drawing.Color.Red;
            this.labelThongBao.Location = new System.Drawing.Point(1, 19);
            this.labelThongBao.Name = "labelThongBao";
            this.labelThongBao.Size = new System.Drawing.Size(280, 13);
            this.labelThongBao.TabIndex = 41;
            this.labelThongBao.Text = "Ghi chú: Tạo phòng \"Kho\" và tình trạng \"Thanh lý\" trước.";
            this.labelThongBao.Visible = false;
            // 
            // FormQuanLyTaiSanThuocPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 285);
            this.Controls.Add(this.groupBox);
            this.Name = "FormQuanLyTaiSanThuocPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxMoTa;
        private System.Windows.Forms.TextBox textBoxSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxTaiSan;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayNhap;
        private System.Windows.Forms.ComboBox comboBoxTinhTrang;
        private System.Windows.Forms.ComboBox comboBoxPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelThongBao;
    }
}