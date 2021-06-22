using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_DoanhThu
    {
        SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadDoanhThuTungThang(int nam)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayDoanhThuTourThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@nam", SqlDbType.Int);
            par1.Value = nam;
            cmd.Parameters.Add(par1);
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

        public DataTable loadTourHoanThanh(int thang,int nam)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayDSTourHoanThanh", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@thang", SqlDbType.Int);
            par1.Value = thang;
            SqlParameter par2 = new SqlParameter("@nam", SqlDbType.Int);
            par2.Value = nam;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
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

        public DataTable loadKhachHangMoiTungThang(int nam)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LaySLKhachDangKyMoi", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@nam", SqlDbType.Int);
            par1.Value = nam;
            cmd.Parameters.Add(par1);
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
        public int demKHMoiTrongThang(int thang)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(IDKhachHang) FROM dbo.KhachHang WHERE MONTH(NgayThem) = " + thang, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch { return -1; }
            finally { SQLDatabase.CloseConnection(conn); }

        }
    }
}
