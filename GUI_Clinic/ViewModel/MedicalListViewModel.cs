using GUI_Clinic.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace GUI_Clinic.ViewModel
{
    public class MedicalListViewModel: BaseViewModel
    {
        public ICommand AddMedicalResultCommand { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public ICommand CloseDialogCommand { get; set; }
        public MedicalListViewModel()
        {
            AddPatientCommand = new RelayCommand<object>( (p) => 
                {
                    Grid gr = p as Grid;
                    if ((gr.FindName("tbxName") as TextBox).Text == "")
                        return false;
                    return true; 
                },
                (p) =>
                { 
                }
                );

            AddMedicalResultCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MedicalResultWindow medicalResultWindow = new MedicalResultWindow();
                medicalResultWindow.ShowDialog();
            });
        }
    }
}
