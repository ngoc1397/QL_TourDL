using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmTaiKhoan : Form
    {
        DTO_NguoiDung nguoiDung;
        public frmTaiKhoan(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenHienThi.Text = nguoiDung.TenHienthi;
            txtTenDN.Text = nguoiDung.TenDangNhap;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO_NguoiDung dAO_NguoiDung = new DAO_NguoiDung();
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản", "Xác nhận", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                int kq = dAO_NguoiDung.sp_KiemTraDangNhap(txtTenDN.Text, GetMd5Hash(txtMatKhauCu.Text));
                if (kq == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo");
                    return;
                }
                if (txtMatKhau.Text.Equals(txtNhapLaiMatKhau.Text) == false)
                {
                    MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo");
                    return;
                }
                else
                {
                    if(dAO_NguoiDung.capNhatTaiKhoan(txtTenDN.Text, GetMd5Hash(txtNhapLaiMatKhau.Text.ToString())))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
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
