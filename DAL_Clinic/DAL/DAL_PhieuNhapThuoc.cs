using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_PhieuNhapThuoc: BaseDAL
    {
        public DAL_PhieuNhapThuoc()
        {
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.PhieuNhapThuoc.Load();
        }
        public ObservableCollection<DTO_PhieuNhapThuoc> GetListPNT()
        {
            return SQLServerDBContext.Instant.PhieuNhapThuoc.Local;
        }
    }
}
