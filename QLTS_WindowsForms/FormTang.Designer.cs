namespace QLTS_WindowsForms
{
    partial class FormTang
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
            this.TENTANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENKHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENCOSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYTAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYSUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.comboBoxKhu = new System.Windows.Forms.ComboBox();
            this.comboBoxCoSo = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.textBoxMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.TENTANG,
            this.TENKHU,
            this.TENCOSO,
            this.MOTA,
            this.NGAYTAO,
            this.NGAYSUA});
            this.dataGridView.Location = new System.Drawing.Point(12, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(395, 266);
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
            this.SUBID.HeaderText = "Mã tầng";
            this.SUBID.Name = "SUBID";
            this.SUBID.ReadOnly = true;
            // 
            // TENTANG
            // 
            this.TENTANG.DataPropertyName = "TENTANG";
            this.TENTANG.HeaderText = "Tên tầng";
            this.TENTANG.Name = "TENTANG";
            this.TENTANG.ReadOnly = true;
            // 
            // TENKHU
            // 
            this.TENKHU.DataPropertyName = "TENKHU";
            this.TENKHU.HeaderText = "Khu";
            this.TENKHU.Name = "TENKHU";
            this.TENKHU.ReadOnly = true;
            // 
            // TENCOSO
            // 
            this.TENCOSO.DataPropertyName = "TENCOSO";
            this.TENCOSO.HeaderText = "Cơ sở";
            this.TENCOSO.Name = "TENCOSO";
            this.TENCOSO.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách tầng";
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(413, 35);
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
            this.buttonXoa.Location = new System.Drawing.Point(494, 35);
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
            this.buttonSua.Location = new System.Drawing.Point(575, 35);
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
            this.panel.Controls.Add(this.comboBoxKhu);
            this.panel.Controls.Add(this.comboBoxCoSo);
            this.panel.Controls.Add(this.buttonOK);
            this.panel.Controls.Add(this.buttonHuyBo);
            this.panel.Controls.Add(this.textBoxMoTa);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.textBoxTen);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.textBoxMa);
            this.panel.Controls.Add(this.label2);
            this.panel.Location = new System.Drawing.Point(413, 64);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 237);
            this.panel.TabIndex = 3;
            this.panel.Visible = false;
            // 
            // comboBoxKhu
            // 
            this.comboBoxKhu.FormattingEnabled = true;
            this.comboBoxKhu.Location = new System.Drawing.Point(81, 105);
            this.comboBoxKhu.Name = "comboBoxKhu";
            this.comboBoxKhu.Size = new System.Drawing.Size(217, 21);
            this.comboBoxKhu.TabIndex = 9;
            // 
            // comboBoxCoSo
            // 
            this.comboBoxCoSo.FormattingEnabled = true;
            this.comboBoxCoSo.Location = new System.Drawing.Point(81, 79);
            this.comboBoxCoSo.Name = "comboBoxCoSo";
            this.comboBoxCoSo.Size = new System.Drawing.Size(217, 21);
            this.comboBoxCoSo.TabIndex = 9;
            this.comboBoxCoSo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCoSo_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(142, 200);
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
            this.buttonHuyBo.Location = new System.Drawing.Point(223, 200);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 8;
            this.buttonHuyBo.Tag = "25";
            this.buttonHuyBo.Text = "Huỷ bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            // 
            // textBoxMoTa
            // 
            this.textBoxMoTa.Location = new System.Drawing.Point(81, 131);
            this.textBoxMoTa.Multiline = true;
            this.textBoxMoTa.Name = "textBoxMoTa";
            this.textBoxMoTa.Size = new System.Drawing.Size(217, 63);
            this.textBoxMoTa.TabIndex = 6;
            this.textBoxMoTa.Tag = "15";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mô tả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cơ sở";
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
            this.label3.Location = new System.Drawing.Point(17, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên tầng";
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
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã tầng";
            // 
            // FormTang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 313);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormTang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tầng";
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
        private System.Windows.Forms.TextBox textBoxMoTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.ComboBox comboBoxCoSo;
        private System.Windows.Forms.ComboBox comboBoxKhu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENTANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENKHU;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENCOSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYTAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYSUA;
    }
}