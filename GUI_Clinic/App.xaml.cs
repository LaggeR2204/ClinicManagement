using BUS_Clinic.BUS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_Clinic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoadLocalData();
        }
        private void LoadLocalData()
        {
            BUSManager.BenhNhanBUS.LoadLocalData();
            BUSManager.PhieuKhamBenhBUS.LoadLocalData();
            BUSManager.DonViBUS.LoadLocalData();
            BUSManager.CachDungBUS.LoadLocalData();
        }
    }
}
