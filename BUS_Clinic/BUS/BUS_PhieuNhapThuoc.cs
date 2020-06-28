﻿using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_PhieuNhapThuoc : BaseBUS
    {
        public BUS_PhieuNhapThuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            DALManager.PhieuNhapThuocDAL.LoadNPCTPhieuNhapThuoc(phieuNhapThuoc);
        }
        public void AddPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuoc(phieuNhapThuoc);
        }
        //public void TransferTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        //{
        //    DALManager.PhieuNhapThuocDAL.TransferTongTien(phieuNhapThuoc);
        //}
        public void TinhTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            ObservableCollection<DTO_CTPhieuNhapThuoc> CTPNTs = DALManager.CTPhieuNhapThuocDAL.GetListCTPNT();

            var cTPNT = from p in CTPNTs
                        where p.MaPNT == phieuNhapThuoc.Id
                        select p;

            foreach (var item in cTPNT)
            {
                phieuNhapThuoc.TongTien += item.ThanhTien;
            }
        }
        public override void LoadLocalData()
        {
            DALManager.PhieuNhapThuocDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_PhieuNhapThuoc> GetListPNT()
        {
            return DALManager.PhieuNhapThuocDAL.GetListPNT();
        }
    }
}
