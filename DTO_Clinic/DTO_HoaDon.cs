using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_HoaDon : BaseModel
    {
        public virtual DTO_CTPhieuKhamBenh CTPhieuKhamBenh { get; set; }
        public virtual DTO_PhieuKhamBenh PhieuKhamBenh { get; set; }
        public string Id { get; set; }
        public double TienKham { get => _tienKham; set { _tienKham = value; OnPropertyChanged(); } }
        public double TienThuoc { get => _tienThuoc; set { _tienThuoc = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        private double _tienKham;
        private double _tienThuoc;
        private double _thanhTien;
        private bool _isDeleted;

        public double TinhTienThuoc(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            double tienThuoc = 0;
            ICollection<DTO_CTPhieuKhamBenh> ListDSCT = phieuKhamBenh.DSCTPhieuKhamBenh;
            foreach (DTO_CTPhieuKhamBenh item in ListDSCT)
            {
                tienThuoc += item.ThanhTien;
            }
            return tienThuoc;
        }
        public DTO_HoaDon()
        {
            IsDeleted = false;
        }

        public  DTO_HoaDon (DTO_PhieuKhamBenh phieuKhamBenh, double _tienKham)
        {
            TienThuoc = TinhTienThuoc(phieuKhamBenh);
            TienKham = _tienKham;
            ThanhTien = TienKham + TienThuoc;

            IsDeleted = false;
        }
    }
}
