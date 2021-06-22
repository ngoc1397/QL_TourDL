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
    public partial class frmPhuongTien : Form
    {
        DAO_DichVu dichVu;
        public frmPhuongTien()
        {
            InitializeComponent();
            dichVu = new DAO_DichVu();
        }
        public void loadDSPhuongTien()
        {
            DataTable dt = new DataTable();
            dt = dichVu.loadPhuongTien();
            gridPhuongTien.DataSource = dt;
            DataBinding(dt);
        }
        public void DataBinding(DataTable dt)
        {
            txtIDPT.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "IDPhuongTien", true, DataSourceUpdateMode.Never);
            txtIDPT.DataBindings.Add(b1);

            txtTenPhuongTien.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "TenPhuongTien", true, DataSourceUpdateMode.Never);
            txtTenPhuongTien.DataBindings.Add(b2);

            txtSoCho.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "SoCho", true, DataSourceUpdateMode.Never);
            txtSoCho.DataBindings.Add(b3);

        }
        private void btnThemPhuongTien_Click(object sender, EventArgs e)
        {
            if (txtTenPhuongTien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenPT = txtTenPhuongTien.Text;
            int soCho = int.Parse(txtSoCho.Value.ToString());
            if (dichVu.themPhuongTien(tenPT,soCho))
            {
                loadDSPhuongTien();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPhuongTien_Load(object sender, EventArgs e)
        {
            loadDSPhuongTien();
        }

        private void btnRefreshPT_Click(object sender, EventArgs e)
        {
            txtIDPT.Clear();
            txtTenPhuongTien.Clear();
           
        }

        private void btnSuaPhuongTien_Click(object sender, EventArgs e)
        {
            if (txtIDPT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phương tiện muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenPhuongTien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idPhuongTien = int.Parse(txtIDPT.Text.ToString());
            string tenPhuongTien = txtTenPhuongTien.Text;
            int soCho = int.Parse(txtSoCho.Value.ToString());
            if (dichVu.capNhatPhuongTien(idPhuongTien,tenPhuongTien,soCho))
            {
                loadDSPhuongTien();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaPhuongTien_Click(object sender, EventArgs e)
        {
            if (txtIDPT.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phương tiện muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idphuongTien = int.Parse(txtIDPT.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phương tiện?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kq = dichVu.xoaPhuongTien(idphuongTien);
                if (kq == 0)
                {
                    MessageBox.Show("Phương tiện đã được sử dụng. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (kq == -1)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (kq == 1)
                {
                    loadDSPhuongTien();
                }
            }
        }
    }
}
