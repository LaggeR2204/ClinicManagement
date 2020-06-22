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
    public class BUS_BenhNhan: BaseBUS
    {
        public BUS_BenhNhan()
        {

        }
        public DTO_BenhNhan GetBenhNhan(int maBenhNhan)
        {
            ObservableCollection<DTO_BenhNhan> ListBN = GetListBN();
            foreach  (DTO_BenhNhan benhNhan in ListBN)
            {
                if (benhNhan.Id == maBenhNhan)
                {
                    return benhNhan;
                }
            }

            return null;
        }
        public void AddBenhNhan(DTO_BenhNhan bn)
        {
            DALManager.BenhNhanDAL.AddBenhNhan(bn);
        }

        public override void LoadLocalData()
        {
            DALManager.BenhNhanDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_BenhNhan> GetListBN()
        {
            return DALManager.BenhNhanDAL.GetListBN();
        }
    }
}
