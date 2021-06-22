using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QL_TOURDL_2
{
    public partial class frmBanve : Form
    {
        int PageSize = 20;
        private DAO_KhachHang khachHang;
        private DAO_Tour tour;
        private DAO_Ve ve;
        private DTO_NguoiDung nguoiDung;
        public frmBanve(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            tour = new DAO_Tour();
            ve = new DAO_Ve();
            this.nguoiDung = nguoiDung;
            khachHang = new DAO_KhachHang();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lstVe.Rows.Count == 1)
            {
                MessageBox.Show("Có vé nào đâu mà thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Chưa có thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtIDTourHT.Text.Length == 0)
            {
                MessageBox.Show("Chưa có thông tin tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán và lưu vé vào hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idTour = int.Parse(txtIDTourHT.Text.ToString());
                int idKhachHang = int.Parse(txtMaKH.Text.ToString());
                string tenVe = txtTenTourHT.Text.ToString();
                int idNhanVien = nguoiDung.IdNhanVien;
                int dem = 0;
                for (int i = 0; i < lstVe.RowCount - 1; i++)
                {
                    int slVe = int.Parse(lstVe.Rows[i].Cells[2].Value.ToString());
                    int idLoaiVe = int.Parse(lstVe.Rows[i].Cells[0].Value.ToString());
                    if(ve.nhapVe(idTour, idKhachHang, tenVe, idLoaiVe, slVe, idNhanVien))
                    {
                        dem++;
                    }
                }
                if(dem == (lstVe.RowCount -1))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTourCB();
                    lstVe.Rows.Clear();
                    txtTenTourHT.Clear();
                    txtIDTourHT.Clear();
                    txtGiaTourHT.Clear();
                    txtDonGiaHT.Clear();
                    txtNgayDiHT.Clear();
                    txtNgayVeHT.Clear();
                    txtSLVeHT.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmBanve_Load(object sender, EventArgs e)
        {
            //loadDSKH();
            loadData();
            loadTourCB();
            loadLoaiVe();
            gridDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourLenKeHoach.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourLenKeHoach.EnableHeadersVisualStyles = false;
            gridDSKH.EnableHeadersVisualStyles = false;
        }
        public void loadDSKH()
        {
            DataTable dt = new DataTable();
            dt = khachHang.loadDSKH();
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
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
        public void loadTourCB()
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourChuanBi();
            gridTourLenKeHoach.DataSource = dt;
            gridTourLenKeHoach.Columns["TenTrangThai"].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }

        public void loadTourTimKiemTen(string tenTour)
        {
            DataTable dt = new DataTable();
            dt = tour.timKiemTourTheoTenBanVe(tenTour);
            gridTourLenKeHoach.DataSource = dt;
            gridTourLenKeHoach.Columns["TenTrangThai"].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }
        public void loadLoaiVe()
        {
            DataTable dt = new DataTable();
            dt = ve.loadLoaiVe();
            cboLoaiVe.DataSource = dt;
            cboLoaiVeIn.DataSource = dt;
            cboLoaiVe.DisplayMember = "TenLoaiVe";
            cboLoaiVe.ValueMember = "IDLoaiVe";
            cboLoaiVeIn.DisplayMember = "TenLoaiVe";
            cboLoaiVeIn.ValueMember = "IDLoaiVe";
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
            Binding b7 = new Binding("Text", dt, "NgayDi", true, DataSourceUpdateMode.Never);
            txtNgayDiHT.DataBindings.Add(b7);

            txtNgayVeHT.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "NgayVe", true, DataSourceUpdateMode.Never);
            txtNgayVeHT.DataBindings.Add(b8);

            txtDonGiaHT.DataBindings.Clear();
            Binding b9 = new Binding("Text", dt, "DonGiaVe", true, DataSourceUpdateMode.Never);
            txtDonGiaHT.DataBindings.Add(b9);
        }
        public void loadTourIDKH(int idKH)
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourIDKH(idKH);
            gridTourLenKeHoach.DataSource = dt;
            gridTourLenKeHoach.Columns[6].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            DataBindingHT(dt);
        }

        private void gridDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDSKH.CurrentCell.Value.ToString().Length > 0)
            {
                if (gridDSKH.SelectedRows.Count > 0)
                {
                    if (gridDSKH.Rows[gridDSKH.SelectedRows[0].Index].Cells[0].Value == null)
                    {
                        MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int idKh = int.Parse(gridDSKH.Rows[gridDSKH.SelectedRows[0].Index].Cells[0].Value.ToString());
                    loadTourIDKH(idKh);
                }
            }
            else
            {
                loadTourCB();
            }
        }

        private void btnAddVe_Click(object sender, EventArgs e)
        {
            if (txtDonGiaHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tour muốn bán vé", "Thông báo");
                return;
            }
            if (cboLoaiVe.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn loại vé", "Thông báo");
                return;
            }
            if (int.Parse(txtSoVeMua.Value.ToString()) == 0)
            {
                MessageBox.Show("Số phương tiện phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idVe = int.Parse(cboLoaiVe.SelectedValue.ToString());
            string tenVe = cboLoaiVe.Text;
            float donGia = float.Parse(txtDonGiaHT.Text.ToString());
            int sl = int.Parse(txtSoVeMua.Value.ToString());
            int slVeConLai = int.Parse(txtSLVeHT.Text.ToString());
            if (sl > slVeConLai)
            {
                MessageBox.Show("Số vé quá nhiều", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int dem = 0;
            for (int i = 0; i < lstVe.RowCount; i++)
            {
                if (lstVe.Rows[i].Cells[0].Value != null)
                {
                    if (idVe == int.Parse(lstVe.Rows[i].Cells[0].Value.ToString()))
                    {
                        lstVe.Rows[i].Cells["SLVe"].Value = int.Parse(lstVe.Rows[i].Cells["SLVe"].Value.ToString()) + sl;
                        if (idVe == 2)
                        {
                            donGia = donGia * (float)0.7;
                            lstVe.Rows[i].Cells["TT"].Value = (decimal)((donGia) * int.Parse(lstVe.Rows[i].Cells["SLVe"].Value.ToString()));
                        }
                        else
                        {
                            lstVe.Rows[i].Cells["TT"].Value = (decimal)((donGia) * int.Parse(lstVe.Rows[i].Cells["SLVe"].Value.ToString()));
                        }
                        dem++;
                        slVeConLai = slVeConLai - sl;
                        txtSLVeHT.Text = slVeConLai.ToString();
                    }
                }
            }
            if (dem == 0)
            {
                var index = lstVe.Rows.Add();
                lstVe.Rows[index].Cells["IDVe"].Value = idVe;
                lstVe.Rows[index].Cells["TenVe"].Value = tenVe;
                lstVe.Rows[index].Cells["SLVe"].Value = sl;
                if (idVe == 2)
                {
                    donGia = donGia * (float)0.7;
                }
                lstVe.Rows[index].Cells["TT"].Value = (decimal)(donGia * sl);
                slVeConLai = slVeConLai - sl;
                txtSLVeHT.Text = slVeConLai.ToString();
            }
        }

        private void btnRemoveVe_Click(object sender, EventArgs e)
        {
            if (lstVe.SelectedRows.Count > 0)
            {
                if (lstVe.Rows[lstVe.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int soVeConLai = int.Parse(txtSLVeHT.Text.ToString());
                int soVeCongLai = int.Parse(lstVe.Rows[lstVe.SelectedRows[0].Index].Cells[2].Value.ToString());
                soVeConLai += soVeCongLai;
                txtSLVeHT.Text = soVeConLai.ToString();
                lstVe.Rows.RemoveAt(lstVe.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int idKH = int.Parse(txtMaKH.Text.ToString());
            string tenKH = txtTenKH.Text.ToString();
            string diaChi = txtDiaChiKH.Text.ToString();
            string sdt = txtSDTKH.Text.ToString();
            string gioitinh = cboGioiTinhKH.Text.ToString();
            string canCuoc = txtCanCuoc.Text.ToString();
            DTO_KhachHang khachHang = new DTO_KhachHang(idKH, tenKH, diaChi, sdt, canCuoc, gioitinh);
            dt.Columns.Add("ID");
            dt.Columns.Add("TenVe");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("ThanhTien");
            decimal tongTien = 0;
            string tenTour = txtTenTourHT.Text.ToString();
            for (int i = 0; i < lstVe.RowCount - 1; i++)
            {
                DataRow row = dt.NewRow();
                row["ID"] = lstVe.Rows[i].Cells[0].Value;
                row["TenVe"] = lstVe.Rows[i].Cells[1].Value;
                row["SoLuong"] = lstVe.Rows[i].Cells[2].Value;
                row["ThanhTien"] = lstVe.Rows[i].Cells[3].Value;
                dt.Rows.Add(row);
                tongTien += decimal.Parse(lstVe.Rows[i].Cells[3].Value.ToString());
            }
            frmInHoaDon frm = new frmInHoaDon(dt, nguoiDung.TenHienthi, tongTien, tenTour, khachHang);
            frm.Show();
        }

        private void txtIDTourHT_TextChanged(object sender, EventArgs e)
        {
            lstVe.Rows.Clear();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text.ToString().Trim(), "dd/MM/yyyy", null);
            string tenKH = txtTenKH.Text.ToString();
            string SDT = txtSDTKH.Text.ToString();
            string diaChi = txtDiaChiKH.Text.ToString();
            string canCuoc = txtCanCuoc.Text.ToString();
            string gioiTinh = cboGioiTinhKH.Text.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm khách hàng " + txtTenKH.Text.ToString(), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (khachHang.themKhachHang(tenKH, SDT, diaChi, gioiTinh, canCuoc,ngaySinh))
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

        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            RefreshKH();
        }

        private void btnLoadTour_Click(object sender, EventArgs e)
        {
            loadTourCB();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if(txtTimKiemKH.Text.Length == 0)
            {
                loadData();
                return;
            }
            string tenKH = txtTimKiemKH.Text.ToString();
            TimKiemKH(tenKH);
        }
        public void TimKiemKH(string tenKH)
        {
            DataTable dt = new DataTable();
            dt = khachHang.timKiemDSKH(tenKH);
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            if(cboLoaiVeIn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Chưa có thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtIDTourHT.Text.Length == 0)
            {
                MessageBox.Show("Chưa có thông tin tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenVe = txtTenTourHT.Text.ToString();
            string ngayDi = txtNgayDiHT.Text.ToString();
            string ngayVe = txtNgayVeHT.Text.ToString();
            string loaiVe = cboLoaiVeIn.Text.ToString();
            decimal donGia = decimal.Parse(txtDonGiaHT.Text.ToString());
            if(int.Parse(cboLoaiVeIn.SelectedValue.ToString()) == 2)
            {
                donGia = donGia * (decimal)0.7;
            }
            frmInVe frm = new frmInVe(loaiVe, ngayDi, ngayVe, tenVe, donGia);
            frm.Show();
        }

        private void btnTinhTongTien_Click(object sender, EventArgs e)
        {
            decimal tongTien = 0;
            for (int i = 0; i < lstVe.RowCount - 1; i++)
            {
                tongTien += decimal.Parse(lstVe.Rows[i].Cells[3].Value.ToString());
            }

            txtTongThanhToan.Text = String.Format("{0:0,0 VNĐ}", tongTien);
        }

        private void txtTimKiemTour_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTimKiemTour.PerformClick();
            }
        }

        private void btnTimKiemTour_Click(object sender, EventArgs e)
        {
            string tenTour = txtTimKiemTour.Text.ToString();
            loadTourTimKiemTen(tenTour);
        }

        private void txtNgaySinh_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime rs;

            CultureInfo ci = new CultureInfo("en-IE");

            if (!DateTime.TryParseExact(this.txtNgaySinh.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                e.Cancel = true;
            }
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            //Sử dụng đối tượng List để chứa danh sách các trang
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 3;

            //Tính toán để hiển thị các trang.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 3;
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
                pages.Add(new Page { Text = "T.đầu", Value = "1" });
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
                pages.Add(new Page { Text = "T.cuối", Value = pageCount.ToString() });
            }

            //Xóa các nút trên trang.
            pnlDieuHuong.Controls.Clear();

            //Lặp và add các Buttons cho trang.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(90 * count, 5);
                btnPage.Size = new System.Drawing.Size(80, 30);
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

        private void txtTimKiemKH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTimKiemKH.PerformClick();
            }
        }
    }
}
