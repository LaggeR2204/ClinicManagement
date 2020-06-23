using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_HoaDon : BaseDAL
    {
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.HoaDon.Load();
        }
    }
}
