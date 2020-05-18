using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_Benh : BaseModel
    {
        private bool _isDeleted;
        public int Id { get; set; }
        public string TenBenh { get => _tenBenh; set { _tenBenh = value; OnPropertyChanged(); }  }

        private string _tenBenh;
        public virtual ICollection<DTO_PhieuKhamBenh> DS_PhieuKhamBenh { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
    }
}
