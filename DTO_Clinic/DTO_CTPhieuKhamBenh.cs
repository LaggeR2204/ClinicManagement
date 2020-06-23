using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTPhieuKhamBenh: BaseModel
    {
        public int MaThuoc { get; set; }
        public int MaCachDung { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public virtual DTO_CachDung CachDung { get; set; }
        public virtual DTO_PhieuKhamBenh PhieuKhamBenh { get; set; }
        public int MaPKB { get; set; }
        public float DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public float ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        private float _donGia;
        private int _soLuong;
        private float _thanhTien;
        private bool _isDeleted;

        public DTO_CTPhieuKhamBenh()
        {
            IsDeleted = false;
        }

        public DTO_CTPhieuKhamBenh(int maPKB, int maThuoc, int maCachDung, int soLuong)
        {
            MaPKB = maPKB;
            MaThuoc = maThuoc;
            MaCachDung = maCachDung;
            SoLuong = soLuong;
        }

    }
}
