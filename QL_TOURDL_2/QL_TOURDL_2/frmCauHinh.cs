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
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenServer.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenDB.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPass.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string conn =  "Data Source="+txtTenServer.Text.Trim()+";Initial Catalog="+txtTenDB.Text.Trim()+";User id="+txtUserName.Text.Trim()+";Password="+txtPass.Text.Trim()+";";
            Properties.Settings.Default.ConectionString = conn;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
