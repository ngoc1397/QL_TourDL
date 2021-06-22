using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_CongNo
    {
        SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadTourTatCa()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiThongTinTourCongNo", conn);
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
        public DTO_PhanTrangKH loadDSTourCNPhanTrang(int pageIndex, int PageSize)
        {
            using (SqlCommand cmd = new SqlCommand("sp_HienThiThongTinTourCongNoPaging", conn))
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
        public DataTable loadCongNo()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiCongNo", conn);
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
        public bool themCongNo(int IDTour,int IDNhaCungCap,int IDNhanVien,string TenCongNo,DateTime HanThanhToan,decimal SoTien)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemCongNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@IDTour", SqlDbType.Int);
                par1.Value = IDTour;
                SqlParameter par2 = new SqlParameter("@IDNhaCungCap", SqlDbType.Int);
                par2.Value = IDNhaCungCap;
                SqlParameter par3 = new SqlParameter("@IDNhanVien", SqlDbType.Int);
                par3.Value = IDNhanVien;
                SqlParameter par4 = new SqlParameter("@TenCongNo", SqlDbType.NVarChar);
                par4.Value = TenCongNo;
                SqlParameter par5 = new SqlParameter("@HanThanhToan", SqlDbType.Date);
                par5.Value = HanThanhToan.Date;
                SqlParameter par6 = new SqlParameter("@SoTien", SqlDbType.Money);
                par6.Value = SoTien;  
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.Parameters.Add(par6);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatTrangThaiCN(int IDCongNo, string TrangThai)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatCongNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@IDCongNo", SqlDbType.Int);
                par1.Value = IDCongNo;
                SqlParameter par2 = new SqlParameter("@TrinhTrang", SqlDbType.Char);
                par2.Value = TrangThai;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
