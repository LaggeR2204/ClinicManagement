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
        public ucCTPhieuKhamBenh(/*DTO_BenhNhan bn*/)
        {
            InitializeComponent();
            this.DataContext = this;

            DTO_BenhNhan bn = new DTO_BenhNhan();// để tạm
            benhNhan = bn;

            InitData();
            InitCommmand();
        }

        #region Property
        private DTO_BenhNhan benhNhan = new DTO_BenhNhan();
        public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        #endregion
        #region Command
        public ICommand LuuPhieuKhamBenhCommand { get; set; }
        public ICommand ThemThuocCommand { get; set; }
        #endregion

        public void InitData()
        {
            ListPKB = BUSManager.PhieuKhamBenhBUS.GetListPKB();
        }

        public void InitCommmand()
        {
            LuuPhieuKhamBenhCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(tbxChanDoan.Text))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_PhieuKhamBenh phieuKhamBenh = new DTO_PhieuKhamBenh(benhNhan.Id, DateTime.Now, 1 /*chuyển chẩn đoán thành chọn bệnh*/ , tbxTrieuChung.Text);
                BUSManager.PhieuKhamBenhBUS.AddPhieuKhamBenh(phieuKhamBenh);
                ListPKB.Add(phieuKhamBenh);
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
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            wdHoaDon hoaDon = new wdHoaDon();
            hoaDon.ShowDialog();
        }
    }
}
