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
