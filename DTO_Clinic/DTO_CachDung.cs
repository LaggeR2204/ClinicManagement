using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CachDung: BaseModel
    {
        private bool _isDeleted;
        public int Id { get; set; }
        public string TenCachDung { get => _tenCachDung; set { _tenCachDung = value; OnPropertyChanged(); } }

        private string _tenCachDung;
        public virtual ICollection<DTO_CTPhieuKhamBenh> DS_CTPhieuKhamBenh { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
    }
}
