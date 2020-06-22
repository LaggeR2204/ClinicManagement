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
    public class BUS_PhieuKhamBenh : BaseBUS
    {
        public BUS_PhieuKhamBenh()
        {

        }
        public override void LoadLocalData()
        {
            DALManager.PhieuKhamBenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_PhieuKhamBenh> GetListPKB()
        {
            return DALManager.PhieuKhamBenhDAL.GetListPKB();
        }
        public List<int> GetListPKB(string ngayKham)
        {
            var listpkb = DALManager.PhieuKhamBenhDAL.GetListPKB();
            var result = from pkb in listpkb
                         where pkb.NgayKham.ToString("d") == ngayKham
                         select pkb.MaBenhNhan;
            return new List<int>(result);
        }
    }
}
