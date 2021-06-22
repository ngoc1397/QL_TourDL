using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QL_TOURDL_2
{
    public partial class frmTour : Form
    {
        int PageSize = 18;
        DAO_NhanVien nhanVien;
        DAO_Tour tour;
        DAO_DichVu dichVu;
        public frmTour()
        {
            InitializeComponent();
            tour = new DAO_Tour();
            nhanVien = new DAO_NhanVien();
            dichVu = new DAO_DichVu();
        }

        private void frmTour_Load(object sender, EventArgs e)
        {
            //loadTourTatCa();
            gridTour.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTour.EnableHeadersVisualStyles = false;
            loadData();
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            loadTrangThaiTour();
            loadTenNV();
        }
        public void loadTourTatCa()
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourTatCaQuanTri();
            gridTour.DataSource = dt;
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }
        public void loadTenNV()
        {
            DataTable dt = new DataTable();
            dt = nhanVien.loadTenNhanVien();
            cboNhanVien.DataSource = dt;
            cboNhanVien.ValueMember = "IDNhanVien";
            cboNhanVien.DisplayMember = "TenNhanVien";
        }
        public void loadTrangThaiTour()
        {
            DataTable dt = new DataTable();
            dt = tour.loadDSTrangThai();
            cboTrangThaiTour.DataSource = dt;
            cboXacNhanTTTour.DataSource = dt;
            cboXacNhanTTTour.ValueMember = "IDTrangThai";
            cboXacNhanTTTour.DisplayMember = "TenTrangThai";
            cboTrangThaiTour.ValueMember = "IDTrangThai";
            cboTrangThaiTour.DisplayMember = "TenTrangThai";
        }
        public void DataBindingHT(DataTable dt)
        {
            txtIDTourHT.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDTour", true, DataSourceUpdateMode.Never);
            txtIDTourHT.DataBindings.Add(b1);

            txtTenTourHT.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenTour", true, DataSourceUpdateMode.Never);
            txtTenTourHT.DataBindings.Add(b2);

            txtGiaTourHT.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "GiaTour", true, DataSourceUpdateMode.Never);
            txtGiaTourHT.DataBindings.Add(b3);

            txtSLVeHT.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "SoLuong", true, DataSourceUpdateMode.Never);
            txtSLVeHT.DataBindings.Add(b4);

            txtNgayDiHT.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "NgayDi", true, DataSourceUpdateMode.Never);
            txtNgayDiHT.DataBindings.Add(b5);

            txtNgayVeHT.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "NgayVe", true, DataSourceUpdateMode.Never);
            txtNgayVeHT.DataBindings.Add(b6);

            txtMoTaHT.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "MoTa", true, DataSourceUpdateMode.Never);
            txtMoTaHT.DataBindings.Add(b7);

            txtDonGiaHT.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "DonGiaVe", true, DataSourceUpdateMode.Never);
            txtDonGiaHT.DataBindings.Add(b8);

            txtTrangThai.DataBindings.Clear();
            Binding b9 = new Binding("Text", dt, "TenTrangThai", true, DataSourceUpdateMode.Never);
            txtTrangThai.DataBindings.Add(b9);
        }

        private void gridTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (gridTour.CurrentCell.Value.ToString().Length > 0)
            {
                lstDiaDanh.Rows.Clear();
                int idTour = int.Parse(txtIDTourHT.Text.ToString());
                DataTable dt1 = dichVu.loadTourDiaDanh(idTour);
                DataTable dt3 = dichVu.loadTourPhuongTien(idTour);
                DataTable dt2 = dichVu.loadTourKhachSan(idTour);
                foreach (DataRow row in dt1.Rows)
                {
                    var index = lstDiaDanh.Rows.Add();
                    lstDiaDanh.Rows[index].Cells["IDDD"].Value = row["IDDiaDanh"];
                    lstDiaDanh.Rows[index].Cells["TenDD"].Value = row["TenDiaDanh"];
                }
                lstKhachSan.Rows.Clear();
                foreach (DataRow row in dt2.Rows)
                {
                    var index = lstKhachSan.Rows.Add();
                    lstKhachSan.Rows[index].Cells["IDKS"].Value = row["IDKhachSan"];
                    lstKhachSan.Rows[index].Cells["TenKS"].Value = row["TenKhachSan"];
                }
                lstPhuongTien.Rows.Clear();
                foreach (DataRow rows in dt3.Rows)
                {
                    var index = lstPhuongTien.Rows.Add();
                    lstPhuongTien.Rows[index].Cells["IDPT"].Value = rows["IDPhuongTien"];
                    lstPhuongTien.Rows[index].Cells["TenPT"].Value = rows["TenPhuongTien"];
                    lstPhuongTien.Rows[index].Cells["SL"].Value = rows["SoLuong"];
                }
            }
        }

        private void btnLocTour_Click(object sender, EventArgs e)
        {
            DateTime ngayDi = txtTuNgay.Value;
            DateTime ngayVe = txtDenNgay.Value;
            locTourTheoNgay(ngayDi,ngayVe);
        }

        public void locTourTheoNgay(DateTime ngayDi, DateTime ngayVe)
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourTheoNgay(ngayDi,ngayVe);
            gridTour.DataSource = dt;
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }

        private void btnLoadTour_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnLocTourTheoTT_Click(object sender, EventArgs e)
        {
            if (cboTrangThaiTour.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idTT = int.Parse(cboTrangThaiTour.SelectedValue.ToString());
            locTourTheoTT(idTT);
        }
        public void locTourTheoNV(int idNV)
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourTheoNV(idNV);
            gridTour.DataSource = dt;
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }
        public void locTourTheoTT(int idTT)
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourTheoTT(idTT);
            gridTour.DataSource = dt;
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }

        public void locTourTheoTen(string tenTour)
        {
            DataTable dt = new DataTable();
            dt = tour.timKiemTourTheoQuanTri(tenTour);
            gridTour.DataSource = dt;
            gridTour.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            gridTour.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }

        private void btnLocTourTheoNV_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idNV = int.Parse(cboNhanVien.SelectedValue.ToString());
            locTourTheoNV(idNV);
        }

        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            if (cboXacNhanTTTour.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtIDTourHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn trạng tour muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idTT = int.Parse(cboXacNhanTTTour.SelectedValue.ToString());
            int idTour = int.Parse(txtIDTourHT.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật trạng thái cho tour?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(tour.capNhatTrangThaiTour(idTour,idTT))
                {
                    MessageBox.Show("Cập nhật thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemTourTheoTen_Click(object sender, EventArgs e)
        {
            string tenTour = txtTKTourTheoTen.Text.ToString();
            locTourTheoTen(tenTour);
        }

        private void txtTKTourTheoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemTourTheoTen.PerformClick();
            }
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            //Sử dụng đối tượng List để chứa danh sách các trang
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Tính toán để hiển thị các trang.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1; endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add nút trang đầu.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "Trang đầu", Value = "1" });
            }

            //Add nút < 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++) { pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage }); } //Add nút >>.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add nút Trang cuối.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Trang cuối", Value = pageCount.ToString() });
            }

            //Xóa các nút trên trang.
            pnlDieuHuong.Controls.Clear();

            //Lặp và add các Buttons cho trang.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(110 * count, 5);
                btnPage.Size = new System.Drawing.Size(100, 30);
                btnPage.FlatStyle = FlatStyle.Flat;
                btnPage.FlatAppearance.BorderSize = 0;
                btnPage.ForeColor = System.Drawing.Color.White;
                btnPage.BackColor = System.Drawing.Color.Indigo;
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlDieuHuong.Controls.Add(btnPage);
                count++;
            }
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            DTO_PhanTrangKH phanTrang = tour.loadTourQuanTriPhanTrang(int.Parse(btnPager.Name), PageSize);
            gridTour.DataSource = phanTrang.dt;
            DataBindingHT(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, int.Parse(btnPager.Name));
        }
        public void loadData()
        {
            DTO_PhanTrangKH phanTrang = tour.loadTourQuanTriPhanTrang(1, PageSize);
            gridTour.DataSource = phanTrang.dt;
            DataBindingHT(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, 1);
        }
        //Tạo class Page để lưu trữ các thuộc tính của Page
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        private void txtTKTourTheoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
