using DAL_Clinic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_BCDoanhThu : BaseBUS
    {
        public override void LoadLocalData()
        {
            DALManager.BCDoanhThuDAL.LoadLocalData();
        }
    }
}
