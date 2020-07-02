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
    public class BUS_DonVi : BaseBUS
    {
        private const string _idPrefix = "DV";
        public BUS_DonVi()
        {

        }
        public void AddDonVi(DTO_DonVi donVi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            bool flag = donvis.Any(d => d.TenDonVi.Equals(donVi.TenDonVi, StringComparison.OrdinalIgnoreCase));

            if (!flag)
            {
                donVi.Id = AutoGenerateID();
                DALManager.DonViDAL.AddDonVi(donVi);
            }
        }
        public void UpdateDonVi(DTO_DonVi donVi, string tenDonViMoi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            bool flag = donvis.Any(d => d.TenDonVi.Equals(tenDonViMoi, StringComparison.OrdinalIgnoreCase));

            if (donVi.TenDonVi != tenDonViMoi && !flag)
            {
                donVi.TenDonVi = tenDonViMoi;
            }
        }
        public void DelDonVi(DTO_DonVi donVi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();
            if (donVi != null)
            {
                if (donvis.Any(d => d.TenDonVi.Equals(donVi.TenDonVi, StringComparison.OrdinalIgnoreCase)))
                {
                    DALManager.DonViDAL.DelDonVi(donVi);
                }
            }
        }
        public DTO_DonVi GetDonViById(string maDonVi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            var dv = donvis.Where(c => c.Id == maDonVi).FirstOrDefault();
            
            return dv;
        }
        public override void LoadLocalData()
        {
            DALManager.DonViDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_DonVi> GetListDV()
        {
            return DALManager.DonViDAL.GetListDV();
        }
        public int DemSoDonVi()
        {
            int re = DALManager.DonViDAL.GetListDV().Count;
            return re;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (DemSoDonVi() + 1).ToString("D5");
        }
    }
}
