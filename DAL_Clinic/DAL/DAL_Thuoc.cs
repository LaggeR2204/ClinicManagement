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
    public class DAL_Thuoc: BaseDAL
    {
        public DAL_Thuoc()
        {
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.Thuoc.Load();
        }
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            return SQLServerDBContext.Instant.Thuoc.Local;
        }
    }
}
