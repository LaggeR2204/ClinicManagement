using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_DonVi:BaseModel
    {
        public int DTO_DonViId { get; set; }
        public string TenDonVi { get => _tenDonVi; set { _tenDonVi = value; OnPropertyChanged(); }  }

        private string _tenDonVi;

    }
}
