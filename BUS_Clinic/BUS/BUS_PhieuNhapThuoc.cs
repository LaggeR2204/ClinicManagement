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
    public class BUS_PhieuNhapThuoc : BaseBUS
    {
        public BUS_PhieuNhapThuoc()
        {

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
