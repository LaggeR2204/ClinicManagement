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
        private static BUS_DonVi _donViBUS;
        private static BUS_CachDung _cachDungBUS;

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

        public static BUS_DonVi DonViBUS
        {
            get
            {
                if (_donViBUS == null)
                    _donViBUS = new BUS_DonVi();
                return _donViBUS;
            }
        }

        public static BUS_CachDung CachDungBUS
        {
            get
            {
                if (_cachDungBUS == null)
                    _cachDungBUS = new BUS_CachDung();
                return _cachDungBUS;
            }
        }

    }
}
