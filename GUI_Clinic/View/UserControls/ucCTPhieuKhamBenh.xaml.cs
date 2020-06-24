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
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }

        private bool IsSave = false;
        #endregion
        #region Command
        public ICommand LuuPhieuKhamBenhCommand { get; set; }
        public ICommand ThemThuocCommand { get; set; }
        public ICommand InPhieuKhamCommand { get; set; }
        #endregion

        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            benhNhan = bn;
            tblTenBenhNhan.Text = bn.TenBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();

            IsSave = false;
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
                    ListThuoc != null)
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
                    string.IsNullOrEmpty(tbxCachDung.Text))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Thuoc newThuoc = new DTO_Thuoc();//them cac dữ lieun của thuốc vào
                ListThuoc.Add(newThuoc);
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
            wdHoaDon hoaDon = new wdHoaDon();
            hoaDon.ShowDialog();
        }
    }
}
