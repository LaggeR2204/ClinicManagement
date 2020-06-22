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
    public class BUS_PhieuKhamBenh: BaseBUS
    {
        public BUS_PhieuKhamBenh()
        {

        }
        public DTO_PhieuKhamBenh GetPhieuKhamBenh(int maPhieuKhamBenh)
        {
            ObservableCollection<DTO_PhieuKhamBenh> ListPKB = GetListPKB();
            foreach (DTO_PhieuKhamBenh item in ListPKB)
            {
                if (item.Id == maPhieuKhamBenh)
                {
                    return item;
                }
            }

            return null;
        }
        public void LoadNPBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            DALManager.PhieuKhamBenhDAL.LoadNPBenh(phieuKhamBenh);
        }
        public void LoadNPBenhNhan(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            DALManager.PhieuKhamBenhDAL.LoadNPBenhNhan(phieuKhamBenh);
        }
        public void LoadNPDSCTPhieuKhamBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            DALManager.PhieuKhamBenhDAL.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);
        }
        public override void LoadLocalData()
        {
            DALManager.PhieuKhamBenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_PhieuKhamBenh> GetListPKB()
        {
            return DALManager.PhieuKhamBenhDAL.GetListPKB();
        }
    }
}
