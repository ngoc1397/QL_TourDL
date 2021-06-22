namespace QL_TOURDL_2
{
    partial class frmPhuongTien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridPhuongTien = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtSoCho = new System.Windows.Forms.NumericUpDown();
            this.txtIDPT = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSuaPhuongTien = new System.Windows.Forms.Button();
            this.btnRefreshPT = new System.Windows.Forms.Button();
            this.btnXoaPhuongTien = new System.Windows.Forms.Button();
            this.btnThemPhuongTien = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenPhuongTien = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhuongTien)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPhuongTien
            // 
            this.gridPhuongTien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPhuongTien.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridPhuongTien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPhuongTien.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridPhuongTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPhuongTien.Location = new System.Drawing.Point(0, 170);
            this.gridPhuongTien.Name = "gridPhuongTien";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPhuongTien.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gridPhuongTien.RowTemplate.Height = 24;
            this.gridPhuongTien.Size = new System.Drawing.Size(595, 477);
            this.gridPhuongTien.TabIndex = 7;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtSoCho);
            this.panel8.Controls.Add(this.txtIDPT);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.btnSuaPhuongTien);
            this.panel8.Controls.Add(this.btnRefreshPT);
            this.panel8.Controls.Add(this.btnXoaPhuongTien);
            this.panel8.Controls.Add(this.btnThemPhuongTien);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.txtTenPhuongTien);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 39);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(595, 131);
            this.panel8.TabIndex = 6;
            // 
            // txtSoCho
            // 
            this.txtSoCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCho.Location = new System.Drawing.Point(152, 48);
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Size = new System.Drawing.Size(433, 27);
            this.txtSoCho.TabIndex = 184;
            // 
            // txtIDPT
            // 
            this.txtIDPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPT.Location = new System.Drawing.Point(508, 5);
            this.txtIDPT.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDPT.Name = "txtIDPT";
            this.txtIDPT.ReadOnly = true;
            this.txtIDPT.Size = new System.Drawing.Size(77, 24);
            this.txtIDPT.TabIndex = 183;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkCyan;
            this.label19.Location = new System.Drawing.Point(478, 7);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 20);
            this.label19.TabIndex = 182;
            this.label19.Text = "ID";
            // 
            // btnSuaPhuongTien
            // 
            this.btnSuaPhuongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaPhuongTien.BackColor = System.Drawing.Color.LightGreen;
            this.btnSuaPhuongTien.FlatAppearance.BorderSize = 0;
            this.btnSuaPhuongTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaPhuongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaPhuongTien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSuaPhuongTien.Image = global::QL_TOURDL_2.Properties.Resources.pencil;
            this.btnSuaPhuongTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaPhuongTien.Location = new System.Drawing.Point(414, 91);
            this.btnSuaPhuongTien.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuaPhuongTien.Name = "btnSuaPhuongTien";
            this.btnSuaPhuongTien.Size = new System.Drawing.Size(77, 35);
            this.btnSuaPhuongTien.TabIndex = 181;
            this.btnSuaPhuongTien.Text = "Sửa";
            this.btnSuaPhuongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaPhuongTien.UseVisualStyleBackColor = false;
            this.btnSuaPhuongTien.Click += new System.EventHandler(this.btnSuaPhuongTien_Click);
            // 
            // btnRefreshPT
            // 
            this.btnRefreshPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPT.BackColor = System.Drawing.Color.LightCyan;
            this.btnRefreshPT.FlatAppearance.BorderSize = 0;
            this.btnRefreshPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshPT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefreshPT.Image = global::QL_TOURDL_2.Properties.Resources.refresh;
            this.btnRefreshPT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshPT.Location = new System.Drawing.Point(190, 91);
            this.btnRefreshPT.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshPT.Name = "btnRefreshPT";
            this.btnRefreshPT.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshPT.TabIndex = 180;
            this.btnRefreshPT.Text = "Refresh";
            this.btnRefreshPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshPT.UseVisualStyleBackColor = false;
            this.btnRefreshPT.Click += new System.EventHandler(this.btnRefreshPT_Click);
            // 
            // btnXoaPhuongTien
            // 
            this.btnXoaPhuongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaPhuongTien.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnXoaPhuongTien.FlatAppearance.BorderSize = 0;
            this.btnXoaPhuongTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhuongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPhuongTien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnXoaPhuongTien.Image = global::QL_TOURDL_2.Properties.Resources.remove;
            this.btnXoaPhuongTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaPhuongTien.Location = new System.Drawing.Point(506, 91);
            this.btnXoaPhuongTien.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaPhuongTien.Name = "btnXoaPhuongTien";
            this.btnXoaPhuongTien.Size = new System.Drawing.Size(79, 35);
            this.btnXoaPhuongTien.TabIndex = 179;
            this.btnXoaPhuongTien.Text = "Xóa";
            this.btnXoaPhuongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaPhuongTien.UseVisualStyleBackColor = false;
            this.btnXoaPhuongTien.Click += new System.EventHandler(this.btnXoaPhuongTien_Click);
            // 
            // btnThemPhuongTien
            // 
            this.btnThemPhuongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemPhuongTien.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThemPhuongTien.FlatAppearance.BorderSize = 0;
            this.btnThemPhuongTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPhuongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPhuongTien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThemPhuongTien.Image = global::QL_TOURDL_2.Properties.Resources.add;
            this.btnThemPhuongTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemPhuongTien.Location = new System.Drawing.Point(316, 91);
            this.btnThemPhuongTien.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemPhuongTien.Name = "btnThemPhuongTien";
            this.btnThemPhuongTien.Size = new System.Drawing.Size(84, 35);
            this.btnThemPhuongTien.TabIndex = 178;
            this.btnThemPhuongTien.Text = "Thêm";
            this.btnThemPhuongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemPhuongTien.UseVisualStyleBackColor = false;
            this.btnThemPhuongTien.Click += new System.EventHandler(this.btnThemPhuongTien_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(20, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 176;
            this.label7.Text = "Số chỗ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(20, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 174;
            this.label8.Text = "Tên phương tiện";
            // 
            // txtTenPhuongTien
            // 
            this.txtTenPhuongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenPhuongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhuongTien.Location = new System.Drawing.Point(152, 5);
            this.txtTenPhuongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenPhuongTien.Name = "txtTenPhuongTien";
            this.txtTenPhuongTien.Size = new System.Drawing.Size(325, 24);
            this.txtTenPhuongTien.TabIndex = 175;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 39);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(166, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "PHƯƠNG TIỆN CUNG CẤP\r\n";
            // 
            // frmPhuongTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(595, 647);
            this.Controls.Add(this.gridPhuongTien);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhuongTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phương tiện";
            this.Load += new System.EventHandler(this.frmPhuongTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPhuongTien)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPhuongTien;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtIDPT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSuaPhuongTien;
        private System.Windows.Forms.Button btnRefreshPT;
        private System.Windows.Forms.Button btnXoaPhuongTien;
        private System.Windows.Forms.Button btnThemPhuongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTenPhuongTien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtSoCho;
    }
}