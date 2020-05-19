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
    public class BillViewModel: BaseViewModel
    {
        public ICommand PrintButtonCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public BillViewModel()
        {
            PrintButtonCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Grid grdPrint = p as Grid;
                FrameworkElement w = GetWindowParent(grdPrint);
                Window window = w as Window;
                try
                {
                    window.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(grdPrint, "Hoa_Don");
                    }
                }
                finally
                {
                    window.IsEnabled = true;
                }
            });
            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Window window = p as Window;
                window.Close();
            });

            FrameworkElement GetWindowParent(Grid p)
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
