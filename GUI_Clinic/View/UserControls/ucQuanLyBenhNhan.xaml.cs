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
    /// Interaction logic for ucQuanLyBenhNhan.xaml
    /// </summary>
    public partial class ucQuanLyBenhNhan : UserControl
    {
        public ucQuanLyBenhNhan()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();  
        }

        #region Property                
        public ObservableCollection<DTO_BenhNhan> ListBN { get; set; }
        public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }
        private int MaBenhNhanSelected = 0;
        public DTO_BenhNhan SelectedItem { get; set; }
        #endregion
        #region Command

        #endregion
        public void InitData()
        {
            ListBN = BUSManager.BenhNhanBUS.GetListBN();
            ListPKB = BUSManager.PhieuKhamBenhBUS.GetListPKB();

            lvBenhNhan.ItemsSource = ListBN;
            lvDanhSachPKB.ItemsSource = ListPKB;

            CollectionView viewBenhNhan = (CollectionView)CollectionViewSource.GetDefaultView(lvBenhNhan.ItemsSource);
            viewBenhNhan.Filter = BenhNhanFilter;

            CollectionView viewPKB = (CollectionView)CollectionViewSource.GetDefaultView(lvDanhSachPKB.ItemsSource);
            viewPKB.Filter = PKBFilter;
        }

        private bool BenhNhanFilter(Object item)
        {
            if (String.IsNullOrEmpty(tbxKeyword.Text))
            {
                return true;
            }
            else
            {
                if (cbxSearchType.SelectedIndex == 0)
                {
                    return ((item as DTO_BenhNhan).TenBenhNhan.IndexOf(tbxKeyword.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (cbxSearchType.SelectedIndex == 1)
                {
                    return ((item as DTO_BenhNhan).DiaChi.IndexOf(tbxKeyword.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (cbxSearchType.SelectedIndex == 2)
                {
                    return ((item as DTO_BenhNhan).SoDienThoai.IndexOf(tbxKeyword.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    return false;
                }
            }
        }

        private bool PKBFilter(Object item)
        {
            if (MaBenhNhanSelected == 0)
            {
                return true;
            }
            else
            {
                return (item as DTO_PhieuKhamBenh).MaBenhNhan == MaBenhNhanSelected;
            }
        }

        private void tbxKeyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvBenhNhan.ItemsSource).Refresh();
        }

        private void lvBenhNhan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tempMaBenhNhanSelected = lvBenhNhan.SelectedItem;
            if (tempMaBenhNhanSelected != null)
            {
                MaBenhNhanSelected = (lvBenhNhan.SelectedItem as DTO_BenhNhan).Id;
                CollectionViewSource.GetDefaultView(lvDanhSachPKB.ItemsSource).Refresh();
            }
            else
            {
                return;
            }
        }

        private void lvDanhSachPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PhieuKhamBenh;
            if (item != null)
            {
                //Mo PKB tuong ung
                wdPhieuKhamBenh phieuKhamBenh = new wdPhieuKhamBenh(item);
                phieuKhamBenh.ShowDialog();
            }
        }
    }
}
