﻿using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_KhachHang
    {
        private SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadDSKH()
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiDanhSachKhachHang", conn);
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

        public DTO_PhanTrangKH loadDSKHPhanTrang(int pageIndex,int PageSize)
        {
            using (SqlCommand cmd = new SqlCommand("sp_HienThiDanhSachKhachHangPaging", conn))
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
        public DataTable timKiemDSKH(string tenKH)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_TimKiemKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@TenKhachHang", SqlDbType.NVarChar);
            par1.Value = tenKH;
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
        public DataTable loadDSSNKH(int thang)
        {
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiDanhSachSNKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@thang", SqlDbType.Int);
            par1.Value = thang;
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

        public bool themKhachHang(string tenKH, string SDT, string diaChi, string gioiTinh, string soCanCuoc, DateTime ngaySinh)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@TenKhachHang", SqlDbType.NVarChar);
                par1.Value = tenKH;
                SqlParameter par2 = new SqlParameter("@SoDienThoai", SqlDbType.Char);
                par2.Value = SDT;
                SqlParameter par3 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par3.Value = diaChi;
                SqlParameter par4 = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
                par4.Value = gioiTinh;
                SqlParameter par5 = new SqlParameter("@SoCanCuoc", SqlDbType.Char);
                par5.Value = soCanCuoc;
                SqlParameter par6 = new SqlParameter("@NgaySinh", SqlDbType.Date);
                par6.Value = ngaySinh.Date;
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
        public bool capNhatKhachHang(int idKH, string tenKH, string SDT, string diaChi, string gioiTinh, string soCanCuoc, DateTime ngaySinh)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDKhachHang", SqlDbType.Int);
                par0.Value = idKH;
                SqlParameter par1 = new SqlParameter("@TenKhachHang", SqlDbType.NVarChar);
                par1.Value = tenKH;
                SqlParameter par2 = new SqlParameter("@SoDienThoai", SqlDbType.Char);
                par2.Value = SDT;
                SqlParameter par3 = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
                par3.Value = diaChi;
                SqlParameter par4 = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
                par4.Value = gioiTinh;
                SqlParameter par5 = new SqlParameter("@SoCanCuoc", SqlDbType.Char);
                par5.Value = soCanCuoc;
                SqlParameter par6 = new SqlParameter("@NgaySinh", SqlDbType.Date);
                par6.Value = ngaySinh.Date;
                cmd.Parameters.Add(par0);
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
        public int xoaKhachHang(int idKH)
        {
            SQLDatabase.OpenConnection(conn);
            try
            {
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_XoaKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@IDKhachHang", SqlDbType.Int);
                par0.Value = idKH;
                SqlParameter par1 = new SqlParameter("@kq", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
            }
            catch { return -1; }
            finally { SQLDatabase.CloseConnection(conn); }
        }

    }
}
