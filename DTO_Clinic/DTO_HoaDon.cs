using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_HoaDon:BaseModel
    {
        public virtual DTO_CTPhieuKhamBenh CTPhieuKhamBenh { get; set; }
        public virtual DTO_PhieuKhamBenh PhieuKhamBenh { get; set; }
        public int Id { get; set; }
        public float TienKham { get => _tienKham; set { _tienKham = value; OnPropertyChanged(); } }
        public float TienThuoc { get => _tienThuoc; set { _tienThuoc = value; OnPropertyChanged(); } }
        public float ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        private float _tienKham;
        private float _tienThuoc;
        private float _thanhTien;
        private bool _isDeleted;

        public void TinhTien()
        {
            PhieuKhamBenh.DSCTPhieuKhamBenh.Count();
        }
    }
}
