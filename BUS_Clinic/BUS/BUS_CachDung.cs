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
        private const string _idPrefix = "CD";
        public BUS_CachDung()
        {

        }
        public void AddCachDung(DTO_CachDung cachDung)
        {
            ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();

            bool flag = cachdungs.Any(c => c.TenCachDung.Equals(cachDung.TenCachDung, StringComparison.OrdinalIgnoreCase));

            if (!flag)
            {
                cachDung.Id = AutoGenerateID();
                DALManager.CachDungDAL.AddCachDung(cachDung);
            }
        }
        public void UpdateCachDung(DTO_CachDung cachDung, string tenCachDungMoi)
        {
            ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();

            bool flag = cachdungs.Any(c => c.TenCachDung.Equals(tenCachDungMoi, StringComparison.OrdinalIgnoreCase));

            if (cachDung.TenCachDung != tenCachDungMoi && !flag)
            {
                cachDung.TenCachDung = tenCachDungMoi;
            }
        }
        public void DelCachDung(DTO_CachDung cachDung)
        {
            ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();
            if (cachDung != null)
            {
                if (cachdungs.Any(c => c.TenCachDung.Equals(cachDung.TenCachDung, StringComparison.OrdinalIgnoreCase)))
                {
                    DALManager.CachDungDAL.DelCachDung(cachDung);
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
        public int DemSoCachDung()
        {
            int re = DALManager.CachDungDAL.GetListCD().Count;
            return re;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (DemSoCachDung() + 1).ToString("D5");
        }
    }
}
