using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QL_TOURDL_2
{
    public partial class frmNhanVien : Form
    {
        DAO_NhanVien nhanVien;
        DAO_NguoiDung nguoiDung;
        public frmNhanVien()
        {
            InitializeComponent();
            nhanVien = new DAO_NhanVien();
            nguoiDung = new DAO_NguoiDung();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadDSNhanVien();
            loadCboChucVu();
            loadCboKieuNguoiDung();
        }
        public void loadDSNhanVien()
        {
            DataTable dt = new DataTable();
            dt = nhanVien.loadDSNhanVien();
            gridNhanVien.DataSource = dt;
            DataBindingNV(dt);
        }
        public void loadCboChucVu()
        {
            DataTable dt = nhanVien.loadChucVu();
            cboChucVu.DataSource = dt;
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "IDChucVu";
        }
        public void loadCboKieuNguoiDung()
        {
            DataTable dt = nguoiDung.loadKieuNguoiDung();
            cboKieuNguoiDung.DataSource = dt;
            cboKieuNguoiDung.DisplayMember = "TenKieuNguoiDung";
            cboKieuNguoiDung.ValueMember = "IDKieuNguoiDung";
        }
        public void DataBindingNV(DataTable dt)
        {
            txtIDNhanVien.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDNhanVien", true, DataSourceUpdateMode.Never);
            txtIDNhanVien.DataBindings.Add(b1);

            txtTenNV.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenNhanVien", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Add(b2);

            cboChucVu.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "TenChucVu", true, DataSourceUpdateMode.Never);
            cboChucVu.DataBindings.Add(b3);

            cboGioiTinh.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "GioiTinh", true, DataSourceUpdateMode.Never);
            cboGioiTinh.DataBindings.Add(b4);

            txtNgaySinh.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "NgaySinh", true, DataSourceUpdateMode.Never);
            txtNgaySinh.DataBindings.Add(b5);

            txtSoDienThoai.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add(b6);

            txtDiaChi.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add(b7);

            txtTrangThai.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "TinhTrang", true, DataSourceUpdateMode.Never);
            txtTrangThai.DataBindings.Add(b8);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoDienThoai.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboChucVu.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboGioiTinh.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenNV = txtTenNV.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text.Trim(), "dd/MM/yyyy", null);
            string sdt = txtSoDienThoai.Text.Trim();
            int idChucvu = (int)cboChucVu.SelectedValue;
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên " + txtTenNV.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhanVien.themNhanVien(idChucvu, tenNV, gioiTinh, ngaySinh, sdt, diaChi))
                {
                    loadDSNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoDienThoai.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboChucVu.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboGioiTinh.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idNhanVien = int.Parse(txtIDNhanVien.Text.ToString());
            string tenNV = txtTenNV.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text.Trim(), "dd/MM/yyyy", null);
            string sdt = txtSoDienThoai.Text.Trim();
            int idChucvu = (int)cboChucVu.SelectedValue;
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật nhân viên " + txtTenNV.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhanVien.capNhatNhanVien(idNhanVien, idChucvu, tenNV, gioiTinh, ngaySinh, sdt, diaChi))
                {
                    loadDSNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên muốn cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idNhanVien = int.Parse(txtIDNhanVien.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên " + txtTenNV.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhanVien.xoaNhanVien(idNhanVien))
                {
                    loadDSNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void btnCapTK_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo");
                return;
            }
            if (txtTenDangNhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                return;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo");
                return;
            }
            if (txtXacNhanMK.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải xác nhận mật khẩu", "Thông báo");
                return;
            }
            string tenDN = txtTenDangNhap.Text.ToString();
            string matKhau = txtMatKhau.Text.ToString();
            string xacNhanMatKhau = txtXacNhanMK.Text.ToString();
            int idKieuND = int.Parse(cboKieuNguoiDung.SelectedValue.ToString());
            int idNhanvien = int.Parse(txtIDNhanVien.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn cấp tài khoản "+ cboKieuNguoiDung.SelectedText+" cho nhân viên " + txtTenNV.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (matKhau.Equals(xacNhanMatKhau))
                {
                    int kq = nguoiDung.themTaiKhoan(idKieuND, idNhanvien, tenDN, GetMd5Hash(matKhau));
                    if (kq == 1)
                    {
                        MessageBox.Show("Cấp tài khoản thành công", "Thông báo");
                        return;
                    }
                    if(kq == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo");
                    return;
                }
            }
        }
        public string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
