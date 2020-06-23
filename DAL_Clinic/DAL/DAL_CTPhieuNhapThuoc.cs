using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_CTPhieuNhapThuoc : BaseDAL
    {
        public DAL_CTPhieuNhapThuoc()
        {

        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.CTPhieuNhapThuoc.Load();
        }
        public ObservableCollection<DTO_CTPhieuNhapThuoc> GetListCTPNT()
        {
            return SQLServerDBContext.Instant.CTPhieuNhapThuoc.Local;
        }
    }
}
