using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_PhieuKhamBenh:BaseModel
    {
        public int DTO_PhieuKhamBenhId { get; set; }
        private DateTime _ngayKham;
        private string _trieuChung;
        public DTO_BenhNhan MaBN { get; set; }
        public string TrieuChung { get => _trieuChung; set { _trieuChung = value; OnPropertyChanged(); }  }
        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); }  }
        public DTO_Benh MaBenh { get; set; }
    }
}
