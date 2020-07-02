using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_HoaDon : BaseBUS
    {
        public override void LoadLocalData()
        {
            DALManager.HoaDonDAL.LoadLocalData();
        }

        public void LoadNPPhieuKhamBenh(DTO_HoaDon hoaDon)
        {
            DALManager.HoaDonDAL.LoadNPPhieuKhamBenh(hoaDon);
        }

        public void AddHoaDon(DTO_HoaDon hd, DTO_PhieuKhamBenh pkb)
        {
            hd.Id = pkb.Id;
            DALManager.HoaDonDAL.AddHoaDon(hd);
        }
        public double TinhTienThuoc(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);
            double tienThuoc = 0;
            foreach (DTO_CTPhieuKhamBenh item in phieuKhamBenh.DSCTPhieuKhamBenh)
            {
                tienThuoc += item.ThanhTien;
            }
            return tienThuoc;
        }

        public ObservableCollection<DTO_HoaDon> GetListHoaDon()
        {
            return DALManager.HoaDonDAL.GetListHoaDon();
        }

        public DTO_HoaDon XuatHoaDon(DTO_HoaDon hoaDon, DTO_PhieuKhamBenh phieuKhamBenh)
        {
            hoaDon.TienThuoc = TinhTienThuoc(phieuKhamBenh);
            hoaDon.ThanhTien = hoaDon.TienKham + hoaDon.TienThuoc; 
            return hoaDon;
        }

        public DTO_HoaDon GetHoaDon (DTO_PhieuKhamBenh phieuKhamBenh)
        {
            DTO_HoaDon hoaDon = null;
            ObservableCollection<DTO_HoaDon> ListHD = GetListHoaDon();
            foreach (DTO_HoaDon item in ListHD)
            {
                item.Id = phieuKhamBenh.Id;
                hoaDon = item;
            }
            return hoaDon;
        }
    }
}
