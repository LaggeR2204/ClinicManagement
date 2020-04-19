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
    public class UcMedicalViewModel : BaseViewModel
    {
        private int tempButton = 0;

        public ICommand MedicalListCommand { get; set; }
        public ICommand MedicalResultCommand { get; set; }
        public ICommand BillCommand { get; set; }

        public UcMedicalViewModel()
        {
            MedicalListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (tempButton != 0)
                {
                    Grid grdUserControlMedical = p as Grid;

                    grdUserControlMedical.Children.Clear();
                    grdUserControlMedical.Children.Add(new ucMedicalList());

                    FrameworkElement grdCursorParent = grdUserControlMedical.Parent as FrameworkElement;
                    var grid = grdCursorParent.FindName("GridCursor");
                    Grid grdCursor = grid as Grid;

                    Grid.SetColumn(grdCursor, 0);

                    tempButton = 0;
                }

            });
            MedicalResultCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (tempButton != 1)
                {
                    Grid grdUserControlMedical = p as Grid;

                    grdUserControlMedical.Children.Clear();
                    grdUserControlMedical.Children.Add(new ucMedicalResult());

                    FrameworkElement grdCursorParent = grdUserControlMedical.Parent as FrameworkElement;
                    var grid = grdCursorParent.FindName("GridCursor");
                    Grid grdCursor = grid as Grid;

                    Grid.SetColumn(grdCursor, 1);

                    tempButton = 1;
                }
            });

            BillCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (tempButton != 2)
                {
                    Grid grdUserControlMedical = p as Grid;

                    grdUserControlMedical.Children.Clear();
                    grdUserControlMedical.Children.Add(new ucBill());

                    FrameworkElement grdCursorParent = grdUserControlMedical.Parent as FrameworkElement;
                    var grid = grdCursorParent.FindName("GridCursor");
                    Grid grdCursor = grid as Grid;

                    Grid.SetColumn(grdCursor, 3);

                    tempButton = 2;
                }

            });
        }
    }
}
