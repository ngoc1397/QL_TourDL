using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QL_TOURDL_2
{
    public partial class frmDoanhThu : Form
    {
        private DAO_DoanhThu doanhThu;
        public frmDoanhThu()
        {
            InitializeComponent();
            doanhThu = new DAO_DoanhThu();
        }
        /// <summary>
        /// thêm class biểu đồ để thể hiện giá trị từ cơ sở dữ liệu cho số lượng khách hàng mới
        /// </summary>
        public class BieuDo
        {
            public int thang;
            public int giatri;
            public BieuDo(int thang, int giatri)
            {
                this.thang = thang;
                this.giatri = giatri;
            }
        }
        /// <summary>
        /// thêm class biểu đồ doanh thu để thể hiện giá trị cho lượng doanh thu theo từng tháng
        /// </summary>
        public class BieuDoDoanhThu
        {
            public int thang;
            public decimal giatri;
            public BieuDoDoanhThu(int thang, decimal giatri)
            {
                this.thang = thang;
                this.giatri = giatri;
            }
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            cboNam.SelectedIndex = 0;
            cboNamKH.SelectedIndex = 0;
            int nam = DateTime.Now.Year;
            int thang = DateTime.Now.Month;
            loadDoanhThuThang(nam);
            loadKhachHangMoi(nam);
            cboNamTourHT.SelectedIndex = 0;
            cboThangTourHT.SelectedIndex = thang - 1;
            loadTourHoanThanh(thang, nam);
            lblChiTieuKHHT.Text = doanhThu.demKHMoiTrongThang(thang).ToString();
            lblChiTieuTour.Text = String.Format("{0:0,0 VNĐ}", Properties.Settings.Default.ChiTieuTour);
            lblChiTieuKH.Text = Properties.Settings.Default.ChiTieuKH.ToString();
            
        }
        //Hiển thị doanh thu tháng theo từng năm
        public void loadDoanhThuThang(int nam)
        {
            DataTable dt = new DataTable();
            chartDoanhThuNam.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartDoanhThuNam.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = doanhThu.loadDoanhThuTungThang(nam);
            List<BieuDoDoanhThu> list = new List<BieuDoDoanhThu>(); // khởi tạo một list doanh thu 12 tháng
            for (int i = 1; i <= 12; i++) //duyệt lấy giá trị
            {
                int dem = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == int.Parse(dt.Rows[j][0].ToString()))//khởi tạo đối tượng bieudo nếu giá trị tháng trong csdl bằng giá trị i của for
                    {
                        int thang = int.Parse(dt.Rows[j][0].ToString());
                        decimal giaTri = decimal.Parse(dt.Rows[j][1].ToString());
                        BieuDoDoanhThu bieuDo = new BieuDoDoanhThu(thang, giaTri);
                        list.Add(bieuDo);
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    BieuDoDoanhThu bieuDo = new BieuDoDoanhThu(i, 0);
                    list.Add(bieuDo);
                }
            }
            //tạo mới 2 mảng để binding dữ liệu cho biểu đồ
            int[] x = new int[12];
            decimal[] y = new decimal[12];
            for (int i = 0; i < 12; i++)
            {
                x[i] = list[i].thang;
                y[i] = list[i].giatri;
            }
            chartDoanhThuNam.Series[0].Points.DataBindXY(x, y);
        }
        //Hiển thị số khách hàng mới trong tháng theo từng năm
        public void loadKhachHangMoi(int nam)
        {
            DataTable dt = new DataTable();
            List<BieuDo> list = new List<BieuDo>();
            chartKhachHangMoi.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartKhachHangMoi.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = doanhThu.loadKhachHangMoiTungThang(nam);
            for (int i = 1; i <= 12; i++)
            {
                int dem = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == int.Parse(dt.Rows[j][0].ToString()))
                    {
                        int thang = int.Parse(dt.Rows[j][0].ToString());
                        int giaTri = int.Parse(dt.Rows[j][1].ToString());
                        BieuDo bieuDo = new BieuDo(thang, giaTri);
                        list.Add(bieuDo);
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    BieuDo bieuDo = new BieuDo(i, 0);
                    list.Add(bieuDo);
                }
            }
            chartKhachHangMoi.DataSource = list;
            int[] x = new int[12];
            int[] y = new int[12];
            for (int i = 0; i < 12; i++)
            {
                x[i] = list[i].thang;
                y[i] = list[i].giatri;
            }
            chartKhachHangMoi.Series[0].Points.DataBindXY(x, y);
        }

        private void btnLocDoanhThu_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadDoanhThuThang(nam);

        }

        private void btnLocKH_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cboNamKH.SelectedItem.ToString());
            loadKhachHangMoi(nam);
        }
        //Lấy danh sách tour đã hoàn thành
        public void loadTourHoanThanh(int thang, int nam)
        {
            DataTable dt = doanhThu.loadTourHoanThanh(thang, nam);
            decimal tongThu = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongThu += decimal.Parse(dt.Rows[i][3].ToString());
            }
            lblChiTieuTourHT.Text = String.Format("{0:0,0 VNĐ}", tongThu);
            gridTourHoanThanh.DataSource = dt;
            chartChiTieu.Series[0].Points.AddXY("Chỉ tiêu", Properties.Settings.Default.ChiTieuTour);//lấy biểu đồ chỉ tiêu từ Property.Setting
            chartChiTieu.Series[0].Points.AddXY("Đã thực hiện", tongThu);
        }

        private void btnLocTourHT_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cboNamTourHT.SelectedItem.ToString());
            int thang = int.Parse(cboThangTourHT.SelectedItem.ToString());
        }

        private void btnNhapChiTieuTour_Click(object sender, EventArgs e)
        {
            decimal chiTieuTour = decimal.Parse(txtNhapChiTieuTour.Text.ToString());
            Properties.Settings.Default.ChiTieuTour = chiTieuTour;
            Properties.Settings.Default.Save();
            lblChiTieuTour.Text = String.Format("{0:0,0 VNĐ}", Properties.Settings.Default.ChiTieuTour);
        }

        private void btnNhapChiTieuKH_Click(object sender, EventArgs e)
        {
            int chiTieuKH = int.Parse(txtNhapChiTieuKH.Text.ToString());
            Properties.Settings.Default.ChiTieuKH = chiTieuKH;
            lblChiTieuKH.Text = Properties.Settings.Default.ChiTieuKH.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
