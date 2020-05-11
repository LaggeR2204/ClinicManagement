using DAL_Clinic;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic
{
    public class BUS_BenhNhan
    {
        DAL_BenhNhan _dalBenhNhan = new DAL_BenhNhan();
        public void ThemBenhNhan(DTO_BenhNhan bn)
        {
            _dalBenhNhan.Add(bn);
        }
    }
}
