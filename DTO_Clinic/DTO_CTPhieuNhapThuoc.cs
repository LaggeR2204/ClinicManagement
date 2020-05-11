using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTPhieuNhapThuoc:BaseModel
    {
        public int DTO_CTPhieuNhapThuocId { get; set; }
        public int SoLuongNhap { get => _soLuongNhap; set { _soLuongNhap = value; OnPropertyChanged(); } }
        public float DonGiaNhap { get => _donGiaNhap; set { _donGiaNhap = value; OnPropertyChanged(); } }
        public float ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }
        private int _soLuongNhap;
        private float _donGiaNhap;
        private float _thanhTien;
    }
}
