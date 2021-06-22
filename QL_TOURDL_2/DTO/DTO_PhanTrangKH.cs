using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhanTrangKH
    {
        public DataTable dt;
        public int rowCount;
        public DTO_PhanTrangKH(DataTable dt,int rowCount)
        {
            this.dt = dt;
            this.rowCount = rowCount;
        }
    }
}
