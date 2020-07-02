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
    public class BUS_ThamSo : BaseBUS
    {
        public override void LoadLocalData()
        {
            DALManager.ThamSoDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_ThamSo> GetListThamSo()
        {
            return DALManager.ThamSoDAL.GetListThamSo();
        }
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            DALManager.ThamSoDAL.UpdateThamSo(TienKham, SoBNToiDa);
        }
    }
}
