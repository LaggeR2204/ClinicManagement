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
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }
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
            ListBenh = GetListBenh();
            bool flag = true;
            foreach (DTO_Benh item in ListBenh)
            {
                if (item.TenBenh == benh.TenBenh)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                benh.Id = AutoGenerateID();
                DALManager.BenhDAL.AddBenh(benh);
            }
        }
        public void UpdateBenh(DTO_Benh benh, string tenBenhMoi)
        {
            ListBenh = GetListBenh();
            bool flag = true;
            foreach (DTO_Benh item in ListBenh)
            {
                if (item.TenBenh == tenBenhMoi)
                {
                    flag = false;
                    break;
                }
            }

            if (benh.TenBenh != tenBenhMoi && flag == true)
            {
                benh.TenBenh = tenBenhMoi;
            }
        }
        public void Delbenh(DTO_Benh benh)
        {
            ListBenh = GetListBenh();
            if (benh != null)
            {
                if (ListBenh.Contains(benh))
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
