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
        public ObservableCollection<DTO_CTPhieuKhamBenh> ListThuoc { get; set; }

        private bool IsSave = false;
        #endregion
        #region Command
        public ICommand LuuPhieuKhamBenhCommand { get; set; }
        public ICommand ThemThuocCommand { get; set; }
        public ICommand InPhieuKhamCommand { get; set; }
        #endregion

        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            phieuKhamBenh = new DTO_PhieuKhamBenh();
            btnThanhToan.Content = "Thanh toán";

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.TenBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();

            IsSave = false;
        }

        public void GetPKB(DTO_PhieuKhamBenh pkb)
        {
            ResetPKB();
            phieuKhamBenh = pkb;
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
            tbxChanDoan.Text = pkb.Benh.TenBenh;

            IsSave = true;
        }

        public void InitData()
        {
            ListPKB = BUSManager.PhieuKhamBenhBUS.GetListPKB();
        }

        public void InitCommmand()
        {
            LuuPhieuKhamBenhCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(tbxChanDoan.Text) ||
                    ListThuoc != null || IsSave == true)
                    return false;
                return true;
            }, (p) =>
            {
                phieuKhamBenh = new DTO_PhieuKhamBenh(benhNhan.Id, DateTime.Now, 1 /*chuyển chẩn đoán thành chọn bệnh*/ , tbxTrieuChung.Text);
                BUSManager.PhieuKhamBenhBUS.AddPhieuKhamBenh(phieuKhamBenh);
                ListPKB.Add(phieuKhamBenh);
                IsSave = true;
            });

            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(cbxThuoc.Text) ||
                    string.IsNullOrEmpty(tbxSoLuong.Text) ||
                    string.IsNullOrEmpty(tbxCachDung.Text) ||
                    IsSave == true)
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Thuoc newThuoc = cbxThuoc.SelectedItem as DTO_Thuoc;
                DTO_CTPhieuKhamBenh cTPhieuKhamBenh = new DTO_CTPhieuKhamBenh(phieuKhamBenh.Id, newThuoc.Id, 1 /*Chuyen cach dung thành chọncachs dùng*/, int.Parse(tbxSoLuong.Text), newThuoc.DonGia);
                ListThuoc.Add(cTPhieuKhamBenh);
            });

            InPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (IsSave)
                    return true;
                return false;
            }, (p) =>
            {
                wdPhieuKhamBenh wDPhieuKhamBenh = new wdPhieuKhamBenh(phieuKhamBenh);
                wDPhieuKhamBenh.ShowDialog();
            });
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            wdHoaDon hoaDon = new wdHoaDon(phieuKhamBenh);
            hoaDon.ShowDialog();
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Text = null;
            tbxChanDoan.Text = null;

            lvThuoc.Items.Clear();
        }
    }
}
