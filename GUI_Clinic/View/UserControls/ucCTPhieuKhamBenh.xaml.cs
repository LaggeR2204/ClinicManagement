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
    /// Interaction logic for ucCTPhieuKhamBenh.xaml
    /// </summary>
    public partial class ucCTPhieuKhamBenh : UserControl
    {
        public ucCTPhieuKhamBenh()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
            InitCommmand();
        }

        #region Property
        private DTO_BenhNhan benhNhan = new DTO_BenhNhan();
        private DTO_PhieuKhamBenh phieuKhamBenh = new DTO_PhieuKhamBenh();
        public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }
        public ObservableCollection<DTO_CTPhieuKhamBenh> ListCTPKB { get; set; }
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_CachDung> ListCachDung { get; set; }
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }

        private bool IsSave = false;
        #endregion
        #region Command
        public ICommand LuuPhieuKhamBenhCommand { get; set; }
        public ICommand ThemThuocCommand { get; set; }
        public ICommand InPhieuKhamCommand { get; set; }
        public ICommand ThanhToanPhieuKhamCommand { get; set; }
        #endregion

        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            EnablePKB();
            phieuKhamBenh = new DTO_PhieuKhamBenh();
            btnThanhToan.Content = "Thanh toán";

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.TenBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
        }

        public void GetPKB(DTO_PhieuKhamBenh pkb)
        {
            btnThanhToan.Content = "Hóa đơn";

            BUSManager.PhieuKhamBenhBUS.LoadNPBenh(pkb);
            BUSManager.PhieuKhamBenhBUS.LoadNPBenhNhan(pkb);
            BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(pkb);
            foreach (DTO_CTPhieuKhamBenh item in pkb.DSCTPhieuKhamBenh)
            {
                BUSManager.CTPhieuKhamBenhBUS.LoadNPThuoc(item);
                BUSManager.ThuocBUS.LoadNPDonVi(item.Thuoc);
                BUSManager.CTPhieuKhamBenhBUS.LoadNPCachDung(item);
            }
            benhNhan = pkb.BenhNhan;
            tblTenBenhNhan.Text = benhNhan.TenBenhNhan;
            tblNgayKham.Text = pkb.NgayKham.ToString();
            lvThuoc.ItemsSource = pkb.DSCTPhieuKhamBenh;
            tbxTrieuChung.Text = pkb.TrieuChung;
            cbxChanDoan.Text = pkb.Benh.TenBenh;

            phieuKhamBenh = pkb;

            DisablePKB();
        }

        public void InitData()
        {
            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListCachDung = BUSManager.CachDungBUS.GetListCD();
            ListBenh = BUSManager.BenhBUS.GetListBenh();
            ListPKB = BUSManager.PhieuKhamBenhBUS.GetListPKB();
            ListCTPKB = new ObservableCollection<DTO_CTPhieuKhamBenh>();
            lvThuoc.ItemsSource = ListCTPKB;
        }

        public void InitCommmand()
        {
            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(cbxThuoc.Text) ||
                    string.IsNullOrEmpty(tbxSoLuong.Text) ||
                    string.IsNullOrEmpty(cbxCachDung.Text) ||
                    IsSave == true)
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Thuoc newThuoc = cbxThuoc.SelectedItem as DTO_Thuoc;
                DTO_CTPhieuKhamBenh cTPhieuKhamBenh = new DTO_CTPhieuKhamBenh(phieuKhamBenh.Id, newThuoc.Id, (cbxCachDung.SelectedItem as DTO_CachDung).Id, int.Parse(tbxSoLuong.Text), newThuoc.DonGia);
                ListCTPKB.Add(cTPhieuKhamBenh);
            });

            InPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    lvThuoc.Items == null)
                    return false;
                return true;
            }, (p) =>
            {
                wdPhieuKhamBenh wDPhieuKhamBenh = new wdPhieuKhamBenh(phieuKhamBenh);
                wDPhieuKhamBenh.ShowDialog();
            });

            ThanhToanPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    lvThuoc.Items == null)
                    return false;
                return true;
            }, (p) =>
            {
                //phieuKhamBenh = new DTO_PhieuKhamBenh(benhNhan.Id, DateTime.Now, 1 /*chuyển chẩn đoán thành chọn bệnh*/ , tbxTrieuChung.Text);
                BUSManager.PhieuKhamBenhBUS.AddPhieuKhamBenh(phieuKhamBenh);
                ListPKB.Add(phieuKhamBenh);

                wdHoaDon hoaDon = new wdHoaDon(phieuKhamBenh);
                hoaDon.ShowDialog();

                IsSave = true;
            });
        }

        private void DisablePKB()
        {
            cbxChanDoan.IsEnabled = false;
            tbxTrieuChung.IsEnabled = false;
            grdNhapThuoc.Visibility = Visibility.Collapsed;
        }

        private void EnablePKB()
        {
            cbxChanDoan.IsEnabled = true;
            tbxTrieuChung.IsEnabled = true;
            grdNhapThuoc.Visibility = Visibility.Visible;

            tblTenBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Text = null;
            cbxChanDoan.Text = null;
        }
    }
}
