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
        private static BUS_PhieuKhamBenh _phieuKhamBenhBUS;

        public static BUS_BenhNhan BenhNhanBUS
        {
            get
            {
                if (_benhNhanBUS == null)
                    _benhNhanBUS = new BUS_BenhNhan();
                return _benhNhanBUS;
            }
        }

        public static BUS_PhieuKhamBenh PhieuKhamBenhBUS
        {
            get
            {
                if (_phieuKhamBenhBUS == null)
                    _phieuKhamBenhBUS = new BUS_PhieuKhamBenh();
                return _phieuKhamBenhBUS;
            }
        }

    }
}
