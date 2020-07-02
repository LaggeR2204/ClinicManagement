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
        private const string _idPrefix = "BE";
        public BUS_Benh()
        {

        }
        public void AddBenh(DTO_Benh benh)
        {
            ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();

            bool flag = benhs.Any(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase));

            if (!flag)
            {
                benh.Id = AutoGenerateID();
                DALManager.BenhDAL.AddBenh(benh);
            }
        }
        public void UpdateBenh(DTO_Benh benh, string tenBenhMoi)
        {
            ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();

            bool flag = benhs.Any(b => b.TenBenh.Equals(tenBenhMoi, StringComparison.OrdinalIgnoreCase));

            if (benh.TenBenh != tenBenhMoi && !flag)
            {
                benh.TenBenh = tenBenhMoi;
            }
        }
        public void Delbenh(DTO_Benh benh)
        {
            ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();
            if (benh != null)
            {
                if (benhs.Any(b=>b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase)))
                {
                    DALManager.BenhDAL.DelBenh(benh);
                }
            }
        }
        public override void LoadLocalData()
        {
            DALManager.BenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_Benh> GetListBenh()
        {
            return DALManager.BenhDAL.GetListBenh();
        }
        public int GetBenhAmount()
        {
            int amount = DALManager.BenhDAL.GetListBenh().Count;
            return amount;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (GetBenhAmount() + 1).ToString("D5");
        }
    }
}
