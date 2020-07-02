using BUS_Clinic.BUS;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdThietLap.xaml
    /// </summary>
    public partial class wdThietLap : Window
    {
        public wdThietLap()
        {
            InitializeComponent();
            InitCommand();
            InitData();
            this.DataContext = this;
        }
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region Property
        public int TienKham { get; set; }
        public int SoBNToiDa { get; set; }
        #endregion
        private void InitData()
        {
            TienKham = BUSManager.ThamSoBUS.GetListThamSo().Where(x => x.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri;
            SoBNToiDa = BUSManager.ThamSoBUS.GetListThamSo().Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri;
        }
        private bool IsValueChanged(int curTienKham, int curBNMax)
        {
            var list = BUSManager.ThamSoBUS.GetListThamSo();
            if (curBNMax != list.Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri)
                return true;
            if (curTienKham != list.Where(x => x.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri)
                return true;
            return false;
        }
        private void InitCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (IsValueChanged(TienKham, SoBNToiDa))
                    return true;
                return false;
            }, (p) =>
            {
                BUSManager.ThamSoBUS.UpdateThamSo(TienKham, SoBNToiDa);
                BUSManager.BCDoanhThuBUS.SaveChange();
                MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                //if (IsValueChanged(TienKham, SoBNToiDa))
                //{
                //    bool rel = MsgBox.Show1("Có những thay đổi chưa được lưu. Bạn có muốn tiếp tục thoát?", MessageType.Warning, MessageButtons.OkCancel);
                //    if (rel)
                //        this.Close();
                //}
                //else
                    this.Close();

            });
        }
    }
}
