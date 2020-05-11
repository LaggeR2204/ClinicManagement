using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CachDung: BaseModel
    {
        public int DTO_CachDungId { get; set; }
        public string TenCachDung { get => _tenCachDung; set { _tenCachDung = value; OnPropertyChanged(); } }

        private string _tenCachDung;
        
    }
}
