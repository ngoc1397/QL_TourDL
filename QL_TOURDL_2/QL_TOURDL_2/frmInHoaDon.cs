using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QL_TOURDL_2
{
    public partial class frmInHoaDon : Form
    {
        DataTable dt;
        string tenND;
        decimal tongTien;
        string tenTour;
        DTO_KhachHang khachHang;
        public frmInHoaDon(DataTable dt,string tenND,decimal tongTien,string tenTour,DTO_KhachHang khachHang)
        {
            this.dt = dt;
            this.tongTien = tongTien;
            this.tenND = tenND;
            this.tenTour = tenTour;
            this.khachHang = khachHang;
            InitializeComponent();
            
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            InHoaDon inHoaDon = new InHoaDon();
            inHoaDon.Database.Tables["HoaDonVe"].SetDataSource(dt);
            inHoaDon.SetParameterValue("NhanVien", tenND);
            inHoaDon.SetParameterValue("TongTien", tongTien);
            inHoaDon.SetParameterValue("TenTour", tenTour);
            inHoaDon.SetParameterValue("TenKH", khachHang.Ten);
            inHoaDon.SetParameterValue("DiaChi", khachHang.DiaChi);
            inHoaDon.SetParameterValue("SDT", khachHang.SoDienThoai);
            inHoaDon.SetParameterValue("CanCuoc", khachHang.CanCuoc);
            inHoaDon.SetParameterValue("GioiTinh", khachHang.GioiTinh);
            crystalReportHoaDon.ReportSource = null;
            crystalReportHoaDon.ReportSource = inHoaDon;
        }
    }
}
