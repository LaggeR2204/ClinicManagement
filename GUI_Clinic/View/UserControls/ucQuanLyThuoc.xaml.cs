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
        #endregion

        #region Command
        
        #endregion

        private void InitData()
        {
            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListPNT = BUSManager.PhieuNhapThuocBUS.GetListPNT();
        }

        private void btnNhapThuoc_Click(object sender, RoutedEventArgs e)
        {
            wdPhieuNhapThuoc wd = new wdPhieuNhapThuoc();
            wd.ShowDialog();
        }
    }
}
