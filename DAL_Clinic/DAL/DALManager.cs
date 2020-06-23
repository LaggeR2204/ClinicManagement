﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public static class DALManager
    {
        private static DAL_BenhNhan _benhNhanDAL;
        private static DAL_PhieuKhamBenh _phieuKhamBenhDAL;
        private static DAL_DonVi _donViDAL;
        private static DAL_CachDung _cachDungDAL;
        private static DAL_Benh _benhDAL;
        private static DAL_Thuoc _thuocDAL;
        private static DAL_PhieuNhapThuoc _phieuNhapThuocDAL;
        private static DAL_CTPhieuNhapThuoc _cTPhieuNhapThuocDAL;

        public static DAL_BenhNhan BenhNhanDAL 
        { 
            get
            {
                if (_benhNhanDAL == null)
                    _benhNhanDAL = new DAL_BenhNhan();
                return _benhNhanDAL;
            }
        }

        public static DAL_PhieuKhamBenh PhieuKhamBenhDAL
        {
            get
            {
                if (_phieuKhamBenhDAL == null)
                    _phieuKhamBenhDAL = new DAL_PhieuKhamBenh();
                return _phieuKhamBenhDAL;
            }
        }

        public static DAL_DonVi DonViDAL
        {
            get
            {
                if (_donViDAL == null)
                    _donViDAL = new DAL_DonVi();
                return _donViDAL;
            }
        }

        public static DAL_CachDung CachDungDAL
        {
            get
            {
                if (_cachDungDAL == null)
                    _cachDungDAL = new DAL_CachDung();
                return _cachDungDAL;
            }
        }

        public static DAL_Benh BenhDAL
        {
            get
            {
                if (_benhDAL == null)
                    _benhDAL = new DAL_Benh();
                return _benhDAL;
            }
        }

        public static DAL_Thuoc ThuocDAL
        {
            get
            {
                if (_thuocDAL == null)
                    _thuocDAL = new DAL_Thuoc();
                return _thuocDAL;
            }
        }

        public static DAL_PhieuNhapThuoc PhieuNhapThuocDAL
        {
            get
            {
                if (_phieuNhapThuocDAL == null)
                    _phieuNhapThuocDAL = new DAL_PhieuNhapThuoc();
                return _phieuNhapThuocDAL;
            }
        }

        public static DAL_CTPhieuNhapThuoc CTPhieuNhapThuocDAL
        {
            get
            {
                if (_cTPhieuNhapThuocDAL == null)
                    _cTPhieuNhapThuocDAL = new DAL_CTPhieuNhapThuoc();
                return _cTPhieuNhapThuocDAL;
            }
        }
    }
}
