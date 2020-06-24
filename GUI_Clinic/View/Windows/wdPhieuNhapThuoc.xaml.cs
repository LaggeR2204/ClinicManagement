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
using System.Windows.Shapes;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdPhieuNhapThuoc.xaml
    /// </summary>
    public partial class wdPhieuNhapThuoc : Window
    {
        public wdPhieuNhapThuoc()
        {
            InitializeComponent();
            this.DataContext = this;
            InitData();
            InitCommand();
        }

        #region Property
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public string TenThuocMoi { get; set; }
        public string CongDungThuocMoi { get; set; }
        #endregion

        #region Command
        public ICommand AddMedicineCommand { get; set; }
        #endregion

        private void InitData()
        {
            cbxTenThuoc.ItemsSource = new ObservableCollection<DTO_Thuoc>(BUSManager.ThuocBUS.GetListThuoc());
            cbxDonVi.ItemsSource = new ObservableCollection<DTO_DonVi>(BUSManager.DonViBUS.GetListDV());
            cbxDonViThuocMoi.ItemsSource = new ObservableCollection<DTO_DonVi>(BUSManager.DonViBUS.GetListDV());
        }

        private void InitCommand()
        {
            AddMedicineCommand = new RelayCommand<Window>((p) =>
            {
                if (SoLuong == 0 || DonGia == 0 ||
                    cbxTenThuoc.SelectedIndex == -1 ||
                    cbxDonVi.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc();
                cTPhieuNhapThuoc.SoLuongNhap = SoLuong;
                cTPhieuNhapThuoc.DonGiaNhap = DonGia;
            });
        }
    }
}
