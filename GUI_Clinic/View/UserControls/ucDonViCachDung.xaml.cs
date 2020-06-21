using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDonViCachDung.xaml
    /// </summary>
    public partial class ucDonViCachDung : UserControl
    {
        public ucDonViCachDung()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
            InitCommand();

            tbxTenDonVi.Text = TenDonViInput;
            tbxTenCachDung.Text = TenCachDungInput;
        }
        #region Property                
        public ObservableCollection<DTO_DonVi> ListDV { get; set; }
        public ObservableCollection<DTO_CachDung> ListCD { get; set; }
        public string TenDonViInput { get; set; }
        public string TenCachDungInput { get; set; }
        #endregion
        #region Command
        public ICommand ThemDonViCommand { get; set; }
        public ICommand XoaDonViCommand { get; set; }
        public ICommand SuaDonViCommand { get; set; }

        public ICommand ThemCachDungCommand { get; set; }
        public ICommand XoaCachDungCommand { get; set; }
        public ICommand SuaCachDungCommand { get; set; }
        #endregion
        public void InitData()
        {
            ListDV = BUSManager.DonViBUS.GetListDV();
            ListCD = BUSManager.CachDungBUS.GetListCD();
        }
        public void InitCommand()
        {
            ThemDonViCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenDonViInput))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_DonVi donVi = new DTO_DonVi(TenDonViInput);
                BUSManager.DonViBUS.AddDonVi(donVi);
            });

            SuaDonViCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenDonViInput) || lvDonVi.SelectedIndex == -1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DTO_DonVi tempDonVi = ListDV.ElementAt<DTO_DonVi>(lvDonVi.SelectedIndex);
                BUSManager.DonViBUS.UpdateDonVi(tempDonVi, TenDonViInput);
            });

            XoaDonViCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenDonViInput) || lvDonVi.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                ObservableCollection<DTO_DonVi> listDonViXoa = new ObservableCollection<DTO_DonVi>();
                foreach (DTO_DonVi item in lvDonVi.SelectedItems)
                {
                    listDonViXoa.Add(item);
                }

                foreach (DTO_DonVi item in listDonViXoa)
                {
                    BUSManager.DonViBUS.DelDonVi(item);
                }
            });


            ThemCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_CachDung cachDung = new DTO_CachDung(TenCachDungInput);
                BUSManager.CachDungBUS.AddCachDung(cachDung);
            });

            SuaCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput) || lvCachDung.SelectedIndex == -1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DTO_CachDung tempCachDung = ListCD.ElementAt<DTO_CachDung>(lvCachDung.SelectedIndex);
                BUSManager.CachDungBUS.UpdateCachDung(tempCachDung, TenCachDungInput);
            });

            XoaCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput) || lvCachDung.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                ObservableCollection<DTO_CachDung> listCachDungXoa = new ObservableCollection<DTO_CachDung>();
                foreach (DTO_CachDung item in lvCachDung.SelectedItems)
                {
                    listCachDungXoa.Add(item);
                }

                foreach (DTO_CachDung item in listCachDungXoa)
                {
                    BUSManager.CachDungBUS.DelCachDung(item);
                }
            });
        }

        private void lvDonVi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDonVi.SelectedIndex != -1)
            {
                TenDonViInput = ListDV.ElementAt<DTO_DonVi>(lvDonVi.SelectedIndex).TenDonVi;
                tbxTenDonVi.Text = TenDonViInput;
            }
            else
            {
                TenDonViInput = null;
                tbxTenDonVi.Text = TenDonViInput;
            }
        }

        private void lvCachDung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCachDung.SelectedIndex != -1)
            {
                TenCachDungInput = ListCD.ElementAt<DTO_CachDung>(lvCachDung.SelectedIndex).TenCachDung;
                tbxTenCachDung.Text = TenCachDungInput;
            }
            else
            {
                TenCachDungInput = null;
                tbxTenCachDung.Text = TenCachDungInput;
            }
        }
    }
}
