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
        public ObservableCollection<DTO_DonVi> ListDV { get; set; }

        public BUS_DonVi()
        {

        }
        public void AddDonVi(DTO_DonVi dv)
        {
            ListDV = GetListDV();
            bool flag = true;
            foreach (DTO_DonVi item in ListDV)
            {
                if (item.TenDonVi == dv.TenDonVi)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                DALManager.DonViDAL.AddDonVi(dv);
            }
        }

        public void UpdateDonVi(DTO_DonVi dv, string tenDonViMoi)
        {
            ListDV = GetListDV();
            bool flag = true;
            foreach (DTO_DonVi item in ListDV)
            {
                if (item.TenDonVi == tenDonViMoi)
                {
                    flag = false;
                    break;
                }
            }

            if (dv.TenDonVi != tenDonViMoi && flag == true)
            {
                dv.TenDonVi = tenDonViMoi;
            }
        }

        public void DelDonVi(DTO_DonVi dv)
        {
            ListDV = GetListDV();
            if (dv != null)
            {
                if (ListDV.Contains(dv))
                {
                    DALManager.DonViDAL.DelDonVi(dv);
                }
            }
        }

        public DTO_DonVi GetDonViById(int maDonVi)
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
    }
}
