namespace QL_TOURDL_2
{
    partial class frmInVe
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
            this.crystalReportInVe = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportInVe
            // 
            this.crystalReportInVe.ActiveViewIndex = -1;
            this.crystalReportInVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportInVe.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportInVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportInVe.Location = new System.Drawing.Point(0, 0);
            this.crystalReportInVe.Name = "crystalReportInVe";
            this.crystalReportInVe.Size = new System.Drawing.Size(1077, 686);
            this.crystalReportInVe.TabIndex = 0;
            this.crystalReportInVe.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmInVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 686);
            this.Controls.Add(this.crystalReportInVe);
            this.Name = "frmInVe";
            this.Text = "frmInVe";
            this.Load += new System.EventHandler(this.frmInVe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportInVe;
    }
}