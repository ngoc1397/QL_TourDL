using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_TOURDL_2
{
    public partial class frmInVe : Form
    {
        string ngayDi, ngayVe, tenVe, loaiVe;
        decimal giaVe;
        public frmInVe(string loaiVe,string ngayDi,string ngayVe,string tenVe,decimal giaVe)
        {
            this.ngayDi = ngayDi;
            this.ngayVe = ngayVe;
            this.tenVe = tenVe;
            this.loaiVe = loaiVe;
            this.giaVe = giaVe;
            InitializeComponent();
        }

        private void frmInVe_Load(object sender, EventArgs e)
        {
            InVe inVe = new InVe();
            inVe.SetParameterValue("NgayDi", ngayDi);
            inVe.SetParameterValue("NgayVe", ngayVe);
            inVe.SetParameterValue("TenTour", tenVe);
            inVe.SetParameterValue("LoaiVe", loaiVe);
            inVe.SetParameterValue("GiaVe", giaVe);
            crystalReportInVe.ReportSource = null;
            crystalReportInVe.ReportSource = inVe;
        }
    }
}
