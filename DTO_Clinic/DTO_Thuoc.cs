using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_Thuoc:BaseModel
    {
        public int Id { get; set; }
        private string _tenThuoc;
        private string _congDung;
        private float _donGia;
        private int _soLuong;
        private bool _isDeleted;
        public virtual DTO_DonVi DonVi { get; set; }
        public int MaDonVi { get; set; }
        public string TenThuoc { get => _tenThuoc; set { _tenThuoc = value; OnPropertyChanged(); }  }
        public string CongDung { get => _congDung; set { _congDung = value; OnPropertyChanged(); } }
        public float DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public virtual ICollection<DTO_CTPhieuKhamBenh> DS_CTPhieuKhamBenh { get; set; }
        public virtual ICollection<DTO_CTPhieuNhapThuoc> DS_CTPhieuNhapThuoc { get; set; }
        public virtual ICollection<DTO_BCSudungThuoc> DS_BCSuDungThuoc { get; set; }        
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_Thuoc()
        {
            IsDeleted = false;
        }

        public DTO_Thuoc(string tenThuoc, int maDonVi, int donGia, int soLuong, string congDung)
        {
            IsDeleted = false;
        }
    }
}
