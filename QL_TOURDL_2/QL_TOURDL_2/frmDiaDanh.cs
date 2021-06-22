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
    public partial class frmDiaDanh : Form
    {
        DAO_DichVu dichVu;
        public frmDiaDanh()
        {
            InitializeComponent();
            dichVu = new DAO_DichVu();
        }
        public void DataBinding(DataTable dt)
        {
            txtIDDiaDanh.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDDiaDanh", true, DataSourceUpdateMode.Never);
            txtIDDiaDanh.DataBindings.Add(b1);

            txtTenDiaDanh.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenDiaDanh", true, DataSourceUpdateMode.Never);
            txtTenDiaDanh.DataBindings.Add(b2);

            txtDiaChiDiaDanh.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChiDiaDanh.DataBindings.Add(b3);

        }
        private void btnThemDiaDanh_Click(object sender, EventArgs e)
        {
            if (txtTenDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenDiaDanh = txtTenDiaDanh.Text;
            string diaChiDiaDanh = txtDiaChiDiaDanh.Text;
            if (dichVu.themDiaDanh(tenDiaDanh, diaChiDiaDanh))
            {
                loadDSDiaDanh();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadDSDiaDanh()
        {
            DataTable dt = new DataTable();
            dt = dichVu.loadDiadanh();
            gridDiaDanh.DataSource = dt;
            DataBinding(dt);
        }

        private void frmDiaDanh_Load(object sender, EventArgs e)
        {
            loadDSDiaDanh();
        }

        private void btnSuaDiaDanh_Click(object sender, EventArgs e)
        {
            if(txtIDDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn địa danh muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChiDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idDiaDanh = int.Parse(txtIDDiaDanh.Text.ToString());
            string tenDiaDanh = txtTenDiaDanh.Text;
            string diaChiDiaDanh = txtDiaChiDiaDanh.Text;
            if (dichVu.capNhatDiaDanh(idDiaDanh,tenDiaDanh, diaChiDiaDanh))
            {
                loadDSDiaDanh();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaDiaDanh_Click(object sender, EventArgs e)
        {
            if (txtIDDiaDanh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn địa danh muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idDiaDanh = int.Parse(txtIDDiaDanh.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa địa danh?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kq = dichVu.xoaDiaDanh(idDiaDanh);
                if (kq == 0)
                {
                    MessageBox.Show("Địa danh đã được sử dụng. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (kq == -1)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (kq == 1)
                {
                    loadDSDiaDanh();
                }
            }
        }

        private void btnRefreshDD_Click(object sender, EventArgs e)
        {
            txtIDDiaDanh.Clear();
            txtDiaChiDiaDanh.Clear();
            txtTenDiaDanh.Clear();
        }
    }
}
