using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_HoaDon:BaseModel
    {
        public int DTO_HoaDonId { get; set; }
        public DTO_PhieuKhamBenh MaPKB { get; set; }
        public float TienKham { get => _tienKham; set { _tienKham = value; OnPropertyChanged(); } }
        public float TienThuoc { get => _tienThuoc; set { _tienThuoc = value; OnPropertyChanged(); } }
        public float ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        private float _tienKham;
        private float _tienThuoc;
        private float _thanhTien;
    }
}
