using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_BenhNhan: BaseBUS
    {
        public BUS_BenhNhan()
        {

        }
        public void AddBenhNhan(DTO_BenhNhan bn)
        {
            DALManager.BenhNhanDAL.AddBenhNhan(bn);
        }
    }
}
