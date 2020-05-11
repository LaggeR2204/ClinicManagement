using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BUS_Clinic.BUS_BenhNhan busBenhnhan = new BUS_Clinic.BUS_BenhNhan();
        public MainWindow()
        {
            InitializeComponent();
            busBenhnhan.ThemBenhNhan(new DTO_Clinic.DTO_BenhNhan() {}); ;
        }
    }
}
