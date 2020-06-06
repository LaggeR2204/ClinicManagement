using GUI_Clinic.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_Clinic.ViewModel
{
    public class MedicalResultViewModel: BaseViewModel
    {
        public ICommand PayBillCommand { get; set; }

        public MedicalResultViewModel()
        {
            PayBillCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                BillWindow billWindow = new BillWindow();
                billWindow.ShowDialog();
            });
        }
    }
}
