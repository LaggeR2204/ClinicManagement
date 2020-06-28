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
    public class BUS_Benh : BaseBUS
    {
        public BUS_Benh()
        {

        }
        public DTO_Benh GetBenh(string maBenh)
        {
            ObservableCollection<DTO_Benh> ListBenh = GetListBenh();
            foreach (DTO_Benh benh in ListBenh)
            {
                if (benh.Id == maBenh)
                {
                    return benh;
                }
            }

            return null;
        }
        public void AddBenh(DTO_Benh benh)
        {
            DALManager.BenhDAL.AddBenh(benh);
        }

        public override void LoadLocalData()
        {
            DALManager.BenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_Benh> GetListBenh()
        {
            return DALManager.BenhDAL.GetListBenh();
        }
    }
}
