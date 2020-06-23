using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for ucDanhSachKhamBenh.xaml
    /// </summary>
    public partial class ucDanhSachKhamBenh : UserControl
    {
        public ucDanhSachKhamBenh()
        {
            InitializeComponent();
            this.DataContext = this;
            InitData();
            InitCommand();
        }
        #region Property                
        public ObservableCollection<DTO_BenhNhan> ListBN { get; set; }
        public List<int> MatchBNList { get; set; }
        public string NameInput { get; set; }
        public DateTime? DateInput { get; set; }
        public string DiaChiInput { get; set; }
        public string SDTInput { get; set; }
        public DateTime? Date { get; set; }
        public List<string> RegionIDList { get; set; }
        public DTO_BenhNhan SelectedPatient { get; set; }
        #endregion
        #region Command
        public ICommand AddPatientCommand { get; set; }
        #endregion
        public void InitData()
        {
            RegionIDList = new List<string>();
            string line = "";
            StreamReader streamReader = new StreamReader(System.IO.Path.Combine(Environment.CurrentDirectory.Replace("bin\\Debug", ""), "Resource\\MAVUNG.txt"));

            while ((line = streamReader.ReadLine()) != null)
            {
                RegionIDList.Add(line);
            }
            Date = DateTime.Now;
            //set itemsource cho list view danh sách khám
            ListBN = new ObservableCollection<DTO_BenhNhan>(BUSManager.BenhNhanBUS.GetListBN());
            lvDSKham.ItemsSource = ListBN;
            //set itemsource cho combobox đăng ký bệnh nhân
            cbxDSBenhNhan.ItemsSource = new ObservableCollection<DTO_BenhNhan>(BUSManager.BenhNhanBUS.GetListBN());
            //Lọc danh sách khám theo ngày
            CollectionView viewBenhNhan = (CollectionView)CollectionViewSource.GetDefaultView(lvDSKham.ItemsSource);
            viewBenhNhan.Filter = BenhNhanFilter;
            RefreshList();
        }
        public void InitCommand()
        {
            AddPatientCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(NameInput) ||
                    string.IsNullOrEmpty(DiaChiInput) ||
                    string.IsNullOrEmpty(SDTInput) ||
                    cbxGioiTinh.SelectedIndex == -1 ||
                    !DateInput.HasValue)
                    return false;
                return true;
            }, (p) =>
            {
                bool gt;
                if (cbxGioiTinh.SelectedIndex == 0)
                    gt = false;
                else
                    gt = true;
                DTO_BenhNhan benhNhan = new DTO_BenhNhan(NameInput, gt, DateInput.Value, DiaChiInput, SDTInput);
                BUSManager.BenhNhanBUS.AddBenhNhan(benhNhan);
                ListBN.Add(benhNhan);
            });
        }
        private bool BenhNhanFilter(Object item)
        {
            if (String.IsNullOrEmpty(dpkNgayKham.Text))
            {
                return true;
            }
            else
            {
                return (MatchBNList.Contains((item as DTO_BenhNhan).Id));
            }
        }
        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            MatchBNList = BUSManager.PhieuKhamBenhBUS.GetListPKB(Date.Value.ToString("d"));
            CollectionViewSource.GetDefaultView(lvDSKham.ItemsSource).Refresh();
        }

        private void tbxSDT_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox temp = sender as TextBox;
            //if (e.Key == Key.D0 && temp.Text.Length == 0)
            //{
            //    e.Handled = true;
            //    return;
            //}
            //if (!(e.Key <= Key.D9 && e.Key >= Key.D0) || 
            //    e.KeyboardDevice.Modifiers == ModifierKeys.Control || 
            //    e.KeyboardDevice.Modifiers == ModifierKeys.Shift ||
            //    e.KeyboardDevice.Modifiers == ModifierKeys.Windows ||
            //    e.KeyboardDevice.Modifiers == ModifierKeys.Alt ||
            //    temp.Text.Length == 9)                
            //{
            //    e.Handled = true;
            //}
            bool isNumPadNumeric = (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);

            bool isNumeric = (e.Key >= Key.D0 && e.Key <= Key.D9);

            if (!isNumPadNumeric || !isNumeric || e.Key != Key.OemPeriod || e.Key != Key.Decimal)
            {
                e.Handled = true;
            }
        }
    }
}
