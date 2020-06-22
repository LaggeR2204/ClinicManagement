using BUS_Clinic.BUS;
using DTO_Clinic;
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
    /// Interaction logic for wdPhieuKhamBenh.xaml
    /// </summary>
    public partial class wdPhieuKhamBenh : Window
    {
        public ObservableCollection<DTO_CTPhieuKhamBenh> ListCTPKB { get; set; }

        public wdPhieuKhamBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            InitializeComponent();
            BUSManager.PhieuKhamBenhBUS.LoadNPBenh(phieuKhamBenh);
            BUSManager.PhieuKhamBenhBUS.LoadNPBenhNhan(phieuKhamBenh);
            BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);

            tblTenBenhNhan.Text = phieuKhamBenh.BenhNhan.TenBenhNhan;
            tblNgayKham.Text = phieuKhamBenh.NgayKham.ToString();
            tblTrieuChung.Text = phieuKhamBenh.TrieuChung;
            tblDuDoanLoaiBenh.Text = phieuKhamBenh.Benh.TenBenh;
            lvMedicine.ItemsSource = phieuKhamBenh.DSCTPhieuKhamBenh;
        }
    }
}
