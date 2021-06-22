using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class DAO_DichVu
    {
        SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadDiadanh()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayDiaDanh", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadKhachSan()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayKhachSan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadPhuongTien()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayPhuongTien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadTourDiaDanh(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiTour_DiaDanh", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = new SqlParameter("@IdTour", SqlDbType.Int);
            par.Value = idTour;
            cmd.Parameters.Add(par);
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadTourKhachSan(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiTour_KhachSan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = new SqlParameter("@idTour", SqlDbType.Int);
            par.Value = idTour;
            cmd.Parameters.Add(par);
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadTourPhuongTien(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiTour_PhuongTien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = new SqlParameter("@idTour", SqlDbType.Int);
            par.Value = idTour;
            cmd.Parameters.Add(par);
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public bool xoaTourDiaDanh(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_XoaTourDiaDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idTour", SqlDbType.Int);
                par1.Value = idTour;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool xoaTourKhachSan(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_XoaTourKhachSan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idTour", SqlDbType.Int);
                par1.Value = idTour;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool xoaTourPhuongTien(int idTour)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_XoaTourPhuongTien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idTour", SqlDbType.Int);
                par1.Value = idTour;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public DataTable loadNCC()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiNhaCC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DataTable loadDSNCC()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayDSNhaCungCap", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    SQLDatabase.CloseConnection(conn);
                    return dt;
                }
            }
        }
        public DTO_PhanTrangKH loadDSNCCPhanTrang(int pageIndex, int PageSize)
        {
            using (SqlCommand cmd = new SqlCommand("sp_HienThiDanhSachNCCPaging", conn))
            {
                //Truyền vào các tham số PageIndex, PageSize cho Stored Procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                //Lấy ra tham số RecordCount của Store Procedured
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                SQLDatabase.OpenConnection(conn);
                //Thực thi câu lệnh truy vấn và gán cho đối tượng DataTable
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                SQLDatabase.CloseConnection(conn);
                int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                DTO_PhanTrangKH phanTrang = new DTO_PhanTrangKH(dt, recordCount);
                return phanTrang;
            }
        }
        public bool themNhaCungCap(string tenNhaCungCap, string diaChi,string soDienThoai,string eMail)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TenNhaCungCap", SqlDbType.NVarChar);
                par1.Value = tenNhaCungCap;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                SqlParameter par3 = new SqlParameter("@SoDienThoai", SqlDbType.Char);
                par3.Value = soDienThoai;
                SqlParameter par4 = new SqlParameter("@Email", SqlDbType.NVarChar);
                par4.Value = eMail;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        //Cập nhật thông tin nhà cung cấp
        public bool capNhatNhaCungCap(int idNhaCungCap,string tenNhaCungCap, string diaChi, string soDienThoai, string eMail)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDNhaCungCap", SqlDbType.Int);
                par0.Value = idNhaCungCap;
                SqlParameter par1 = new SqlParameter("@TenNhaCungCap", SqlDbType.NVarChar);
                par1.Value = tenNhaCungCap;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                SqlParameter par3 = new SqlParameter("@SoDienThoai", SqlDbType.Char);
                par3.Value = soDienThoai;
                SqlParameter par4 = new SqlParameter("@Email", SqlDbType.NVarChar);
                par4.Value = eMail;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        //Xóa nhà cung cấp
        public int xoaNhaCungCap(int idNhaCungCap)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_XoaNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDNhaCungCap", SqlDbType.Int);
                par0.Value = idNhaCungCap;
                SqlParameter par1 = new SqlParameter("@KQ", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
                //Trả về 0 là bị khóa ngoại không thể xóa
                //Trả về 1 là xóa thành công
            }
            catch { return -1; }//lỗi
            finally { SQLDatabase.CloseConnection(conn); }
        }
        /// <summary>
        /// Hàm thêm xóa sửa cho địa danh
        /// </summary>
        public bool themDiaDanh(string tenDiaDanh, string diaChi)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemDiaDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TenDiaDanh", SqlDbType.NVarChar);
                par1.Value = tenDiaDanh;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        //Cập nhật thông tin địa danh
        public bool capNhatDiaDanh(int idDiaDanh,string tenDiaDanh, string diaChi)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatDiaDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDDiaDanh", SqlDbType.Int);
                par0.Value = idDiaDanh;
                SqlParameter par1 = new SqlParameter("@TenDiaDanh", SqlDbType.NVarChar);
                par1.Value = tenDiaDanh;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int xoaDiaDanh(int idDiaDanh)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_XoaDiaDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDDiaDanh", SqlDbType.Int);
                par0.Value = idDiaDanh;
                SqlParameter par1 = new SqlParameter("@KQ", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
                //Trả về 0 là bị khóa ngoại không thể xóa
                //Trả về 1 là xóa thành công
            }
            catch { return -1; }//lỗi
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool themKhachSan(string tenKhachSan, string diaChi)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemKhachSan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TenKhachSan", SqlDbType.NVarChar);
                par1.Value = tenKhachSan;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        //Cập nhật thông tin địa danh
        public bool capNhatKhachSan(int idKhachSan, string tenKhachSan, string diaChi)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatKhachSan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDKhachSan", SqlDbType.Int);
                par0.Value = idKhachSan;
                SqlParameter par1 = new SqlParameter("@TenKhachSan", SqlDbType.NVarChar);
                par1.Value = tenKhachSan;
                SqlParameter par2 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int xoaKhachSan(int idKhachSan)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_XoaKhachSan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDKhachSan", SqlDbType.Int);
                par0.Value = idKhachSan;
                SqlParameter par1 = new SqlParameter("@KQ", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
                //Trả về 0 là bị khóa ngoại không thể xóa
                //Trả về 1 là xóa thành công
            }
            catch { return -1; }//lỗi
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool themPhuongTien(string tenPhuongTien, int soCho)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemPhuongTien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TenPhuongTien", SqlDbType.NVarChar);
                par1.Value = tenPhuongTien;
                SqlParameter par2 = new SqlParameter("@SoCho", SqlDbType.Int);
                par2.Value = soCho;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        //Cập nhật thông tin địa danh
        public bool capNhatPhuongTien(int idPhuongTien, string tenPhuongTien, int soCho)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatPhuongTien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDPhuongTien", SqlDbType.Int);
                par0.Value = idPhuongTien;
                SqlParameter par1 = new SqlParameter("@TenPhuongTien", SqlDbType.NVarChar);
                par1.Value = tenPhuongTien;
                SqlParameter par2 = new SqlParameter("@SoCho", SqlDbType.Int);
                par2.Value = soCho;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int xoaPhuongTien(int idKhachSan)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_XoaPhuongTien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDPhuongTien", SqlDbType.Int);
                par0.Value = idKhachSan;
                SqlParameter par1 = new SqlParameter("@KQ", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
                //Trả về 0 là bị khóa ngoại không thể xóa
                //Trả về 1 là xóa thành công
            }
            catch { return -1; }//lỗi
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
