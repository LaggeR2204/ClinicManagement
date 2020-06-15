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

                var uc = w.FindName("ucControlBar");
                ucControlBar ucControlBar = uc as ucControlBar;

                var grd = w.FindName("SelectedButton");
                Grid grdSelectedButton = grd as Grid;

                //listView.SelectedItem = listView.Items.IndexOf(0);
                int index = listView.SelectedIndex;
                switch (index)
                {
                    case 0:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucMedicalList());
                        grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                        break;
                    case 1:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucPatientList());
                        grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                        break;
                    case 2:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucMedicine());
                        grdSelectedButton.Margin = new Thickness(0, 120, 0, 0);
                        break;                    
                    case 3:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucUnit());
                        grdSelectedButton.Margin = new Thickness(0, 180, 0, 0);
                        break;
                    case 4:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucRevenueReport());
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
    }
}
