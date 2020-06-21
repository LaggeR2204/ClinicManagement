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
    public class BUS_CachDung : BaseBUS
    {
        public ObservableCollection<DTO_CachDung> ListCD { get; set; }

        public BUS_CachDung()
        {

        }
        public void AddCachDung(DTO_CachDung cd)
        {
            ListCD = GetListCD();
            bool flag = true;
            foreach (DTO_CachDung item in ListCD)
            {
                if (item.TenCachDung == cd.TenCachDung)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                DALManager.CachDungDAL.AddCachDung(cd);
            }
        }

        public void UpdateCachDung(DTO_CachDung cd, string tenCachDungMoi)
        {
            if (cd.TenCachDung != tenCachDungMoi)
            {
                cd.TenCachDung = tenCachDungMoi;
            }
        }

        public void DelCachDung(DTO_CachDung cd)
        {
            ListCD = GetListCD();
            if (cd != null)
            {
                if (ListCD.Contains(cd))
                {
                    DALManager.CachDungDAL.DelCachDung(cd);
                }
            }
        }

        public override void LoadLocalData()
        {
            DALManager.CachDungDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_CachDung> GetListCD()
        {
            return DALManager.CachDungDAL.GetListCD();
        }
    }
}
