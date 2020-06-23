using DAL_Clinic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CTBaoCaoDoanhThu : BaseBUS
    {
        public override void LoadLocalData()
        {
            DALManager.CTBaoCaoDoanhThuDAL.LoadLocalData();
        }
    }
}
