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
            ResetPKB();
            btnThanhToan.Content = "Thanh toán";

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.TenBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            lvThuoc.ItemsSource = ListCTPKB;

            phieuKhamBenh = new DTO_PhieuKhamBenh(benhNhan.Id, DateTime.Now, null, null);
        }

        public void GetPKB(DTO_PhieuKhamBenh pkb)
        {
            ResetPKB();
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
                if (BUSManager.ThuocBUS.CheckIfSoLuongThuocDu(newThuoc))
                {
                    DTO_CTPhieuKhamBenh cTPhieuKhamBenh = new DTO_CTPhieuKhamBenh(phieuKhamBenh.Id, newThuoc.Id, (cbxCachDung.SelectedItem as DTO_CachDung).Id, int.Parse(tbxSoLuong.Text), newThuoc.DonGia);
                    BUSManager.ThuocBUS.LoadNPDonVi(newThuoc);
                    cTPhieuKhamBenh.Thuoc = newThuoc;
                    cTPhieuKhamBenh.CachDung = cbxCachDung.SelectedItem as DTO_CachDung;
                    ListCTPKB.Add(cTPhieuKhamBenh);
                }
                else
                {
                    MessageBox.Show("Số lượng thuốc còn lại trong kho không đủ");
                }
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
                if (IsSave == false)
                {
                    DTO_PhieuKhamBenh newPhieuKhamBenh = new DTO_PhieuKhamBenh(benhNhan.Id, DateTime.Now, (cbxChanDoan.SelectedItem as DTO_Benh).Id, tbxTrieuChung.Text);
                    BUSManager.PhieuKhamBenhBUS.AddPhieuKhamBenh(newPhieuKhamBenh);
                    foreach (DTO_CTPhieuKhamBenh item in ListCTPKB)
                    {
                        item.MaPKB = newPhieuKhamBenh.Id;
                        BUSManager.ThuocBUS.SuDungThuoc(item.MaThuoc, item.SoLuong);
                        BUSManager.CTPhieuKhamBenhBUS.AddCTPhieuKhamBenh(item);
                    }
                    BUSManager.PhieuKhamBenhBUS.SaveChange();

                    ListPKB.Add(BUSManager.PhieuKhamBenhBUS.GetPhieuKhamBenh(newPhieuKhamBenh.Id));

                    //wdHoaDon hoaDon = new wdHoaDon(BUSManager.PhieuKhamBenhBUS.GetPhieuKhamBenh(newPhieuKhamBenh.Id));
                    //hoaDon.ShowDialog();
                }
                else
                {
                    //wdHoaDon hoaDon = new wdHoaDon(BUSManager.PhieuKhamBenhBUS.GetPhieuKhamBenh(phieuKhamBenh.Id));
                    //hoaDon.ShowDialog();
                }
                IsSave = true;
            });
        }

        private void RemoveCategory(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            DTO_CTPhieuKhamBenh item = b.CommandParameter as DTO_CTPhieuKhamBenh;
            ListCTPKB.Remove(item);
        }
        private void ResetThuocInput()
        {
            cbxThuoc.SelectedIndex = -1;
            cbxCachDung.SelectedIndex = -1;
            tbxSoLuong.Clear();
        }
        private void DisablePKB()
        {
            cbxChanDoan.IsHitTestVisible = false;
            //tbxTrieuChung.IsEnabled = false;
            tbxTrieuChung.IsHitTestVisible = false;
            grdNhapThuoc.Visibility = Visibility.Collapsed;
        }

        private void EnablePKB()
        {
            cbxChanDoan.IsHitTestVisible = true;
            tbxTrieuChung.IsHitTestVisible = true;
            grdNhapThuoc.Visibility = Visibility.Visible;
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Clear();
            cbxChanDoan.SelectedIndex = -1;

            ListCTPKB.Clear();
            lvThuoc.ItemsSource = null;
        }
    }
}
