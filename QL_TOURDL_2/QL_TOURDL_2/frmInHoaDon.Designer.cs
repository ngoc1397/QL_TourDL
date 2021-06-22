namespace QL_TOURDL_2
{
    partial class frmInHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInHoaDon));
            this.crystalReportHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportHoaDon
            // 
            this.crystalReportHoaDon.ActiveViewIndex = -1;
            this.crystalReportHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crystalReportHoaDon.Name = "crystalReportHoaDon";
            this.crystalReportHoaDon.Size = new System.Drawing.Size(805, 824);
            this.crystalReportHoaDon.TabIndex = 0;
            this.crystalReportHoaDon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(805, 824);
            this.Controls.Add(this.crystalReportHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất hóa đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportHoaDon;
    }
}