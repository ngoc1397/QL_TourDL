using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QL_TOURDL_2
{
    public partial class frmCongNo : Form
    {
        int PageSize = 14;
        private DAO_CongNo congNo;
        private DAO_DichVu dichVu;
        private DTO_NguoiDung nguoiDung;
        public frmCongNo(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            congNo = new DAO_CongNo();
            dichVu = new DAO_DichVu();
        }

        private void frmCongNo_Load(object sender, EventArgs e)
        {
            loadData();
            loadCongNo();
            loadCboNhaCC();
            gridCongNo.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridCongNo.EnableHeadersVisualStyles = false;
            gridTourCN.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourCN.EnableHeadersVisualStyles = false;
        }
        public void loadCboNhaCC()
        {
            DataTable dt = new DataTable();
            dt = dichVu.loadNCC();
            cboNhaCungCap.DataSource = dt;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.ValueMember = "IDNhaCungCap";
            cboNhaCungCap.AutoCompleteMode = AutoCompleteMode.Suggest; //Hiện chế độ autocomplete combobox
            cboNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems; //Hiện chế độ autocomplete combobox
        }
        public void loadTourTatCa()
        {
            DataTable dt = new DataTable();
            dt = congNo.loadTourTatCa();
            gridTourCN.DataSource = dt;
            gridTourCN.Columns[3].DefaultCellStyle.ForeColor = Color.Red; //Hiện màu cho column
            gridTourCN.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingHT(dt);
        }
        public void loadCongNo()
        {
            DataTable dt = new DataTable();
            dt = congNo.loadCongNo();
            gridCongNo.DataSource = dt;
            lblTongSo.Text = dt.Rows.Count.ToString();
            gridCongNo.Columns[5].DefaultCellStyle.ForeColor = Color.Crimson;
            gridCongNo.Columns[5].DefaultCellStyle.Font = new Font("Time new Romans", 10,FontStyle.Bold);
            gridCongNo.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            DataBindingCongNo(dt);
        }

        //Binding dữ liệu cho gridview tour
        public void DataBindingHT(DataTable dt)
        {
            txtIDTourCN.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDTour", true, DataSourceUpdateMode.Never);
            txtIDTourCN.DataBindings.Add(b1);

            txtTenTourCN.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenTour", true, DataSourceUpdateMode.Never);
            txtTenTourCN.DataBindings.Add(b2);
        }

        public void DataBindingCongNo(DataTable dt)
        {
            txtIDCongNo.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDCongNo", true, DataSourceUpdateMode.Never);
            txtIDCongNo.DataBindings.Add(b1);

            txtTenNV.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Add(b2);

            txtNCC.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "TenNhaCungCap", true, DataSourceUpdateMode.Never);
            txtNCC.DataBindings.Add(b3);

            txtTenCNHT.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "TenCongNo", true, DataSourceUpdateMode.Never);
            txtTenCNHT.DataBindings.Add(b4);

            txtTrangThai.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "TrinhTrang", true, DataSourceUpdateMode.Never);
            txtTrangThai.DataBindings.Add(b5);

            txtToiHan.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "HanThanhToan", true, DataSourceUpdateMode.Never);
            txtToiHan.DataBindings.Add(b6);

            txtSoTien.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "SoTien", true, DataSourceUpdateMode.Never);
            txtSoTien.DataBindings.Add(b7);

            txtNgayTao.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "NgayTao", true, DataSourceUpdateMode.Never);
            txtNgayTao.DataBindings.Add(b8);
        }

        //bắt sự kiện cell click lên grid view để lòa dữ liệu cho danh sách khách sạn và phương tiện của tour
        private void gridTourCN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//lỗi
            {
                return;
            }
            if (gridTourCN.CurrentCell.Value.ToString().Length > 0)//tránh trường hợp cell bị null
            {
                int idTour = int.Parse(txtIDTourCN.Text.ToString());
                DataTable dt3 = dichVu.loadTourPhuongTien(idTour);
                DataTable dt2 = dichVu.loadTourKhachSan(idTour);
                lstKhachSan.Rows.Clear();
                foreach (DataRow row in dt2.Rows)
                {
                    var index = lstKhachSan.Rows.Add(); // thêm một row mới và lấy ra index của row đó
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

        private void btnAddCN_Click(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtIDTourCN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtToiHanCN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thời gian tới hạn công nợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSoTienCN.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền phải trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTour = int.Parse(txtIDTourCN.Text.ToString());
            int idNcc = int.Parse(cboNhaCungCap.SelectedValue.ToString());
            string tenNCC = cboNhaCungCap.Text;
            string tenCN = txtTenCN.Text;
            DateTime toiHan = DateTime.ParseExact(txtToiHanCN.Text.ToString().Trim(), "dd/MM/yyyy", null); //Parse kiểu string thành datetime
            decimal soTien = decimal.Parse(txtSoTienCN.Text.ToString());
            var index = lstCongNo.Rows.Add();
            lstCongNo.Rows[index].Cells["IDTour"].Value = idTour;
            lstCongNo.Rows[index].Cells["IDNCC"].Value = idNcc;
            lstCongNo.Rows[index].Cells["TenNCC"].Value = tenNCC;
            lstCongNo.Rows[index].Cells["TenCN"].Value = tenCN;
            lstCongNo.Rows[index].Cells["HanTT"].Value = toiHan.Date;
            lstCongNo.Rows[index].Cells["SoTien"].Value = soTien;
        }

        //kiểm tra nhập liệu ngày tháng, nếu nhập sai thì không cho người dùng thao tác cho đến khi nhập đúng
        private void txtToiHanCN_Validating(object sender, CancelEventArgs e)
        {
            DateTime rs;

            CultureInfo ci = new CultureInfo("en-IE");

            if (!DateTime.TryParseExact(this.txtToiHanCN.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                e.Cancel = true;
            }
        }
        //chặn nhập kí tự chữ
        private void txtSoTienCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemCongNo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn lưu công nợ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int dem = 0;
                for (int i = 0; i < lstCongNo.RowCount - 1; i++)
                {
                    int idTour = (int)lstCongNo.Rows[i].Cells[0].Value;
                    int idNhaCC = (int)lstCongNo.Rows[i].Cells[1].Value;
                    int idNhanvien = nguoiDung.IdNhanVien;
                    string tenCongNo = (string)lstCongNo.Rows[i].Cells[3].Value;
                    DateTime hanTT = (DateTime)lstCongNo.Rows[i].Cells[4].Value;
                    decimal soTien = (decimal)lstCongNo.Rows[i].Cells[5].Value;
                    if (congNo.themCongNo(idTour, idNhaCC, idNhanvien, tenCongNo, hanTT, soTien))
                    {
                        dem++;
                    }
                }
                if (dem == lstCongNo.RowCount - 1)
                {
                    loadCongNo();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshCN_Click(object sender, EventArgs e)
        {
            txtTenCN.Clear();
            txtSoTienCN.Clear();
            txtToiHanCN.Clear();
            lstCongNo.Rows.Clear();
        }

        private void btnRemoveCN_Click(object sender, EventArgs e)
        {
            if (lstCongNo.SelectedRows.Count > 0)
            {
                if (lstCongNo.Rows[lstCongNo.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstCongNo.Rows.RemoveAt(lstCongNo.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhanCongNo_Click(object sender, EventArgs e)
        {
            int idCongNo = int.Parse(txtIDCongNo.Text.ToString());
            string trangThai = cboTrangThai.Text.ToString();
            if(congNo.capNhatTrangThaiCN(idCongNo,trangThai))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                loadCongNo();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DTO_PhanTrangKH phanTrang = congNo.loadDSTourCNPhanTrang(int.Parse(btnPager.Name), PageSize);
            gridTourCN.DataSource = phanTrang.dt;
            DataBindingHT(phanTrang.dt);
            HienThiThanhDieuHuong(phanTrang.rowCount, int.Parse(btnPager.Name));
        }
        public void loadData()
        {
            DTO_PhanTrangKH phanTrang = congNo.loadDSTourCNPhanTrang(1, PageSize);
            gridTourCN.DataSource = phanTrang.dt;
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
    }
}
