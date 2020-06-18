using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using BUS_Clinic.BUS;
using GUI_Clinic.View.UserControls;

namespace GUI_Clinic.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedListMenu { get; set; }
        //public ICommand ToggleButtonMenuChecked { get; set; }
        //public ICommand ToggleButtonMenuUnchecked { get; set; }
        //public ICommand GotFocusGridMain { get; set; }
        //Moi thu xu li se nam trong nay
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                IsLoaded = true;
                LoadLocalData();
                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();
            });
            //ToggleButtonMenuChecked = new RelayCommand<object>((p) => { return true; }, (p) => {
            //    Grid grdMain = p as Grid;
            //    grdMain.Effect = new BlurEffect();
            //});
            //ToggleButtonMenuUnchecked = new RelayCommand<object>((p) => { return true; }, (p) => {
            //    Grid grdMain = p as Grid;
            //    grdMain.Effect = null;
            //});
            //GotFocusGridMain = new RelayCommand<object>((p) => { return true; }, (p) => {
            //    ToggleButton toggleMenu = p as ToggleButton;
            //    if (toggleMenu.IsChecked == true)
            //    {
            //        toggleMenu.IsChecked = false;
            //    }
            //});
            SelectionChangedListMenu = new RelayCommand<object>((p) => { return true; }, (p) => {
                ListView listView = p as ListView;

                FrameworkElement window = GetWindowParent(listView);
                Window w = window as Window;
                var grid = w.FindName("grdUserControl");
                Grid grdUserControl = grid as Grid;

                var uc_tempMedicalList = grdUserControl.FindName("uc_MedicalList");
                ucMedicalList uc_MedicalList = uc_tempMedicalList as ucMedicalList;
                var uc_tempUnit = grdUserControl.FindName("uc_Unit");
                ucUnit uc_Unit = uc_tempUnit as ucUnit;
                var uc_tempMedicine = grdUserControl.FindName("uc_Medicine");
                ucMedicine uc_Medicine = uc_tempMedicine as ucMedicine;
                var uc_tempPatientList = grdUserControl.FindName("uc_PatientList");
                ucPatientList uc_PatientList = uc_tempPatientList as ucPatientList;
                var uc_tempRevenueReport = grdUserControl.FindName("uc_RevenueReport");
                ucRevenueReport uc_RevenueReport = uc_tempRevenueReport as ucRevenueReport;

                var grd = w.FindName("SelectedButton");
                Grid grdSelectedButton = grd as Grid;

                //listView.SelectedItem = listView.Items.IndexOf(0);
                int index = listView.SelectedIndex;
                switch (index)
                {
                    case 0:
                        uc_Unit.Visibility = Visibility.Hidden;
                        uc_PatientList.Visibility = Visibility.Hidden;
                        uc_Medicine.Visibility = Visibility.Hidden;
                        uc_RevenueReport.Visibility = Visibility.Hidden;
                        uc_MedicalList.Visibility = Visibility.Visible;
                        //grdUserControl.Children.Clear();
                        //grdUserControl.Children.Add(new ucMedicalList());
                        grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                        break;
                    case 1:
                        uc_Unit.Visibility = Visibility.Hidden;
                        uc_PatientList.Visibility = Visibility.Visible;
                        uc_Medicine.Visibility = Visibility.Hidden;
                        uc_RevenueReport.Visibility = Visibility.Hidden;
                        uc_MedicalList.Visibility = Visibility.Hidden;
                        //grdUserControl.Children.Clear();
                        //grdUserControl.Children.Add(new ucPatientList());
                        grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                        break;
                    case 2:
                        uc_Unit.Visibility = Visibility.Hidden;
                        uc_PatientList.Visibility = Visibility.Hidden;
                        uc_Medicine.Visibility = Visibility.Visible;
                        uc_RevenueReport.Visibility = Visibility.Hidden;
                        uc_MedicalList.Visibility = Visibility.Hidden;
                        //grdUserControl.Children.Clear();
                        //grdUserControl.Children.Add(new ucMedicine());
                        grdSelectedButton.Margin = new Thickness(0, 120, 0, 0);
                        break;                    
                    case 3:
                        uc_Unit.Visibility = Visibility.Visible;
                        uc_PatientList.Visibility = Visibility.Hidden;
                        uc_Medicine.Visibility = Visibility.Hidden;
                        uc_RevenueReport.Visibility = Visibility.Hidden;
                        uc_MedicalList.Visibility = Visibility.Hidden;
                        //grdUserControl.Children.Clear();
                        //grdUserControl.Children.Add(new ucUnit());
                        grdSelectedButton.Margin = new Thickness(0, 180, 0, 0);
                        break;
                    case 4:
                        uc_Unit.Visibility = Visibility.Hidden;
                        uc_PatientList.Visibility = Visibility.Hidden;
                        uc_Medicine.Visibility = Visibility.Hidden;
                        uc_RevenueReport.Visibility = Visibility.Visible;
                        uc_MedicalList.Visibility = Visibility.Hidden;
                        //grdUserControl.Children.Clear();
                        //grdUserControl.Children.Add(new ucRevenueReport());
                        grdSelectedButton.Margin = new Thickness(0, 240, 0, 0);
                        break;
                    default:
                        break;
                }
            });

            FrameworkElement GetWindowParent(ListView p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }

                return parent;
            }
        }
        private void LoadLocalData()
        {
            BUSManager.BenhNhanBUS.LoadLocalData();
        }
    }
}
