using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic
{
    public class DAL_BenhNhan
    {
        public void Add(DTO_BenhNhan obj)
        {
            SQLServerDBContext.Instant.BenhNhan.Add(obj);
        }       
    }
}
