using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public static class BUSManager
    {
        private static BUS_BenhNhan _benhNhanBUS;
        public static BUS_BenhNhan BenhNhanBUS
        {
            get
            {
                if (_benhNhanBUS == null)
                    _benhNhanBUS = new BUS_BenhNhan();
                return _benhNhanBUS;
            }
        }

    }
}
