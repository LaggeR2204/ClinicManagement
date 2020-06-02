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
        public ICommand AddPatientCommand { get; set; }
        public ICommand CloseDialogCommand { get; set; }

        public MedicalListViewModel()
        {
            AddPatientCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                AddPatientDialog addPatientDialog = new AddPatientDialog();
                addPatientDialog.ShowDialog();
            });
        }
    }
}
