using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedListMenu { get; set; }
        //Moi thu xu li se nam trong nay
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            });
            SelectionChangedListMenu = new RelayCommand<object>((p) => { return true; }, (p) => {
                ListView listView = p as ListView;

                FrameworkElement window = GetWindowParent(listView);
                Window w = window as Window;
                var grid = w.FindName("grdUserControl");
                Grid grdUserControl = grid as Grid;

                int index = listView.SelectedIndex;
                switch (index)
                {
                    case 0:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucMedical());
                        break;
                    case 1:
                        grdUserControl.Children.Clear();
                        grdUserControl.Children.Add(new ucMedicine());
                        break;
                    case 2:
                        break;
                    case 3:
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
