using DTO_Clinic;
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
    /// Interaction logic for wdHoaDon.xaml
    /// </summary>
    public partial class wdHoaDon : Window
    {
        public wdHoaDon(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            InitializeComponent();
            hoaDon = new DTO_HoaDon(phieuKhamBenh, 100000);
        }
        #region Property
        public DTO_HoaDon hoaDon;
        #endregion

        private void btnInHoaDon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdMain, "HoaDon");
                }
            }
            finally
            {

                this.IsEnabled = true;
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
