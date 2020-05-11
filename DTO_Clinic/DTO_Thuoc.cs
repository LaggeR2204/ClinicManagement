using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_Thuoc:BaseModel
    {
        public int DTO_ThuocId { get; set; }
        private string _tenThuoc;
        private string _congDung;
        private float _donGia;
        private int _soLuong;
        public DTO_DonVi MaDonVi { get; set; }
        public string TenThuoc { get => _tenThuoc; set { _tenThuoc = value; OnPropertyChanged(); }  }
        public string CongDung { get => _congDung; set { _congDung = value; OnPropertyChanged(); } }
        public float DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
    }
}
