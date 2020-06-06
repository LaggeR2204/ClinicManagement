using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_Clinic.ViewModel
{
    public class AddPatientViewModel: BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }

        public AddPatientViewModel()
        {
            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Window window = p as Window;
                window.Close();
            });
        }
    }
}
