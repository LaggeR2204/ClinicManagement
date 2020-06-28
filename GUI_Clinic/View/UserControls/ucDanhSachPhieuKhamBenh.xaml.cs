using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            InitCommand();
            grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
        }

        #region Property
        public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }
        #endregion
        #region Command
        public ICommand TaoPhieuKhamCommand { get; set; }
        #endregion

        public void InitData()
        {
            ListPKB = new ObservableCollection<DTO_PhieuKhamBenh>(BUSManager.PhieuKhamBenhBUS.GetListPKB());
            lvDSPKB.ItemsSource = ListPKB;
        }

        public void InitCommand()
        {
            TaoPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (lvBenhNhan.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                grdPhieuKhamBenh.Visibility = Visibility.Visible;
                ucCTPKB.GetBenhNhan(lvBenhNhan.SelectedItem as DTO_BenhNhan);
            });
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
            grdPhieuKhamBenh.Visibility = Visibility.Visible;
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PhieuKhamBenh;
            if (item != null)
            {
                ucCTPKB.GetPKB(item);
            }
        }
    }
}
