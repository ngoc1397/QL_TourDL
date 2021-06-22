using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
namespace QL_TOURDL_2
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SQLDatabase.ConnectionString = Properties.Settings.Default.ConectionString;
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                SQLDatabase.OpenConnection(conn);
            }
            catch { MessageBox.Show("Không thể kết nối đến máy chủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);return; }
            finally { SQLDatabase.CloseConnection(conn); }
            if (txtTenDN.Text == String.Empty)
            {
                lblValidate.Text = "Bạn phải nhập tên đăng nhập";
                return;
            }
            if (txtMatKhau.Text == String.Empty)
            {
                lblValidate.Text = "Bạn phải nhập mật khẩu";
                return;
            }
            try
            {
                string userName = "";
                string passWord = "";
                userName = txtTenDN.Text;
                passWord = GetMd5Hash(txtMatKhau.Text.Trim().ToString());
                DAO_NguoiDung nguoiDung = new DAO_NguoiDung();
                int kqDN = nguoiDung.sp_KiemTraDangNhap(userName, passWord);
                if (kqDN == 1)
                {
                    int loaiTK = nguoiDung.kiemTraLoaiTaiKhoan(userName);
                    DTO_NguoiDung ND = nguoiDung.layNguoiDung(userName, passWord);
                    frmMain frm = new frmMain(loaiTK,ND);
                    if (ckbNhoMK.Checked == true)
                    {
                        Properties.Settings.Default.Username = userName;
                        Properties.Settings.Default.Password = txtMatKhau.Text;
                        Properties.Settings.Default.Save();
                    }
                    if (ckbNhoMK.Checked == false)
                    {
                        Properties.Settings.Default.Username = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                    
                }
                else

                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Thông báo");
                    txtTenDN.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username.Length > 0 && Properties.Settings.Default.Password.Length > 0)
            {
                txtTenDN.Text = Properties.Settings.Default.Username;
                txtMatKhau.Text = Properties.Settings.Default.Password;
            }
        }
        public string GetMd5Hash( string input)
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (ckbNhoMK.Checked == false)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
            Application.Exit();
        }

        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            frmCauHinh frm = new frmCauHinh();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
