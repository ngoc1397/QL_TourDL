using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace QL_TOURDL_2
{
    public partial class frmThemTour : Form
    {
        private int PageSize = 20;
        private DAO_DichVu dichVu;
        private DAO_Tour tour;
        private DAO_KhachHang khachHang;
        private DTO_NguoiDung nguoiDung;
        public frmThemTour(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            dichVu = new DAO_DichVu();
            tour = new DAO_Tour();
            khachHang = new DAO_KhachHang();
            this.nguoiDung = nguoiDung;
        }

        private void frmThemTour_Load(object sender, EventArgs e)
        {
            loadCboDiaDanh();
            loadCboKhachSan();
            loadCboPhuongTien();
            loadTourKH();
            loadData();
            txtNgayDiHT.CustomFormat = "dd/MM/yyyy";
            gridDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourYC.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourLenKeHoach.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            gridTourYC.EnableHeadersVisualStyles = false;
            gridDSKH.EnableHeadersVisualStyles = false;
            gridTourLenKeHoach.EnableHeadersVisualStyles = false;
        }
        /// <summary>
        /// Thêm tour trong hệ thống
        /// </summary>

        //load combobox địa danh
        public void loadCboDiaDanh()
        {
            DataTable dt = dichVu.loadDiadanh();
            cboDiaDanhHT.DataSource = dt;
            cboDiaDanhHT.DisplayMember = "TenDiaDanh";
            cboDiaDanhHT.ValueMember = "IDDiaDanh";
            cboDiaDanhHT.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDiaDanhHT.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboDiaDanhYC.DataSource = dt;
            cboDiaDanhYC.DisplayMember = "TenDiaDanh";
            cboDiaDanhYC.ValueMember = "IDDiaDanh";
            cboDiaDanhYC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDiaDanhYC.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //load combobox khách sạn
        public void loadCboKhachSan()
        {
            DataTable dt = dichVu.loadKhachSan();
            cboKhachSanHT.DataSource = dt;
            cboKhachSanHT.DisplayMember = "TenKhachSan";
            cboKhachSanHT.ValueMember = "IDKhachSan";
            cboKhachSanHT.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboKhachSanHT.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboKhachSanYC.DataSource = dt;
            cboKhachSanYC.DisplayMember = "TenKhachSan";
            cboKhachSanYC.ValueMember = "IDKhachSan";
            cboKhachSanYC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboKhachSanYC.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //load combobox phương tiện
        public void loadCboPhuongTien()
        {
            DataTable dt = dichVu.loadPhuongTien();
            cboPhuongTienHT.DataSource = dt;
            cboPhuongTienHT.DisplayMember = "TenPhuongTien";
            cboPhuongTienHT.ValueMember = "IDPhuongTien";
            cboPhuongTienHT.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboPhuongTienHT.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboPhuongTienYC.DataSource = dt;
            cboPhuongTienYC.DisplayMember = "TenPhuongTien";
            cboPhuongTienYC.ValueMember = "IDPhuongTien";
            cboPhuongTienYC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboPhuongTienYC.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //load danh sách tour đang lên kế hoạch
        public void loadTourKH()
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourKeHoach();
            gridTourLenKeHoach.DataSource = dt;
            DataBindingHT(dt);
        }
        //binding data cho gridview tour kế hoạch
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
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Thêm mới địa danh vào danh sách địa danh cho 1 tour
        private void btnAddDiaDanhHT_Click(object sender, EventArgs e)
        {
            if (cboDiaDanhHT.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn địa danh", "Thông báo");
                return;
            }
            int idDiadanh = int.Parse(cboDiaDanhHT.SelectedValue.ToString());
            string tenDiaDanh = cboDiaDanhHT.Text;
            for (int i = 0; i < lstDiaDanh.RowCount; i++)
            {
                if (lstDiaDanh.Rows[i].Cells[0].Value != null)
                {
                    if (idDiadanh == int.Parse(lstDiaDanh.Rows[i].Cells[0].Value.ToString())) //check trùng địa danh đã thêm
                    {
                        MessageBox.Show("Địa danh đã tồn tại");
                        return;
                    }
                }
            }
            var index = lstDiaDanh.Rows.Add();
            lstDiaDanh.Rows[index].Cells["IDDD"].Value = idDiadanh;
            lstDiaDanh.Rows[index].Cells["TenDD"].Value = tenDiaDanh;
        }
        //Thêm mới khách sạn vào danh sách khách sạn cho 1 tour
        private void btnAddKSHT_Click(object sender, EventArgs e)
        {
            if (cboKhachSanHT.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn khách sạn", "Thông báo");
                return;
            }
            int idKhachsan = int.Parse(cboKhachSanHT.SelectedValue.ToString());
            string tenKhachsan = cboKhachSanHT.Text;
            for (int i = 0; i < lstKhachSan.RowCount; i++)
            {
                if (lstKhachSan.Rows[i].Cells[0].Value != null)
                {
                    if (idKhachsan == int.Parse(lstKhachSan.Rows[i].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Khách sạn đã tồn tại");
                        return;
                    }
                }
            }
            var index = lstKhachSan.Rows.Add();
            lstKhachSan.Rows[index].Cells["IDKS"].Value = idKhachsan;
            lstKhachSan.Rows[index].Cells["TenKS"].Value = tenKhachsan;
        }

        //Thêm mới phương tiện vào danh sách phương tiện cho tour
        private void btnAddPTHT_Click(object sender, EventArgs e)
        {
            if (cboPhuongTienHT.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn phương tiện", "Thông báo");
                return;
            }
            if (int.Parse(txtSoChoHT.Value.ToString()) == 0)
            {
                MessageBox.Show("Số phương tiện phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idPt = int.Parse(cboPhuongTienHT.SelectedValue.ToString());
            string tenPt = cboPhuongTienHT.Text;
            int sl = int.Parse(txtSoChoHT.Value.ToString());
            int dem = 0;
            for (int i = 0; i < lstPhuongTien.RowCount; i++)
            {
                if (lstPhuongTien.Rows[i].Cells[0].Value != null)//Check null
                {
                    if (idPt == int.Parse(lstPhuongTien.Rows[i].Cells[0].Value.ToString()))//check trùng
                    {
                        lstPhuongTien.Rows[i].Cells["SL"].Value = int.Parse(lstPhuongTien.Rows[i].Cells["SL"].Value.ToString()) + sl;//nếu trùng thì số lượng cộng thêm
                        dem++;
                    }
                }
            }
            if (dem == 0)
            {
                var index = lstPhuongTien.Rows.Add();
                lstPhuongTien.Rows[index].Cells["IDPT"].Value = idPt;
                lstPhuongTien.Rows[index].Cells["TenPT"].Value = tenPt;
                lstPhuongTien.Rows[index].Cells["SL"].Value = sl;
            }
        }

        private void gridTourLenKeHoach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //int idTour = int.Parse(txtIDTourHT.Text.ToString());
            //lstDiaDanh.DataSource = dichVu.loadTourDiaDanh(idTour);
        }

        private void gridTourLenKeHoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (gridTourLenKeHoach.CurrentCell.Value.ToString().Length > 0)
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

        private void btnThemTourHT_Click(object sender, EventArgs e)
        {
            if (txtTenTourHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGiaTourHT.Text.Length == 0 && txtDonGiaHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá tour hoặc đơn giá từng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSLVeHT.Value.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayDiHT.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayVeHT.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày về", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSLVeHT.Value.ToString()) == 0)
            {
                MessageBox.Show("Số vé phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenTour = txtTenTourHT.Text.ToString();
            DateTime ngayDi = txtNgayDiHT.Value.Date;
            DateTime ngayVe = txtNgayVeHT.Value.Date;
            DateTime today = DateTime.Now;
            if(ngayDi < today)
            {
                MessageBox.Show("Ngày về phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ngayVe < today)
            {
                MessageBox.Show("Ngày đi phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string moTa = txtMoTaHT.Text.ToString();
            int soLuongVe = int.Parse(txtSLVeHT.Value.ToString());
            float giaTour = 0;
            float giaVe = 0;
            if (txtGiaTourHT.Text.Length == 0 || txtDonGiaHT.Text.Length == 0)
            {
                if (txtGiaTourHT.Text.Length == 0)
                {
                    giaVe = float.Parse(txtDonGiaHT.Text.ToString());
                    giaTour = giaVe * soLuongVe;
                }
                if (txtDonGiaHT.Text.Length == 0)
                {
                    giaTour = float.Parse(txtGiaTourHT.Text.ToString());
                    giaVe = giaTour / soLuongVe;
                }
            }
            else
            {
                giaVe = float.Parse(txtDonGiaHT.Text.ToString());
                giaTour = float.Parse(txtGiaTourHT.Text.ToString());
            }
            if (tour.themTour(tenTour, giaTour, soLuongVe, ngayDi, ngayVe, moTa, nguoiDung.IdNhanVien, giaVe))
            {
                int id = tour.layMaxIDTourNV(nguoiDung.IdNhanVien);
                for (int i = 0; i < lstDiaDanh.RowCount - 1; i++)
                {
                    int idDiaDanh = int.Parse(lstDiaDanh.Rows[i].Cells[0].Value.ToString());
                    tour.themTourDiaDanh(id, idDiaDanh);
                }
                for (int i = 0; i < lstKhachSan.RowCount - 1; i++)
                {
                    int idKhachSan = int.Parse(lstKhachSan.Rows[i].Cells[0].Value.ToString());
                    tour.themTourKhachSan(id, idKhachSan);
                }
                for (int i = 0; i < lstPhuongTien.RowCount - 1; i++)
                {
                    int idPhuongtien = int.Parse(lstPhuongTien.Rows[i].Cells[0].Value.ToString());
                    int Sl = int.Parse(lstPhuongTien.Rows[i].Cells[2].Value.ToString());
                    tour.themTourPhuongTien(id, idPhuongtien, Sl);
                }
                MessageBox.Show("Thêm thành công");
                loadTourKH();
            }
        }

        private void btnRemoveDDHT_Click(object sender, EventArgs e)
        {
            if (lstDiaDanh.SelectedRows.Count > 0)
            {
                if (lstDiaDanh.Rows[lstDiaDanh.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstDiaDanh.Rows.RemoveAt(lstDiaDanh.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveKSHT_Click(object sender, EventArgs e)
        {
            if (lstKhachSan.SelectedRows.Count > 0)
            {
                if (lstKhachSan.Rows[lstKhachSan.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstKhachSan.Rows.RemoveAt(lstKhachSan.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemovePTHT_Click(object sender, EventArgs e)
        {
            if (lstPhuongTien.SelectedRows.Count > 0)
            {
                if (lstPhuongTien.Rows[lstPhuongTien.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstPhuongTien.Rows.RemoveAt(lstPhuongTien.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyTourHT_Click(object sender, EventArgs e)
        {
            if (txtIDTourHT.Text.Length == 0)
            {
                MessageBox.Show("Hãy tour bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idtour = int.Parse(txtIDTourHT.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tour?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tour.huyTour(idtour))
                {
                    loadTourKH();
                    txtIDTourHT.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReFreshHT_Click(object sender, EventArgs e)
        {
            txtTenTourHT.Clear();
            txtMoTaHT.Clear();
            lstDiaDanh.Rows.Clear();
            lstKhachSan.Rows.Clear();
            lstPhuongTien.Rows.Clear();
            txtGiaTourHT.Clear();
            txtDonGiaHT.Clear();
        }

        private void btnSuaHT_Click(object sender, EventArgs e)
        {
            if (txtIDTourHT.Text.Length == 0)
            {
                MessageBox.Show("Hãy chọn tour muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenTourHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGiaTourHT.Text.Length == 0 && txtDonGiaHT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá tour hoặc đơn giá từng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSLVeHT.Value.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayDiHT.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayVeHT.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày về", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSLVeHT.Value.ToString()) == 0)
            {
                MessageBox.Show("Số vé phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(txtIDTourHT.Text.ToString());
            string tenTour = txtTenTourHT.Text.ToString();
            DateTime ngayDi = txtNgayDiHT.Value.Date;
            DateTime ngayVe = txtNgayVeHT.Value.Date;
            string moTa = txtMoTaHT.Text.ToString();
            int soLuongVe = int.Parse(txtSLVeHT.Value.ToString());
            float giaTour = 0;
            float giaVe = 0;
            if (txtGiaTourHT.Text.Length == 0 || txtDonGiaHT.Text.Length == 0)
            {
                if (txtGiaTourHT.Text.Length == 0)
                {
                    giaVe = float.Parse(txtDonGiaHT.Text.ToString());
                    giaTour = giaVe * soLuongVe;
                }
                if (txtDonGiaHT.Text.Length == 0)
                {
                    giaTour = float.Parse(txtGiaTourHT.Text.ToString());
                    giaVe = giaTour / soLuongVe;
                }
            }
            else
            {
                giaVe = float.Parse(txtDonGiaHT.Text.ToString());
                giaTour = float.Parse(txtGiaTourHT.Text.ToString());
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật tour?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tour.capNhatTour(id, tenTour, giaTour, soLuongVe, ngayDi, ngayVe, moTa, nguoiDung.IdNhanVien, giaVe))
                {
                    if (dichVu.xoaTourDiaDanh(id))
                    {
                        for (int i = 0; i < lstDiaDanh.RowCount - 1; i++)
                        {
                            int idDiaDanh = int.Parse(lstDiaDanh.Rows[i].Cells[0].Value.ToString());
                            tour.themTourDiaDanh(id, idDiaDanh);
                        }
                    }
                    if (dichVu.xoaTourKhachSan(id))
                    {
                        for (int i = 0; i < lstKhachSan.RowCount - 1; i++)
                        {
                            int idKhachSan = int.Parse(lstKhachSan.Rows[i].Cells[0].Value.ToString());
                            tour.themTourKhachSan(id, idKhachSan);
                        }
                    }
                    if (dichVu.xoaTourPhuongTien(id))
                    {
                        for (int i = 0; i < lstPhuongTien.RowCount - 1; i++)
                        {
                            int idPhuongtien = int.Parse(lstPhuongTien.Rows[i].Cells[0].Value.ToString());
                            int Sl = int.Parse(lstPhuongTien.Rows[i].Cells[2].Value.ToString());
                            tour.themTourPhuongTien(id, idPhuongtien, Sl);
                        }
                    }
                    MessageBox.Show("Cập nhật thành công");
                    loadTourKH();
                }
            }
        }
        //Code về thêm tour theo yêu cầu khách hàng
        public void loadDSKH()
        {
            DataTable dt = new DataTable();
            dt = khachHang.loadDSKH();
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
        }
        public void loadTourIDKH(int idKH)
        {
            DataTable dt = new DataTable();
            dt = tour.loadTourIDKH(idKH);
            gridTourYC.DataSource = dt;
            gridTourYC.Columns[6].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            DataBindingYC(dt);
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
        public void DataBindingYC(DataTable dt)
        {
            txtIDYC.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDTour", true, DataSourceUpdateMode.Never);
            txtIDYC.DataBindings.Add(b1);

            txtTenTourYC.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenTour", true, DataSourceUpdateMode.Never);
            txtTenTourYC.DataBindings.Add(b2);

            txtGiaTourYC.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "GiaTour", true, DataSourceUpdateMode.Never);
            txtGiaTourYC.DataBindings.Add(b3);

            txtSLVeYC.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "SoLuong", true, DataSourceUpdateMode.Never);
            txtSLVeYC.DataBindings.Add(b4);

            txtNgayDiYC.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "NgayDi", true, DataSourceUpdateMode.Never);
            txtNgayDiYC.DataBindings.Add(b5);

            txtNgayVeYC.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "NgayVe", true, DataSourceUpdateMode.Never);
            txtNgayVeYC.DataBindings.Add(b6);

            txtMoTaYC.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "MoTa", true, DataSourceUpdateMode.Never);
            txtMoTaYC.DataBindings.Add(b7);

            txtDonGiaYC.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "DonGiaVe", true, DataSourceUpdateMode.Never);
            txtDonGiaYC.DataBindings.Add(b8);

            txtGhiChuYC.DataBindings.Clear();
            Binding b9 = new Binding("Text", dt, "GhiChu", true, DataSourceUpdateMode.Never);
            txtGhiChuYC.DataBindings.Add(b9);
        }

        private void gridTourYC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (gridTourYC.CurrentCell.Value.ToString().Length > 0)
            {
                lstDiaDanhYC.Rows.Clear();
                int idTour = int.Parse(txtIDYC.Text.ToString());
                DataTable dt1 = dichVu.loadTourDiaDanh(idTour);
                DataTable dt3 = dichVu.loadTourPhuongTien(idTour);
                DataTable dt2 = dichVu.loadTourKhachSan(idTour);
                foreach (DataRow row in dt1.Rows)
                {
                    var index = lstDiaDanhYC.Rows.Add();
                    lstDiaDanhYC.Rows[index].Cells["IDDDYC"].Value = row["IDDiaDanh"];
                    lstDiaDanhYC.Rows[index].Cells["TenDDYC"].Value = row["TenDiaDanh"];
                }
                lstKhachSanYC.Rows.Clear();
                foreach (DataRow row in dt2.Rows)
                {
                    var index = lstKhachSanYC.Rows.Add();
                    lstKhachSanYC.Rows[index].Cells["IDKSYC"].Value = row["IDKhachSan"];
                    lstKhachSanYC.Rows[index].Cells["TenKSYC"].Value = row["TenKhachSan"];
                }
                lstPhuongTienYC.Rows.Clear();
                foreach (DataRow rows in dt3.Rows)
                {
                    var index = lstPhuongTienYC.Rows.Add();
                    lstPhuongTienYC.Rows[index].Cells["IDPTYC"].Value = rows["IDPhuongTien"];
                    lstPhuongTienYC.Rows[index].Cells["TenPTYC"].Value = rows["TenPhuongTien"];
                    lstPhuongTienYC.Rows[index].Cells["SLYC"].Value = rows["SoLuong"];
                }
            }
        }

        private void btnAddDDYC_Click(object sender, EventArgs e)
        {
            if (cboDiaDanhYC.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn địa danh", "Thông báo");
                return;
            }
            int idDiadanh = int.Parse(cboDiaDanhYC.SelectedValue.ToString());
            string tenDiaDanh = cboDiaDanhYC.Text;
            for (int i = 0; i < lstDiaDanhYC.RowCount; i++)
            {
                if (lstDiaDanhYC.Rows[i].Cells[0].Value != null)
                {
                    if (idDiadanh == int.Parse(lstDiaDanhYC.Rows[i].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Địa danh đã tồn tại");
                        return;
                    }
                }
            }
            var index = lstDiaDanhYC.Rows.Add();
            lstDiaDanhYC.Rows[index].Cells["IDDDYC"].Value = idDiadanh;
            lstDiaDanhYC.Rows[index].Cells["TenDDYC"].Value = tenDiaDanh;
        }

        private void btnAddKSYC_Click(object sender, EventArgs e)
        {
            if (cboKhachSanYC.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn khách sạn", "Thông báo");
                return;
            }
            int idKhachsan = int.Parse(cboKhachSanYC.SelectedValue.ToString());
            string tenKhachsan = cboKhachSanYC.Text;
            for (int i = 0; i < lstKhachSanYC.RowCount; i++)
            {
                if (lstKhachSanYC.Rows[i].Cells[0].Value != null)
                {
                    if (idKhachsan == int.Parse(lstKhachSanYC.Rows[i].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Khách sạn đã tồn tại");
                        return;
                    }
                }
            }
            var index = lstKhachSanYC.Rows.Add();
            lstKhachSanYC.Rows[index].Cells["IDKSYC"].Value = idKhachsan;
            lstKhachSanYC.Rows[index].Cells["TenKSYC"].Value = tenKhachsan;
        }

        private void btnAddPTYC_Click(object sender, EventArgs e)
        {
            if (cboPhuongTienYC.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn phương tiện", "Thông báo");
                return;
            }
            if (int.Parse(txtSoChoYC.Value.ToString()) == 0)
            {
                MessageBox.Show("Số phương tiện phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idPt = int.Parse(cboPhuongTienYC.SelectedValue.ToString());
            string tenPt = cboPhuongTienYC.Text;
            int sl = int.Parse(txtSoChoYC.Value.ToString());
            int dem = 0;
            for (int i = 0; i < lstPhuongTienYC.RowCount; i++)
            {
                if (lstPhuongTienYC.Rows[i].Cells[0].Value != null)
                {
                    if (idPt == int.Parse(lstPhuongTienYC.Rows[i].Cells[0].Value.ToString()))
                    {
                        lstPhuongTienYC.Rows[i].Cells["SLYC"].Value = int.Parse(lstPhuongTienYC.Rows[i].Cells["SLYC"].Value.ToString()) + sl;
                        dem++;
                    }
                }
            }
            if (dem == 0)
            {
                var index = lstPhuongTienYC.Rows.Add();
                lstPhuongTienYC.Rows[index].Cells["IDPTYC"].Value = idPt;
                lstPhuongTienYC.Rows[index].Cells["TenPTYC"].Value = tenPt;
                lstPhuongTienYC.Rows[index].Cells["SLYC"].Value = sl;
            }
        }

        private void btnRemoveDDYC_Click(object sender, EventArgs e)
        {
            if (lstDiaDanhYC.SelectedRows.Count > 0)
            {
                if (lstDiaDanhYC.Rows[lstDiaDanhYC.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstDiaDanhYC.Rows.RemoveAt(lstDiaDanhYC.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveKSYC_Click(object sender, EventArgs e)
        {
            if (lstKhachSanYC.SelectedRows.Count > 0)
            {
                if (lstKhachSanYC.Rows[lstKhachSanYC.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstKhachSanYC.Rows.RemoveAt(lstKhachSanYC.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemovPTYC_Click(object sender, EventArgs e)
        {
            if (lstPhuongTienYC.SelectedRows.Count > 0)
            {
                if (lstPhuongTienYC.Rows[lstPhuongTienYC.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    MessageBox.Show("Dòng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstPhuongTienYC.Rows.RemoveAt(lstPhuongTienYC.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (txtTimKiemKH.Text.Length == 0)
            {
                loadData();
                return;
            }
            string tenKH = txtTimKiemKH.Text.ToString();
            DataTable dt = new DataTable();
            dt = khachHang.timKiemDSKH(tenKH);
            gridDSKH.DataSource = dt;
            DataBindingKH(dt);
        }

        private void btnThemTourYC_Click(object sender, EventArgs e)
        {
            if (txtTenTourYC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGiaTourYC.Text.Length == 0 && txtDonGiaYC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá tour hoặc đơn giá từng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSLVeYC.Value.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayDiYC.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayVeYC.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày về", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSLVeYC.Value.ToString()) == 0)
            {
                MessageBox.Show("Số vé phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách hàng muốn thêm tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenTour = txtTenTourYC.Text.ToString();
            DateTime ngayDi = txtNgayDiYC.Value.Date;
            DateTime ngayVe = txtNgayVeYC.Value.Date;
            DateTime today = DateTime.Now;
            if (ngayDi < today)
            {
                MessageBox.Show("Ngày về phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ngayVe < today)
            {
                MessageBox.Show("Ngày đi phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string moTa = txtMoTaYC.Text.ToString();
            int soLuongVe = int.Parse(txtSLVeYC.Value.ToString());
            float giaTour = 0;
            float giaVe = 0;
            if (txtGiaTourYC.Text.Length == 0 || txtDonGiaYC.Text.Length == 0)
            {
                if (txtGiaTourYC.Text.Length == 0)
                {
                    giaVe = float.Parse(txtDonGiaYC.Text.ToString());
                    giaTour = giaVe * soLuongVe;
                }
                if (txtDonGiaYC.Text.Length == 0)
                {
                    giaTour = float.Parse(txtGiaTourYC.Text.ToString());
                    giaVe = giaTour / soLuongVe;
                }
            }
            else
            {
                giaVe = float.Parse(txtDonGiaYC.Text.ToString());
                giaTour = float.Parse(txtGiaTourYC.Text.ToString());
            }
            if (tour.themTour(tenTour, giaTour, soLuongVe, ngayDi, ngayVe, moTa, nguoiDung.IdNhanVien, giaVe))
            {
                int id = tour.layMaxIDTourNV(nguoiDung.IdNhanVien);
                for (int i = 0; i < lstDiaDanhYC.RowCount - 1; i++)
                {
                    int idDiaDanh = int.Parse(lstDiaDanhYC.Rows[i].Cells[0].Value.ToString());
                    tour.themTourDiaDanh(id, idDiaDanh);
                }
                for (int i = 0; i < lstKhachSanYC.RowCount - 1; i++)
                {
                    int idKhachSan = int.Parse(lstKhachSanYC.Rows[i].Cells[0].Value.ToString());
                    tour.themTourKhachSan(id, idKhachSan);
                }
                for (int i = 0; i < lstPhuongTienYC.RowCount - 1; i++)
                {
                    int idPhuongtien = int.Parse(lstPhuongTienYC.Rows[i].Cells[0].Value.ToString());
                    int Sl = int.Parse(lstPhuongTienYC.Rows[i].Cells[2].Value.ToString());
                    tour.themTourPhuongTien(id, idPhuongtien, Sl);
                }
                int idKH = int.Parse(txtMaKH.Text.ToString());
                if (tour.ThemTourKH(id, idKH, txtGhiChuYC.Text.ToString()))
                {
                    MessageBox.Show("Thêm thành công");
                    loadTourIDKH(idKH);
                }
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
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
                loadTourKH();
            }
        }
        public void RefreshTourKH()
        {
            txtTenTourYC.Clear();
            txtMoTaYC.Clear();
            lstDiaDanhYC.Rows.Clear();
            lstKhachSanYC.Rows.Clear();
            lstPhuongTienYC.Rows.Clear();
            txtGiaTourYC.Clear();
            txtDonGiaYC.Clear();
        }
        public void RefreshKH()
        {
            txtTenKH.Clear();
            txtMaKH.Clear();
            txtSDTKH.Clear();
            txtCanCuoc.Clear();
            txtDiaChiKH.Clear();
        }

        private void btnRefreshYC_Click(object sender, EventArgs e)
        {
            RefreshTourKH();
        }

        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            RefreshKH();
        }

        private void btnSuaTourYC_Click(object sender, EventArgs e)
        {
            if (txtIDYC.Text.Length == 0)
            {
                MessageBox.Show("Hãy chọn tour muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenTourYC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGiaTourYC.Text.Length == 0 && txtDonGiaYC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá tour hoặc đơn giá từng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSLVeYC.Value.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayDiYC.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNgayVeYC.Value == null)
            {
                MessageBox.Show("Bạn phải chọn ngày về", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSLVeYC.Value.ToString()) == 0)
            {
                MessageBox.Show("Số vé phải từ 1 trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách hàng muốn thêm tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = int.Parse(txtIDYC.Text.ToString());
            string tenTour = txtTenTourYC.Text.ToString();
            DateTime ngayDi = txtNgayDiYC.Value.Date;
            DateTime ngayVe = txtNgayVeYC.Value.Date;
            string moTa = txtMoTaYC.Text.ToString();
            int soLuongVe = int.Parse(txtSLVeYC.Value.ToString());
            float giaTour = 0;
            float giaVe = 0;
            if (txtGiaTourYC.Text.Length == 0 || txtDonGiaYC.Text.Length == 0)
            {
                if (txtGiaTourYC.Text.Length == 0)
                {
                    giaVe = float.Parse(txtDonGiaYC.Text.ToString());
                    giaTour = giaVe * soLuongVe;
                }
                if (txtDonGiaYC.Text.Length == 0)
                {
                    giaTour = float.Parse(txtGiaTourYC.Text.ToString());
                    giaVe = giaTour / soLuongVe;
                }
            }
            else
            {
                giaVe = float.Parse(txtDonGiaYC.Text.ToString());
                giaTour = float.Parse(txtGiaTourYC.Text.ToString());
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật tour?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tour.capNhatTour(id, tenTour, giaTour, soLuongVe, ngayDi, ngayVe, moTa, nguoiDung.IdNhanVien, giaVe))
                {
                    if (dichVu.xoaTourDiaDanh(id))
                    {
                        for (int i = 0; i < lstDiaDanhYC.RowCount - 1; i++)
                        {
                            int idDiaDanh = int.Parse(lstDiaDanhYC.Rows[i].Cells[0].Value.ToString());
                            tour.themTourDiaDanh(id, idDiaDanh);
                        }
                    }
                    if (dichVu.xoaTourKhachSan(id))
                    {
                        for (int i = 0; i < lstKhachSanYC.RowCount - 1; i++)
                        {
                            int idKhachSan = int.Parse(lstKhachSanYC.Rows[i].Cells[0].Value.ToString());
                            tour.themTourKhachSan(id, idKhachSan);
                        }
                    }
                    if (dichVu.xoaTourPhuongTien(id))
                    {
                        for (int i = 0; i < lstPhuongTienYC.RowCount - 1; i++)
                        {
                            int idPhuongtien = int.Parse(lstPhuongTienYC.Rows[i].Cells[0].Value.ToString());
                            int Sl = int.Parse(lstPhuongTienYC.Rows[i].Cells[2].Value.ToString());
                            tour.themTourPhuongTien(id, idPhuongtien, Sl);
                        }
                    }
                    int idKH = int.Parse(txtMaKH.Text.ToString());
                    if (tour.capNhatTourKH(id, idKH, txtGhiChuYC.Text.ToString()))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        loadTourIDKH(idKH);
                    }
                }
            }
        }

        private void btnHuyTourYC_Click(object sender, EventArgs e)
        {
            if (txtIDYC.Text.Length == 0)
            {
                MessageBox.Show("Hãy tour bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách hàng muốn thêm tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idtour = int.Parse(txtIDYC.Text.ToString());
            int idKH = int.Parse(txtMaKH.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tour?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tour.huyTour(idtour))
                {
                    loadTourIDKH(idKH);
                    txtIDTourHT.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtGiaTourYC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGiaYC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaTourHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGiaHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
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
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (khachHang.themKhachHang(tenKH, SDT, diaChi, gioiTinh, canCuoc, ngaySinh))
                {
                    loadDSKH();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1; endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
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
            gridDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.LightCyan;
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
