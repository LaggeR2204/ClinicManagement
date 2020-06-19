using BUS_Clinic.BUS;
using System;
using System.Collections.Generic;
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

namespace GUI_Clinic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLocalData();
        }

        private void LoadLocalData()
        {
            BUSManager.BenhNhanBUS.LoadLocalData();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Visible;
                    grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case 1:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Visible;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    break;
                case 2:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Visible;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 120, 0, 0);
                    break;
                case 3:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Visible;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 180, 0, 0);
                    break;
                case 4:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Visible;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 240, 0, 0);
                    break;
                case 5:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Hidden;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Visible;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 300, 0, 0);
                    break;
                case 6:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Visible;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Hidden;
                    uc_DonViCachDung.Visibility = Visibility.Hidden;
                    uc_QuanLyThuoc.Visibility = Visibility.Hidden;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Hidden;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Hidden;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Hidden;
                    grdSelectedButton.Margin = new Thickness(0, 360, 0, 0);
                    break;
                default:
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BUSManager.BenhNhanBUS.SaveChange();
        }
    }
}
