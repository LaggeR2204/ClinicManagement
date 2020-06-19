using BUS_Clinic.BUS;
using DTO_Clinic;
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
        public ObservableCollection<DTO_BenhNhan> ListBN { get; set; }

        public ucQuanLyBenhNhan()
        {
            InitializeComponent();
            this.DataContext = this;
            ListBN = BUSManager.BenhNhanBUS.GetListBN();
        }
    }
}
