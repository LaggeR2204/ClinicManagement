using GUI_Clinic.View.UserControls;
using GUI_Clinic.View.Windows;
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
    public class MedicineViewModel: BaseViewModel
    {
        public ICommand AddMedicineCommand { get; set; }
        public ICommand MedicineReportCommand { get; set; }
        public ICommand MedicationEntryListCommand { get; set; }

        public MedicineViewModel()
        {
            AddMedicineCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                 MedicationEntryFormWindow medicationEntryFormWindow = new MedicationEntryFormWindow();
                medicationEntryFormWindow.ShowDialog();
            });

            MedicineReportCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserControl userControl = p as UserControl;

                FrameworkElement window = GetWindowParent(userControl);
                Window w = window as Window;
                var grid = w.FindName("grdUserControl");
                Grid grdUserControl = grid as Grid;

                var uc = w.FindName("ucControlBar");
                ucControlBar ucControlBar = uc as ucControlBar;

                grdUserControl.Children.Add(new ucMedicineReport());
                ucControlBar.Tag = "Báo cáo sử dụng thuốc";
            });

            MedicationEntryListCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MedicationEntryListWindow medicationEntryListWindow = new MedicationEntryListWindow();
                medicationEntryListWindow.ShowDialog();
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
