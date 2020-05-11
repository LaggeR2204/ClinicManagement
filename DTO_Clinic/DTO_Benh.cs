using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_Benh : BaseModel
    {
        public int DTO_BenhId { get; set; }
        public string TenBenh { get => _tenBenh; set { _tenBenh = value; OnPropertyChanged(); }  }

        private string _tenBenh;

    }
}
