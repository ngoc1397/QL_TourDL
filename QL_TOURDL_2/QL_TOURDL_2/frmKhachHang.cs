using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QL_TOURDL_2
{
    public partial class frmKhachHang : Form
    {
        DAO_KhachHang khachHang;
        int PageSize = 25;
        public frmKhachHang()
        {
            InitializeComponent();
            khachHang = new DAO_KhachHang();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            //loadDSKH();
            loadData();
            int thang = DateTime.Now.Month;
            cboThang.SelectedIndex = thang - 1;
            loadDSSNKH(thang);
            gridDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridDSKH.EnableHeadersVisualStyles = false;
        }
        public void loadDSKH()
        {
            DataTable dt = new DataTable();
            dt = khachHang.loadDSKH();
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
        }
        public void loadDSSNKH(int thang)
        {
            DataTable dt = new DataTable();
            dt = khachHang.loadDSSNKH(thang);
            gridSinhNhatKH.DataSource = dt;
            DataBindingSNKH(dt);
            lblTongSoSN.Text = dt.Rows.Count.ToString();
        }
        public void DataBindingKH(DataTable dt)
        {
            txtMaKH.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDKhachHang", true, DataSourceUpdateMode.Never);
            txtMaKH.DataBindings.Add(b1);

            txtTenKH.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKH.DataBindings.Add(b2);

            txtSDTKH.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtSDTKH.DataBindings.Add(b3);

            txtDiaChiKH.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChiKH.DataBindings.Add(b4);

            cboGioiTinhKH.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "GioiTinh", true, DataSourceUpdateMode.Never);
            cboGioiTinhKH.DataBindings.Add(b5);

            txtCanCuoc.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "SoCanCuoc", true, DataSourceUpdateMode.Never);
            txtCanCuoc.DataBindings.Add(b6);

            txtNgaySinh.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "NgaySinh", true, DataSourceUpdateMode.Never);
            txtNgaySinh.DataBindings.Add(b7);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if(txtTenKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSDTKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập SĐT để liên lạc khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCanCuoc.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập căn cước khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboGioiTinhKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenKH = txtTenKH.Text.ToString();
            string SDT = txtSDTKH.Text.ToString();
            string diaChi = txtDiaChiKH.Text.ToString();
            string canCuoc = txtCanCuoc.Text.ToString();
            string gioiTinh = cboGioiTinhKH.Text.ToString();
            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text.ToString().Trim(),"dd/MM/yyyy",null);
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm khách hàng " + txtTenKH.Text.ToString(), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (khachHang.themKhachHang(tenKH, SDT, diaChi, gioiTinh, canCuoc, ngaySinh))
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void RefreshKH()
        {
            txtTenKH.Clear();
            txtMaKH.Clear();
            txtSDTKH.Clear();
            txtCanCuoc.Clear();
            txtDiaChiKH.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshKH();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách hàng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSDTKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập SĐT để liên lạc khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCanCuoc.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập căn cước khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboGioiTinhKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idKH = int.Parse(txtMaKH.Text.ToString());
            DateTime ngaySinh = Convert.ToDateTime(txtNgaySinh.Text.ToString());
            string tenKH = txtTenKH.Text.ToString();
            string SDT = txtSDTKH.Text.ToString();
            string diaChi = txtDiaChiKH.Text.ToString();
            string canCuoc = txtCanCuoc.Text.ToString();
            string gioiTinh = cboGioiTinhKH.Text.ToString();
            if(MessageBox.Show("Bạn có chắc chắn muốn cập nhật khách hàng?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(khachHang.capNhatKhachHang(idKH,tenKH, SDT, diaChi, gioiTinh, canCuoc,ngaySinh))
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách hàng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idKH = int.Parse(txtMaKH.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kq = khachHang.xoaKhachHang(idKH);
                if (kq == 0)
                {
                    MessageBox.Show("Khách hàng đã từng mua tour hoặc vé. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (kq == -1)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(kq == 1)
                {
                    loadData();
                }
            }
        }

        private void btnTinKiemKH_Click(object sender, EventArgs e)
        {
            string tenKH = txtTimKiemKH.Text.ToString();
            if (txtTimKiemKH.Text.Length == 0)
            {
                loadData();
                return;
            }
            TimKiemKH(tenKH);
        }
        public void TimKiemKH(string tenKH)
        {
            DataTable dt = new DataTable();
            dt = khachHang.timKiemDSKH(tenKH);
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
        }

        private void txtNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            DateTime rs;

            CultureInfo ci = new CultureInfo("en-IE");

            if (!DateTime.TryParseExact(this.txtNgaySinh.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                e.Cancel = true;
            }
        }

        private void btnLocKH_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(cboThang.Text.ToString());
            loadDSSNKH(thang);
        }
        public void DataBindingSNKH(DataTable dt)
        {
            txtTenKHSN.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "TenKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKHSN.DataBindings.Add(b1);

            txtSDTSN.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtSDTSN.DataBindings.Add(b2);

            txtDiaChiKHSN.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChiKHSN.DataBindings.Add(b3);

            txtNgaySinhSN.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "NgaySinh", true, DataSourceUpdateMode.Never);
            txtNgaySinhSN.DataBindings.Add(b4);
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
            DTO_PhanTrangKH phanTrang = khachHang.loadDSKHPhanTrang(int.Parse(btnPager.Name), PageSize);
            gridDSKH.DataSource = phanTrang.dt;
            DataBindingKH(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, int.Parse(btnPager.Name));
        }
        public void loadData()
        {
            DTO_PhanTrangKH phanTrang = khachHang.loadDSKHPhanTrang(1, PageSize);
            gridDSKH.DataSource = phanTrang.dt;
            DataBindingKH(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, 1);
        }
        //Tạo class Page để lưu trữ các thuộc tính của Page
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        private void gridDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtTimKiemKH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTinKiemKH.PerformClick();
            }
        }
    }
}
