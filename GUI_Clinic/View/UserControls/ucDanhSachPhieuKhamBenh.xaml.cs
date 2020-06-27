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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachPhieuKhamBenh.xaml
    /// </summary>
    public partial class ucDanhSachPhieuKhamBenh : UserControl
    {
        public ucDanhSachPhieuKhamBenh()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
        }

        #region Property
        public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }

        private bool IsSave = false;
        #endregion
        #region Command
        #endregion

        public void InitData()
        {
            ListPKB = new ObservableCollection<DTO_PhieuKhamBenh>(BUSManager.PhieuKhamBenhBUS.GetListPKB());
            lvDSPKB.ItemsSource = ListPKB;
        }

        private bool PhieuKhamBenhFilter(Object item)
        {
            if (String.IsNullOrEmpty(dpkNgayKham.Text))
            {
                return true;
            }
            else
            {
                return ((item as DTO_PhieuKhamBenh).NgayKham.Date.Equals(dpkNgayKham.SelectedDate));
            }
        }

        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lvDSPKB.ItemsSource = ListPKB;

            CollectionView viewPKB = (CollectionView)CollectionViewSource.GetDefaultView(lvDSPKB.ItemsSource);
            viewPKB.Filter = PhieuKhamBenhFilter;
        }

        private void lvDSPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PhieuKhamBenh;
            if (item != null)
            {
                ucCTPKB.GetPKB(item);
            }
        }
    }
}
