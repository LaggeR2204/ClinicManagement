using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTPhieuKhamBenh: BaseModel
    {
        public int DTO_CTPhieuKhamBenhId { get; set; }
        public DTO_Thuoc MaThuoc { get; set; }
        public DTO_CachDung MaCachDung { get; set; }
        public DTO_PhieuKhamBenh MaPKB { get; set; }
        public float DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public float ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        private float _donGia;
        private int _soLuong;
        private float _thanhTien;
        
    }
}
