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

namespace QL_TOURDL_2
{
    public partial class frmKhachSan : Form
    {
        DAO_DichVu dichVu;
        public frmKhachSan()
        {
            InitializeComponent();
            dichVu = new DAO_DichVu();
        }
        public void loadDSKhachSan()
        {
            DataTable dt = new DataTable();
            dt = dichVu.loadKhachSan();
            gridKhachSan.DataSource = dt;
            DataBinding(dt);
        }
        public void DataBinding(DataTable dt)
        {
            txtIDKS.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDKhachSan", true, DataSourceUpdateMode.Never);
            txtIDKS.DataBindings.Add(b1);

            txtTenKhachSan.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenKhachSan", true, DataSourceUpdateMode.Never);
            txtTenKhachSan.DataBindings.Add(b2);

            txtDiaChiKhachSan.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChiKhachSan.DataBindings.Add(b3);

        }
        private void frmKhachSan_Load(object sender, EventArgs e)
        {
            loadDSKhachSan();
        }

        private void btnThemNhaHang_Click(object sender, EventArgs e)
        {
            if (txtTenKhachSan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiKhachSan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenKhachSan = txtTenKhachSan.Text;
            string diaChiKhachSan = txtDiaChiKhachSan.Text;
            if (dichVu.themKhachSan(tenKhachSan, diaChiKhachSan))
            {
                loadDSKhachSan();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshNH_Click(object sender, EventArgs e)
        {
            txtIDKS.Clear();
            txtTenKhachSan.Clear();
            txtDiaChiKhachSan.Clear();
        }

        private void btnSuaNhaHang_Click(object sender, EventArgs e)
        {
            if (txtIDKS.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách sạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenKhachSan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiKhachSan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idKhachSan = int.Parse(txtIDKS.Text.ToString());
            string tenKhachSan = txtTenKhachSan.Text;
            string diaChiKS = txtDiaChiKhachSan.Text;
            if (dichVu.capNhatKhachSan(idKhachSan, tenKhachSan, diaChiKS))
            {
                loadDSKhachSan();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNhaHang_Click(object sender, EventArgs e)
        {
            if (txtIDKS.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn khách sạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idKhachSan = int.Parse(txtIDKS.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách sạn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kq = dichVu.xoaKhachSan(idKhachSan);
                if (kq == 0)
                {
                    MessageBox.Show("Khách sạn đã được sử dụng. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (kq == -1)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (kq == 1)
                {
                    loadDSKhachSan();
                }
            }
        }
    }
}
