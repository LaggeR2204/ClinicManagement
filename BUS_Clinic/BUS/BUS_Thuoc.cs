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
    public class BUS_Thuoc: BaseBUS
    {
        public BUS_Thuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.LoadNPCTPhieuNhapThuoc(thuoc);
        }
        public void LoadNPDonVi(DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.LoadNPDonVi(thuoc);
        }
        public void AddThuoc(DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.AddThuoc(thuoc);
        }
        public bool CheckThuocMoi(DTO_Thuoc thuocMoi)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            bool has = thuocs.Any(t => (t.TenThuoc.Equals(thuocMoi.TenThuoc, StringComparison.OrdinalIgnoreCase)) && (t.MaDonVi == thuocMoi.MaDonVi));

            return has;
        }
        public void CapNhatThuocVuaNhap(DTO_Thuoc thuocVuaNhap)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            var kq = thuocs.Where(c => (c.Id == thuocVuaNhap.Id) && (c.MaDonVi == thuocVuaNhap.MaDonVi)).FirstOrDefault();

            kq.SoLuong += thuocVuaNhap.SoLuong;
            kq.DonGia = thuocVuaNhap.DonGia;
        }
        public override void LoadLocalData()
        {
            DALManager.ThuocDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            return DALManager.ThuocDAL.GetListThuoc();
        }
    }
}
