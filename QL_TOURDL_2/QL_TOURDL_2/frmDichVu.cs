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
    public partial class frmDichVu : Form
    {
        DAO_DichVu dichVu;
        int PageSize = 25;
        public frmDichVu()
        {
            InitializeComponent();
            dichVu = new DAO_DichVu();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            gridNhaCC.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridNhaCC.EnableHeadersVisualStyles = false;
            loadData();
        }
        public void DataBinding(DataTable dt)
        {
            txtIDNCC.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDNhaCungCap", true, DataSourceUpdateMode.Never);
            txtIDNCC.DataBindings.Add(b1);

            txtTenNCC.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenNhaCungCap", true, DataSourceUpdateMode.Never);
            txtTenNCC.DataBindings.Add(b2);

            txtDiaChiNCC.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChiNCC.DataBindings.Add(b3);

            txtSDTNCC.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtSDTNCC.DataBindings.Add(b4);

            txtEmailNCC.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "Email", true, DataSourceUpdateMode.Never);
            txtEmailNCC.DataBindings.Add(b5);
        }
        
        
        public void loadDSNhaCC()
        {
            DataTable dt = new DataTable();
            dt = dichVu.loadDSNCC();
            gridNhaCC.DataSource = dt;
        }

        private void btnThemDiaDanh_Click(object sender, EventArgs e)
        {
           
        }

        private void btnFrmDiaDanh_Click(object sender, EventArgs e)
        {
            frmDiaDanh frm = new frmDiaDanh();
            frm.ShowDialog();
        }

        private void btnFrmKhachSan_Click(object sender, EventArgs e)
        {
            frmKhachSan frm = new frmKhachSan();
            frm.ShowDialog();
        }

        private void btnFrmPhuongTien_Click(object sender, EventArgs e)
        {
            frmPhuongTien frm = new frmPhuongTien();
            frm.ShowDialog();
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
            DTO_PhanTrangKH phanTrang = dichVu.loadDSNCCPhanTrang(int.Parse(btnPager.Name), PageSize);
            gridNhaCC.DataSource = phanTrang.dt;
            DataBinding(phanTrang.dt);
            //DataBindingKH(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, int.Parse(btnPager.Name));
        }
        public void loadData()
        {
            DTO_PhanTrangKH phanTrang = dichVu.loadDSNCCPhanTrang(1, PageSize);
            gridNhaCC.DataSource = phanTrang.dt;
            DataBinding(phanTrang.dt);
            //DataBindingKH(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, 1);
        }
        //Tạo class Page để lưu trữ các thuộc tính của Page
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if(txtTenNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSDTNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenNCC = txtTenNCC.Text.ToString();
            string diaChiNCC = txtDiaChiNCC.Text.ToString();
            string SDTNCC = txtSDTNCC.Text.ToString();
            string email = txtEmailNCC.Text.ToString();
            if(dichVu.themNhaCungCap(tenNCC,diaChiNCC,SDTNCC,email))
            {
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if(txtIDNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSDTNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idNhaCungCap = int.Parse(txtIDNCC.Text.ToString());
            string tenNCC = txtTenNCC.Text.ToString();
            string diaChiNCC = txtDiaChiNCC.Text.ToString();
            string SDTNCC = txtSDTNCC.Text.ToString();
            string email = txtEmailNCC.Text.ToString();
            if (dichVu.capNhatNhaCungCap(idNhaCungCap,tenNCC, diaChiNCC, SDTNCC, email))
            {
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtIDNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtEmailNCC.Clear();
            txtSDTNCC.Clear();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (txtIDNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idNCC = int.Parse(txtIDNCC.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kq = dichVu.xoaNhaCungCap(idNCC);
                if (kq == 0)
                {
                    MessageBox.Show("Nhà cung cấp đã từng cung cấp dịch vụ. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (kq == -1)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (kq == 1)
                {
                    loadData();
                }
            }
        }
    }
}
