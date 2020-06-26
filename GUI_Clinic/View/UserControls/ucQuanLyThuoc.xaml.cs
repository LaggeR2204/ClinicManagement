using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using GUI_Clinic.View.Windows;
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
    /// Interaction logic for ucQuanLyThuoc.xaml
    /// </summary>
    public partial class ucQuanLyThuoc : UserControl
    {
        public ucQuanLyThuoc()
        {
            InitializeComponent();
            this.DataContext = this;
            InitData();
        }

        #region Property
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_PhieuNhapThuoc> ListPNT { get; set; }
        //public DTO_Thuoc thuoc { get; set; }
        //public DTO_PhieuNhapThuoc phieuNhapThuoc { get; set; }
        #endregion

        #region Command

        #endregion

        private void InitData()
        {
            //thuoc = new DTO_Thuoc("thuoc ngu", 2, 50000, 10, "ngu");
            //BUSManager.ThuocBUS.AddThuoc(thuoc);

            //phieuNhapThuoc = new DTO_PhieuNhapThuoc(DateTime.Now, 500000000);
            //BUSManager.PhieuNhapThuocBUS.AddPhieuNhapThuoc(phieuNhapThuoc);

            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            foreach (DTO_Thuoc item in ListThuoc)
            {
                BUSManager.ThuocBUS.LoadNPDonVi(item);
            }

            ListPNT = BUSManager.PhieuNhapThuocBUS.GetListPNT();
            foreach (DTO_PhieuNhapThuoc item in ListPNT)
            {
                BUSManager.PhieuNhapThuocBUS.TransferTongTien(item);
            }

            lvThuoc.ItemsSource = ListThuoc;

            CollectionView viewThuoc = (CollectionView)CollectionViewSource.GetDefaultView(lvThuoc.ItemsSource);
            viewThuoc.Filter = ThuocFilter;
        }

        private bool ThuocFilter(object item)
        {
            if (String.IsNullOrEmpty(tbxTimThuoc.Text))
                return true;
            else
                return ((item as DTO_Thuoc).TenThuoc.IndexOf(tbxTimThuoc.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void tbx_TimThuoc_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvThuoc.ItemsSource).Refresh();
        }

        private void btnNhapThuoc_Click(object sender, RoutedEventArgs e)
        {
            wdPhieuNhapThuoc wd = new wdPhieuNhapThuoc();
            wd.ShowDialog();
        }
    }
}
