using BUS_Clinic.BUS;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Clinic.ViewModel
{
    public class ucPatientListViewModel:BaseViewModel
    {
        public ObservableCollection<DTO_BenhNhan> ListBN { get; set; }
        public ucPatientListViewModel()
        {
            ListBN = BUSManager.BenhNhanBUS.GetListBN();
        }
    }
}
