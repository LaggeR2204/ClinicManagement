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
    public class DAL_PhieuKhamBenh: BaseDAL
    {
        public DAL_PhieuKhamBenh()
        {
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.PhieuKhamBenh.Load();
        }
        public ObservableCollection<DTO_PhieuKhamBenh> GetListPKB()
        {
            return SQLServerDBContext.Instant.PhieuKhamBenh.Local;      
        }
    }
}
