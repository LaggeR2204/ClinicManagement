using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
   public class DTO_PhieuNhapThuoc:BaseModel
    {
        public int DTO_PhieuNhapThuocId { get; set; }
        public DateTime NgayNhap { get => _ngayNhap; set { _ngayNhap = value; OnPropertyChanged(); } }
        public float TongTien { get => _tongTien; set { _tongTien = value; OnPropertyChanged(); } }

        private DateTime _ngayNhap;
        private float _tongTien;

    }
}
