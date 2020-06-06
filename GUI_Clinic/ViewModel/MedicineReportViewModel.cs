using GUI_Clinic.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI_Clinic.ViewModel
{
    public class MedicineReportViewModel: BaseViewModel
    {
        public ICommand BackCommand { get; set; }

        public MedicineReportViewModel()
        {
            BackCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserControl userControl = p as UserControl;

                FrameworkElement window = GetWindowParent(userControl);
                Window w = window as Window;
                var grid = w.FindName("grdUserControl");
                Grid grdUserControl = grid as Grid;

                var uc = w.FindName("ucControlBar");
                ucControlBar ucControlBar = uc as ucControlBar;

                grdUserControl.Children.Remove(userControl);
                ucControlBar.Tag = "Quản lí thuốc";
            });

            FrameworkElement GetWindowParent(UserControl p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }

                return parent;
            }
        }
    }
}
