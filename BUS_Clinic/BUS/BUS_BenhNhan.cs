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
    public class BUS_BenhNhan : BaseBUS
    {
        public BUS_BenhNhan()
        {

        }
        public DTO_BenhNhan GetBenhNhanById(int maBenhNhan)
        {
            ObservableCollection<DTO_BenhNhan> ListBN = GetListBN();
            var result = ListBN.Where(c => c.Id == maBenhNhan).FirstOrDefault();
            return result;
        }
        public void AddBenhNhan(DTO_BenhNhan bn)
        {
            ObservableCollection<DTO_BenhNhan> ListBN = GetListBN();
            var rel = ListBN.Where(c => c.TenBenhNhan == bn.TenBenhNhan && c.SoDienThoai == bn.SoDienThoai).FirstOrDefault();
            if (rel != null)
                return;
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
