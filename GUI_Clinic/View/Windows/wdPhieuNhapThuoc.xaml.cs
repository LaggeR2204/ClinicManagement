using BUS_Clinic.BUS;
using GUI_Clinic.Command;
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
        public string SelectedMedicine { get; set; }
        public string SelectedUnit { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        #endregion

        #region Command
        public ICommand AddMedicineCommand { get; set; }
        #endregion

        private void InitData()
        {

        }

        private void InitCommand()
        {
            
        }
    }
}
