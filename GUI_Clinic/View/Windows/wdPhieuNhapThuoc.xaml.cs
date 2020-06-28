﻿using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using GUI_Clinic.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
        public double DonGia { get; set; }
        //public List<int> ListSTT { get; set; }
        //public string TenThuocMoi { get; set; }
        //public string CongDungThuocMoi { get; set; }
        public DateTime NgayNhapThuoc { get; set; }
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_DonVi> ListDonVi { get; set; }
        public ObservableCollection<DTO_Thuoc> List { get; set; }
        #endregion

        #region Command
        public ICommand ThemThuocCommand { get; set; }
        public ICommand ThemThuocMoiCommand { get; set; }
        #endregion

        private void InitData()
        {
            NgayNhapThuoc = DateTime.Now;

            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListDonVi = BUSManager.DonViBUS.GetListDV();

            foreach (DTO_Thuoc item in ListThuoc)
            {
                BUSManager.ThuocBUS.LoadNPDonVi(item);
            }

            //ListSTT = new List<int>();
            //lvSTT.ItemsSource = ListSTT;

            List = new ObservableCollection<DTO_Thuoc>();
            lvDanhSachThuocNhap.ItemsSource = List;

            //foreach (DTO_Thuoc item in List)
            //{
            //    BUSManager.ThuocBUS.LoadNPDonVi(item);
            //}
        }

        private void InitCommand()
        {
            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (tbxDonGia.Text == "0" || tbxSoLuong.Text == "0" || cbxTenThuoc.SelectedIndex == -1 || cbxDonVi.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Thuoc themThuoc = new DTO_Thuoc();

                themThuoc.Id = (cbxTenThuoc.SelectedItem as DTO_Thuoc).Id;
                themThuoc.TenThuoc = (cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc;
                themThuoc.MaDonVi = (cbxDonVi.SelectedItem as DTO_DonVi).Id;
                themThuoc.DonVi = BUSManager.DonViBUS.GetDonViById(themThuoc.MaDonVi);
                themThuoc.SoLuong = SoLuong;
                themThuoc.DonGia = DonGia;

                if (BUSManager.ThuocBUS.CheckThuocMoi(themThuoc))
                {
                    List.Add(themThuoc);

                    cbxTenThuoc.SelectedIndex = -1;
                    cbxDonVi.SelectedIndex = -1;
                    tbxDonGia.Text = "0";
                    tbxSoLuong.Text = "0";
                }
                else
                {
                    MessageBox.Show("Thuốc bạn chọn chưa có loại đơn vị này.");

                    cbxTenThuoc.SelectedIndex = -1;
                    cbxDonVi.SelectedIndex = -1;
                    tbxDonGia.Text = "0";
                    tbxSoLuong.Text = "0";
                }
            });

            ThemThuocMoiCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTenThuocMoi.Text) || cbxDonViThuocMoi.SelectedIndex == -1 || string.IsNullOrEmpty(tbxCongDungThuocMoi.Text))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Thuoc thuocMoi = new DTO_Thuoc();
                thuocMoi.TenThuoc = tbxTenThuocMoi.Text;
                thuocMoi.MaDonVi = (cbxDonViThuocMoi.SelectedItem as DTO_DonVi).Id;
                thuocMoi.CongDung = tbxCongDungThuocMoi.Text;
                thuocMoi.DonGia = 0;
                thuocMoi.SoLuong = 0;

                if (!BUSManager.ThuocBUS.CheckThuocMoi(thuocMoi))
                {
                    BUSManager.ThuocBUS.AddThuoc(thuocMoi);
                    ListThuoc.Add(thuocMoi);

                    tbxTenThuocMoi.Clear();
                    cbxDonViThuocMoi.SelectedIndex = -1;
                    tbxCongDungThuocMoi.Text = "";
                }
                else
                {
                    MessageBox.Show("Thuốc với đơn vị bạn nhập đã tồn tại trong cơ sở dữ liệu");

                    tbxTenThuocMoi.Clear();
                    cbxDonViThuocMoi.SelectedIndex = -1;
                    tbxCongDungThuocMoi.Text = "";
                }
            });
        }

        private void btnNhapThuoc_Click(object sender, RoutedEventArgs e)
        {
            if (List.Count != 0)
            {
                DTO_PhieuNhapThuoc phieuNhapThuoc = new DTO_PhieuNhapThuoc(NgayNhapThuoc, 0);
                BUSManager.PhieuNhapThuocBUS.AddPhieuNhapThuoc(phieuNhapThuoc);
                string tempID = phieuNhapThuoc.Id;

                foreach (DTO_Thuoc item in List)
                {
                    DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, item.Id, item.SoLuong, item.DonGia);
                    BUSManager.ThuocBUS.CapNhatThuocVuaNhap(item);
                    BUSManager.CTPhieuNhapThuocBUS.AddCTPhieuNhapThuoc(cTPhieuNhapThuoc);
                }

                BUSManager.PhieuNhapThuocBUS.TinhTongTien(phieuNhapThuoc);

                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thuốc.");
            }
        }


        //private void btnThemThuoc_Click(object sender, RoutedEventArgs e)
        //{
        //    DTO_Thuoc themThuoc = new DTO_Thuoc((cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc, (cbxDonVi.SelectedItem as DTO_DonVi).Id, DonGia, SoLuong, "");
        //    //themThuoc.Id = STTBatDau + 1;
        //    //themThuoc.TenThuoc = (cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc;
        //    //themThuoc.MaDonVi = (cbxDonVi.SelectedItem as DTO_DonVi).Id;
        //    //themThuoc.SoLuong = SoLuong;
        //    //themThuoc.DonGia = DonGia;

        //    List = new ObservableCollection<DTO_Thuoc>();
        //    List.Add(themThuoc);

        //    CollectionViewSource.GetDefaultView(lvDanhSachThuocNhap.ItemsSource).Refresh();
        //}
    }
}
