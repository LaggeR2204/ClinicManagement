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
